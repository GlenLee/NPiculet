using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_Jump : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e) {
		string groupCode = WebParmKit.GetQuery("groupCode", "");
		if (!string.IsNullOrEmpty(groupCode)) {
			using (var db = new NPiculetEntities()) {
				var group = db.cms_content_group.SingleOrDefault(g => g.GroupCode == groupCode);
				if (group != null) {
					switch (group.GroupType) {
						//新闻列表页
						case "List":
							Server.Transfer("~/Web/ContentList.aspx?groupCode=" + group.GroupCode);
							break;

						//单页内容
						case "Content":
							Server.Transfer("~/Web/ContentView.aspx?id=" + group.GroupCode);
							break;

						//图片新闻
						case "Image":
							Server.Transfer("~/Web/ImagesList.aspx?groupCode=" + group.GroupCode);
							break;

						default:
							Response.Redirect("~/");
							break;
					}
				}
			}
		}
	}
}