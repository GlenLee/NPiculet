using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_DictGroupList : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly DictBus _bus = new DictBus();

	private void BindData() {
		var predicate = LinQKit.CreateWhere<bas_dict_group>(a => a.IsDel == 0);

		string key = this.txtKeywords.Text.FormatSqlParm();
		if (!string.IsNullOrEmpty(key)) {
			predicate = predicate.And(a => (a.Name.Contains(key) || a.Code.Contains(key)));
		}

		this.list.DataSource = _bus.GetDictGroupList(predicate);
		this.list.DataBind();

		BindKit.BindOnClientClick(this.list, "Delete", "return confirm('确定要删除吗？');");
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				int id = ConvertKit.ConvertValue(this.list.DataKeys[e.RowIndex]["Id"], 0);
				var group = _bus.GetDictGroup(a => a.Id == id);
				if (group != null) {
					group.IsDel = 1;
					_bus.SaveGroup(group);
				}

			}
			BindData();
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}
}