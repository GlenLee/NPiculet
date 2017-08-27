using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Toolkit;
using NPiculet.Logic.Base;
using NPiculet.Logic.Sys;

public partial class modules_info_InfoPageList : AdminPage
{
	[Category("业务参数"), Browsable(true), Description("栏目编码")]
	public string GroupCode { get { return WebParmKit.GetQuery("code", ""); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}

		this.NPager1.PageClick += (o, args) => {
			BindData();
		};
	}

	private void BindData() {

		var configs = new ConfigManager();
		var limit = configs.GetConfig("NewsEditLimit");

		using (var db = new NPiculetEntities()) {
			string code = GroupCode;

			cms_content_group cg;

			if (code.IsNumeric()) {
				int gid = Convert.ToInt32(code);
				cg = (from g in db.cms_content_group
					where g.Id == gid || g.GroupCode == code
					select g).FirstOrDefault();
			} else {
				cg = (from g in db.cms_content_group
					where g.GroupCode == code
					select g).FirstOrDefault();
			}

			if (cg != null) {
				var query = (from p in db.cms_content_page
					where p.GroupCode == cg.GroupCode
					select p);

				//过滤条件
				if (!string.IsNullOrEmpty(this.txtKeywords.Text)) {
					string key = this.txtKeywords.Text;
					query = query.Where(q => q.Title.Contains(key) || q.Content.Contains(key));
				}

				//检查编辑权限
				var user = this.CurrentUserInfo;
				if (user.Id > 1) {
					switch (limit) {
						case "Org":
							var orgId = user.Organization.Id;
							query = query.Where(q => q.OrgId == orgId);
							break;
						case "User":
							var userId = user.Id;
							query = query.Where(q => q.UserId == userId);
							break;
					}
				}

				//排序
				query = (from p in query
					orderby p.OrderBy descending, p.CreateDate descending
					select p);

				this.Title = cg.GroupName;

				int count = query.Count();
				this.NPager1.RecordCount = count;

				var dt = query.Pagination(this.NPager1.CurrentPage, this.NPager1.PageSize).ToList();

				this.list.DataSource = dt;
				this.list.DataBind();
			}
		}
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				CmsContentBus _bus = new CmsContentBus();
				string dataId = this.list.DataKeys[e.RowIndex]["Id"].ToString();
				string title = this.list.DataKeys[e.RowIndex]["Title"].ToString();
				_bus.DeletePage(ConvertKit.ConvertValue(dataId, 0));

				//减少积分
				int point = new ConfigManager().GetConfig<int>("NewsPoint");
				var pbus = new CmsPointBus();
				pbus.SavePointLog(this.CurrentUserInfo, "cms_content_page", dataId, -point, "删除文章，减少积分", title);
			}
			BindData();
		}
	}

	protected string GetIsEnabledString() {
		string enabled = Convert.ToString(Eval("IsEnabled"));
		return enabled == "1" ? "发布" : "<span style=\"color:red\">编辑</span>";
	}

	protected string GetOrderByString() {
		string top = Convert.ToString(Eval("OrderBy"));
		return top == "1" ? "置顶" : "";
	}

	protected void btnSearch_Click(object sender, EventArgs e) {
		BindData();
	}
}