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
using NPiculet.Logic.Sys;
using NPiculet.Plugin;
using NPiculet.Toolkit;

public partial class modules_member_MemberCharge : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			BindLog();
		}
	}

	private readonly SysMemberInfoBus _userBus = new SysMemberInfoBus();
	private readonly SysMemberDataBus _dataBus = new SysMemberDataBus();

	private void BindData()
	{
		var userId = ConvertKit.ConvertValue(this.Id.Value, 0);
		if (userId > 0) {
			var model = _userBus.QueryModel("Id=" + userId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);

				var data = _dataBus.QueryModel("UserAccount='" + model.Account + "'");
				if (data != null) {
					BindKit.BindModelToContainer(this.editor, data);

					this.Id.Value = model.Id.ToString();
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			SysMemberInfo model = null;

			var dt = _userBus.GetMemberList(1, 1, string.Format("Account='{0}' or Mobile='{1}'", this.Account.Text, this.Mobile.Text));
			if (dt.Rows.Count > 0) {
				this.Id.Value = dt.Rows[0]["Id"].ToString();
				BindData();
				model = _userBus.QueryModel("Id=" + this.Id.Value);
			} else {
				model = new SysMemberInfo();
				BindKit.FillModelFromContainer(this.editor, model);
				//获取最大排序
				model.UserSn = Guid.NewGuid().ToString().ToLower();
				model.IsEnabled = 1;
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
				//新增数据
				model.Id = _userBus.InsertIdentity(model);
			}

			//保存用户信息
			var data = _dataBus.QueryModel("UserAccount='" + model.Account + "'");
			if (data == null) {
				data = _dataBus.CreateModel();
				BindKit.FillModelFromContainer(this.editor, data);
				data.UserId = model.Id;
				data.UserAccount = model.Account;
				data.IsDel = 0;
				_dataBus.Insert(data);
			}
			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("执行成功！");
			BindLog();
		}
	}

	private void BindLog()
	{
		SysActionLogBus bus = new SysActionLogBus();
		var dt = bus.Query(1, 10, "ActionAccount='" + this.Account.Text + "'", "Date DESC");

		this.details.DataSource = dt;
		this.details.DataBind();
	}

	protected void btnClear_Click(object sender, EventArgs e)
	{
		foreach (Control control in this.editor.Controls) {
			if (control is TextBox) {
				((TextBox) control).Text = string.Empty;
			}
			if (control is HiddenField) {
				((HiddenField)control).Value = string.Empty;
			}
			if (control is Literal) {
				((Literal)control).Text = string.Empty;
			}
		}
		this.details.DataSource = null;
		this.details.DataBind();
	}
}