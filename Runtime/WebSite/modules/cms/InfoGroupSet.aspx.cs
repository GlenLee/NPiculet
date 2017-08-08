using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Data;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
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

	private readonly CmsContentGroupBus _bus = new CmsContentGroupBus();

	private DataView _dv = null;

	private void BindData()
	{
		this.tree.Nodes.Clear();
		BindTree(0);
		this.tree.ExpandAll();

		SetControlStatus();
	}

	private void BindTree(int parentId)
	{
		var dt = _bus.Query(null, null);
		if (dt != null) {
			_dv = dt.DefaultView;
			_dv.Sort = "OrderBy";
			BuildTree(null, parentId);
		}
	}

	private void BuildTree(TreeNode node, int parentId)
	{
		_dv.RowFilter = "ParentId=" + parentId;
		foreach (DataRowView dr in _dv) {

			string code = Convert.ToString(dr["GroupCode"]);

			var tn = new TreeNode();
			//显示文字
			if (dr["IsShow"] != DBNull.Value && !Convert.ToBoolean(dr["IsShow"])) {
				tn.Text = "<span style=\"color:red;\">" + Convert.ToString(dr["GroupName"]) + "</span>";
			} else {
				tn.Text = Convert.ToString(dr["GroupName"]);
			}
			//组编码及类型
			tn.Text +=  " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetGroupTypeName(Convert.ToString(dr["GroupType"])) + ")</span>";
			//组ID
			tn.Value = Convert.ToString(dr["Id"]);

			if (node == null) {
				this.tree.Nodes.Add(tn);
			} else {
				node.ChildNodes.Add(tn);
			}
			BuildTree(tn, Convert.ToInt32(dr["Id"]));
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
		return type;
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

			bool upload;

			if (this.Id.Value == "") {
				upload = CreateNewData();
			} else {
				var data = _bus.GetGroup(ConvertKit.ConvertValue(this.Id.Value, 0));
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
	private bool UpdateCurrentData(CmsContentGroup data) {
		string oldGroupCode = data.GroupCode;

		BindKit.FillModelFromContainer(this.editor, data);

		//更新字典数据
		if (data.PropertyChangedList.Contains("GroupCode")) {
			if (VerifyExistGroupCode(data.GroupCode, data)) {
				this.AlertBeauty("编码已存在，请更换编码！");
				return false;
			}
			DbHelper.Execute("UPDATE " + new CmsContentPage().TableName + " SET GroupCode=@GroupCode WHERE GroupCode=@OldGroupCode"
				, DbHelper.CreateParameter("OldGroupCode", oldGroupCode)
				, DbHelper.CreateParameter("GroupCode", data.GroupCode));
				}

		_bus.Update(data, null);
		return true;
	}

	/// <summary>
	/// 创建一条新数据
	/// </summary>
	private bool CreateNewData() {
		var data = new CmsContentGroup();
		if (!VerifyExistGroupCode(this.GroupCode.Text, data)) {
			BindKit.FillModelFromContainer(this.editor, data);
			_bus.Insert(data);
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
	private bool VerifyExistGroupCode(string groupCode, CmsContentGroup currentGroup) {
		var list = _bus.QueryList<CmsContentGroup>("GroupCode=@GroupCode and Id!=@Id", null,
			DbHelper.CreateParameter("GroupCode", groupCode),
			DbHelper.CreateParameter("Id", currentGroup.Id)
		);
		return (list.Count > 0);
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new CmsContentGroup();
			BindKit.FillModelFromContainer(this.editor, data);
			data.ParentId = Convert.ToInt32(this.ParentId.Value);

			_bus.Insert(data);

			ClearControls();

			BindData();
		}
	}

	protected void btnChild_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new CmsContentGroup();
			BindKit.FillModelFromContainer(this.editor, data);
			data.ParentId = Convert.ToInt32(this.Id.Value);

			_bus.Insert(data);

			ClearControls();

			BindData();
		}
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			_bus.Delete("Id=" + this.Id.Value);

			BindData();
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		var val = this.tree.SelectedValue;
		var data = _bus.GetGroup(Convert.ToInt32(val));
		if (data != null) {
			BindKit.BindModelToContainer(this.editor, data);
			SetControlStatus();
		}
		ClearControls();
	}

}