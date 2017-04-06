using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_DictItemEdit : AdminPage
{
	private readonly CmsDictGroupBus _groupBus = new CmsDictGroupBus();
	private readonly CmsDictItemBus _bus = new CmsDictItemBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindGroupList();
			BindData();
		}
	}

	private void BindGroupList()
	{
		BindKit.BindToListControl(this.GroupCode, _groupBus.Query(""), "Name", "Code");

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
		int Id = WebParmKit.GetRequestString("key", 0);
		if (Id > 0) {
			var model = _bus.QueryModel("Id=" + Id);
			if (model != null) {
				BindKit.BindModelToContainer(this.container, model);
				//this.Value.Color = model.Value;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = _bus.CreateModel();
			//model.Value = this.Value.Color;

			BindKit.FillModelFromContainer(this.container, model);

			if (this.Id.Value == "") {
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				_bus.Insert(model);
			} else {
				_bus.Update(model, null);
			}

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}