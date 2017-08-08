using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_common_OrgDialog : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack) {
			BindOrgTree();
		}
		string mode = WebParmKit.GetQuery("mode", "");
		if (mode == "single") {
			this.tree.ShowCheckBoxes = TreeNodeTypes.None;
			this.tree.SelectedNodeChanged += Tree_SelectedNodeChanged;
		} else {
			//this.tree.ShowCheckBoxes = TreeNodeTypes.Leaf;
			this.tree.ShowCheckBoxes = TreeNodeTypes.All;
		}
	}

	private void Tree_SelectedNodeChanged(object sender, EventArgs e)
	{
		var node = this.tree.SelectedNode;
		this.JavaSrcipt("ok({ id:" + node.Value + ", name:'" + node.Text + "' });");
	}

	private DataView dv = null;

	private void BindOrgTree()
	{
		SysOrgInfoBus bus = new SysOrgInfoBus();
		DataTable dt = bus.GetOrgTreeData();
		if (dt != null) {
			dv = dt.DefaultView;
		}
		BuildTree(null, 0);
	}

	private void BuildTree(TreeNodeCollection nodes, int parentId)
	{
		dv.RowFilter = "ParentId=" + parentId;
		foreach (DataRowView dr in dv) {
			if (nodes == null) nodes = this.tree.Nodes;
			TreeNode tn = new TreeNode(dr["OrgName"].ToString(), dr["Id"].ToString());
			nodes.Add(tn);
			BuildTree(tn.ChildNodes, (int)dr["Id"]);
		}
	}

	string result = "";

	protected void btnOk_Click(object sender, EventArgs e)
	{
		GetSelectedNodes(this.tree.Nodes);
		if (!string.IsNullOrEmpty(result)) {
			this.JavaSrcipt("ok('" + result + "');");
		} else {
			this.Alert("您还没有选中任何数据！");
		}
	}

	private void GetSelectedNodes(TreeNodeCollection nodes)
	{
		foreach (TreeNode node in nodes) {
			if (node.Checked) {
				if (!string.IsNullOrEmpty(result)) result += ",";
				result += node.Value;
			}
			GetSelectedNodes(node.ChildNodes);
		}
	}
}