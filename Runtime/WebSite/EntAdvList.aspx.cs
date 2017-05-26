using System;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;

public partial class EntAdvList : MemberPage
{
	readonly NPiculetEntities _db = new NPiculetEntities();

	protected void Page_Load(object sender, EventArgs e)
	{
		BindData();
	}

	private void BindData()
	{
		if (CurrentUserInfo == null) return;

		var list = from row in _db.cms_adv_info where row.Creator == CurrentUserInfo.Account
			select new {
				row.Id,
				row.CreateDate,
				row.Creator,
				row.Description,
				row.StartDate,
				row.EndDate,
				row.Image,
				Status = AdvHelper.GetStatus(row.IsEnabled),
				row.LoopEnd,
				row.LoopStart,
				row.OrderBy,
				row.Type,
				row.Url,
				row.ValidTerm
			};

		AdvList.DataSource = list;
		AdvList.DataBind();
	}

	protected void AdvList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
	{
		int id = int.Parse(e.CommandArgument.ToString());
		var model = _db.cms_adv_info.SingleOrDefault(x => x.Id == id);

		if (model == null)
			return;

		if (e.CommandName == "Delete") {
			if (!CanDelete(model))
				JavaSrcipt("$.alert('此申请已不能删除！');");
			else {
				_db.cms_adv_info.Remove(model);
				_db.SaveChanges();
				BindData();
			}
		}

		if (e.CommandName == "Edit") {
			if (!CanEdit(model))
				JavaSrcipt("$.alert('此申请已不能编辑！');");
			else {
				Response.Redirect("EntAdvEdit.aspx?key=" + id);
			}
		}

		if (e.CommandName == "PostToAudit") {
			if (!CatPostToAudit(model))
				JavaSrcipt("$.alert('只有编辑中的申请可以提交审核！');");
			else {
				model.IsEnabled += 1;
				_db.Entry(model).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();
				BindData();
			}
		}
	}

	private bool CanDelete(cms_adv_info model)
	{
		if (model.IsEnabled == (int)AdvStatus.待审核)
			return false;

		if (model.IsEnabled == (int)AdvStatus.已审核)
			return false;
		return true;
	}

	private bool CanEdit(cms_adv_info model)
	{
		if (model.IsEnabled == (int)AdvStatus.编辑中 || model.IsEnabled == (int)AdvStatus.未通过)
			return true;
		return false;
	}

	private bool CatPostToAudit(cms_adv_info model)
	{
		if (model.IsEnabled == (int)AdvStatus.编辑中)
			return true;
		return false;
	}
}
