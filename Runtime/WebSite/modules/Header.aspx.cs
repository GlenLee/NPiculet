using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;

public partial class modules_Header : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.loginName.Text = this.CurrentUserName;
        //if (!Page.IsPostBack) { }
    }

	protected string GetMenuList()
	{
		MenuBus _bus = new MenuBus();
		DataTable menus = _bus.GetMainMenu(this.CurrentUserId);
		//string menuString = "", formatString = "<li><a href=\"Sidebar.aspx?id={0}\" target=\"sideFrame\">{1}</a></li>";
		string menuString = "", formatString = "<li><a href=\"#\" onclick=\"showSidebar(this, 'Sidebar.aspx?id={0}')\">{1}</a></li>";
		foreach (DataRow menu in menus.Rows) {
			menuString += string.Format(formatString, menu["Id"], menu["Name"]);
		}
		return menuString;
	}

	protected string GetWebSiteName()
	{
		string pname = new ConfigManager().GetConfig("PlatformName");
		return string.IsNullOrEmpty(pname) ? "管理后台" : pname;
	}

	public string GetHeadIcon()
	{
		int userid = this.CurrentUserId;
		UserBus bus = new UserBus();
		string url = bus.GetUserHeadIcon(userid);
		if (url.Length < 3) {
			return "images/person.png";
		} else {
			return "../upFile/" + url;
		}
	}
}