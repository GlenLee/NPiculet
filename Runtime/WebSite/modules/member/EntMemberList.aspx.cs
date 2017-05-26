using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

namespace modules.member
{
	public partial class ModulesMemberEntMemberList : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindData();
			}

			this.NPager1.PageClick += (o, args) =>
			{
				BindData();
			};
		}

		private readonly SysMemberInfoBus _bus = new SysMemberInfoBus();
		private readonly NPiculetEntities _db = new NPiculetEntities();

		private void BindData()
		{
			BindStatus();

			var query = (from a in _db.sys_member_info
						 join b in _db.sys_member_data on a.Id equals b.UserId
						 join c in _db.sys_member_corporation on a.Id equals c.UserId
						 where a.IsDel == 0 && a.MemberLevel == "企业用户"
						 orderby a.CreateDate descending
						 select new {
							 a.Id,
							 a.Account,
							 a.Password,
							 a.Name,
							 b.Mobile,
							 c.ChargeMan,
							 c.ChargeManTel,
							 a.IsEnabled,
							 a.MemberLevelStatus,
							 a.Status,
							 a.CreateDate,
							 b.Exp,
							 c.CorporationName,
							 c.CorporationBreifName
						 });

			string key = this.txtKeywords.Text;
			if (!string.IsNullOrEmpty(key))
				query = query.Where(a => (a.Account.Contains(key) || a.Name.Contains(key) || a.CorporationName.Contains(key) || a.CorporationBreifName.Contains(key)));

			int count = query.Count();
			this.NPager1.PageSize = 15;
			this.NPager1.RecordCount = count;

			var data = query.Pagination(this.NPager1.CurrentPage, this.NPager1.PageSize).ToList();

			this.list.DataSource = data;
			this.list.DataBind();

			var corpInfo = from row in data
						   join corpDetail in _db.sys_member_corporation
						   on row.Account equals corpDetail.UserAccount
						   select new {
							   lng = corpDetail.longitude,
							   lat = corpDetail.Altitudes,
							   sn = row.Id,
							   name = corpDetail.CorporationBreifName,
							   color = EntMemeberStatusHelper.GetStatusColor(row.Status)
						   };

			this.corpItems.Value = corpInfo.ToJson();
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

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				if (this.list.DataKeys.Count > e.RowIndex)
				{
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
		protected void btnListView_Click(object sender, EventArgs e)
		{
			memberList.Visible = true;
			memberMap.Visible = false;
		}
		protected void btnMapView_Click(object sender, EventArgs e)
		{
			memberList.Visible = false;
			memberMap.Visible = true;
			ClientScript.RegisterStartupScript(this.GetType(), "showCorpsOnMap", "showCorpsOnMap()", true);
		}

		protected string GetColorString()
		{
			string result="";
			foreach (EntMemeberStatus status in EntMemeberStatusHelper.AllMemberStatusEnum)
			{
				result += "<font color='" + status.Description() + "'>" + status + "</font>&nbsp&nbsp";
			}
			return result;
		}

		protected void btnBatchApprove_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow row in list.Rows)
			{
				var checkBox = row.FindControl("checkBox") as CheckBox;
				if (checkBox == null || !checkBox.Checked)
					continue;

				var dataKey = list.DataKeys[row.DataItemIndex];
				if (dataKey != null)
				{
					var userId = dataKey["Id"].ToString();
					if (string.IsNullOrEmpty(userId))
						continue;
					var model = _bus.QueryModel("Id = " + userId);
					if (model != null)
					{
						model.Status = ((int)EntMemeberStatus.已审核).ToString();
						_bus.Update(model, null);
					}
				}
			}
			BindData();
		}

        protected string GetMemberStatus(string enabled)
        {
            return enabled == "1" ? "<font color='Green'>会员</font>" : "<font color='red'>非会员</font>";
        }

        protected string GetExp()
		{
			var exp = Convert.ToDecimal(Eval("Exp"));
			return exp == 0 ? "0" : exp.ToString("0.##");
		}
	}
}