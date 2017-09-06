using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class web_Search : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}

		this.nPager.PageClick += (o, args) => {
			BindData();
		};
	}

	private void BindData()
	{
		string searchKey = WebParmKit.GetQuery("keyword", "");

		if (!string.IsNullOrEmpty(searchKey)) {

			this.keyword.Text = " - " + searchKey;

			using (var db = new NPiculetEntities()) {

				var query = (from a in db.cms_content_page
					join g in db.cms_content_group on a.GroupCode equals g.GroupCode
					where a.IsEnabled == 1 && (a.Title.Contains(searchKey) || a.Content.Contains(searchKey))
					orderby a.CreateDate descending
					select new {
						a.Id,
						g.GroupCode,
						g.GroupName,
						a.Title,
						a.Content,
						a.CreateDate
					}
				);

				int count = query.Count();
				if (count > 0) {
					this.phShowTable.Visible = true;
					this.phEmpty.Visible = false;

					this.nPager.RecordCount = query.Count();

					this.list.DataSource = query.Pagination(this.nPager.CurrentPage, this.nPager.PageSize).ToList();
					this.list.DataBind();
				} else {
					this.phShowTable.Visible = false;
					this.phEmpty.Visible = true;
				}
			}
		} else {
			this.phShowTable.Visible = false;
			this.phEmpty.Visible = true;
		}
	}

	protected string GetNewsTitle()
	{
		string title = Convert.ToString(Eval("Title"));
		return title.Left(38, "…");
	}
}