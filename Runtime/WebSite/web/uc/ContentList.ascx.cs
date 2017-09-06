using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Cms.Business;

public partial class web_uc_ContentList : System.Web.UI.UserControl
{
	private readonly CmsContentBus _bus = new CmsContentBus();

	public string GroupCode { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			this.NPager1.PageSize = 13;

			BindData(1);
		}

		this.NPager1.PageClick += (o, args) => {
			BindData(args.PageIndex);
		};
	}

	private void BindData(int pageIndex) {
		var where = LinQKit.CreateWhere<cms_content_page>(a => a.IsEnabled == 1 && a.GroupCode == GroupCode);

		string search = WebParmKit.GetQuery("key", "").FormatSqlParm();
		if (!string.IsNullOrEmpty(search)) {
			where = where.And(a => a.Title.Contains(search));
		}
		int count;
		var data = _bus.GetPageList(out count, pageIndex, this.NPager1.PageSize, where);

		this.list.DataSource = data;
		this.list.DataBind();

		this.NPager1.RecordCount = count;
	}
}