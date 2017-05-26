using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_news_InfoGroupSet : System.Web.UI.Page
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
			case "Content": return "内容页";
			case "List": return "普通列表";
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
			var data = new CmsContentPage();
			BindKit.FillModelFromContainer(this.editor, data);

			if (this.Id.Value == "") {
				_bus.Insert(data);
			} else {
				_bus.Update(data, null);
			}

			ClearControls();

			BindData();
		}
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

	}

}