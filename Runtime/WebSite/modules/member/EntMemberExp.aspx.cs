using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class modules_member_EntMemberExp : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		int userId = WebParmKit.GetQuery("id", 0);
		if (userId > 0) {
			using (var db = new NPiculetEntities()) {
				string targetId = userId.ToString();
				this.list.DataSource = (from a in db.sys_action_log
										join b in db.sys_action_detail on a.Id equals b.ActionId
										where a.ActionType == "Exp" && a.TargetId == targetId
										orderby a.Date descending
										select new {
											a.Id,
											a.Tag,
											a.Comment,
											a.Date,
											Image = b.NewValue
										}).ToList();
				this.list.DataBind();
			}
		}
	}

	protected void btnSave_OnClick(object sender, EventArgs e)
	{
		int userId = WebParmKit.GetQuery("id", 0);
		if (userId > 0) {
			using (var db = new NPiculetEntities()) {
				var model = db.sys_member_data.FirstOrDefault(a => a.UserId == userId);
				if (model != null) {
					decimal val = ConvertKit.ConvertValue<decimal>(this.number.Text, (decimal)0);
					model.Exp = (model.Exp ?? 0) + (this.symbol.SelectedValue == "+" ? val : -val);

					var log = new sys_action_log();
					log.ActionType = "Exp";
					log.TargetId = userId.ToString();
					log.Tag = (this.symbol.SelectedValue == "+" ? "增加" : "减少") + "：" + val.ToString("0.##") + "分，总分：" + model.Exp.Value.ToString("0.##");
					log.Comment = this.reson.Text;
					log.Date = DateTime.Now;
					db.sys_action_log.Add(log);
					db.SaveChanges();

					var detail = new sys_action_detail();
					detail.ActionId = log.Id;
					detail.FieldCode = "Image";
					detail.NewValue = FileWebKit.SaveFile(this.photo.PostedFile);
					db.sys_action_detail.Add(detail);
					db.SaveChanges();
				}
			}
			BindData();
		}
	}

	protected void list_OnRowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow) {
			var dataKey = this.list.DataKeys[e.Row.RowIndex];
			if (dataKey != null) {
				string image = Convert.ToString(dataKey["Image"]);
				if (string.IsNullOrEmpty(image)) {
					e.Row.Cells[3].Text = "无";
				}
			}
		}
	}
}