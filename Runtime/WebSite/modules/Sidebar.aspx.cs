using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Data;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_Sidebar : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private DataView _menus = null;

	private void BindData()
	{
		int parentId = 1;
		var bus = new SysMenuBus();
		var dt = bus.GetSubMenu(parentId, this.CurrentUserId);

		if (dt != null) {
			_menus = dt.DefaultView;
			_menus.RowFilter = "ParentId=" + parentId;

			this.menu.DataSource = _menus;
			this.menu.DataBind();
		}
	}

	protected DataView BuildMenus(int parentId)
	{
		_menus.RowFilter = "ParentId=" + parentId;
		return _menus;
	}

	protected string GetPageUrl()
	{
		var url = Convert.ToString(Eval("Url"));

		return ResolveClientUrl(string.Format("modules/{0}", url));
	}
}