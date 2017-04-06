using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;

public partial class modules_system_OnlineUserList : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
	    if (!Page.IsPostBack) {
		    BindData();
	    }
    }

	private void BindData()
	{
		Response.Write("<br>Session的所有值:<br>");
		foreach (string key in Session.Contents) {
			Response.Write(key.ToString() + "： " + Session[key].ToString() + "<br>");
		}
	}
}