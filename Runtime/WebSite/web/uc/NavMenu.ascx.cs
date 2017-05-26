using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_uc_NavMenu : System.Web.UI.UserControl
{
	public int Active { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected string GetActive(int index)
	{
		return Active == index ? " class=\"active\"" : "";
	}
}