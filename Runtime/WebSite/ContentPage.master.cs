using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Sys;
using System.Net;
using System.IO;
using NPiculet.Toolkit;

public partial class ContentPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

    protected string GetWebSiteName()
	{
		string pname = new ConfigManager().GetConfig("WebSiteName");
		return string.IsNullOrEmpty(pname) ? ConfigurationManager.AppSettings["WebTitle"] : pname;
	}
}
