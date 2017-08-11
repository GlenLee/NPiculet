using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Data;

public partial class web_ContentView : System.Web.UI.Page
{
	private readonly NPiculetEntities _db = new NPiculetEntities();
	private const string GROUP_NAME = "PageAssociatorShow";

	protected void Page_Load(object sender, EventArgs e)
	{
		BindData();
	}

	private void BindData()
	{
		var list = _db.cms_content_page.Where(x => x.GroupCode == GROUP_NAME).Take(10).ToList();
		this.Associators.DataSource = list;
		this.Associators.DataBind();
	}
}