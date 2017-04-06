using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_system_DictGroupList : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly CmsDictGroupBus _bus = new CmsDictGroupBus();

	private void BindData()
	{
		string whereString = "IsDel=0";
		string key = this.txtKeywords.Text.FormatSqlParm();

		if (!string.IsNullOrEmpty(key)) {
			whereString += " AND (Name LIKE '%" + key + "%' OR Code LIKE '%" + key + "%')";
		}

		this.list.DataSource = _bus.Query(whereString, "CreateDate DESC");
		this.list.DataBind();

		BindKit.BindOnClientClick(this.list, "Delete", "return confirm('确定要删除吗？');");
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				string id = this.list.DataKeys[e.RowIndex]["Id"].ToString();
				_bus.Update(new CmsDictGroup() { IsDel = 1 }, "Id=" + id);

			}
			BindData();
		}
	}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
	    BindData();
    }
}