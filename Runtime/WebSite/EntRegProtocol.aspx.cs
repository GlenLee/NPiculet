using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Business;

public partial class EntRegProtocol : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		var bus = new CmsContentPageBus();
		var content = bus.QueryModel("GroupCode='EntProtocol'");
		if (content != null) {
			this.protocol.Text = content.Content;
		}
	}
}