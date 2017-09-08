using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Toolkit;

public partial class web_uc_NavMenu : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e) {
		BindData();
	}

	private List<cms_content_group> _groups;

	private void BindData() {
		var gbus = new CmsContentBus();
		_groups = gbus.GetSubGroupList("top");
		this.list.DataSource = _groups;
		this.list.DataBind();
	}

	protected string GetActive() {
		string active = WebParmKit.GetQuery("groupCode", "");
		string current = Convert.ToString(Eval("GroupCode"));
		return active == current ? " class=\"active\"" : "";
		//int index = Convert.ToInt32(Eval("OrderBy"));
		//return Active == index ? " class=\"active\"" : "";
	}

	protected string GetPageUrl() {
		string type = Convert.ToString(Eval("GroupType"));

		if (type == "External") {
			return Convert.ToString(Eval("Url"));
		} else {
			string groupCode = Convert.ToString(Eval("GroupCode"));
			string url;
			if (groupCode == "home") {
				url = "~/";
			} else {
				url = "~/list/" + groupCode;
			}
			return ResolveClientUrl(url);
		}
	}

	protected string GetBorderStyle(int i) {
		int count = _groups.Count - 1;
		if (i == count)
			return " class=\"end\"";
		return "";
	}
}