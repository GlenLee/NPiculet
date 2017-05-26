using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Toolkit;

public partial class web_uc_ContentSidebar : System.Web.UI.UserControl
{
	public string Active { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected string GetActive(string currentCode)
	{
		return Active == currentCode ? " class=\"active\"" : "";
	}
}