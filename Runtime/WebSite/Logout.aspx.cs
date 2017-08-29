using System;
using NPiculet.Authorization;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
	{
		LoginKit.Logout();
		Response.Redirect("~/login.aspx");
    }
}