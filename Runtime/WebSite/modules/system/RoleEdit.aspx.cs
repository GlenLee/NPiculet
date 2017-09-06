using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
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
		} else {
			EventProcess();
		}
	}

	private readonly RoleBus _rbus = new RoleBus();

	private void BindData()
	{
		this._userList.Visible = false;
		var dataId = WebParmKit.GetQuery("key", 0);
		if (dataId > 0) {
			var model = _rbus.GetRole(dataId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);

				this._userList.Visible = true;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var id = ConvertKit.ConvertValue(this.Id.Value, 0);
			sys_role_info model;

			if (id == 0) {
				model = new sys_role_info();
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
			} else {
				model = _rbus.GetRole(a => a.Id == id);
			}
			BindKit.FillModelFromContainer(this.editor, model);
			_rbus.Save(model);

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
			_dv = new AuthorizationBus().GetRoleLinkUser(int.Parse(this.Id.Value)).DefaultView;
		}
		if (_dv != null) {
			BindKit.BindToListControl(this.userList, _dv, "UserName", "UserId");
		}
	}

	protected void btnDelUser_Click(object sender, EventArgs e) {
		foreach (ListItem item in this.userList.Items) {
			if (item.Selected) {
				new AuthorizationBus().DeleteUserRole(ConvertKit.ConvertValue(item.Value, 0), ConvertKit.ConvertValue(this.Id.Value, 0));
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
			AuthorizationBus abus = new AuthorizationBus();
			switch (target) {
				case "addUsers":
					string[] orgArgs = argument.Split(',');

					DataTable udt = abus.GetRoleLinkUser(rid);

					List<sys_link_user_role> urlist = new List<sys_link_user_role>();
					foreach (string arg in orgArgs) {
						bool doInsert = true;
						foreach (DataRow dr in udt.Rows) {
							string orgId = Convert.ToString(dr["UserId"]);
							if (orgId == arg) doInsert = false;
						}
						if (doInsert)
							urlist.Add(new sys_link_user_role() { RoleId = rid, UserId = int.Parse(arg) });
					}
					abus.UpdateUserRoleList(this.CurrentUserId, urlist);

					BindUserList();
					break;
			}
		}
	}
}