using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_system_DictGroupEdit : AdminPage
{
	private readonly CmsDictGroupBus _bus = new CmsDictGroupBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			DataBind();
		}
	}

	private void DataBind()
	{
		int Id = WebParmKit.GetRequestString("key", 0);
		if (Id > 0) {
			var model = _bus.QueryModel("Id=" + Id);
			if (model != null) {
				BindKit.BindModelToContainer(this.container, model);
				this.OldCode.Value = model.Code;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = _bus.CreateModel();
			BindKit.FillModelFromContainer(this.container, model);
			model.IsEntity = 0;

			if (this.Id.Value == "") {
				model.IsEntity = 0;
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				_bus.Insert(model);
			} else {
				_bus.Update(model, null);

				string code = model.Code;
				new CmsDictItemBus().Update(new CmsDictItem() { GroupCode = code }, "GroupCode='" + this.OldCode.Value + "'");
				this.OldCode.Value = code;
			}

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}