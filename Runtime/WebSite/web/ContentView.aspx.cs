using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class web_ContentView : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e) {
		BindQuote();
		BindBottomAd();
	}

	private void BindQuote() {
		string url = "<a href=\"{0}\">{1}</a>";
		int id = WebParmKit.GetQuery("id", 0);
		using (var db = new NPiculetEntities()) {
			//上一条
			var prev = db.cms_content_page.OrderByDescending(o => o.Id).FirstOrDefault(x => x.Id < id);
			if (prev != null) {
				this.phPrevLink.Visible = true;
				this.btnPrevTitle.Text = string.Format(url, prev.Id, prev.Title.Left(60, "…"));
			}
			//下一条
			var next = db.cms_content_page.OrderBy(o => o.OrderBy).FirstOrDefault(x => x.Id > id);
			if (next != null) {
				this.phNextLink.Visible = true;
				this.btnNextTitle.Text = string.Format(url, next.Id, next.Title.Left(60, "…"));
			}
		}
	}

	protected void BindBottomAd()
	{
		var abus = new CmsAdvBus();
		var a = abus.GetSingleAd("5");
		if (a != null) {
			//this.bottomBanner.Visible = true;
			if (!string.IsNullOrEmpty(a.Url)) this.bottomBanner.NavigateUrl = a.Url;
			this.bottomBanner.ImageUrl = a.Image;
		} else {
			//this.bottomBanner.Visible = false;
		}
	}
}