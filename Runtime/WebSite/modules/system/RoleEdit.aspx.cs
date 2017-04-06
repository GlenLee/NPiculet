using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_RoleEdit : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			BindUserList();
		}
	}

	private readonly SysRoleInfoBus _bus = new SysRoleInfoBus();

	private void BindData()
	{
		var dataId = WebParmKit.GetRequestString("key", 0);
		if (dataId > 0) {
			var model = _bus.QueryModel("Id=" + dataId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = _bus.CreateModel();

			BindKit.FillModelFromContainer(this.editor, model);

			if (this.Id.Value == "") {
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				_bus.Insert(model);
			} else {
				_bus.Update(model, null);
			}

			this.promptControl.ShowSuccess("保存成功！");
		}
	}

	/// <summary>
	/// 显示用户信息
	/// </summary>
	private void BindUserList()
	{
		this.userList.Items.Clear();
		DataView _dv = null;
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			_dv = new SysAuthorizationBus().GetUserLinkRole(int.Parse(this.Id.Value)).DefaultView;
		}
		if (_dv != null) {
			foreach (DataRowView dr in _dv) {
				var item = new ListItem(Convert.ToString(dr["Name"]), Convert.ToString(dr["UserId"]));
				//item.Selected = true;
				this.userList.Items.Add(item);
			}
		}
	}

}