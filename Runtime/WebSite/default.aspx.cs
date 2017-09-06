using NPiculet.Base.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Cms.Business;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack) {
			BindMainNews();
			BindImageList();
			BindNews();
			BindPointList();
			BindExtLink();
		}
	}

	private void BindImageList()
	{
		using (var db = new NPiculetEntities()) {

			var news = (from a in db.cms_content_page
				where a.IsEnabled == 1 && a.GroupCode == "images"
				orderby a.OrderBy descending, a.CreateDate descending
				select a).Skip(6).Take(6).ToList();

			this.imagesList.DataSource = news;
			this.imagesList.DataBind();
		}
	}

	private void BindMainNews() {
		using (var db = new NPiculetEntities()) {
			var news = (from a in db.cms_content_page
				where a.IsEnabled == 1 && a.GroupCode == "images"
				orderby a.OrderBy descending, a.CreateDate descending
				select a).Take(6).ToList();
			this.newsImages.DataSource = news.Take(3);
			this.newsImages.DataBind();

			this.newslist.DataSource = news.Skip(1).Take(6);
			this.newslist.DataBind();

			if (news.Count > 0) {
				var mainNews = news.First();
				this.hotNewsTitleLink.Text = mainNews.Title.Left(24, "…");
				this.hotNewsTitleLink.ToolTip = mainNews.Title;
				this.hotNewsTitleLink.NavigateUrl = "~/view/" + mainNews.Id;
				hotNewsInfo.Text = GetHotNewsContent(mainNews.Content);
				hotNewsTitleMore.NavigateUrl = hotNewsTitleLink.NavigateUrl;
			}
		}
	}

	private string GetHotNewsContent(string originalText)
	{
		const int stringLen = 80;
		string temp = "　　" + NoHtml(originalText);
		if (temp.Length > stringLen)
			return temp.Substring(0, stringLen - 1);
		return temp;
	}

	private static string NoHtml(string htmlstring)
	{
		htmlstring = htmlstring.Replace("　", " ");
		//删除脚本
		htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
		//删除HTML
		htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
		htmlstring = Regex.Replace(htmlstring, @" +", " ", RegexOptions.IgnoreCase);
		htmlstring = htmlstring.Replace("<", "");
		htmlstring = htmlstring.Replace(">", "");
		htmlstring = htmlstring.Replace("\r\n", "");
		htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();

		return htmlstring;
	}

	protected string IsNewIcon()
	{
		DateTime createDate = ConvertKit.ConvertValue(Eval("CreateDate"), DateTime.MinValue);
		if (createDate >= DateTime.Now.AddDays(-3)) {
			return "<img src=\"styles/images/new.png\" alt=\"\" />";
		}
		return "";
	}

	protected string GetMainNewsTitle()
	{
		var title = Convert.ToString(Eval("Title"));
		return title.Left(30, "…");
	}

	protected string GetNewsTitle()
	{
		var length = 50;
		var title = Convert.ToString(Eval("Title"));
		return title.Length > length ? title.Substring(0, length - 1) + "…" : title;
	}

	protected int count;

	private void BindNews()
	{
		using (var db = new NPiculetEntities()) {

			var query = (from a in db.cms_content_group
				join b in db.cms_content_group on a.ParentId equals b.Id
				where a.IsEnabled == 1 && b.GroupCode == "index"
				orderby a.OrderBy, a.Id
				select a).ToList();

			this.news1.DataSource = query.Skip(1).Take(3);
			this.news1.DataBind();

			this.news2.DataSource = query.Skip(4).Take(3);
			this.news2.DataBind();

			count = query.Count - 7;

			this.news3.DataSource = query.Skip(7);
			this.news3.DataBind();
		}
	}

	/// <summary>
	/// 绑定积分列表
	/// </summary>
	private void BindPointList()
	{
		using (var db = new NPiculetEntities()) {

			var orgs = (from a in db.sys_org_info
				where a.IsDel == 0 && a.IsEnabled == 1 && a.Level == 1
				orderby a.Point descending, a.OrderBy, a.CreateDate descending
				select new {
					a.ParentId,
					a.OrgName,
					a.Point
				}).ToList();

			this.placePointsList.DataSource = orgs.Where(a => a.ParentId == 1).Select((q, i) => new { q.ParentId, q.OrgName, q.Point, Ranking = i + 1 });
			this.placePointsList.DataBind();

			this.deptPointsList.DataSource = orgs.Where(a => a.ParentId == 18).Select((q, i) => new { q.ParentId, q.OrgName,  q.Point, Ranking = i + 1 });
			this.deptPointsList.DataBind();
		}
	}

	protected string ShowRanking() {
		int ranking = ConvertKit.ConvertValue(Eval("Ranking"), 0);
		return ranking <= 3 ? "<img src=\"styles/web/page/cup" + ranking + ".png\" alt=\"\"/>" : ranking.ToString();
	}

	private void BindExtLink()
	{
		using (var db = new NPiculetEntities()) {
			var query = (from a in db.cms_friendlinks_info where a.IsEnabled == 1 select a).ToList();
			this.float_link_1.DataSource = query.Where(q => q.Type == "省厅各直属部门");
			this.float_link_1.DataBind();
			this.float_link_2.DataSource = query.Where(q => q.Type == "全国经侦");
			this.float_link_2.DataBind();
			this.float_link_3.DataSource = query.Where(q => q.Type == "全省经侦");
			this.float_link_3.DataBind();
			this.float_link_4.DataSource = query.Where(q => q.Type == "各业务处室");
			this.float_link_4.DataBind();
		}
	}

	/// <summary>
	/// 获取顶部广告
	/// </summary>
	/// <returns></returns>
	private string GetAd(string type)
	{
		string ad = "<a href=\"{0}\"><img src=\"{1}\" alt=\"{2}\"/></a>";

		var abus = new CmsAdvBus();
		var a = abus.GetSingleAd(type);
		if (a != null) {
			string url = string.IsNullOrEmpty(a.Url) ? "#" : (a.Url.Left(4) == "http" ? a.Url : ResolveClientUrl(a.Url));
			string imgUrl = ResolveClientUrl(a.Image);

			return string.Format(ad, url, imgUrl, a.Description);
		}
		return "";
	}

	/// <summary>
	/// 获取顶部广告
	/// </summary>
	/// <returns></returns>
	protected string GetTopAd() {
		return GetAd("MainPageTop");
	}

	/// <summary>
	/// 获取中部广告
	/// </summary>
	/// <returns></returns>
	protected string GetMiddleAd()
	{
		return GetAd("MainPageMiddle");
	}

	/// <summary>
	/// 获取业务
	/// </summary>
	/// <param name="code"></param>
	/// <param name="i"></param>
	/// <returns></returns>
	protected string GetBusLinkUrl(string code, int i) {
		using (var db = new NPiculetEntities()) {
			var query = (from a in db.cms_friendlinks_info where a.Type == code select a).ToList();
			return query.Count > i ? query[i].Url : "#";
		}
	}

	protected string GetExtUrl() {
		string url = Convert.ToString(Eval("Url"));
		if (url.IndexOf("http://") > -1 || url.IndexOf("https://") > -1)
			return url;
		else
			return ResolveClientUrl(url);
	}
}