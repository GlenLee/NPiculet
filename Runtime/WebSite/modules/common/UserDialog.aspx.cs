using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Log;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_common_UserDialog : NormalPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			this.NPager1.PageSize = 20;

			BindOrgTree();
			BindUser();
		}

		this.NPager1.PageClick += (o, args) => {
			BindUser();
		};

		string target = WebParmKit.GetFormValue("__EVENTTARGET", "");

		EventSelectUser(target);
		EventDeleteSelected(target);
	}

	private DataView treedv = null;

	private void BindOrgTree()
	{
		SysOrgInfoBus bus = new SysOrgInfoBus();
		DataTable dt = bus.Query();
		if (dt != null) {
			treedv = dt.DefaultView;
		}
		BuildTree(null, 0);
	}

	private void BuildTree(TreeNodeCollection nodes, int parentId)
	{
		treedv.RowFilter = "ParentId=" + parentId;
		foreach (DataRowView dr in treedv) {
			if (nodes == null) nodes = this.tree.Nodes;
			TreeNode tn = new TreeNode(dr["OrgName"].ToString(), dr["Id"].ToString());
			nodes.Add(tn);
			BuildTree(tn.ChildNodes, (int)dr["Id"]);
		}
	}

	private void BindUser()
	{
		string whereString = "IsDel=0";

		SysUserInfoBus ubus = new SysUserInfoBus();
		var data = ubus.GetUserList(this.NPager1.CurrentPage, this.NPager1.PageSize, whereString);

		this.NPager1.RecordCount = ubus.GetUserCount(whereString);

		this.list.DataSource = data;
		this.list.DataBind();
	}

	private void BindSelectedList()
	{
		this.selectedList.DataSource = this._selectedUserList;
		this.selectedList.DataBind();
	}

	private List<SysUserInfo> _selectedUserList
	{
		get
		{
			var data = ViewState["__SelectedUserList__"] as List<SysUserInfo>;
			if (data == null) data = new List<SysUserInfo>();
			return data;
		}
		set { ViewState["__SelectedUserList__"] = value; }
	}

	private void EventDeleteSelected(string target)
	{
		if (target == "BtnDeleteSelected") {
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int arg = WebParmKit.GetFormValue("__EVENTARGUMENT", 0);
			if (arg > 0) {
				var l = this._selectedUserList;
				var user = (from a in l where a.Id == arg select a).FirstOrDefault();
				if (user != null) {
					l.Remove(user);
					this._selectedUserList = l;

					BindSelectedList();
				}
			}
			sw.Stop();
			Logger.Debug("BtnDeleteSelected:" + sw.Elapsed.TotalMilliseconds + "ms");
		}
	}

	private void EventSelectUser(string target)
	{
		if (target == "BtnSelectUser") {
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int arg = WebParmKit.GetFormValue("__EVENTARGUMENT", 0);
			if (arg > 0) {
				var user = new SysUserInfoBus().QueryModel("Id=" + arg);

				var l = _selectedUserList;

				if (user != null) {
					bool contain = (from a in l where a.Id == user.Id select a).Count() > 0;
					if (!contain) {
						l.Add(user);

						_selectedUserList = l;
						BindSelectedList();
					}
				}
			}
			sw.Stop();
			Logger.Debug("BtnSelectUser:" + sw.Elapsed.TotalMilliseconds + "ms");
		}
	}

	protected void btnOk_Click(object sender, EventArgs e)
	{
		var l = this._selectedUserList;
		if (l.Count > 0) {
			string result = "";
			foreach (var user in l) {
				if (!string.IsNullOrEmpty(result)) result += ",";
				result += user.Id;
			}
			this.JavaSrciptAjax(this.UpdatePanel1, "ok('" + result + "');");
		} else {
			this.AlertAjax(this.UpdatePanel1, "您还没有选中任何数据！");
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		var val = this.tree.SelectedValue;
		this.AlertAjax(this.btnOk, val);
		//var data = _bus.GetMenuItem(Convert.ToInt32(val));
		//if (data != null) {
		//    BindKit.BindModelToContainer(this.editor, data);
		//    this.CurName.Text = data.Name;
		//    SetControlStatus();
		//}
	}
}