using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Authorization;
using NPiculet.Logic.Base;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class modules_Login : NormalPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {

			//简单保存密码，读取保存的Cookie信息
			HttpCookie cookies = Request.Cookies["USER_COOKIE"];
			if (cookies != null) {
				//如果Cookie不为空，则将Cookie里面的用户名和密码读取出来赋值给前台的文本框。
				this.txtAccount.Text = cookies["UserName"];
				this.txtPassword.Attributes.Add("value", cookies["UserPassword"]);
			}
		}
	}

	/// <summary>
	/// 登陆
	/// </summary>
	public void Login()
	{
		string account = this.txtAccount.Text;
		string pwd = this.txtPassword.Text;
		var user = LoginKit.AdminExist(account);

		//登录
		if (user != null && user.Password == pwd) {
			LoginKit.AdminLogin(user);
			string url = WebParmKit.GetQuery("url", "");
			if (!string.IsNullOrEmpty(url)) {
				Response.Redirect(url);
			} else {
				Response.Redirect("Main.aspx");
			}
		} else if (user == null) {
			this.AlertBeauty("账号不存在！");
		} else if (user.Password != pwd) {
			this.AlertBeauty("密码不正确！");
		} else {
			this.AlertBeauty("此账号没有权限进入系统！");
		}
	}

	//获取系统名称
	public string GetWebTitle()
	{
		return new ConfigManager().GetConfig("WebSiteName");
	}

	//登陆按钮点击事件
	protected void btnLogin_Click(object sender, EventArgs e)
	{
		Login();
	}

	protected string GetPlatformName()
	{
		string pname = new ConfigManager().GetConfig("PlatformName");
		return string.IsNullOrEmpty(pname) ? "管理后台" : pname;
	}
}