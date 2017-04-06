using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Data;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class member_Login : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
		}
	}

	/// <summary>
	/// 登陆
	/// </summary>
	public void Login()
	{
 		string account = txtAccount.Text;
		string pwd = this.txtPassword.Text;
		var user = LoginKit.AdminExist(account, pwd);
		if (user != null) {
			LoginKit.AdminLogin(user);
			string url = WebParmKit.GetRequestString("url", "");
			if (!string.IsNullOrEmpty(url)) {
				Response.Redirect(url);
			} else {
				Response.Redirect("Main.aspx");
			}
		} else {
			this.Alert("请输入正确的账号或密码！");
		}
	}

	//获取系统名称
	public string GetWebTitle()
	{
		return new ConfigManager().GetWebConfig("WebSiteName");
	}

	//登陆按钮点击事件
	protected void btnLogin_Click(object sender, EventArgs e)
	{
		Login();
	}

	protected string GetPlatformName()
	{
		return new ConfigManager().GetWebConfig("PlatformName");
	}
}