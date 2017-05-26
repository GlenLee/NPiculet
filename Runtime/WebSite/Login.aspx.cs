using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (vcode.Text.Trim().ToLower() != Session["_VerifyCode_"].ToString())
        {
            this.JavaSrcipt("$.alert('验证码错误！');");
            return;
        }
        
       
        string userName = account.Text.Trim().FormatSqlParm();
        string password = pwd.Text.Trim().FormatSqlParm();
        string verifyCode = vcode.Text.Trim().ToLower().FormatSqlParm();

        var user = LoginKit.MemberExist(userName, password);
       
        if (user != null)
        {
            if (user.StateCode == "1" || user.Level == "个人用户")
            {
                LoginKit.MemberLogin(user);
                Response.Redirect("~/default.aspx");
            }
            else
            {
                this.JavaSrcipt("$.alert('您的账号未通过审核，请等待管理员审核账号信息！');");
            }
           
        }
        else
        {
            this.JavaSrcipt("$.alert('请输入正确的账号或密码！');");
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("./EntRegStep1.aspx");
    }

}