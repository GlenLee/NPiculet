using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;

public partial class System_MenuSet : AdminPage
{
	private readonly MenuBus _mbus = new MenuBus();
	private List<sys_menu> _menus = null;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			SetControlStatus();
			BindBelong();
			BindData();
		}
	}

	#region 设置控件状态

	/// <summary>
	/// 设置控件状态
	/// </summary>
	private void SetControlStatus()
	{
		bool visible = !string.IsNullOrEmpty(this.Id.Value);

		this.btnSave.Text = visible ? "<i class=\"fa fa-check\"></i>保存" : "<i class=\"fa fa-plus\"></i>新增根节点";
		this.btnSame.Visible = visible;
		this.btnChild.Visible = visible;
		this.btnDelete.Visible = visible;
		this.btnFix.Visible = !visible;
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
		this.Sort.Text = "0";
		this.promptControl.Hide();

		SetControlStatus();
	}

	#endregion

	#region 绑定菜单树

	/// <summary>
	/// 绑定菜单数据
	/// </summary>
	private void BindData()
	{
		this.tree.Nodes.Clear();
		BindTree(0);
		this.tree.ExpandAll();

		SetControlStatus();
	}

	/// <summary>
	/// 绑定数据树
	/// </summary>
	/// <param name="parentId"></param>
	private void BindTree(int parentId)
	{
		var data = _mbus.GetMenuList(a => a.IsDel == 0);
		if (data != null) {
			_menus = data;
			BuildTree(null, parentId);
		}
	}

	/// <summary>
	/// 绑定数据树
	/// </summary>
	/// <param name="node"></param>
	/// <param name="parentId"></param>
	private void BuildTree(TreeNode node, int parentId)
	{
		var query = (from a in _menus where a.ParentId == parentId orderby a.Sort select a);
		foreach (var menu in query) {

			var tn = new TreeNode();
			//tn.Text = Convert.ToString(menu.Name) + " <span style=\"color:#999;\">(" + (string.IsNullOrEmpty(code) ? "" : code + " / ") + GetTypeName(Convert.ToInt32(menu.Type)) + ")</span>";
			tn.Text = Convert.ToString(menu.Name) + " <span style=\"color:#999;\">(" + Convert.ToString(menu.Sort) + ")</span>";
			tn.Value = Convert.ToString(menu.Id);

			if (!Convert.ToBoolean(menu.IsEnabled)) tn.Text = "<span style=\"color:red;\">" + tn.Text + "</span>";
			if (node == null) {
				this.tree.Nodes.Add(tn);
			} else {
				node.ChildNodes.Add(tn);
			}
			BuildTree(tn, Convert.ToInt32(menu.Id));
		}
	}

	#endregion

	#region 数据控制类

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

	/// <summary>
	/// 处理“栏目”所属
	/// </summary>
	/// <param name="data"></param>
	private void ProcessBelong(ref sys_menu data)
	{
		switch (data.Belong) {
			case 2:
				data.Code = this.InfoGroupCategory.SelectedValue + "," + this.InfoGroupList.SelectedValue;
				break;
			case 3:
				data.Code = this.DictList.SelectedValue;
				break;
		}
	}

	#endregion

	#region 数据维护功能

	/// <summary>
	/// 保存或新增数据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			sys_menu data;

			if (id == 0) {
				data = new sys_menu();
				data.ParentId = 0;
				data.RootId = 0;
				data.Path = "";
				data.Depth = 0;
				data.IsExternal = 0;
				data.IsEnabled = 1;
				data.IsDel = 0;
				data.Creator = this.CurrentUserName;
				data.CreateDate = DateTime.Now;
			} else {
				data = _mbus.GetMenu(a => a.Id == id);
			}
			BindKit.FillModelFromContainer(this.editor, data);

			//处理“栏目”所属
			ProcessBelong(ref data);

			_mbus.Save(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("保存成功！");
		}
	}

	/// <summary>
	/// 新增同级数据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSame_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new sys_menu();
			BindKit.FillModelFromContainer(this.editor, data);

			//处理“栏目”所属
			ProcessBelong(ref data);

			data.Id = 0;
			data.ParentId = Convert.ToInt32(this.ParentId.Value);
			data.RootId = GetRootId();
			data.IsExternal = 0;
			data.IsEnabled = 1;
			data.IsDel = 0;
			data.Creator = this.CurrentUserName;
			data.CreateDate = DateTime.Now;
			_mbus.Save(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("新增同级成功！");
		}
	}

	/// <summary>
	/// 新增同级子数据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnChild_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var data = new sys_menu();
			BindKit.FillModelFromContainer(this.editor, data);

			//处理“栏目”所属
			ProcessBelong(ref data);

			data.Id = 0;
			data.ParentId = Convert.ToInt32(this.Id.Value);
			data.RootId = GetRootId();
			data.Depth++;
			data.Path = data.Path + "/" + this.Id.Value;
			data.IsExternal = 0;
			data.IsEnabled = 1;
			data.IsDel = 0;
			data.Creator = this.CurrentUserName;
			data.CreateDate = DateTime.Now;
			_mbus.Save(data);

			ClearControls();

			BindData();

			this.promptControl.ShowSuccess("新增下级成功！");
		}
	}

	/// <summary>
	/// 删除数据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnDelete_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			string path = this.Path.Value + "/" + id;

			if (string.IsNullOrEmpty(path)) {
				_mbus.Delete(a => a.Id == id);
			} else {
				_mbus.Delete(a => a.Id == id || a.Path.StartsWith(path));
			}

			ClearControls();
			BindData();

			this.promptControl.ShowSuccess("删除成功！");
		}
	}

	/// <summary>
	/// 修复菜单层次路径
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnFix_Click(object sender, EventArgs e)
	{
		int count = _mbus.FixMenuPath();
		this.promptControl.ShowSuccess("菜单层次深度及路径信息已修复完成，共修复了 {0} 条数据！", count);
	}

	#endregion

	#region 菜单业务功能

	/// <summary>
	/// 选中菜单时编辑
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		ClearControls();

		var val = this.tree.SelectedValue;
		var data = _mbus.GetMenuItem(Convert.ToInt32(val));
		if (data != null) {
			BindKit.BindModelToContainer(this.editor, data);
			SetControlStatus();
			BindBelong();

			//获取数据时，处理“栏目”所属
			switch (data.Belong) {
				case 2:
					string[] belongs = (data.Code ?? "").Split(',');
					if (belongs.Length == 2) {
						string categoryId = belongs[0], groupId = belongs[1];
						BindKit.SelectItemInSingleListControl(this.InfoGroupCategory, categoryId, true);
						BindInfoGroupList();
						BindKit.SelectItemInSingleListControl(this.InfoGroupList, groupId, true);
						InfoGroupList_SelectedIndexChanged(this, e);
					}
					break;
				case 3:
					BindKit.SelectItemInSingleListControl(this.DictList, data.Code, true);
					break;
			}

			this.CurName.Text = data.Name;
		}
	}

	/// <summary>
	/// 处理菜单归属
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Belong_SelectedIndexChanged(object sender, EventArgs e)
	{
		BindBelong();
	}

	/// <summary>
	/// 绑定归属
	/// </summary>
	private void BindBelong()
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

				BindInfoGroupCategory();
				BindInfoGroupList();
				break;

			case "3":
				this.phNormalMenu.Visible = false;
				this.phInfoGroup.Visible = false;
				this.phDict.Visible = true;

				BindDictList();
				break;
		}
	}

	/// <summary>
	/// 绑定信息组根分类
	/// </summary>
	private void BindInfoGroupCategory()
	{
		var cbus = new CmsContentBus();
		BindKit.BindToListControl(this.InfoGroupCategory, cbus.GetGroupList(a => a.IsEnabled == 1 && a.ParentId == 0), "GroupName", "Id");
	}

	/// <summary>
	/// 绑定信息组列表
	/// </summary>
	private void BindInfoGroupList()
	{
		int parentId = Convert.ToInt32(this.InfoGroupCategory.SelectedValue);
		var cbus = new CmsContentBus();
		BindKit.BindToListControl(this.InfoGroupList, cbus.GetGroupList(a => a.IsEnabled == 1 && a.ParentId == parentId), "GroupName", "Id");

		InfoGroupList_SelectedIndexChanged(this.InfoGroupCategory, new EventArgs());
	}

	/// <summary>
	/// 选择信息组，联动信息栏目下拉框
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void InfoGroupCategory_SelectedIndexChanged(object sender, EventArgs e) {
		BindInfoGroupList();
	}

	/// <summary>
	/// 生成信息维护页地址
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void InfoGroupList_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.Name.Text = this.InfoGroupList.SelectedItem.Text;

		var cbus = new CmsContentBus();
		var c = cbus.GetGroup(ConvertKit.ConvertValue(this.InfoGroupList.SelectedValue, 0));
		string url = (c != null && c.GroupType == "Content") ? "cms/ContentEdit.aspx?gid=" : "cms/PageList.aspx?gid=";
		this.Url.Text = url + this.InfoGroupList.SelectedValue;
	}

	/// <summary>
	/// 绑定字典列表
	/// </summary>
	private void BindDictList()
	{
		var dbus = new DictBus();
		BindKit.BindToListControl(this.DictList, dbus.GetDictGroupList(a => a.IsEnabled == 1 && a.IsDel == 0), "Name", "Id");

		DictList_SelectedIndexChanged(this.Belong, new EventArgs());
	}

	/// <summary>
	/// 生成字典维护页地址
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void DictList_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.Name.Text = this.DictList.SelectedItem.Text;

		string url = "system/DictItemList.aspx?group={0}&fix=true&cols={1}";

		var dictId = ConvertKit.ConvertValue(this.DictList.SelectedValue, 0);
		var dict = new DictBus().GetDictGroup(a => a.Id == dictId);
		if (dict != null)
			this.Url.Text = string.Format(url, dict.Code, dict.Memo);
		else
			this.Url.Text = string.Empty;
	}

	#endregion

}