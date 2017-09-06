using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_DictItemEdit : AdminPage
{
	private readonly DictBus _dbus = new DictBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindGroupList();
			BindData();
		}
	}

	private void BindGroupList()
	{
		BindKit.BindToListControl(this.GroupCode, _dbus.GetDictGroupList(a => a.IsDel == 0), "Name", "Code");

		//获取字典分组
		string group = WebParmKit.GetQuery("group", "");
		string fix = WebParmKit.GetQuery("fix", "");
		if (!string.IsNullOrEmpty(group)) {
			this.GroupCode.SelectedIndex = this.GroupCode.Items.IndexOf(this.GroupCode.Items.FindByValue(group));
		}
		if (fix == "true") {
			this.GroupCode.Enabled = false;
		}
	}

	private void BindData()
	{
		int dataId = WebParmKit.GetQuery("key", 0);
		if (dataId > 0) {
			var model = _dbus.GetDictItem(a => a.Id == dataId);
			if (model != null) {
				BindKit.BindModelToContainer(this.container, model);
				//this.Value.Color = model.Value;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var id = ConvertKit.ConvertValue(this.Id.Value, 0);
			bas_dict_item model;

			if (id == 0) {
				model = new bas_dict_item();
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
			} else {
				model = _dbus.GetDictItem(a => a.Id == id);
			}
			BindKit.FillModelFromContainer(this.container, model);
			_dbus.SaveItem(model);

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}