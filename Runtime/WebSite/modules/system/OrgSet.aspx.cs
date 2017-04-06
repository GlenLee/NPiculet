using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
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

	private readonly SysOrgInfoBus _bus = new SysOrgInfoBus();
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
		var dt = _bus.Query("IsDel=0", null);
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

			//string code = Convert.ToString(dr["Code"]);

			var tn = new TreeNode();
			//tn.Text = Convert.ToString(dr["Name"]) + " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetTypeName(Convert.ToInt32(dr["Type"])) + ")</span>";
			tn.Text = Convert.ToString(dr["OrgName"]);
			tn.Value = Convert.ToString(dr["Id"]);

			if (!Convert.ToBoolean(dr["IsEnabled"])) tn.Text = "<span style=\"color:red;\">" + tn.Text + "</span>";
			if (node == null) {
				this.tree.Nodes.Add(tn);
			} else {
				node.ChildNodes.Add(tn);
			}
			BuildTree(tn, Convert.ToInt32(dr["Id"]));
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
		this.OrderBy.Text = "0";
		this.promptControl.Hide();

		SetControlStatus();
	}

	/// <summary>
	/// 设置控件状态
	/// </summary>
	private void SetControlStatus()
	{
		bool visible = !string.IsNullOrEmpty(this.Id.Value);

		this.btnSave.Text = visible ? "保存" : "新增根节点";
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

			var data = _bus.CreateModel();
			BindKit.FillModelFromContainer(this.editor, data);

			if (this.Id.Value == "") {
				data.FullName = data.Alias;
				data.ParentId = 0;
				data.RootId = 0;
				data.Path = "";
				data.Level = 0;
				data.IsDel = 0;
				data.Creator = this.CurrentUserName;
				data.CreateDate = DateTime.Now;
				_bus.Insert(data);
			} else {
				data.FullName = data.FullName.IndexOf("/") > -1 ? data.FullName.Substring(0, data.FullName.LastIndexOf("/")) + "/" + data.Alias : data.Alias;

				_bus.Update(data, null);
			}

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("保存成功！");
		}
	}

	protected void btnSame_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = _bus.CreateModel();
			BindKit.FillModelFromContainer(this.editor, data);
			data.ParentId = Convert.ToInt32(this.ParentId.Value);
			data.RootId = GetRootId();
			data.FullName = data.FullName.IndexOf("/") > -1 ? data.FullName.Substring(0, data.FullName.LastIndexOf("/")) + "/" + data.Alias : data.Alias;
			data.IsDel = 0;
			data.Creator = this.CurrentUserName;
			data.CreateDate = DateTime.Now;
			_bus.Insert(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("新增同级成功！");
		}
	}

	protected void btnChild_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = _bus.CreateModel();
			BindKit.FillModelFromContainer(this.editor, data);
			data.ParentId = Convert.ToInt32(this.Id.Value);
			data.RootId = GetRootId();
			data.Path = data.Path + "/" + this.Id.Value;
			data.Level++;
			data.FullName = data.FullName + "/" + data.Alias;
			data.IsDel = 0;
			data.Creator = this.CurrentUserName;
			data.CreateDate = DateTime.Now;
			_bus.Insert(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("新增下级成功！");
		}
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			//_bus.Delete("Id=" + this.Id.Value + " or Path like '" + this.Path.Value + "%'");
			_bus.Update(new SysOrgInfo() { IsDel = 1 }, "Id=" + this.Id.Value);

			ClearControls();
			BindData();

			this.promptControl.ShowSuccess("删除成功！");
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		ClearControls();
		var val = this.tree.SelectedValue;
		var data = _bus.GetOrgInfo(Convert.ToInt32(val));
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
		var bus = new SysOrgInfoBus();
		var data = bus.QueryList("IsDel=0");
		var updateList = new List<SysOrgInfo>();
		//修复第一层
		var root = (from a in data where a.ParentId == 0 select a);
		for (int i = 0; i < root.Count(); i++) {
			var org = root.ElementAt(i);
			if (!(org.Level == 0 && org.RootId == 0 && org.Path == "")) {
				org.Level = 0;
				org.RootId = 0;
				org.Path = "";
				org.FullName = org.Alias;

				updateList.Add(org);
			}
			//检查下层菜单
			FixSubOrgPath(data, org, updateList);
		}
		bus.UpdateList(updateList);
		return updateList.Count;
	}

	private static void FixSubOrgPath(List<SysOrgInfo> data, SysOrgInfo parent, List<SysOrgInfo> updateList)
	{
		var layer = (from a in data where a.ParentId == parent.Id select a);
		foreach (SysOrgInfo org in layer) {
			string curPath = parent.Path + "/" + parent.Id;
			int curRootId = parent.RootId == 0 ? parent.Id : parent.RootId;
			int curDepth = parent.Level.Value + 1;
			string curFullName = parent.FullName;

			if (!(org.Level == curDepth && org.RootId == curRootId && org.Path == curPath)) {
				org.Level = curDepth;
				org.RootId = curRootId;
				org.Path = curPath;
				org.FullName = curFullName + "/" + org.Alias;

				updateList.Add(org);
			}
			FixSubOrgPath(data, org, updateList);
		}
	}

}