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
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class web_ContentList : System.Web.UI.Page
{
	private readonly CmsContentBus _cbus = new CmsContentBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData() {
		string groupCode = WebParmKit.GetQuery("groupCode", "").FormatSqlParm();

		var group = _cbus.GetGroup(groupCode);
		if (group != null) {
			this.title.Text = group.GroupName;
		}

		var where = LinQKit.CreateWhere<cms_content_page>(a => a.IsEnabled == 1 && a.GroupCode == groupCode);

		string search = WebParmKit.GetQuery("key", "").FormatSqlParm();
		if (!string.IsNullOrEmpty(search)) {
			where = where.And(a => a.Title.Contains(search));
		}

		int count;
		var data = _cbus.GetPageList(out count, this.nPager.CurrentPage, this.nPager.PageSize, where);

		this.list.DataSource = data;
		this.list.DataBind();

		this.nPager.RecordCount = count;
		
		if (count > 0) {
			this.phShowTable.Visible = true;
			this.phEmpty.Visible = false;
		} else {
			this.phShowTable.Visible = false;
			this.phEmpty.Visible = true;
		}
	}

	protected string GetNewsTitle() {
		string title = Convert.ToString(Eval("Title"));
		return title.Left(48, "…");
	}

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
		BindData();
	}
}