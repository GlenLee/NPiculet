using System;
using System.Web.UI;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.WebControls;

public partial class modules_common_RoleDialog : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindRoleList();
		}
	}

	private void BindRoleList()
	{
		RoleBus bus = new RoleBus();

		int count;
		var data = bus.GetRoleList(out count, this.nPager.CurrentPage, this.nPager.PageSize, a => a.IsDel == 0 && a.IsEnabled == 1);

		this.nPager.RecordCount = count;

		this.list.DataSource = data;
		this.list.DataBind();
	}

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
		BindRoleList();
	}
}