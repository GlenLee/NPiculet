using System;
using System.Web.UI;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;

public partial class modules_common_RoleDialog : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			this.NPager1.PageSize = 15;

			BindRoleList();
		}
		//分页事件
		this.NPager1.PageClick += (o, args) => {
			BindRoleList();
		};
	}

	private void BindRoleList()
	{
		RoleBus bus = new RoleBus();

		int count;
		var data = bus.GetRoleList(out count, this.NPager1.CurrentPage, this.NPager1.PageSize, a => a.IsDel == 0 && a.IsEnabled == 1);

		this.NPager1.RecordCount = count;

		this.list.DataSource = data;
		this.list.DataBind();
	}
}