using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Cms.Business;
using NPiculet.Logic.Sys;

public partial class web_Default : System.Web.UI.Page
{
	private ConfigManager _config = new ConfigManager();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack) {
			BindNews();
		}
	}

	/// <summary>
	/// 绑定新闻数据
	/// </summary>
	private void BindNews()
	{
		int count;

		var cbus = new CmsContentBus();
		var list = cbus.GetPageList(out count, 1, 10, a => a.GroupCode == "News" && a.IsEnabled == 1);
		this.news.DataSource = list;
		this.news.DataBind();
	}

	/// <summary>
	/// 获取网站名称
	/// </summary>
	/// <returns></returns>
	protected string GetWebSiteName()
	{
		return _config.GetConfig("WebSiteName");
	}
}