using System;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

namespace modules.info
{
	public partial class AdvList : AdminPage
	{
		private readonly CmsAdvBus _abus = new CmsAdvBus();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				BindType();
				BindData();
			}
		}

		private void BindType()
		{
			DictBus dbus = new DictBus();
			var data = dbus.GetActiveItemList("AdPosition");
			BindKit.BindToListControl(this.ddlPosition, data, "Name", "Code");
			this.ddlPosition.Items.Insert(0, new ListItem("全部", ""));
		}

		private void BindData()
		{
			var where = LinQKit.CreateWhere<cms_adv_info>(null);

			if (!string.IsNullOrEmpty(this.ddlPosition.SelectedValue)) {
				string val = this.ddlPosition.SelectedValue;
				where = (q => q.Position == val);
			}

			int count;
			var data = _abus.GetAdList(out count, this.nPager.CurrentPage, this.nPager.PageSize, where);

			this.nPager.RecordCount = count;

			list.DataSource = data;
			list.DataBind();
		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex <= -1)
				return;
			if (list.DataKeys.Count > e.RowIndex) {
				var dataKey = list.DataKeys[e.RowIndex];
				if (dataKey != null) {
					int dataId = ConvertKit.ConvertValue(dataKey["Id"], 0);
					_abus.Delete(dataId);
				}
			}
			BindData();
		}

		protected void btnSearch_Click(object sender, EventArgs e) {
			BindData();
		}

		protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
			BindData();
		}
	}
}