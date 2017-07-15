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
using NPiculet.Base.EF;

public partial class System_MenuSet : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			SetControlStatus();
			Belong_SelectedIndexChanged(sender, e);
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

			var tn = new TreeNode();
			//tn.Text = Convert.ToString(dr["Name"]) + " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetTypeName(Convert.ToInt32(dr["Type"])) + ")</span>";
			tn.Text = Convert.ToString(dr["Name"]) + " <span style=\"color:#999;\">(" + Convert.ToString(dr["OrderBy"]) + ")</span>";
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

			//处理“栏目”所属
			if (data.Belong == 2) {
				data.Code = this.InfoGroupCategory.SelectedValue + "," + this.InfoGroupList.SelectedValue;
			}

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

			//处理“栏目”所属
			if (data.Belong == 2) {
				data.Code = this.InfoGroupCategory.SelectedValue + "," + this.InfoGroupList.SelectedValue;
			}

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

			//处理“栏目”所属
			if (data.Belong == 2) {
				data.Code = this.InfoGroupCategory.SelectedValue + "," + this.InfoGroupList.SelectedValue;
			}

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

			//处理“栏目”所属
			if (data.Belong == 2) {
				//data.Code = this.InfoGroupList.SelectedValue + "," + this.InfoPageList.SelectedValue;
				string[] belongs = !string.IsNullOrWhiteSpace(data.Code) && data.Code.IndexOf(",") > -1 ? data.Code.Split(',') : null;
				if (belongs != null) {
					string categoryId = belongs[0], groupId = belongs[1];
					BindKit.SelectItemInSingleListControl(this.InfoGroupCategory, categoryId, true);
					BindKit.SelectItemInSingleListControl(this.InfoGroupList, groupId, true);
				}
			}

			this.CurName.Text = data.Name;
			SetControlStatus();
			Belong_SelectedIndexChanged(sender, e);
		}
	}

	protected void btnFix_Click(object sender, EventArgs e)
	{
		int count = _bus.FixMenuPath();
		this.promptControl.ShowSuccess("菜单层次深度及路径信息已修复完成，共修复了 {0} 条数据！", count);
	}

	protected void Belong_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (this.Belong.SelectedValue) {
			case "1":
				this.phNormalMenu.Visible = true;
				this.phInfoGroup.Visible = false;
				this.phDict.Visible = false;
				break;

			case "2":
				this.phNormalMenu.Visible = false;
				this.phInfoGroup.Visible = true;
				this.phDict.Visible = false;

				using (NPiculetEntities db = new NPiculetEntities()) {
					var group = (from g in db.cms_content_group
								 where g.IsEnabled == 1 && g.ParentId == 0
								 orderby g.OrderBy
								 select g).ToList();
					this.InfoGroupCategory.DataSource = group;
					this.InfoGroupCategory.DataTextField = "GroupName";
					this.InfoGroupCategory.DataValueField = "Id";
					this.InfoGroupCategory.DataBind();
				}

				InfoGroupList_SelectedIndexChanged(sender, e);
				break;

			case "3":
				this.phNormalMenu.Visible = false;
				this.phInfoGroup.Visible = false;
				this.phDict.Visible = true;

				using (NPiculetEntities db = new NPiculetEntities()) {
					var dict = (from d in db.bas_dict_group
								 where d.IsEnabled == 1 && d.IsDel == 0
								 orderby d.OrderBy
								 select d).ToList();
					this.DictList.DataSource = dict;
					this.DictList.DataTextField = "Name";
					this.DictList.DataValueField = "Code";
					this.DictList.DataBind();
				}

				DictList_SelectedIndexChanged(sender, e);
				break;
		}
	}

	protected void InfoGroupList_SelectedIndexChanged(object sender, EventArgs e)
	{
		using (NPiculetEntities db = new NPiculetEntities()) {
			int parentId = Convert.ToInt32(this.InfoGroupCategory.SelectedValue);
			var group = (from g in db.cms_content_group
						 where g.IsEnabled == 1 && g.ParentId == parentId
						 orderby g.OrderBy
						 select g).ToList();
			this.InfoGroupList.DataSource = group;
			this.InfoGroupList.DataTextField = "GroupName";
			this.InfoGroupList.DataValueField = "Id";
			this.InfoGroupList.DataBind();
		}

		InfoPageList_SelectedIndexChanged(sender, e);
	}

	protected void InfoPageList_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.Name.Text = this.InfoGroupList.SelectedItem.Text;

		string url = "info/InfoPageList.aspx?code=";
		this.Url.Text = url + this.InfoGroupList.SelectedValue;
	}

	protected void DictList_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.Name.Text = this.DictList.SelectedItem.Text;

		string url = "system/DictItemList.aspx?group={0}&fix=true&cols={1}";
		this.Url.Text = string.Format(url, this.DictList.SelectedValue, "");
	}
}