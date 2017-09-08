using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;

public partial class web_uc_PageTop : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e) {
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		using (var db = new NPiculetEntities()) {

			var sdate = DateTime.Now;
			var edate = sdate.AddDays(-1);

			var info = (from a in db.cms_adv_info
				where a.StartDate < sdate && a.EndDate > edate
				select a).FirstOrDefault();

			if (info != null) {

				this.bannerImageLink.NavigateUrl = info.Url;
				this.bannerImageLink.ImageUrl = info.Image;

				this.bannerCover.ImageUrl = info.Cover;

				if (!string.IsNullOrEmpty(info.Css)) {
					string style = "<style type=\"text/css\">" + info.Css + "</style>";
					this.CssScript.Text = style;
				}
				if (!string.IsNullOrEmpty(info.Script)) {
					string script = "<script>" + info.Script + "</script>";
					this.CssScript.Text += script;
				}
				this.phBanner.Visible = true;

				if (info.Delay != null && info.Delay > 0)
					this.CssScript.Text += "<script>setTimeout(function() { $('.full-win').slideUp(); }, " + (info.Delay * 1000) + ");</script>";

			} else {
				this.phBanner.Visible = false;
			}

		}
	}
}