using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_OrgSet : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			SetControlStatus();
		}
	}

	private readonly OrgBus _obus = new OrgBus();
	private List<sys_org_info> _orgs = null;

	private void BindData()
	{
		this.tree.Nodes.Clear();
		BindTree(0);
		this.tree.ExpandAll();

		SetControlStatus();
	}

	private void BindTree(int parentId)
	{
		var data = _obus.GetOrgList(a => a.IsDel == 0);
		if (data != null && data.Count > 0) {
			_orgs = data;
			BuildTree(null, parentId);
		}
	}

	private void BuildTree(TreeNode node, int parentId) {
		var query = (from a in _orgs where a.ParentId == parentId orderby a.Sort select a).ToList();
		foreach (var org in query) {

			//string code = Convert.ToString(dr["Code"]);

			var tn = new TreeNode();
			//tn.Text = Convert.ToString(dr["Name"]) + " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetTypeName(Convert.ToInt32(dr["Type"])) + ")</span>";
			tn.Text = Convert.ToString(org.OrgName) + " <span style=\"color:#999;\">(" + Convert.ToString(org.Sort) + ")</span>";
			tn.Value = Convert.ToString(org.Id);

			if (!Convert.ToBoolean(org.IsEnabled)) tn.Text = "<span style=\"color:red;\">" + tn.Text + "</span> <span style=\"color:#999;\">(" + Convert.ToString(org.Sort) + ")</span>";
			if (node == null) {
				this.tree.Nodes.Add(tn);
			} else {
				node.ChildNodes.Add(tn);
			}
			BuildTree(tn, org.Id);
		}
	}

	/// <summary>
	/// 清除控件值
	/// </summary>
	private void ClearControls()
	{
		for (int i = 0; i < this.editor.Controls.Count; i++) {
			Control control = this.editor.Controls[i];
			if (control is TextBox) {
				((TextBox)control).Text = string.Empty;
			}
			if (control is HiddenField) {
				((HiddenField)control).Value = string.Empty;
			}
		}
		this.OrgType.Value = "1";
		this.Sort.Text = "0";
		this.promptControl.Hide();

		SetControlStatus();
	}

	/// <summary>
	/// 设置控件状态
	/// </summary>
	private void SetControlStatus()
	{
		bool visible = !string.IsNullOrEmpty(this.Id.Value);

		this.btnSave.Text = visible ? "<i class=\"fa fa-check\"></i>保存" : "<i class=\"fa fa-plus\"></i>新增根节点";
		this.btnAuth.Visible = visible;
		this.btnSame.Visible = visible;
		this.btnChild.Visible = visible;
		this.btnDelete.Visible = visible;
	}

	/// <summary>
	/// 获取根ID
	/// </summary>
	/// <returns></returns>
	private int GetRootId()
	{
		int parentId = Convert.ToInt32(this.ParentId.Value);
		int rootId = Convert.ToInt32(this.RootId.Value);
		return (parentId == 0 && rootId == 0) ? Convert.ToInt32(this.Id.Value) : rootId;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			this.CurName.Text = "";

			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			sys_org_info data;

			if (id == 0) {
				data = new sys_org_info();
				data.FullName = data.Alias;
				data.ParentId = 0;
				data.RootId = 0;
				data.Path = "";
				data.Level = 0;
				data.IsDel = 0;
				data.Creator = this.CurrentUserName;
				data.CreateDate = DateTime.Now;
			} else {
				data = _obus.GetOrgInfo(id);
				data.FullName = data.FullName.IndexOf("/") > -1 ? data.FullName.Substring(0, data.FullName.LastIndexOf("/")) + "/" + data.Alias : data.Alias;
			}
			BindKit.FillModelFromContainer(this.editor, data);
			_obus.SaveOrg(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("保存成功！");
		}
	}

	protected void btnSame_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new sys_org_info();
			BindKit.FillModelFromContainer(this.editor, data);
			data.Id = 0;
			data.ParentId = Convert.ToInt32(this.ParentId.Value);
			data.RootId = GetRootId();
			data.FullName = data.FullName.IndexOf("/") > -1 ? data.FullName.Substring(0, data.FullName.LastIndexOf("/")) + "/" + data.Alias : data.Alias;
			data.IsDel = 0;
			data.Creator = this.CurrentUserName;
			data.CreateDate = DateTime.Now;
			_obus.SaveOrg(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("新增同级成功！");
		}
	}

	protected void btnChild_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new sys_org_info();
			BindKit.FillModelFromContainer(this.editor, data);
			data.Id = 0;
			data.ParentId = Convert.ToInt32(this.Id.Value);
			data.RootId = GetRootId();
			data.Path = data.Path + "/" + this.Id.Value;
			data.Level++;
			data.FullName = data.FullName + "/" + data.Alias;
			data.IsDel = 0;
			data.Creator = this.CurrentUserName;
			data.CreateDate = DateTime.Now;
			_obus.SaveOrg(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("新增下级成功！");
		}
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			int orgId = ConvertKit.ConvertValue(this.Id.Value, 0);
			var data = _obus.GetOrgInfo(orgId);
			data.IsDel = 1;
			_obus.SaveOrg(data);

			ClearControls();
			BindData();

			this.promptControl.ShowSuccess("删除成功！");
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		ClearControls();
		var val = this.tree.SelectedValue;
		var data = _obus.GetOrgInfo(Convert.ToInt32(val));
		if (data != null) {
			BindKit.BindModelToContainer(this.editor, data);
			//this.CurName.Text = data.OrgName;
			this.CurName.Text = data.FullName;
			SetControlStatus();
		}
	}

	protected void btnAuth_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.Id.Value)) {
			this.promptControl.ShowWarning("授权失败，请选择一个组织进行授权！");
			return;
		}
		Response.Redirect("AuthSet.aspx?key=" + this.Id.Value + "&m=Org&p=OrgSet.aspx");
	}

	protected void btnFix_Click(object sender, EventArgs e)
	{
		int count = FixOrgPath();
		this.promptControl.ShowSuccess("结构信息已修复完成，共修复了 {0} 条数据！", count);
	}

	/// <summary>
	/// 修复菜单项路径及层次信息。
	/// </summary>
	public int FixOrgPath()
	{
		var data = _obus.GetOrgList(a => a.IsDel == 0);
		//修复第一层
		var root = (from a in data where a.ParentId == 0 select a);
		for (int i = 0; i < root.Count(); i++) {
			var org = root.ElementAt(i);
			if (!(org.Level == 0 && org.RootId == 0 && org.Path == "")) {
				org.Level = 0;
				org.RootId = 0;
				org.Path = "";
				org.FullName = org.Alias;

				_obus.SaveOrg(org);
			}
			//检查下层菜单
			FixSubOrgPath(data, org);
		}
		return 0;
	}

	private void FixSubOrgPath(List<sys_org_info> data, sys_org_info parent)
	{
		var layer = (from a in data where a.ParentId == parent.Id select a);
		foreach (var org in layer) {
			string curPath = parent.Path + "/" + parent.Id;
			int curRootId = parent.RootId == 0 ? parent.Id : parent.RootId;
			int curDepth = parent.Level.Value + 1;
			string curFullName = parent.FullName;

			if (!(org.Level == curDepth && org.RootId == curRootId && org.Path == curPath)) {
				org.Level = curDepth;
				org.RootId = curRootId;
				org.Path = curPath;
				org.FullName = curFullName + "/" + org.Alias;

				_obus.SaveOrg(org);
			}
			FixSubOrgPath(data, org);
		}
	}

}