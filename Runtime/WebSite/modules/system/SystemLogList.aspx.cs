using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;

public partial class modules_system_SystemLogList : System.Web.UI.Page
{
	ActionLogBus bus = new ActionLogBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		this.NPager1.PageSize = 15;
		this.NPager1.PageClick += (o, args) => { BindLog(); };

		if (!Page.IsPostBack) {
			BindLog();
		}
	}

	private void BindLog() {
		Expression<Func<sys_action_log, bool>> predicate = null;

		if (!string.IsNullOrEmpty(this.ddlActionType.SelectedValue)) {
			predicate = a => a.ActionType == this.ddlActionType.SelectedValue;
		}

		int count;
		var dt = bus.GetRecordList(out count, this.NPager1.CurrentPage, this.NPager1.PageSize, predicate);

		this.NPager1.RecordCount = count;

		this.logs.DataSource = dt;
		this.logs.DataBind();
	}

	protected void ddlActionType_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		BindLog();
	}
}