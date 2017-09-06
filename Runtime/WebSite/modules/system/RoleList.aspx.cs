using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_system_RoleList : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly RoleBus _bus = new RoleBus();

	public Expression<Func<T, bool>> CreatePredicate<T>(Expression<Func<T, bool>> predicate)
	{
		return predicate;
	}

	public Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> p1, Expression<Func<T, bool>> p2)
	{
		return Expression.Lambda<Func<T, bool>>(Expression.And(p1, p2), p1.Parameters);
	}

	private void BindData()
	{
		Expression<Func<sys_role_info, bool>> predicate = a => a.IsDel == 0;

		string key = this.txtKeywords.Text.FormatSqlParm();
		if (!string.IsNullOrEmpty(key)) {
			predicate = And(predicate, a => a.RoleName.Contains(key));
		}

		int count;

		this.list.DataSource = _bus.GetRoleList(out count, this.nPager.CurrentPage, this.nPager.PageSize, predicate);
		this.list.DataBind();

		this.nPager.RecordCount = count;
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				string id = this.list.DataKeys[e.RowIndex]["Id"].ToString();
				_bus.Delete(ConvertKit.ConvertValue(id, 0));
			}
			BindData();
		}
	}

	protected string GetStatusString(string enabled)
	{
		return enabled == "1" ? "启用" : "停用";
	}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
	    BindData();
    }

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
		BindData();
	}
}