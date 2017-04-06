using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_news_NewsList : AdminPage
{
	public string GroupCode { get { return WebParmKit.GetQuery("code", ""); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly CmsContentPageBus _bus = new CmsContentPageBus();

	private void BindData()
	{
		this.list.DataSource = _bus.Query("GroupCode='" + GroupCode + "'", null);
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