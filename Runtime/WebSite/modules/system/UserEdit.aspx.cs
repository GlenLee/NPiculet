using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Data;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class system_Admin_UserEdit : AdminPage
{
	private readonly UserBus _ubus = new UserBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindOrgDropDownList();
			BindUserType();
			BindData();
			BindOrgList();
			BindRoleList();
		} else {
			EventProcess();
		}
	}

	private void BindOrgDropDownList() {
		using (var db = new NPiculetEntities()) {
			var companys = (from o in db.sys_org_info
				where o.Level == 0 && o.IsDel == 0
				select o).ToList();
			BindKit.BindToListControl(this.RootCompanyList, companys, "OrgName", "Id");

			int pid = ConvertKit.ConvertValue(this.RootCompanyList.SelectedValue, 0);
			var orgs = (from o in db.sys_org_info
				where o.Level == 1&& o.IsDel == 0 && o.ParentId == pid
				select o).ToList();
			BindKit.BindToListControl(this.OrgId, orgs, "OrgName", "Id");
		}
	}

	private void BindData()
	{
		var userId = WebParmKit.GetQuery("key", 0);
		if (userId > 0) {
			var model = _ubus.GetUserInfo(userId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);

				var data = _ubus.GetUserData(model.Account);
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
	/// 绑定用户类型
	/// </summary>
	private void BindUserType()
	{
		using (var db = new NPiculetEntities()) {
			var list = (from d in db.bas_dict_item where d.GroupCode == "UserType" orderby d.OrderBy select d).ToList();
			BindKit.BindToListControl(this.Type, list, "Name", "Value");
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
			_dv = new AuthorizationBus().GetUserLinkOrg(int.Parse(this.Id.Value)).DefaultView;
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
			_dv = new AuthorizationBus().GetUserLinkRole(int.Parse(this.Id.Value)).DefaultView;
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
			var user = new sys_user_info();

			BindKit.FillModelFromContainer(this.editor, user);

			//保存用户信息
			if (user.Id == 0) {
				if (_ubus.UserExist(this.Account.Text)) {
					this.promptControl.ShowError("用户账号已存在，请重新输入！");
					return;
				}

				//获取最大排序
				int maxOrderBy = _ubus.GetMaxOrderBy();

				user.UserSn = Guid.NewGuid().ToString().ToLower();
				user.IsEnabled = 1;
				user.IsDel = 0;
				user.OrderBy = maxOrderBy + 1;
				user.Creator = this.CurrentUserName;
				user.CreateDate = DateTime.Now;
				_ubus.SaveUser(user);
			} else {
				_ubus.SaveUser(user);
			}

			var data = _ubus.GetUserData(user.Id);
			if (data == null) {
				data = new sys_user_data();
				BindKit.FillModelFromContainer(this.editor, data);
				data.UserId = user.Id;
				data.UserAccount = user.Account;
				data.IsDel = 0;
				_ubus.SaveData(data);
			} else {
				BindKit.FillModelFromContainer(this.editor, data);
				_ubus.SaveData(data, a => a.UserId == user.Id);
			}
			this.Id.Value = user.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");

            this._userOrg.Visible = true;
            this._userRole.Visible = true;
		}
	}

	protected void btnDelOrg_Click(object sender, EventArgs e)
	{
		foreach (ListItem item in this.orgList.Items) {
			if (item.Selected) {
				new AuthorizationBus().DeleteUserOrg(ConvertKit.ConvertValue(this.Id.Value, 0), ConvertKit.ConvertValue(item.Value, 0));
			}
		}
		BindOrgList();
	}

	protected void btnDelRole_Click(object sender, EventArgs e)
	{
		foreach (ListItem item in this.roleList.Items) {
			if (item.Selected) {
				new AuthorizationBus().DeleteUserRole(ConvertKit.ConvertValue(this.Id.Value, 0), ConvertKit.ConvertValue(item.Value, 0));
			}
		}
		BindRoleList();
	}

	private void EventProcess()
	{
		string target = WebParmKit.GetFormValue("__EVENTTARGET", "");
		string argument = WebParmKit.GetFormValue("__EVENTARGUMENT", "");
		int uid = ConvertKit.ConvertValue<int>(this.Id.Value);
		if (uid > 0) {
			AuthorizationBus abus = new AuthorizationBus();
			switch (target) {
				case "addOrg":
					string[] orgArgs = argument.Split(',');

					DataTable udt = abus.GetUserLinkOrg(uid);

					List<sys_link_user_org> uolist = new List<sys_link_user_org>();
					foreach (string arg in orgArgs) {
						bool doInsert = true;
						foreach (DataRow dr in udt.Rows) {
							string orgId = Convert.ToString(dr["OrgId"]);
							if (orgId == arg) doInsert = false;
						}
						if (doInsert)
							uolist.Add(new sys_link_user_org() { UserId = uid, OrgId = int.Parse(arg) });
					}
					abus.UpdateUserOrgList(uid, uolist);

					BindOrgList();
					break;

				case "addRole":
					string[] roleArgs = argument.Split(',');

					DataTable rdt = abus.GetUserLinkRole(uid);

					List<sys_link_user_role> urlist = new List<sys_link_user_role>();
					foreach (string arg in roleArgs) {
						bool doInsert = true;
						foreach (DataRow dr in rdt.Rows) {
							string orgId = Convert.ToString(dr["RoleId"]);
							if (orgId == arg) doInsert = false;
						}
						if (doInsert)
							urlist.Add(new sys_link_user_role() { UserId = ConvertKit.ConvertValue(this.Id.Value, 0), RoleId = int.Parse(arg) });
					}
					abus.UpdateUserRoleList(uid, urlist);

					BindRoleList();
					break;
			}
		}
	}
}