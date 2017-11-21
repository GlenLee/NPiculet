using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_cms_MsgBoardGroupList : AdminPage
{
	private readonly CmsMsgBoardBus _mbus = new CmsMsgBoardBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private void BindData()
	{
		int count;
		var data = _mbus.GetGroupList(out count, this.nPager.CurrentPage, this.nPager.PageSize);

		this.nPager.RecordCount = count;

		list.DataSource = data;
		list.DataBind();
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex <= -1)
			return;
		if (list.DataKeys.Count > e.RowIndex) {
			var dataKey = list.DataKeys[e.RowIndex];
			if (dataKey != null) {
				int dataId = ConvertKit.ConvertValue(dataKey["Id"], 0);
				_mbus.DeleteGroup(dataId);
			}
		}
		BindData();
	}

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e)
	{
		BindData();
	}
}
