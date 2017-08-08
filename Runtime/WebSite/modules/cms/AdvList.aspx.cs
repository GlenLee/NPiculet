using System;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

namespace modules.info
{
	public partial class AdvList : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				BindType();
				BindData();
			}
		}

		private void BindType()
		{
			BasDictItemBus ibus = new BasDictItemBus();
			var list = ibus.GetActiveItemList("Publicity");
			BindKit.BindToListControl(this.ddlPosition, list, "Name", "Code");
			this.ddlPosition.Items.Insert(0, new ListItem("全部", ""));
		}

		private readonly CmsAdvInfoBus _bus = new CmsAdvInfoBus();

		private void BindData()
		{
			using (var db = new NPiculetEntities()) {

				var query = (from a in db.cms_adv_info select a);

				//过滤条件
				if (!string.IsNullOrEmpty(this.ddlPosition.SelectedValue)) {
					string val = this.ddlPosition.SelectedValue;
					query = query.Where(q => q.Position == val);
				}
				//if (!string.IsNullOrEmpty(this.txtKeywords.Text)) {
				//	string key = this.txtKeywords.Text;
				//	query = query.Where(q => q.Description.Contains(key));
				//}

				//排序
				query = query.OrderByDescending(q => q.CreateDate);

				this.nPager.RecordCount = query.Count();

				list.DataSource = query.Pagination(this.nPager.CurrentPage, this.nPager.PageSize).ToList();
				list.DataBind();
			}

		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex <= -1)
				return;
			if (list.DataKeys.Count > e.RowIndex) {
				var dataKey = list.DataKeys[e.RowIndex];
				if (dataKey != null) {
					string dataId = dataKey["Id"].ToString();
					_bus.Delete("Id=" + dataId);
				}
			}
			BindData();
		}

		protected void btnSearch_Click(object sender, EventArgs e) {
			BindData();
		}
	}
}