using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Data;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class system_Admin_UserEdit : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			BindOrgList();
			BindRoleList();
		} else {
			EventProcess();
		}
	}

	private readonly SysUserInfoBus _userBus = new SysUserInfoBus();
	private readonly SysUserDataBus _dataBus = new SysUserDataBus();

	private void BindData()
	{
		var userId = WebParmKit.GetRequestString("key", 0);
		if (userId > 0) {
			var model = _userBus.QueryModel("Id=" + userId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);

				var data = _dataBus.QueryModel("UserAccount='" + model.Account + "'");
				if (data != null) {
					BindKit.BindModelToContainer(this.editor, data);

					this.Id.Value = model.Id.ToString();
				}

				this._userOrg.Visible = true;
				this._userRole.Visible = true;
			}
		} else {
			this._userOrg.Visible = false;
			this._userRole.Visible = false;
		}
	}

	/// <summary>
	/// 显示用户信息
	/// </summary>
	private void BindOrgList()
	{
		this.orgList.Items.Clear();
		DataView _dv = null;
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			_dv = new SysAuthorizationBus().GetUserLinkOrg(int.Parse(this.Id.Value)).DefaultView;
		}
		if (_dv != null) {
			foreach (DataRowView dr in _dv) {
				var item = new ListItem(Convert.ToString(dr["FullName"]), Convert.ToString(dr["OrgId"]));
				//item.Selected = true;
				this.orgList.Items.Add(item);
			}
		}
	}

	/// <summary>
	/// 显示用户信息
	/// </summary>
	private void BindRoleList()
	{
		this.roleList.Items.Clear();
		DataView _dv = null;
		if (!string.IsNullOrEmpty(this.Id.Value)) {
			_dv = new SysAuthorizationBus().GetUserLinkRole(int.Parse(this.Id.Value)).DefaultView;
		}
		if (_dv != null) {
			foreach (DataRowView dr in _dv) {
				var item = new ListItem(Convert.ToString(dr["RoleName"]), Convert.ToString(dr["RoleId"]));
				//item.Selected = true;
				this.roleList.Items.Add(item);
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = _userBus.CreateModel();

			BindKit.FillModelFromContainer(this.editor, model);

			//保存用户信息
			if (this.Id.Value == "") {
				if (_userBus.UserExist(this.Account.Text)) {
					this.promptControl.ShowError("用户账号已存在，请重新输入！");
					return;
				}

				//获取最大排序
				int maxOrderBy = _userBus.GetMaxOrderBy();

				model.UserSn = Guid.NewGuid().ToString().ToLower();
				model.IsEnabled = 1;
				model.IsDel = 0;
				model.OrderBy = maxOrderBy + 1;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				model.Id = _userBus.InsertIdentity(model);
			} else {
				_userBus.Update(model, null);
			}

			var data = _dataBus.QueryModel("UserAccount='" + model.Account + "'");
			if (data == null) {
				data = _dataBus.CreateModel();
				BindKit.FillModelFromContainer(this.editor, data);
				data.UserId = model.Id;
				data.UserAccount = model.Account;
				data.IsDel = 0;
				_dataBus.Insert(data);
			} else {
				BindKit.FillModelFromContainer(this.editor, data);
				_dataBus.Update(data, "UserAccount='" + data.UserAccount + "'");
			}
			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");

            this._userOrg.Visible = true;
            this._userRole.Visible = true;
		}
	}

	protected void btnDelOrg_Click(object sender, EventArgs e)
	{
		foreach (ListItem item in this.orgList.Items) {
			if (item.Selected) {
				string whereString = "UserId=" + this.Id.Value + " and OrgId=" + item.Value;
				new SysLinkUserOrgBus().Delete(whereString);
			}
		}
		BindOrgList();
	}

	protected void btnDelRole_Click(object sender, EventArgs e)
	{
		foreach (ListItem item in this.roleList.Items) {
			if (item.Selected) {
				string whereString = "UserId=" + this.Id.Value + " and RoleId=" + item.Value;
				new SysLinkUserRoleBus().Delete(whereString);
			}
		}
		BindRoleList();
	}

	private void EventProcess()
	{
		string target = WebParmKit.GetFormValue("__EVENTTARGET", "");
		string argument = WebParmKit.GetFormValue("__EVENTARGUMENT", "");
		switch (target) {
			case "addOrg":
				SysLinkUserOrgBus ubus = new SysLinkUserOrgBus();
				string[] orgArgs = argument.Split(',');
				foreach (string arg in orgArgs) {
					ubus.Insert(new SysLinkUserOrg() { UserId = Convert.ToInt32(this.Id.Value), OrgId = int.Parse(arg) });
				}
				BindOrgList();
				break;
			case "addRole":
				SysLinkUserRoleBus rbus = new SysLinkUserRoleBus();
				string[] roleArgs = argument.Split(',');
				foreach (string arg in roleArgs) {
					rbus.Insert(new SysLinkUserRole() { UserId = Convert.ToInt32(this.Id.Value), RoleId = int.Parse(arg) });
				}
				BindRoleList();
				break;
		}
	}
}