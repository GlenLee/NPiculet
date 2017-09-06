using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Data;
using NPiculet.Toolkit;
using NPiculet.Logic.Base;

public partial class modules_info_InfoGroupSet : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly CmsContentBus _cbus = new CmsContentBus();

	private List<cms_content_group> _groups = null;

	private void BindData()
	{
		this.tree.Nodes.Clear();
		BindTree(0);
		this.tree.ExpandAll();

		SetControlStatus();
	}

	private void BindTree(int parentId)
	{
		var data = _cbus.GetGroupList();
		if (data != null && data.Count > 0) {
			_groups = data;
			BuildTree(null, parentId);
		}
	}

	private void BuildTree(TreeNode node, int parentId)
	{
		var query = from g in _groups where g.ParentId == parentId select g;
		foreach (var g in query) {

			string code = Convert.ToString(g.GroupCode);

			var tn = new TreeNode();
			//显示文字
			if (g.IsEnabled == 1) {
				tn.Text = Convert.ToString(g.GroupName);
			} else {
				tn.Text = "<span style=\"color:red;\">" + Convert.ToString(g.GroupName) + "</span>";
			}
			//组编码及类型
			tn.Text +=  " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetGroupTypeName(Convert.ToString(g.GroupType)) + ")</span>";
			//组ID
			tn.Value = Convert.ToString(g.Id);

			if (node == null) {
				this.tree.Nodes.Add(tn);
			} else {
				node.ChildNodes.Add(tn);
			}
			BuildTree(tn, Convert.ToInt32(g.Id));
		}
	}

	private string GetGroupTypeName(string type)
	{
		switch (type) {
			case "Content": return "单页";
			case "List": return "列表";
			case "Image": return "图片列表";
			default: return "无";
		}
	}

	private void ClearControls()
	{
		this.Id.Value = String.Empty;
		this.GroupCode.Text = String.Empty;
		this.GroupName.Text = String.Empty;
		this.Memo.Text = String.Empty;

		SetControlStatus();
	}

	private void SetControlStatus()
	{
		bool visible = !string.IsNullOrEmpty(this.Id.Value);
		//this.btnSave.Visible = visible;
		this.btnAdd.Visible = visible;
		this.btnChild.Visible = visible;
		this.btnDelete.Visible = visible;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			//自动创建随机编码
			if (string.IsNullOrWhiteSpace(this.GroupCode.Text)) {
				this.GroupCode.Text = StringKit.GetRandomStringByNumber(6);
			}

			var id = ConvertKit.ConvertValue(this.Id.Value, 0);
			bool upload;

			if (id == 0) {
				upload = CreateNewData();
			} else {
				var data = _cbus.GetGroup(id);
				if (data == null) {
					upload = CreateNewData();
				} else {
					upload = UpdateCurrentData(data);
				}
			}

			if (upload) {
				ClearControls();
				BindData();
			}
		}
	}

	/// <summary>
	/// 更新当前数据
	/// </summary>
	/// <param name="data"></param>
	private bool UpdateCurrentData(cms_content_group data)
	{
		string oldGroupCode = data.GroupCode;

		BindKit.FillModelFromContainer(this.editor, data);

		//更新字典数据
		if (new NPiculetEntities().Entry(data).Property(m => m.GroupCode).IsModified) {
			if (VerifyExistGroupCode(data.GroupCode, data)) {
				this.AlertBeauty("编码已存在，请更换编码！");
				return false;
			}
			DbHelper.Execute("UPDATE cms_content_page SET GroupCode=@GroupCode WHERE GroupCode=@OldGroupCode"
				, DbHelper.CreateParameter("OldGroupCode", oldGroupCode)
				, DbHelper.CreateParameter("GroupCode", data.GroupCode)
			);
		}

		_cbus.SaveGroup(data);
		return true;
	}

	/// <summary>
	/// 创建一条新数据
	/// </summary>
	private bool CreateNewData() {
		var data = new cms_content_group();
		if (!VerifyExistGroupCode(this.GroupCode.Text, data)) {
			BindKit.FillModelFromContainer(this.editor, data);
			_cbus.SaveGroup(data);
			return true;
		} else {
			this.AlertBeauty("编码已存在，请更换编码！");
			return false;
		}
	}

	/// <summary>
	/// 验证编码是否存在
	/// </summary>
	/// <param name="groupCode"></param>
	/// <param name="currentGroup"></param>
	/// <returns></returns>
	private bool VerifyExistGroupCode(string groupCode, cms_content_group currentGroup) {
		var list = DbHelper.Query("SELECT Id FROM cms_content_group WHERE vGroupCode=@GroupCode and Id!=@Id",
			DbHelper.CreateParameter("GroupCode", groupCode),
			DbHelper.CreateParameter("Id", currentGroup.Id)
		);
		return (list.Rows.Count > 0);
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new cms_content_group();
			BindKit.FillModelFromContainer(this.editor, data);
			data.ParentId = Convert.ToInt32(this.ParentId.Value);

			_cbus.SaveGroup(data);

			ClearControls();

			BindData();
		}
	}

	protected void btnChild_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new cms_content_group();
			BindKit.FillModelFromContainer(this.editor, data);
			data.ParentId = Convert.ToInt32(this.Id.Value);

			_cbus.SaveGroup(data);

			ClearControls();

			BindData();
		}
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			_cbus.DeleteGroup(ConvertKit.ConvertValue(this.Id.Value, 0));

			BindData();
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		var val = this.tree.SelectedValue;
		var data = _cbus.GetGroup(Convert.ToInt32(val));
		if (data != null) {
			BindKit.BindModelToContainer(this.editor, data);
			SetControlStatus();
		}
	}

}