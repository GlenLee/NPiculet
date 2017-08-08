using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
		SysRoleInfoBus bus = new SysRoleInfoBus();

		string whereString = "IsDel=0 and IsEnabled=1";

		int count = bus.RecordCount(whereString);
		this.NPager1.RecordCount = count;

		DataTable dt = bus.Query(this.NPager1.CurrentPage, this.NPager1.PageSize, whereString, "CreateDate DESC");

		this.list.DataSource = dt;
		this.list.DataBind();
	}
}