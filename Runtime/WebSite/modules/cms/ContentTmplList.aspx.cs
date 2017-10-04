using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class modules_cms_ContentTmplList : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		using (var db = new NPiculetEntities()) {

			var query = (from a in db.cms_content_tmpl select a);

			//过滤条件
			if (!string.IsNullOrEmpty(this.txtKeywords.Text)) {
				string key = this.txtKeywords.Text;
				query = query.Where(q => q.Name.Contains(key));
			}
			this.nPager.RecordCount = query.Count();

			this.list.DataSource = query.OrderBy(a => a.Sort).Pagination(this.nPager.CurrentPage, this.nPager.PageSize).ToList();
			this.list.DataBind();

		}
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {

				int id = ConvertKit.ConvertValue(this.list.DataKeys[e.RowIndex]["Id"], 0);
				using (var db = new NPiculetEntities()) {
					var tmpl = new cms_content_tmpl() { Id = id };
					db.cms_content_tmpl.Attach(tmpl);
					db.cms_content_tmpl.Remove(tmpl);
					db.SaveChanges();
				}

			}
			BindData();
		}
	}

	protected string GetIsEnabledString()
	{
		string enabled = Convert.ToString(Eval("IsEnabled"));
		return enabled == "1" ? "发布" : "<span style=\"color:red\">编辑</span>";
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}

	protected void nPager_OnPageClick(object sender, NPiculet.WebControls.PageEventArgs e) {
		BindData();
	}
}