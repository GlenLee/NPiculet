using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_ContentPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected override void OnPreRender(EventArgs e) {
		base.OnPreRender(e);

		this.pageTitle.Text = this.Page.Header.Title;
	}
}
