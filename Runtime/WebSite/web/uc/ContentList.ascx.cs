using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Toolkit;

public partial class web_uc_ContentList : System.Web.UI.UserControl
{
	private readonly CmsContentBus _cbus = new CmsContentBus();

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
		var p = LinQKit.CreateWhere<cms_content_page>(a => a.GroupCode == GroupCode);

		string search = WebParmKit.GetRequestString("key", "").FormatSqlParm();
		if (!string.IsNullOrEmpty(search)) {
			p.And(a => a.Title.Contains(search));
		}

		int count;
		var data = _cbus.GetPageList(out count, pageIndex, this.NPager1.PageSize, p);

		this.list.DataSource = data.ToList();
		this.list.DataBind();

		this.NPager1.RecordCount = count;
	}
}