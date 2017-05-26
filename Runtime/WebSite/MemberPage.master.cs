using NPiculet.Logic.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberMasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

    protected string GetPlatformName()
    {
        string pname = new ConfigManager().GetWebConfig("WebSiteName");
        return string.IsNullOrEmpty(pname) ? "管理后台" : pname;
    }
}
