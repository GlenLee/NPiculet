using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Data;
using System.Data;

public partial class modules_DashBoard : AdminPage
{
	private DataView dv;

    protected void Page_Load(object sender, EventArgs e)
	{
		string sql = @"SELECT CONCAT(
	DATE_FORMAT(CreateDate, '%Y%m%d%H'),
	LPAD(FLOOR(DATE_FORMAT(CreateDate, '%i')/5),2,'0')
) AS g, COUNT(*) AS c FROM npc_sys_member_info WHERE CreateDate>'{0}' GROUP BY g ORDER BY g";
		sql = string.Format(sql, DateTime.Now.AddHours(-48).ToString("yyyy-MM-dd HH:mm:ss"));

		dv = DbHelper.Query(sql).DefaultView;

	    BindRegTotal(this.regToday, DateTime.Now);
		BindRegTotal(this.regYesterday, DateTime.Now.AddDays(-1));
		BindRegTotal(this.regBeforeYesterday, DateTime.Now.AddDays(-2));
	}

	private void BindRegTotal(Literal control, DateTime date)
	{
		string sql = @"SELECT COUNT(*) FROM npc_sys_member_info WHERE CreateDate>='{0}' and CreateDate<'{1}'";
		string sdate = date.ToString("yyyy-MM-dd");
		string edate = date.AddDays(1).ToString("yyyy-MM-dd");
		control.Text = DbHelper.QueryValue(string.Format(sql, sdate, edate)).ToString();
    }

	protected string GetChartXAxis()
	{
		string args = "";

		foreach (DataRowView dr in dv) {
			args += Convert.ToString(dr["g"]) + ",";
		}

		return args.Trim(',');
	}

	protected string GetChartSeries()
	{
		string args = "";

		foreach (DataRowView dr in dv) {
			args += Convert.ToString(dr["c"]) + ",";
		}

		return args.Trim(',');
	}

}