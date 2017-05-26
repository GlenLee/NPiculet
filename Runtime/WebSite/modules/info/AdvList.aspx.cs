using System;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;

namespace modules.info
{
	public partial class AdvList : AdminPage
	{
		private readonly NPiculetEntities _db = new NPiculetEntities();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindData();
			}
		}

		private readonly CmsAdvInfoBus _bus = new CmsAdvInfoBus();

		private void BindData()
		{
			var dataSource = from row in _db.cms_adv_info.Where(row => row.IsEnabled == 0 || row.IsEnabled == 1).ToList()
							 select new
							 {
								 row.Id,
								 row.CreateDate,
								 row.Creator,
								 row.StartDate,
								 row.Description,
								 row.EndDate,
								 row.Image,
								 row.IsEnabled,
								 Status = AdvHelper.GetStatus(row.IsEnabled),
								 row.LoopEnd,
								 row.LoopStart,
								 row.OrderBy,
								 row.Type,
								 row.Url,
								 row.ValidTerm
							 };
			list.DataSource = dataSource.ToArray();
			list.DataBind();

		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex <= -1)
				return;
			if (list.DataKeys.Count > e.RowIndex)
			{
				var dataKey = list.DataKeys[e.RowIndex];
				if (dataKey != null)
				{
					string dataId = dataKey["Id"].ToString();
					_bus.Delete("Id=" + dataId);
				}
			}
			BindData();
		}

		protected void list_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			string[] args = e.CommandArgument.ToString().Split(',');
			var id = int.Parse(args[0]);

			var model = _db.cms_adv_info.SingleOrDefault(x => x.Id == id);
			if (model == null)
			{
				JavaSrcipt("$.alert('该申请已经不存在！');");
				return;
			}

			if (e.CommandName == "PassAudit")
			{
				if (model.IsEnabled != (int)AdvStatus.待审核)
					JavaSrcipt("$.alert('只能批准【待审核】的的申请！');");
				else
				{
					model.IsEnabled = (int)AdvStatus.已审核;
					int day = model.ValidTerm ?? 0;
					model.EndDate = model.StartDate + new TimeSpan(day, 0, 0, 0);
					_db.Entry(model).State = System.Data.Entity.EntityState.Modified;
					_db.SaveChanges();
					BindData();
				}
			}

			if (e.CommandName == "RejectAudit")
			{
				model.IsEnabled = (int)AdvStatus.未通过;
				model.EndDate = null;
				_db.Entry(model).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();
				BindData();
			}
		}
		protected void list_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
	}
}