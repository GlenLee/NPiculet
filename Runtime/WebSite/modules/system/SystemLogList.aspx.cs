using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Business;

public partial class modules_system_SystemLogList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
	    this.NPager1.PageSize = 15;
	    this.NPager1.PageClick += (o, args) => { BindLog(); };

	    if (!Page.IsPostBack) {
		    BindLog();
	    }
    }

	private void BindLog()
	{
		string whereString = "1=1";

		if (!string.IsNullOrEmpty(this.ddlActionType.SelectedValue)) {
			whereString = "ActionType='" + this.ddlActionType.SelectedValue + "'";
		}

		SysActionLogBus bus = new SysActionLogBus();

		this.NPager1.RecordCount = bus.RecordCount(whereString);

		var dt = bus.Query(this.NPager1.CurrentPage, this.NPager1.PageSize, whereString, "Date DESC");

		this.logs.DataSource = dt;
		this.logs.DataBind();
	}

	protected void ddlActionType_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		BindLog();
	}
}