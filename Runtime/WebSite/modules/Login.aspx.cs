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

public partial class modules_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            //简单保存密码，读取保存的Cookie信息
            HttpCookie cookies = Request.Cookies["USER_COOKIE"];
            if (cookies != null)
            {
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
        var user = LoginKit.AdminExist(account, pwd);
        if (user != null && user.Type == 0) {
            LoginKit.AdminLogin(user);
            string url = WebParmKit.GetRequestString("url", "");
            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("Main.aspx");
            }
        }
        else
        {
            this.Alert("请输入正确的账号或密码！");
            this.JavaSrcipt("showAlert('请输入正确的账号或密码！');");
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
		string pname = new ConfigManager().GetWebConfig("PlatformName");
		return string.IsNullOrEmpty(pname) ? "管理后台" : pname;
    }
}