using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Logic.Sys;
using NPiculet.Plugin;
using NPiculet.Toolkit;

public partial class modules_member_MemberVerify : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}

		this.NPager1.PageClick += (o, args) => {
			BindData();
		};
	}

	private readonly SysMemberInfoBus _bus = new SysMemberInfoBus();

	private void BindData()
	{
		string whereString = "IsDel=0";
		string key = this.txtKeywords.Text.FormatSqlParm();
		if (!string.IsNullOrEmpty(key))
			whereString += string.Format(" and (Account LIKE '%{0}%' or Name LIKE '%{0}%')", key);

		if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue) && this.ddlStatus.SelectedValue != "全部")
			whereString += string.Format(" and Status='{0}'", this.ddlStatus.SelectedValue);
		else
			whereString += " and (Status='已注册-未充值' or Status='已注册-已充值')";

		int count = _bus.RecordCount(whereString);
		this.NPager1.PageSize = 15;
		this.NPager1.RecordCount = count;

		DataTable dt = _bus.GetMemberList(this.NPager1.CurrentPage, this.NPager1.PageSize, whereString);

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
		return enabled == "1" ? "启用" : "停用";
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}

	protected void btnRobot_Click(object sender, EventArgs e)
	{
		foreach (GridViewRow row in this.list.Rows) {
			if (row.RowType == DataControlRowType.DataRow) {
				var box = row.FindControl("chkBox") as HtmlInputCheckBox;
				if (box != null) {
					if (box.Checked) {
						string dataId = box.Value;
						_bus.Update(new SysMemberInfo() { Status = "外挂" }, "Id=" + dataId);
					}
				}
			}
		}
		BindData();
	}

	protected void btnVerify_Click(object sender, EventArgs e)
	{
		foreach (GridViewRow row in this.list.Rows) {
			if (row.RowType == DataControlRowType.DataRow) {
				var box = row.FindControl("chkBox") as HtmlInputCheckBox;
				if (box != null) {
					if (box.Checked) {
						string dataId = box.Value;

						var member = _bus.QueryModel("Id=" + dataId);
						var data = new SysMemberDataBus().QueryModel("UserId=" + dataId);

						if (member != null && data != null && member.Status == "已注册-未充值") {
							//UpPhoneMoney(member, data); //充值
						}
					}
				}
			}
		}
		BindData();
	}
}