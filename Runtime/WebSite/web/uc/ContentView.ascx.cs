using NPiculet.Base.EF;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_uc_ContentView : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	/// <summary>
	/// 绑定数据，并更新点击数
	/// </summary>
	private void BindData()
	{
		//根据ID查数据
		int id = WebParmKit.GetQuery("id", 0);
		if (id > 0) {
			using (var db = new NPiculetEntities()) {
				var data = db.cms_content_page.FirstOrDefault(x => x.Id == id);
				ShowContentView(data, db);
			}
		} else {
			//根据GroupCode查数据
			string groupCode = WebParmKit.GetQuery("groupCode", "");
			using (var db = new NPiculetEntities()) {
				var data = db.cms_content_page.FirstOrDefault(p => p.GroupCode == groupCode);
				ShowContentView(data, db);
			}
		}
	}

	/// <summary>
	/// 显示新闻内容
	/// </summary>
	/// <param name="data"></param>
	/// <param name="db"></param>
	private void ShowContentView(cms_content_page data, NPiculetEntities db) {
		if (data != null) {
			data.Click++;

			string backUrl = WebParmKit.GetQuery("back", "~/web/" + data.GroupCode);
			this.btnBack.NavigateUrl = backUrl;

			this.title.Text = data.Title;
			if (!string.IsNullOrEmpty(data.SubTitle)) this.title.Text += "<div class=\"subtitle\">" + data.SubTitle + "</div>";
			this.clicks.Text = data.Click.ToString();
			this.content.Text = data.Content;
			this.author.Text = data.Author;
			this.source.Text = data.Source;
			this.date.Text = data.CreateDate.ToString("yyyy-MM-dd HH:mm");
			db.SaveChanges();
		}
	}
}