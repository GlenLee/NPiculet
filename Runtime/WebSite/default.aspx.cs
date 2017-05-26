using NPiculet.Base.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class _Default : System.Web.UI.Page
{
	private NPiculetEntities _db = new NPiculetEntities();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			BindMemeberList();
			BindLawList();
			BindNewsList();
			BindConsultNewsList();
			BindAssociatorShow();
			BindBarList();
			BindAssociationNews();
			BindPagePolicyList();
			BindEntHireList();
			BindSaleList();
			CommonLib.BindAdvToRepeater(RecommendBrands, AdvType.推荐品牌, 20);
			CommonLib.BindAdvToRepeater(AdvertisingOfTop, AdvType.轮播广告, 5);
			CommonLib.BindAdvToRepeater(BottomBanner, AdvType.底部广告, 2);
		}

		var member = LoginKit.GetCurrentMember();
		bool login = (member != null);
		indexLoginForm.Visible = !login;
		indexUserInfo.Visible = login;
	}

	private void BindEntHireList()
	{
		var list = _db.cms_content_page.Where
			(row => row.GroupCode == "EntHire" && row.IsEnabled == (int)HireStatus.已公开)
			.OrderByDescending(x => x.CreateDate)
			.Take(8)
			.ToList();

		TopEntHireList.DataSource = list;
		TopEntHireList.DataBind();
	}

	private void BindMemeberList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageJobSeeker" && x.IsEnabled == (int)HireStatus.已公开)
			.OrderByDescending(x => x.CreateDate)
			.Take(7)
			.ToList();

		if (data.Count >= 1)
		{
			this.TopJobSeekers.DataSource = data;
			this.TopJobSeekers.DataBind();
		}
	}
	private void BindLawList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageLaw")
			.OrderByDescending(x => x.CreateDate)
			.Take(12)
			.ToList();
		if (data.Count >= 1)
		{
			this.LawList.DataSource = data;
			this.LawList.DataBind();
		}
	}

	private void BindNewsList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageNew")
			.OrderByDescending(x => x.CreateDate)
			.Take(7)
			.ToList();
		if (data.Count >= 1)
		{
			var hotNews = data[0];
			var hotNewsUrl = "~/web/ContentView.aspx?groupCode="+ hotNews.GroupCode + "&id=" + hotNews.Id;
			hotNewsImg.ImageUrl = string.IsNullOrEmpty(hotNews.Thumb) ? "~/styles/images/noimage.jpg" : hotNews.Thumb;
			hotNewsTitle.Text = hotNews.Title;
			hotNewsInfo.Text = GetHotNewsContent(hotNews.Content);
			hotNewsInfo.NavigateUrl = hotNewsTitleLink.NavigateUrl = hotNewsImgLink.NavigateUrl = hotNewsUrl;
			hotNewsTitleMore.NavigateUrl = hotNewsTitleLink.NavigateUrl;

			data.RemoveAt(0);
			this.newslist.DataSource = data;
			this.newslist.DataBind();
		}
	}

	private void BindSaleList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "Sale").OrderByDescending(x => x.CreateDate).Take(8).ToList();
		if (data.Count >= 1) {
			this.salelist.DataSource = data;
			this.salelist.DataBind();
		}
	}

	private string GetHotNewsContent(string originalText)
	{
		const int stringLen = 120;
		string temp = NoHtml(originalText);
		if (temp.Length > stringLen)
			return temp.Substring(0, stringLen - 1);
		return temp;
	}

	private static string NoHtml(string htmlstring)
	{
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
		htmlstring.Replace("<", "");
		htmlstring.Replace(">", "");
		htmlstring.Replace("\r\n", "");
		htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();

		return htmlstring;
	}

	private void BindConsultNewsList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageConsultNews")
			.OrderByDescending(x => x.CreateDate)
			.Take(12)
			.ToList();
		if (data.Count >= 1)
		{
			this.ConsultNewsList.DataSource = data;
			this.ConsultNewsList.DataBind();
		}
	}

	protected string IsNewIcon()
	{
		DateTime createDate = ConvertKit.ConvertValue(Eval("CreateDate"), DateTime.MinValue);
		if (createDate >= DateTime.Now.AddDays(-3)) {
			return "<img src=\"styles/images/new.png\" alt=\"\" />";
		}
		return "";
	}

	private void BindAssociatorShow()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageAssociatorShow")
			.OrderByDescending(x => x.CreateDate)
			.Take(7)
			.ToList();
		if (data.Count >= 1)
		{
			this.AssociatorShowList.DataSource = data;
			this.AssociatorShowList.DataBind();
		}
	}

	private void BindBarList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageBar")
			.OrderByDescending(x => x.CreateDate)
			.Take(14)
			.ToList();
		if (data.Count >= 1)
		{
			this.BarList.DataSource = data;
			this.BarList.DataBind();
		}
	}

	private void BindAssociationNews()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PageAssociationNews")
			.OrderByDescending(x => x.CreateDate)
			.Take(9)
			.ToList();
		if (data.Count >= 1) {
			var anNews = data[0];
			var anNewsUrl = "~/web/ContentView.aspx?groupCode=" + anNews.GroupCode + "&id=" + anNews.Id;
			anImage.ImageUrl = string.IsNullOrEmpty(anNews.Thumb) ? "~/styles/images/noimage.jpg" : anNews.Thumb;
			anTitle.Text = anNews.Title;
			anLink3.Text = GetHotNewsContent(anNews.Content);
			anLink.NavigateUrl = anLink2.NavigateUrl = anLink3.NavigateUrl = anLink4.NavigateUrl = anNewsUrl;

			data.RemoveAt(0);

			this.AssociationNewsList.DataSource = data;
			this.AssociationNewsList.DataBind();
		}
	}

	private void BindPagePolicyList()
	{
		var data = _db.cms_content_page.Where(x => x.GroupCode == "PagePolicy")
			.OrderByDescending(x => x.CreateDate)
			.Take(14)
			.ToList();
		if (data.Count >= 1)
		{
			this.PagePolicyList.DataSource = data;
			this.PagePolicyList.DataBind();
		}
	}

	protected string GetGameTitle()
	{
		var length = 24;
		var title = Convert.ToString(Eval("Title"));
		return title.Length > length ? title.Substring(0, length - 1) + "…" : title;
	}

	protected string GetNewsTitle()
	{
		var length = 50;
		var title = Convert.ToString(Eval("Title"));
		return title.Length > length ? title.Substring(0, length - 1) + "…" : title;
	}

	protected string GetAdvImageUrl()
	{
		throw new NotImplementedException();
	}

	protected string GetAdvLinkUrl()
	{
		throw new NotImplementedException();
	}
}