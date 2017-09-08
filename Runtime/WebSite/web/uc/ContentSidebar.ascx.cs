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
			BindNavList();
			BindImpList();
		}
	}

	private void BindData()
	{
		var cbus = new CmsContentBus();
		List<cms_content_group> groups = cbus.GetSubGroupList("index");
		this.list.DataSource = groups;
		this.list.DataBind();
	}

	private void BindNavList()
	{
		//CmsContentGroupBus gbus = new CmsContentGroupBus();
		//List<CmsContentGroup> groups = gbus.GetSubGroupList("top");
		//this.navlist.DataSource = groups;
		//this.navlist.DataBind();
	}

	private void BindImpList()
	{
		var cbus = new CmsContentBus();
		List<cms_content_group> groups = cbus.GetSubGroupList("important");
		this.implist.DataSource = groups;
		this.implist.DataBind();
	}

	protected string GetActive(string currentCode)
	{
		return Active == currentCode ? " class=\"active\"" : "";
	}
}