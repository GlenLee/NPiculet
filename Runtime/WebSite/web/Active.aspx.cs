using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_Active : System.Web.UI.Page
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
			string groupCode = "active";
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
	private void ShowContentView(cms_content_page data, NPiculetEntities db)
	{
		if (data != null) {
			data.Click++;

			this.title.Text = data.Title;
			this.clicks.Text = data.Click.ToString();
			this.content.Text = data.Content;
			this.author.Text = data.Author;
			this.date.Text = data.CreateDate.ToString("yyyy-MM-dd HH:mm");
			db.SaveChanges();
		}
	}
}