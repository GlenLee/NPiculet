using System;
using NPiculet.Base.EF;
using System.Linq;
using System.Text;

namespace web.uc
{
	public partial class FriendLinks : System.Web.UI.UserControl
	{
		public string FriendLinksHtml
		{
			get
			{
				if (ViewState["_friendLinksHtml"] == null || string.IsNullOrEmpty(ViewState["_friendLinksHtml"].ToString()))
					ViewState["_friendLinksHtml"] = CreateHtml();
				return Convert.ToString(ViewState["_friendLinksHtml"]);
			}
		}

		protected string CreateHtml()
		{
			string friendLinksHtml = "";

			using (NPiculetEntities db = new NPiculetEntities())
			{
				var linksWithImg = db.cms_friendlinks_info.Where(x => !string.IsNullOrEmpty(x.Image));
				var linksWithoutImg = db.cms_friendlinks_info.Where(x => string.IsNullOrEmpty(x.Image));
				StringBuilder builder = new StringBuilder();
				string html = "";
				if (linksWithoutImg.Any())
				{
					foreach (var link in linksWithoutImg)
					{
						builder.AppendFormat(" <a href='{0}' target='_blank'>{1}</a> |", link.Url, link.Description);
					}
					html = builder.ToString();
					html = html.Substring(0, html.Length - 2);
					friendLinksHtml += "<div>" + html + "</div>";
				}

				builder = new StringBuilder();
				if (linksWithImg.Any())
				{
					foreach (var link in linksWithImg)
					{
						builder.AppendFormat(" <a href='{0}' target='_blank'><img alt='{1}' src='{2}'/></a> |", link.Url, link.Description, ResolveClientUrl(link.Image));
					}
					html = builder.ToString();
					html = html.Substring(0, html.Length - 2);
					friendLinksHtml = "<div>" + html + "</div>";
				}
			}
			return friendLinksHtml;
		}
	}
}