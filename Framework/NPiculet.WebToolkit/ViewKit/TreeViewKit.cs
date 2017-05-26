/*
Name: TreeViewKit Class
Date: 2010-6-21
Author: iSLeeCN
Description: TreeViewKit Class.
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 树控件处理类，处理树控件中的通用事务。
	/// </summary>
	public static class TreeViewKit
	{
		/// <summary>
		/// 建立树控件。
		/// </summary>
		/// <param name="tree">树控件</param>
		/// <param name="node">当前节点</param>
		/// <param name="dv">数据视图</param>
		/// <param name="text">节点文本字段</param>
		/// <param name="val">节点值字段</param>
		/// <param name="filterString">过滤规则</param>
		/// <param name="parentVal">父节点值</param>
		public static void BuildTree(TreeView tree, TreeNode node, DataView dv, string text, string val, string filterString, string parentVal)
		{
			if (node == null) {
				dv.RowFilter = string.Format(filterString, parentVal);
				foreach (DataRowView dr in dv) {
					TreeNode tn = new TreeNode(dr[text].ToString(), dr[val].ToString());
					tree.Nodes.Add(tn);
					BuildTree(tree, tn, dv, text, val, filterString, dr[val].ToString());
				}
			} else {
				dv.RowFilter = string.Format(filterString, parentVal);
				foreach (DataRowView dr in dv) {
					TreeNode tn = new TreeNode(dr[text].ToString(), dr[val].ToString());
					node.ChildNodes.Add(tn);
					BuildTree(tree, tn, dv, text, val, filterString, dr[val].ToString());
				}
			}
		}

		/// <summary>
		/// 建立树控件。
		/// </summary>
		/// <param name="tree">树控件</param>
		/// <param name="node">当前节点</param>
		/// <param name="dt">数据表</param>
		/// <param name="text">节点文本字段</param>
		/// <param name="val">节点值字段</param>
		/// <param name="filterString">过滤规则</param>
		/// <param name="parentVal">父节点值</param>
		public static void BuildTree(TreeView tree, TreeNode node, DataTable dt, string text, string val, string filterString, string parentVal)
		{
			BuildTree(tree, node, dt.DefaultView, text, val, filterString, parentVal);
		}

		/// <summary>
		/// 展开节点。
		/// </summary>
		/// <param name="tree">树控件</param>
		/// <param name="valuePath">值路径</param>
		public static void ExpandNode(TreeView tree, string valuePath)
		{
			string[] vals = valuePath.Split('/');
			for (int i = 0; i < vals.Length; i++) {
				string path = String.Empty;
				for (int j = 0; j <= i; j++) {
					if (path != String.Empty)
						path += "/";
					path += vals[j];
				}
				TreeNode tn = tree.FindNode(path);
				if (tn != null) {
					tn.Expanded = true;
				}
			}
		}

		/// <summary>
		/// 获取树控件中选中的节点，并将节点填充到传入的 results 列表中。
		/// </summary>
		/// <param name="nodes">节点集</param>
		/// <param name="results">结果列表</param>
		public static void GetTreeValues(TreeNodeCollection nodes, List<TreeNode> results)
		{
			foreach (TreeNode node in nodes) {
				if (node.Checked) {
					results.Add(node);
				}
				GetTreeValues(node.ChildNodes, results);
			}
		}

		/// <summary>
		/// 获取树控件中选中的节点，并将节点填充到传入的 results 列表中。
		/// </summary>
		/// <param name="tree">树控件</param>
		/// <param name="results">结果列表</param>
		public static void GetTreeValues(TreeView tree, List<TreeNode> results)
		{
			foreach (TreeNode node in tree.Nodes) {
				if (node.Checked) {
					results.Add(node);
				}
				GetTreeValues(node.ChildNodes, results);
			}
		}

        private static void CreateTreeView(TreeView tv, DataTable dtTreeView, string fldValue, string fldText, string fldParent, string fldToolTip, bool dynNavigator, string target, string navigatePage, string navigateKey, string nodePICURL)
        {
            //加入父节点
            DataView dvTree = new DataView(dtTreeView);

            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = fldParent + "=''";
            if (dvTree.Count == 0)
            {
                return;
            }
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                Node.Text = Row[fldText].ToString();
                Node.Value = Row[fldValue].ToString();
                Node.ToolTip = Row[fldToolTip].ToString();
                if (!string.IsNullOrEmpty(target))
                {
                    Node.Target = target;
                    if (dynNavigator)
                    {
                        Node.NavigateUrl = Row[navigatePage].ToString();
                        if (!string.IsNullOrEmpty(nodePICURL))
                            Node.ImageUrl = Row[nodePICURL].ToString();
                    }
                    else
                        Node.NavigateUrl = navigatePage + "?" + navigateKey + "=" + Node.Value + "&d=" + DateTime.Now.Millisecond.ToString();
                }
                tv.Nodes.Add(Node);
                //Node.Expanded = true;

                if (!tv.ShowCheckBoxes.ToString().ToLower().Equals("none"))
                    Node.SelectAction = TreeNodeSelectAction.None;
                else
                    Node.SelectAction = TreeNodeSelectAction.SelectExpand;
                AddTreeNode(tv, Node, dtTreeView, fldValue, fldText, fldParent, fldToolTip, dynNavigator, target, navigatePage, navigateKey, nodePICURL);    //再次递归
            }
        }

        private static void AddTreeNode(TreeView tv, TreeNode pNode, DataTable dtTreeView, string fldValue, string fldText, string fldParent, string fldToolTip, bool dynNavigator, string target, string navigatePage, string navigateKey, string nodePICURL)
        {
            if (pNode == null)
                return;
            DataView dvTree = new DataView(dtTreeView);

            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = fldParent + "='" + pNode.Value + "'";
            if (dvTree.Count == 0)
                return;

            //if (String.IsNullOrEmpty(Request.QueryString["ShowEnd"]))
            //{
            //    pNode.ShowCheckBox = true;
            //}
            //else
            //{
            //    pNode.ShowCheckBox = !(Request.QueryString["ShowEnd"].ToString() == "false");
            //}

            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                Node.Text = Row[fldText].ToString();
                Node.Value = Row[fldValue].ToString();
                Node.ToolTip = Row[fldToolTip].ToString();
                if (!string.IsNullOrEmpty(target))
                {
                    Node.Target = target;
                    if (dynNavigator)
                    {
                        Node.NavigateUrl = Row[navigatePage].ToString();
                        if (!string.IsNullOrEmpty(nodePICURL))
                            Node.ImageUrl = Row[nodePICURL].ToString();
                    }
                    else
                        Node.NavigateUrl = navigatePage + "?" + navigateKey + "=" + Node.Value + "&d=" + DateTime.Now.Millisecond.ToString();
                }
                pNode.ChildNodes.Add(Node);//添加当前节点的子节点
                //Node.Expanded = true;
                if (!tv.ShowCheckBoxes.ToString().ToLower().Equals("none"))
                    Node.SelectAction = TreeNodeSelectAction.None;
                else
                    Node.SelectAction = TreeNodeSelectAction.SelectExpand;
                AddTreeNode(tv, Node, dtTreeView, fldValue, fldText, fldParent, fldToolTip, dynNavigator, target, navigatePage, navigateKey, nodePICURL);    //再次递归
            }

        }

        public static void InitTreeView(TreeView tv, TreeNode node, ArrayList listValue, ArrayList listText)
        {
            TreeNodeCollection nodes = null;
            if (node == null)
                nodes = tv.Nodes;
            else
                nodes = node.ChildNodes;

            foreach (TreeNode treeNode in nodes)
            {
                if (listValue.Count > 0)
                {
                    if (listValue.Contains(treeNode.Value) || listText.Contains(treeNode.Text))
                    {
                        treeNode.Checked = true;
                    }
                }
                if (treeNode.ChildNodes.Count > 0)
                {
                    InitTreeView(tv, treeNode, listValue, listText);
                }
            }
        }
	}
}