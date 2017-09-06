using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Sys;

public partial class IndexPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected string GetWebSiteName()
	{
		string pname = new ConfigManager().GetConfig("WebSiteName");
		return string.IsNullOrEmpty(pname) ? "管理后台" : pname;
	}
}
