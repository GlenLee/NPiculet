using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;

public partial class web_uc_ContentSidebar : System.Web.UI.UserControl
{
	public string Active { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		var cbus = new CmsContentBus();
		List<cms_content_group> groups = cbus.GetSubGroupList("Home");
		this.list.DataSource = groups;
		this.list.DataBind();
	}

	protected string GetActive(string currentCode)
	{
		return Active == currentCode ? " class=\"active\"" : "";
	}
}