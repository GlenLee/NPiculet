using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Toolkit;

public partial class modules_SubFrame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected string GetPageUrl()
	{
		string id = WebParmKit.GetRequestString("id", "");
		return "Sidebar.aspx?id=" + id;
	}
}