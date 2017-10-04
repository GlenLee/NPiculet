using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_PointSet : AdminPage
{
	private readonly OrgBus _obus = new OrgBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			BindLogs();
		}
		this.nPager.PageClick += (o, args) => {
			BindLogs();
		};
	}

	private void BindLogs() {
		using (var db = new NPiculetEntities()) {

			var logs = (from l in db.cms_points_log
				orderby l.CreateDate descending
				select l);

			this.nPager.RecordCount = logs.Count();

			this.pointLogs.DataSource = logs.Pagination(this.nPager.CurrentPage, this.nPager.PageSize).ToList();
			this.pointLogs.DataBind();
		}
	}

	private void BindData()
	{
		string whereString = "IsDel=0 and Level=1";

		var data = _obus.GetOrgList(a => a.IsDel == 0 && a.Level == 1);

		this.list.DataSource = data.ToList();
		this.list.DataBind();
	}

	protected void btnSave_OnClick(object sender, EventArgs e) {

		CmsPointBus pbus = new CmsPointBus();

		foreach (GridViewRow row in this.list.Rows) {
			if (row.RowType == DataControlRowType.DataRow) {
				var dataKey = this.list.DataKeys[row.RowIndex];
				if (dataKey != null) {
					int orgId = ConvertKit.ConvertValue(dataKey["Id"], 0);
					string orgName = Convert.ToString(dataKey["OrgName"]);
					decimal cpoint = ConvertKit.ConvertValue(dataKey["Point"], 0m);

					string val = (row.FindControl("point") as TextBox).Text;
					decimal mpoint = ConvertKit.ConvertValue(val, 0m);
					if (!string.IsNullOrEmpty(val) && cpoint != mpoint) {
						decimal point = mpoint - cpoint;
						pbus.SavePointLog(this.CurrentUserInfo, orgId, "cms_point_log", orgId.ToString(), point, "手动调整，" + (point > 0 ? "增加积分" : "减少积分"), orgName);
					}
				}
			}
		}

		BindData();
		BindLogs();
	}
}