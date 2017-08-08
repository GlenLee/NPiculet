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

public partial class modules_system_RoleEdit : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			BindUserList();
		} else {
			EventProcess();
		}
	}

	private readonly SysRoleInfoBus _bus = new SysRoleInfoBus();

	private void BindData()
	{
		this._userList.Visible = false;
		var dataId = WebParmKit.GetQuery("key", 0);
		if (dataId > 0) {
			var model = _bus.QueryModel("Id=" + dataId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);

				this._userList.Visible = true;
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
		//this.userList.Items.Clear();
		DataView _dv = null;
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			_dv = new SysAuthorizationBus().GetRoleLinkUser(int.Parse(this.Id.Value)).DefaultView;
		}
		if (_dv != null) {
			BindKit.BindToListControl(this.userList, _dv, "UserName", "UserId");
		}
	}

	protected void btnDelUser_Click(object sender, EventArgs e) {
		foreach (ListItem item in this.userList.Items) {
			if (item.Selected) {
				string whereString = "UserId=" + item.Value + " and RoleId=" + this.Id.Value;
				new SysLinkUserRoleBus().Delete(whereString);
			}
		}
		BindUserList();
	}

	private void EventProcess()
	{
		string target = WebParmKit.GetFormValue("__EVENTTARGET", "");
		string argument = WebParmKit.GetFormValue("__EVENTARGUMENT", "");
		int rid = ConvertKit.ConvertValue(this.Id.Value, 0);
		if (rid > 0) {
			switch (target) {
				case "addUsers":
					SysLinkUserRoleBus ubus = new SysLinkUserRoleBus();
					string[] orgArgs = argument.Split(',');

					DataTable udt = ubus.Query("RoleId=" + rid);

					foreach (string arg in orgArgs) {
						bool doInsert = true;
						foreach (DataRow dr in udt.Rows) {
							string orgId = Convert.ToString(dr["UserId"]);
							if (orgId == arg) doInsert = false;
						}
						if (doInsert)
							ubus.Insert(new SysLinkUserRole() { RoleId = rid, UserId = int.Parse(arg) });
					}

					BindUserList();
					break;
			}
		}
	}
}