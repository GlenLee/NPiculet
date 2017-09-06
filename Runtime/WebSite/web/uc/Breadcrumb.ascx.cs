using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_uc_Breadcrumb : System.Web.UI.UserControl
{
	public string GroupCode { get; set; }

	NPiculetEntities sy = new NPiculetEntities();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack) 
			return;
		GroupCode = WebParmKit.GetQuery("groupCode", "");
		string articleId = WebParmKit.GetQuery("id", "");
	
		if (string.IsNullOrEmpty(GroupCode) && !string.IsNullOrEmpty(articleId))
		{
			GroupCode = GetGroupCodeByArticleId(int.Parse(articleId));
		}
		BindData();
	}

	private string GetGroupCodeByArticleId(int articleId)
	{
		var article = sy.cms_content_page.SingleOrDefault(x => x.Id == articleId);
		return article == null ? "" : article.GroupCode;
	}

	private void BindData()
	{
		var singleGroup = sy.cms_content_group.FirstOrDefault(x => x.GroupCode == GroupCode);
		if (singleGroup == null)
			return;
		if (string.IsNullOrEmpty(singleGroup.GroupName))
			return;
		curPageName.Text = singleGroup.GroupName;
		listPageLink.NavigateUrl = "/web/ContentList.aspx?code=" + GroupCode;
	}
}