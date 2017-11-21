using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_ContentGroup : System.Web.UI.Page {

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

			string groupCode = WebParmKit.GetQuery("groupCode", "");

			var group = (from g in db.cms_content_group
				where g.GroupCode == groupCode
				select g).FirstOrDefault();
			if (group != null)
				this.groupTitle.Text = group.GroupName;

			var query = (from a in db.cms_content_group
				join b in db.cms_content_group on a.ParentId equals b.Id
				where a.IsEnabled == 1 && b.GroupCode == groupCode
				orderby a.Sort, a.Id
				select a).ToList();

			count = query.Count;

			this.news.DataSource = query;
			this.news.DataBind();
		}
	}
}