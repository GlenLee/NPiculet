using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;
using NPiculet.Logic.Base;

public partial class modules_info_InfoPageList : AdminPage
{
	[Category("业务参数"), Browsable(true), Description("栏目编码")]
	public string GroupCode { get { return WebParmKit.GetQuery("code", ""); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData(1);
		}

		this.NPager1.PageClick += (o, args) => {
			BindData(args.PageIndex);
		};
	}

	private void BindData(int pageIndex)
	{
		using (var db = new NPiculetEntities()) {
			string code = GroupCode;

			cms_content_group cg;

			if (code.IsNumeric()) {
				int gid = Convert.ToInt32(code);
				cg = (from g in db.cms_content_group
					where g.Id == gid || g.GroupCode == code
					select g).FirstOrDefault();
			} else {
				cg = (from g in db.cms_content_group
					where g.GroupCode == code
					select g).FirstOrDefault();
			}

			if (cg != null) {
				var query = (from p in db.cms_content_page
					where p.GroupCode == cg.GroupCode
					orderby p.OrderBy
					select p);

				this.Title = cg.GroupName;

				int count = query.Count();
				this.NPager1.RecordCount = count;

				var dt = query.Pagination(pageIndex, this.NPager1.PageSize).ToList();

				this.list.DataSource = dt;
				this.list.DataBind();
			}
		}
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				CmsContentPageBus _bus = new CmsContentPageBus();
				string dataId = this.list.DataKeys[e.RowIndex]["Id"].ToString();
				_bus.Delete("Id=" + dataId);
			}
			BindData(this.NPager1.CurrentPage);
		}
	}
}