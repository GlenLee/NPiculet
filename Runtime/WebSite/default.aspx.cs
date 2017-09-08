using NPiculet.Base.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Cms.Business;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack) {
			BindNews();
		}
	}

	private void BindNews() {
		int count;

		var cbus = new CmsContentBus();
		var list = cbus.GetPageList(out count, 1, 10, a => a.GroupCode == "News" && a.IsEnabled == 1);
		this.news.DataSource = list;
		this.news.DataBind();
	}
}