using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;


public partial class EntHireList : MemberPage
{
	readonly NPiculetEntities _db = new NPiculetEntities();
	protected void Page_Load(object sender, EventArgs e)
	{
		BindData();
	}

	private void BindData()
	{
		if (CurrentUserInfo == null)
			return;

		var list = from row in _db.cms_content_page.Where(row => row.Author == CurrentUserInfo.Account && row.GroupCode == "EntHire").ToList()
				   select new
				   {
					   row.Id,
					   row.Title,
					   row.Content,
					   row.CreateDate,
					   Status = HireStatusHelper.GetStatus(row.IsEnabled)
				   };

		EntHireListView.DataSource = list;
		EntHireListView.DataBind();
	}

	protected void EntHireList_ItemCommand(object source, RepeaterCommandEventArgs e)
	{
		int id = int.Parse(e.CommandArgument.ToString());
		var model = _db.cms_content_page.SingleOrDefault(x => x.Id == id);

		if (model == null)
			return;

		if (e.CommandName == "Delete")
		{
			_db.cms_content_page.Remove(model);
			_db.SaveChanges();
			BindData();
		}

		if (e.CommandName == "Edit")
		{
			Response.Redirect("EntHireEdit.aspx?key=" + id + "&code=EntHire");
		}
	}
}

