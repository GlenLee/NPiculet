using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;

public partial class web_uc_SimpleWidget : System.Web.UI.UserControl
{
	public string GroupCode { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		using (var db = new NPiculetEntities()) {

			var group = db.cms_content_group.SingleOrDefault(g => g.GroupCode == this.GroupCode);
			if (group != null) this.title.Text = group.GroupName;

			var data = db.cms_content_page.Where(x => x.GroupCode == this.GroupCode)
				.OrderByDescending(x => x.CreateDate)
				.Take(12)
				.ToList();
			if (data.Count >= 1) {
				this.list.DataSource = data;
				this.list.DataBind();
			}
		}
	}

	protected string GetNewsTitle()
	{
		var length = 24;
		var title = Convert.ToString(Eval("Title"));
		return title.Length > length ? title.Substring(0, length - 1) + "…" : title;
	}
}