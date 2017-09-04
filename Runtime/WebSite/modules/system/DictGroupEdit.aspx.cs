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
			BindData();
		}
	}

	/// <summary>
	/// 绑定数据
	/// </summary>
	private void BindData()
	{
		int id = WebParmKit.GetQuery("key", 0);
		if (id > 0) {
			var model = _dbus.GetDictGroup(a => a.Id == id);
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

			if (model.Id == 0) {
				model.IsEntity = 0;
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				_dbus.SaveGroup(model);
			} else {
				_dbus.SaveGroup(model);

				if (this.OldCode.Value != model.Code) {
					_dbus.UpdateDictItemCode(this.OldCode.Value, model.Code);
				}
				this.OldCode.Value = model.Code;
			}

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}