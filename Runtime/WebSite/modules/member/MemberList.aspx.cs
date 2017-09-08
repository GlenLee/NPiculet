using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

namespace modules.member
{
	public partial class ModulesMemberMemberList : AdminPage
	{
		private readonly MemberBus _mbus = new MemberBus();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				BindData();
			}
		}

		private void BindData()
		{
			string whereString = "IsDel=0";

			string key = this.txtKeywords.Text.FormatSqlParm();
			if (!string.IsNullOrEmpty(key))
				whereString += string.Format(" and (Account LIKE '%{0}%' or Name LIKE '%{0}%')", key);

			if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue))
				whereString += string.Format(" and Status='{0}'", this.ddlStatus.SelectedValue);

			int count;
			DataTable dt = _mbus.GetMemberList(out count, this.nPager.CurrentPage, this.nPager.PageSize, whereString, "CreateDate DESC");

			this.list.DataSource = dt.DefaultView;
			this.list.DataBind();

			this.nPager.RecordCount = count;
		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex > -1) {
				if (this.list.DataKeys.Count > e.RowIndex) {
					int id = ConvertKit.ConvertValue(this.list.DataKeys[e.RowIndex]["Id"], 0);
					_mbus.Delete(id);
				}
				BindData();
			}
		}
        
        protected string GetStatusString(string enabled)
		{
			//return enabled == "1" ? "启用" : "停用";
			return enabled == "1" ? "<font color='Green'>启用</font>" : "<font color='red'>停用</font>";
		}

		protected void btnRobot_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow row in this.list.Rows) {
				if (row.RowType == DataControlRowType.DataRow) {
					var box = row.FindControl("chkBox") as HtmlInputCheckBox;
					if (box != null) {
						if (box.Checked) {
							int dataId = ConvertKit.ConvertValue(box.Value, 0);
							_mbus.UpdateStatus(dataId, "外挂");
						}
					}
				}
			}
			BindData();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			BindData();
		}

		protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
			BindData();
		}
	}
}