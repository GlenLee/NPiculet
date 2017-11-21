using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_cms_MsgBoardList : AdminPage
{
	private readonly CmsMsgBoardBus _mbus = new CmsMsgBoardBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindGroup();
			BindData();
		}
	}

	private void BindGroup()
	{
		var data = _mbus.GetGroupList();
		BindKit.BindToListControl(this.ddlGroup, data, "Name", "Id", true);
	}

	private void BindData()
	{
		int count;
		var data = _mbus.GetRecordList(out count, this.nPager.CurrentPage, this.nPager.PageSize);

		this.nPager.RecordCount = count;

		list.DataSource = data;
		list.DataBind();
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e) {
		int dataId = GridViewKit.GetDataKey<int>(this.list, e.RowIndex, "Id");
		_mbus.DeleteRecord(dataId);
		BindData();
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}

	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e)
	{
		BindData();
	}

	protected string GetGroupName()
	{
		string code = Convert.ToString(Eval("GroupCode"));
		var group = _mbus.GetGroup(a => a.Code == code);
		return group == null ? "" : group.Name;
	}

	protected void list_OnRowCommand(object sender, GridViewCommandEventArgs e) {
		switch (e.CommandName) {
			case "Check":
				int dataId = ConvertKit.ConvertValue(e.CommandArgument, 0);
				using (var db = new NPiculetEntities()) {
					db.cms_msgboard_record.Where(a => a.Id == dataId).UpdateFromQuery(a => new cms_msgboard_record() { Status = 1 });
				}
				DataBind();
				break;
		}
	}
}
