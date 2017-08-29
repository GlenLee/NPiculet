using System;
using System.Web.UI;
using NPiculet.Authorization;

namespace web.uc
{
	public partial class WebUcMemberLoginOfIndex : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string userName = tbUserName.Text.Trim();
			string password = tbPassword.Text.Trim();
			string verifyCode = tbVerifyCode.Text.Trim().ToLower();

			Login(userName, password, verifyCode);
		}
		protected void btnRegister_Click(object sender, EventArgs e)
		{
			Response.Redirect("./EntRegStep1.aspx");
		}

		public void Login(string userName, string password, string verifyCode)
		{
			if (verifyCode != Session["_VerifyCode_"].ToString())
			{
				this.JavaSrcipt("$.alert('验证码错误！');");
				return;
			}

			var user = LoginKit.MemberExist(userName, password);
			if (user == null)
			{
				this.JavaSrcipt("$.alert('请输入正确的账号或密码！');");
				return;
			}
			
			if (user.StateCode == "1" || user.Level == "个人用户")
			{
				LoginKit.MemberLogin(user);
				Response.Redirect("~/default.aspx");
			}
			else
			{
				this.JavaSrcipt("$.alert('您的账号正在审核，请等待管理员审核账号信息！<br/><br/>如果您没有填完企业信息，请点击<a href=\"http://kmgdwx.com/EntRegStep2.aspx?account=" + userName + "\" target=\"_blank\" style=\"font-weight:bold;\">继续填写&gt;&gt;&gt;</a>');");
			}
		}
	}
}