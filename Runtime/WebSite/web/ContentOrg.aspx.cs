using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_ContentOrg : System.Web.UI.Page {

	protected int count;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindNews();
		}
	}

	private void BindNews()
	{
		using (var db = new NPiculetEntities()) {

			string groupCode = "dept";
			int orgId = WebParmKit.GetQuery("orgId", 0);

			var org = (from o in db.sys_org_info
				where o.Id == orgId
				select o).FirstOrDefault();
			if (org != null)
				this.orgTitle.Text = org.OrgName;

			var query = (from a in db.cms_content_group
				join b in db.cms_content_group on a.ParentId equals b.Id
				where a.IsEnabled == 1 && b.GroupCode == groupCode && a.OrgId == orgId
						 orderby a.OrderBy, a.Id
				select a).ToList();

			count = query.Count;

			this.news.DataSource = query;
			this.news.DataBind();
		}
	}
}