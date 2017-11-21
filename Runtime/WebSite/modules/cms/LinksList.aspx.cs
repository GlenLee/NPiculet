using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;
using NPiculet.WebControls;

namespace modules.info
{
	public partial class LinksList : AdminPage
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
				var query = (from a in db.cms_friendlinks_info
					from b in db.bas_dict_item
					where a.Type == b.Code && b.GroupCode == "ExtLinkType"
					orderby a.Sort
					select new {
						a.Id,
						TypeName = b.Name,
						a.Description,
						a.Url,
						a.Sort
					});

				this.nPager.RecordCount = query.Count();

				this.list.DataSource = query.Pagination(this.nPager.CurrentPage, this.nPager.PageSize).ToList();
				this.list.DataBind();
			}
		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex > -1) {
				if (this.list.DataKeys.Count > e.RowIndex) {
					var dataKey = this.list.DataKeys[e.RowIndex];
					if (dataKey != null) {
						int dataId = ConvertKit.ConvertValue(dataKey["Id"], 0);

						using (var db = new NPiculetEntities()) {
							var data = new cms_friendlinks_info { Id = dataId };
							db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
							db.SaveChanges();
						}
					}
				}
				BindData();
			}
		}

		protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
			BindData();
		}
	}
}