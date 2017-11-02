using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;

public partial class RegStep1 : NormalPage
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnNext_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {

			var nickname = this.Nickname.Text;

			var mbus = new MemberBus();
			var existname = mbus.MemberInfoExist(a => a.Name == nickname);

			if (existname) {
				this.Alert("名称已存在，请重新输入！");
				this.Name.Focus();
				return;
			}

			if (!string.IsNullOrEmpty(this.Mobile.Text.Trim())) {
				var mobile = this.Mobile.Text;
				var m = mbus.MemberDataExist(x => x.Mobile == mobile);

				if (m) {
					this.Alert("手机号码已经存在,不能重复注册!");
					return;
				}
			}

			var account = this.Account.Text;
			var exist = mbus.MemberInfoExist(x => x.Account == account);

			if (exist) {
				this.Alert("帐号已存在，请重新输入！");
			} else {
				try {
					sys_member_info member = new sys_member_info();
					//用户主信息

					member.Id = 0;
					member.MemberSn = Guid.NewGuid().ToString().Replace("-", "");
					member.Account = this.Account.Text;
					member.Password = this.Password.Text;
					member.Name = this.Name.Text;
					member.MemberLevel = "个人用户";
					member.IsEnabled = 1;
					member.Status = "0";
					member.IsDel = 0;
					member.CreateDate = DateTime.Now;

					mbus.SaveMember(member);

					//用户资料
					sys_member_data data = new sys_member_data();

					data.MemberId = member.Id;
					data.MemberAccount = member.Account;
					data.Mobile = this.Mobile.Text;
					data.Nickname = this.Name.Text;

					mbus.SaveMemberData(data);

					Response.Redirect("RegStep2.aspx?account=" + member.Account);
				} catch (Exception ex) {
					Logger.Error("(o゜▽゜)o☆[BINGO!]", ex);
					this.Alert("注册失败，请重新输入。");
				}

			}
		}
	}
}