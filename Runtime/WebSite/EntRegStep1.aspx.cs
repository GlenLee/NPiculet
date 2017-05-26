using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class EntRegStep1 : NormalPage
{
	private readonly NPiculetEntities _db = new NPiculetEntities();

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnEntRegNext_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid)
			return;

		//string temp = Mobile.Text.Trim();
		//var exist = _db.sys_member_data.Any(x => x.Mobile == temp);
		//if (exist)
		//{
		//    this.Alert("手机号码已经存在,不能重复注册!");
		//    return;
		//}

		var account = Account.Text.Trim();
		var existaccount = _db.sys_member_info.Any(x => x.Account == account);
		if (existaccount) {
			this.Alert("帐号已存在，请重新输入！");
			return;
		}

		try {
			//用户基本信息
			sys_member_info user = new sys_member_info {
				UserSn = Guid.NewGuid().ToString().Replace("-", ""),
				Account = this.Account.Text.Trim().FormatSqlParm(),
				Password = this.Password.Text.Trim().FormatSqlParm(),
				IsEnabled = 1,
				MemberLevel = "企业用户",
				Name = Name.Text.Trim().FormatSqlParm(),
				IsDel = 0,
				Status = "0",
				CreateDate = DateTime.Now

			};
			_db.sys_member_info.Add(user);
			_db.SaveChanges();

			//用户资料
			sys_member_data data = new sys_member_data {
				Email = Email.Text.Trim().FormatSqlParm(),
				UserId = user.Id,
				UserAccount = user.Account,
				Mobile = Mobile.Text.Trim().FormatSqlParm(),
			};
			_db.sys_member_data.Add(data);
			_db.SaveChanges();

			Response.Redirect("EntRegStep2.aspx?account=" + user.Account);
		} catch (Exception ex) {

			Logger.Error("企业会员注册失败，请重新输入", ex);
			this.Alert("注册失败，请重新输入。");
		}
	}
}