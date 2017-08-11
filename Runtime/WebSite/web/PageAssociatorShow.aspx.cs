using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

public partial class web_PageAssociatorShow : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack) {
			BindMap();

			memberMap.Visible = true;
			//ClientScript.RegisterStartupScript(this.GetType(), "showCorpsOnMap", "showCorpsOnMap()", true);
		}
	}

	protected string GetColorString()
	{
		string result = "";
		result += "<font color='green'>已审核</font>&nbsp&nbsp";
		result += "<font color='red'>未审核</font>&nbsp&nbsp";
		return result;
	}

	private void BindMap()
	{
		using (var db = new NPiculetEntities()) {
			var query = (from a in db.sys_member_info
				join b in db.sys_member_data on a.Id equals b.UserId
				join c in db.sys_member_corporation on a.Id equals c.UserId
				where a.IsDel == 0 && a.MemberLevel == "企业用户"
				orderby a.CreateDate descending
				select new {
					a.Id,
					a.Account,
					a.Password,
					a.Name,
					a.IsEnabled,
					a.MemberLevelStatus,
					a.Status,
					a.CreateDate
					,
					b.Exp,
					c.CorporationName,
					c.CorporationBreifName
				});

			//string key = this.txtKeywords.Text;
			//if (!string.IsNullOrEmpty(key))
			//	query = query.Where(a => (a.Account.Contains(key) || a.Name.Contains(key)));

			//int count = query.Count();
			//this.NPager1.PageSize = 15;
			//this.NPager1.RecordCount = count;

			//var data = query.Pagination(this.NPager1.CurrentPage, this.NPager1.PageSize).ToList();

			//this.list.DataSource = data;
			//this.list.DataBind();

			var corpInfo = from row in query.ToList()
						   join corpDetail in db.sys_member_corporation
					on row.Account equals corpDetail.UserAccount
				select new {
					lng = corpDetail.longitude,
					lat = corpDetail.Altitudes,
					sn = row.Id,
					name = corpDetail.CorporationBreifName,
					color = row.Status == "1" ? "green" : "red"
				};

			this.corpItems.Value = corpInfo.ToJson();
		}
	}
}