using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Business;

public partial class RegProtocol : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		var bus = new CmsContentPageBus();
		var content = bus.GetContentPage("MemberProtocol");
		if (content != null) {
			this.protocol.Text = content.Content;
		}
	}
}