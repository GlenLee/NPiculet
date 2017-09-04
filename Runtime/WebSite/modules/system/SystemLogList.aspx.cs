using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using PageEventArgs = NPiculet.WebControls.PageEventArgs;

public partial class modules_system_SystemLogList : AdminPage
{
	ActionLogBus _lbus = new ActionLogBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindType();
			BindLog();
		}
	}

	private void BindType() {
		var data = new DictBus().GetActiveItemList("SystemLog");
		BindKit.BindToListControl(this.ddlActionType, data, "Name", "Code", true);
	}

	private void BindLog() {
		Expression<Func<sys_action_log, bool>> predicate = null;

		if (!string.IsNullOrEmpty(this.ddlActionType.SelectedValue)) {
			predicate = a => a.ActionType == this.ddlActionType.SelectedValue;
		}

		int count;
		var dt = _lbus.GetRecordList(out count, this.nPager.CurrentPage, this.nPager.PageSize, predicate);

		this.nPager.RecordCount = count;

		this.logs.DataSource = dt;
		this.logs.DataBind();
	}

	protected void ddlActionType_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		BindLog();
	}

	protected void nPager_OnPageClick(object sender, PageEventArgs e) {
		BindLog();
	}
}