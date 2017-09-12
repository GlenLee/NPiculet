using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Authorization;
using NPiculet.Logic.Business;

public partial class web_uc_LoginWidget : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		var user = LoginKit.GetCurrentMember();
		if (user == null) return;

		var mbus = new MemberBus();
		var member = mbus.GetMemberInfo(user.Id);
		if (member != null) {
			lblAccount.Text = member.Account;
			lblMemberLevel.Text = member.MemberLevel;
			lblName.Text = member.Name;
		}
	}

	protected void btnLogin_Click(object sender, EventArgs e) {
		string userName = tbUserName.Text.Trim();
		string password = tbPassword.Text.Trim();
		string verifyCode = tbVerifyCode.Text.Trim().ToLower();

		Login(userName, password, verifyCode);
	}

	protected void btnRegister_Click(object sender, EventArgs e) {
		Response.Redirect("./EntRegStep1.aspx");
	}

	public void Login(string userName, string password, string verifyCode) {
		if (verifyCode != Session["_VerifyCode_"].ToString()) {
			this.JavaSrcipt("$.alert('验证码错误！');");
			return;
		}

		var user = LoginKit.MemberExist(userName, password);
		if (user == null) {
			this.JavaSrcipt("$.alert('请输入正确的账号或密码！');");
			return;
		}

		LoginKit.MemberLogin(user);
		BindData();
	}
}