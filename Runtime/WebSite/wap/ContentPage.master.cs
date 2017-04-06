using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Sys;

public partial class wap_ContentPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected string GetWapSiteName()
	{
		return new ConfigManager().GetWebConfig("WapSiteName");
	}
}
