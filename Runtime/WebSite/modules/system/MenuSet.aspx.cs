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

public partial class System_MenuSet : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			SetControlStatus();
		}
	}

	private readonly SysMenuBus _bus = new SysMenuBus();
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

			string code = Convert.ToString(dr["Code"]);

			var tn = new TreeNode();
			//tn.Text = Convert.ToString(dr["Name"]) + " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetTypeName(Convert.ToInt32(dr["Type"])) + ")</span>";
			tn.Text = Convert.ToString(dr["Name"]) + " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + Convert.ToString(dr["OrderBy"]) + ")</span>";
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
		this.Target.SelectedIndex = 0;
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
		this.btnSame.Visible = visible;
		this.btnChild.Visible = visible;
		this.btnDelete.Visible = visible;
		this.btnFix.Visible = !visible;
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
			var data = _bus.CreateModel();
			BindKit.FillModelFromContainer(this.editor, data);

			if (this.Id.Value == "") {
				data.ParentId = 0;
				data.RootId = 0;
				data.Path = "";
				data.Depth = 0;
				data.IsExternal = 0;
				data.IsEnabled = 1;
				data.IsDel = 0;
				data.Creator = this.CurrentUserName;
				data.CreateDate = DateTime.Now;
				_bus.Insert(data);
			} else {
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
			data.IsExternal = 0;
			data.IsEnabled = 1;
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
			data.Depth++;
			data.Path = data.Path + "/" + this.Id.Value;
			data.IsExternal = 0;
			data.IsEnabled = 1;
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
			_bus.Update(new SysMenu() { IsDel = 1 }, "Id=" + this.Id.Value);

			ClearControls();
			BindData();

			this.promptControl.ShowSuccess("删除成功！");
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		ClearControls();
		var val = this.tree.SelectedValue;
		var data = _bus.GetMenuItem(Convert.ToInt32(val));
		if (data != null) {
			BindKit.BindModelToContainer(this.editor, data);
			this.CurName.Text = data.Name;
			SetControlStatus();
		}
	}

	protected void btnFix_Click(object sender, EventArgs e)
	{
		int count = _bus.FixMenuPath();
		this.promptControl.ShowSuccess("菜单层次深度及路径信息已修复完成，共修复了 {0} 条数据！", count);
	}
}