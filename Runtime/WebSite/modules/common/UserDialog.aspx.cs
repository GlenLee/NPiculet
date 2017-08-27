using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_common_UserDialog : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			this.NPager1.PageSize = 20;

			BindOrgTree();
			BindUserList();
		}

		this.NPager1.PageClick += (o, args) => {
			BindUserList();
		};

		string target = WebParmKit.GetFormValue("__EVENTTARGET", "");

		EventSelectUser(target);
		EventDeleteSelected(target);
	}

	private List<sys_org_info> _treeOrgs = null;

	private void BindOrgTree()
	{
		OrgBus bus = new OrgBus();
		var data = bus.GetOrgList(a => a.Level<=1 && a.IsDel == 0);
		if (data != null && data.Count > 0) {
			_treeOrgs = data;
		}
		BuildTree(null, 0);
	}

	private void BuildTree(TreeNodeCollection nodes, int parentId) {
		var query = from a in _treeOrgs where a.ParentId == parentId select a;
		foreach (var o in query) {
			if (nodes == null) nodes = this.tree.Nodes;
			TreeNode tn = new TreeNode(o.OrgName, o.Id.ToString());
			nodes.Add(tn);
			BuildTree(tn.ChildNodes, o.Id);
		}
	}

	/// <summary>
	/// 绑定可选用户列表
	/// </summary>
	private void BindUserList(int orgId = 0)
	{
		string whereString = "IsDel=0";
		if (orgId > 0) {
			whereString += " and OrgId=" + orgId;
		}

		UserBus ubus = new UserBus();
		int count;
		var data = ubus.GetUserList(out count, this.NPager1.CurrentPage, this.NPager1.PageSize, whereString);

		this.NPager1.RecordCount = count;

		this.list.DataSource = data;
		this.list.DataBind();
	}

	/// <summary>
	/// 绑定已选用户列表
	/// </summary>
	private void BindSelectedList()
	{
		this.selectedList.DataSource = this._selectedUserList;
		this.selectedList.DataBind();
	}

	private List<sys_user_info> _selectedUserList
	{
		get
		{
			var data = ViewState["__SelectedUserList__"] as List<sys_user_info>;
			if (data == null) data = new List<sys_user_info>();
			return data;
		}
		set { ViewState["__SelectedUserList"] = value; }
	}

	private void EventDeleteSelected(string target)
	{
		if (target == "BtnDeleteSelected") {
			//Stopwatch sw = new Stopwatch();
			//sw.Start();
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
			//sw.Stop();
			//Logger.Debug("BtnDeleteSelected:" + sw.Elapsed.TotalMilliseconds + "ms");
		}
	}

	private void EventSelectUser(string target)
	{
		if (target == "BtnSelectUser") {
			//Stopwatch sw = new Stopwatch();
			//sw.Start();
			int arg = WebParmKit.GetFormValue("__EVENTARGUMENT", 0);
			if (arg > 0) {
				var user = new UserBus().GetUserInfo(arg);

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
			//sw.Stop();
			//Logger.Debug("BtnSelectUser:" + sw.Elapsed.TotalMilliseconds + "ms");
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
			this.JavaSrcipt("ok('" + result + "');", this.UpdatePanel1);
		} else {
			this.AlertBeauty("您还没有选中任何数据！", this.UpdatePanel1);
		}
	}

	protected void tree_SelectedNodeChanged(object sender, EventArgs e) {
		TreeNode tn = this.tree.SelectedNode;
		if (tn.Depth == 0) {
			BindUserList();
		} else {
			var val = ConvertKit.ConvertValue(tn.Value, 0);
			BindUserList(val);
		}
	}
}