using System;
using System.Data;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

namespace modules.member
{
	public partial class ModulesMemberMemberList : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				BindData();
			}

			this.NPager1.PageClick += (o, args) => { BindData(); };
		}

		protected void BindStatus()
		{
			if (ddlStatus.Items.Count >= 1)
				return;

			foreach (EntMemeberStatus status in EntMemeberStatusHelper.AllMemberStatusEnum)
			{
				ddlStatus.Items.Add(status.ToString());
			}
			ddlStatus.Items.Add("全部");
			ddlStatus.SelectedIndex = ddlStatus.Items.Count - 1;
		}

		private readonly SysMemberInfoBus _bus = new SysMemberInfoBus();

		private void BindData()
		{
			BindStatus();

			string whereString = "IsDel=0 AND MemberLevel = '个人用户'";
			string key = this.txtKeywords.Text.FormatSqlParm();
			if (!string.IsNullOrEmpty(key))
				whereString += string.Format(" and (Account LIKE '%{0}%' or Name LIKE '%{0}%')", key);

			if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue) && this.ddlStatus.SelectedValue != "全部")
				if (this.ddlStatus.SelectedValue == "已注册")
					whereString += " and (Status='已注册-未充值' or Status='已注册-已充值')";
				else
					whereString += string.Format(" and Status='{0}'", this.ddlStatus.SelectedIndex);

			int count = _bus.RecordCount(whereString);
			this.NPager1.PageSize = 15;
			this.NPager1.RecordCount = count;

			DataTable dt = _bus.Query(this.NPager1.CurrentPage, this.NPager1.PageSize, whereString, "CreateDate DESC");

			this.list.DataSource = dt.DefaultView;
			this.list.DataBind();
		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex > -1) {
				if (this.list.DataKeys.Count > e.RowIndex) {
					string id = this.list.DataKeys[e.RowIndex]["Id"].ToString();
					_bus.Update(new SysMemberInfo() { IsDel = 1 }, "Id=" + id);
					new SysMemberDataBus().Update(new SysMemberData() { IsDel = 1 }, "UserId=" + id);
				}
				BindData();
			}
		}
        
        protected string GetStatusString(string enabled)
		{
			//return enabled == "1" ? "启用" : "停用";
			return enabled == "1" ? "<font color='Green'>启用</font>" : "<font color='red'>停用</font>";
		}

        protected string GetStatus(string enabled)
		{
			int intValue;
			int.TryParse(enabled, out intValue);
			string status = EntMemeberStatusHelper.GetStatus(intValue);
			string color = EntMemeberStatusHelper.GetStatusColor(enabled);
			return "<font color='" + color + "'>" + status + "</font>";
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			BindData();
		}
	}
}