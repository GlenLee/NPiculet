using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_NavInfoPage : AdminPage
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
		var bus = new CmsContentPageBus();
		var dt = bus.Query(null, "OrderBy");

		if (dt != null) {
			_menus = dt.DefaultView;
			_menus.RowFilter = "ParentId=0";

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
		string type = Convert.ToString(Eval("GroupType"));
		string code = Convert.ToString(Eval("GroupCode"));
		switch (type) {
			case "Content":
				return "info/InfoContentEdit.aspx?m=content&code=" + code;
			case "List":
				return "info/InfoPageList.aspx?code=" + code;
		}
		return "#";
	}
}