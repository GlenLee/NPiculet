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

public partial class modules_system_DictGroupEdit : AdminPage
{
	private readonly DictBus _dbus = new DictBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			DataBind();
		}
	}

	private void DataBind()
	{
		int Id = WebParmKit.GetQuery("key", 0);
		if (Id > 0) {
			var model = _dbus.GetDictGroup(a => a.Id == Id);
			if (model != null) {
				BindKit.BindModelToContainer(this.container, model);
				this.OldCode.Value = model.Code;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = new bas_dict_group();
			BindKit.FillModelFromContainer(this.container, model);
			model.IsEntity = 0;

			if (this.Id.Value == "") {
				model.IsEntity = 0;
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				_dbus.SaveGroup(model);
			} else {
				_dbus.SaveGroup(model);

				string code = model.Code;
				var items = _dbus.GetDictItemList(this.OldCode.Value);
				foreach (var item in items) {
					item.GroupCode = code;
					_dbus.SaveItem(item);
				}
				this.OldCode.Value = code;
			}

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}