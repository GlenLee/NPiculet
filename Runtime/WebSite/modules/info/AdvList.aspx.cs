using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;

public partial class system_Modules_AdvList : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly CmsAdvInfoBus _bus = new CmsAdvInfoBus();

	private void BindData()
	{
		this.list.DataSource = _bus.Query();
		this.list.DataBind();
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				string dataId = this.list.DataKeys[e.RowIndex]["Id"].ToString();
				_bus.Delete("Id=" + dataId);
			}
			BindData();
		}
	}
}