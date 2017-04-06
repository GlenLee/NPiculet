using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.WebControls;

public partial class modules_common_OrgDialog : NormalPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack) {
			this.tree.ShowCheckBoxes = TreeNodeTypes.Leaf;

			BindOrgTree();
	    }
    }

	private DataView dv = null;

	private void BindOrgTree()
	{
		SysOrgInfoBus bus = new SysOrgInfoBus();
		DataTable dt = bus.Query();
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