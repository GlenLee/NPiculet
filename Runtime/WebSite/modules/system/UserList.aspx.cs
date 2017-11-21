using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class system_Admin_UserList : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly UserBus _bus = new UserBus();

	private void BindData()
	{
		string whereString = "IsDel=0";
		string key = this.txtKeywords.Text.FormatSqlParm();
		if (!string.IsNullOrEmpty(key))
			whereString += string.Format(" and (Account LIKE '%{0}%' or Name LIKE '%{0}%')", key);

		int count;
		DataTable dt = _bus.GetUserList(out count, this.nPager.CurrentPage, this.nPager.PageSize, whereString, "Sort, CreateDate DESC");

		this.nPager.RecordCount = count;

		this.list.DataSource = dt.DefaultView;
		this.list.DataBind();
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		int dataId = GridViewKit.GetDataKey<int>(this.list, e.RowIndex, "Id");
		_bus.Delete(dataId);
		BindData();
	}

	protected string GetStatusString(string enabled)
	{
		return enabled == "1" ? "启用" : "停用";
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
		BindData();
	}
}