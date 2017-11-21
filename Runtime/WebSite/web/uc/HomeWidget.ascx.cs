using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_uc_HomeWidget : System.Web.UI.UserControl
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

			int pageSize = 8;

			var group = db.cms_content_group.FirstOrDefault(g => g.GroupCode == this.GroupCode);
			if (group != null) this.title.Text = group.GroupName;

			var query = db.cms_content_page.Where(x => x.IsEnabled == 1 && x.GroupCode == this.GroupCode);

			query = query
				.OrderByDescending(x => x.Sort)
				.ThenByDescending(x => x.CreateDate)
				.Take(pageSize);

			var data = query.ToList();

			for (int i = 0; i < pageSize; i++) {
				if (i >= data.Count) {
					data.Add(new cms_content_page() {
						Title = "<span style=\"color:#ddd\">即将发布…</span>",
						CreateDate = DateTime.MinValue
					});
				} else {
					data[i].Title = GetNewsTitle(data[i].Title);
				}
			}

			this.list.DataSource = data;
			this.list.DataBind();
		}
	}

	protected string GetNewsTitle(string title)
	{
		var length = 16;
		return title.Length > length ? title.Substring(0, length - 1) + "…" : title;
	}

	protected string GetNewStyle() {
		var createDate = Convert.ToDateTime(Eval("CreateDate"));
		TimeSpan ts = DateTime.Now - createDate;
		if (ts.Days <= 3) {
			return " new";
		}
		return "";
	}

	protected string GetCreateDate()
	{
		var createDate = Convert.ToDateTime(Eval("CreateDate"));
		if (createDate == DateTime.MinValue) {
			return "";
		}
		return createDate.ToString("MM-dd");
	}

	protected string GetViewUrl() {
		string url = ResolveClientUrl("~/view") + "/" + Eval("Id");
		return url;
	}
}