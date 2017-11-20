using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_cms_PageList : AdminPage
{
	CmsContentBus _cbus = new CmsContentBus();

	public int GroupId { get { return WebParmKit.GetQuery("gid", 0); } }
	public string GroupCode { get { return WebParmKit.GetQuery("group", ""); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData() {
		var configs = new ConfigManager();
		var limit = configs.GetConfig("NewsEditLimit"); //限制类型

		int gid = this.GroupId;
		string code = this.GroupCode;

		cms_content_group cg = _cbus.GetGroup(g => g.Id == gid || g.GroupCode == code);

		if (cg == null) {
			this.btnAdd.Visible = false;
			this.AlertBeauty("没有找到组数据，请检查菜单及栏目配置！");
			return;
		}
		this.Page.Header.Title = cg.GroupName;

		//新增页链接
		string editUrl = "PageEdit.aspx?";
		this.btnAdd.NavigateUrl = editUrl + (string.IsNullOrEmpty(code) ? "gid=" + gid : "group=" + code);

		//查询数据
		var where = LinQKit.CreateWhere<cms_content_page>(a => a.GroupCode == cg.GroupCode);

		if (!string.IsNullOrEmpty(this.txtKeywords.Text)) {
			string key = this.txtKeywords.Text;
			where = where.And(q => q.Title.Contains(key) || q.Content.Contains(key));
		}

		//检查编辑权限
		var user = this.CurrentUserInfo;
		if (user.Id > 1) {
			switch (limit) {
				case "Org": //限制在根组织机构
					var orgId = user.Organization.Id;
					where = where.And(q => q.OrgId == orgId);
					break;
				case "User": //限制在用户自身
					var userId = user.Id;
					where = where.And(q => q.UserId == userId);
					break;
			}
		}

		int count;
		var dt = _cbus.GetPageList(out count, this.nPager.CurrentPage, this.nPager.PageSize, where).ToList();

		this.list.DataSource = dt;
		this.list.DataBind();

		this.nPager.RecordCount = count;
	}

	/// <summary>
	/// 删除数据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
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

	/// <summary>
	/// 获取启用状态
	/// </summary>
	/// <returns></returns>
	protected string GetIsEnabledString()
	{
		string enabled = Convert.ToString(Eval("IsEnabled"));
		return enabled == "1" ? "发布" : "<span style=\"color:red\">编辑</span>";
	}

	/// <summary>
	/// 获取排序状态
	/// </summary>
	/// <returns></returns>
	protected string GetOrderByString()
	{
		string top = Convert.ToString(Eval("Sort"));
		return top == "0" ? "置顶" : "";
	}

	/// <summary>
	/// 获取编辑页地址及参数
	/// </summary>
	/// <returns></returns>
	protected string GetEditPageUrl()
	{
		int gid = this.GroupId;
		string code = this.GroupCode;
		string editUrl = "PageEdit.aspx?";
		string url = editUrl + (string.IsNullOrEmpty(code) ? "gid=" + gid : "group=" + code);

		string id = Convert.ToString(Eval("Id"));
		return url + "&id=" + id;
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e)
	{
		BindData();
	}
}