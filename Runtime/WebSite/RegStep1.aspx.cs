using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegStep1 : System.Web.UI.Page
{
	NPiculetEntities db = new NPiculetEntities();

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnNext_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {

			var nickname = this.Nickname.Text.Trim().FormatSqlParm();

			var existname = db.sys_member_data.Count(x => x.Nickname == nickname);

			if (existname > 0) {
				this.Alert("名称已存在，请重新输入！");
				this.Name.Focus();
				return;
			}

			//if (!string.IsNullOrEmpty(this.Mobile.Text.Trim())) {
			//	var mobile = this.Mobile.Text.Trim().FormatSqlParm();
			//	var m = db.sys_member_data.Count(x => x.Mobile == mobile);

			//	if (m > 0) {
			//		this.Alert("手机号码已经存在,不能重复注册!");
			//		return;

			//	}
			//}

			var account = this.Account.Text.Trim().FormatSqlParm();
			var exist = db.sys_member_info.Count(x => x.Account == account);

			if (exist > 0) {
				this.Alert("帐号已存在，请重新输入！");
			} else {
				try {
					sys_member_info user = new sys_member_info();
					//用户主信息

					user.UserSn = Guid.NewGuid().ToString().Replace("-", "");
					user.Account = this.Account.Text.Trim().FormatSqlParm();
					user.Password = this.Password.Text.Trim().FormatSqlParm();
					user.Name = this.Name.Text.Trim().FormatSqlParm();
					user.MemberLevel = "个人用户";
					user.IsEnabled = 1;
					user.Status = "0";
					user.IsDel = 0;
					user.CreateDate = DateTime.Now;

					db.sys_member_info.Add(user);

					db.SaveChanges();

					//用户资料
					sys_member_data data = new sys_member_data();

					data.UserId = user.Id;
					data.UserAccount = user.Account;
					data.Mobile = this.Mobile.Text.Trim().FormatSqlParm();
					data.Nickname = this.Name.Text.Trim().FormatSqlParm();

					db.sys_member_data.Add(data);
					db.SaveChanges();

					Response.Redirect("RegStep2.aspx?account=" + user.Account);
				} catch (Exception ex) {
					Logger.Error("(o゜▽゜)o☆[BINGO!]", ex);
					this.Alert("注册失败，请重新输入。");
					return;
				}


				//修补错误数据
				// dbus.FixData();

				//展示信息
				//this.CcfbCode.Text = user.UserSn;

				//this.txtName.Text = user.Name;
				//this.txtAccount.Text = user.Account;
				//this.result.Text = user.Name + "[" + user.UserSn + "]";

				//this.step1.Visible = false;
				//this.step2.Visible = true;
			}
		}
	}
}