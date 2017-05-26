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
	/// ���ؼ������࣬�������ؼ��е�ͨ������
	/// </summary>
	public static class TreeViewKit
	{
		/// <summary>
		/// �������ؼ���
		/// </summary>
		/// <param name="tree">���ؼ�</param>
		/// <param name="node">��ǰ�ڵ�</param>
		/// <param name="dv">������ͼ</param>
		/// <param name="text">�ڵ��ı��ֶ�</param>
		/// <param name="val">�ڵ�ֵ�ֶ�</param>
		/// <param name="filterString">���˹���</param>
		/// <param name="parentVal">���ڵ�ֵ</param>
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
		/// �������ؼ���
		/// </summary>
		/// <param name="tree">���ؼ�</param>
		/// <param name="node">��ǰ�ڵ�</param>
		/// <param name="dt">���ݱ�</param>
		/// <param name="text">�ڵ��ı��ֶ�</param>
		/// <param name="val">�ڵ�ֵ�ֶ�</param>
		/// <param name="filterString">���˹���</param>
		/// <param name="parentVal">���ڵ�ֵ</param>
		public static void BuildTree(TreeView tree, TreeNode node, DataTable dt, string text, string val, string filterString, string parentVal)
		{
			BuildTree(tree, node, dt.DefaultView, text, val, filterString, parentVal);
		}

		/// <summary>
		/// չ���ڵ㡣
		/// </summary>
		/// <param name="tree">���ؼ�</param>
		/// <param name="valuePath">ֵ·��</param>
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
		/// ��ȡ���ؼ���ѡ�еĽڵ㣬�����ڵ���䵽����� results �б��С�
		/// </summary>
		/// <param name="nodes">�ڵ㼯</param>
		/// <param name="results">����б�</param>
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
		/// ��ȡ���ؼ���ѡ�еĽڵ㣬�����ڵ���䵽����� results �б��С�
		/// </summary>
		/// <param name="tree">���ؼ�</param>
		/// <param name="results">����б�</param>
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
            //���븸�ڵ�
            DataView dvTree = new DataView(dtTreeView);

            //����ParentID,�õ���ǰ�������ӽڵ�
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
                AddTreeNode(tv, Node, dtTreeView, fldValue, fldText, fldParent, fldToolTip, dynNavigator, target, navigatePage, navigateKey, nodePICURL);    //�ٴεݹ�
            }
        }

        private static void AddTreeNode(TreeView tv, TreeNode pNode, DataTable dtTreeView, string fldValue, string fldText, string fldParent, string fldToolTip, bool dynNavigator, string target, string navigatePage, string navigateKey, string nodePICURL)
        {
            if (pNode == null)
                return;
            DataView dvTree = new DataView(dtTreeView);

            //����ParentID,�õ���ǰ�������ӽڵ�
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
                pNode.ChildNodes.Add(Node);//��ӵ�ǰ�ڵ���ӽڵ�
                //Node.Expanded = true;
                if (!tv.ShowCheckBoxes.ToString().ToLower().Equals("none"))
                    Node.SelectAction = TreeNodeSelectAction.None;
                else
                    Node.SelectAction = TreeNodeSelectAction.SelectExpand;
                AddTreeNode(tv, Node, dtTreeView, fldValue, fldText, fldParent, fldToolTip, dynNavigator, target, navigatePage, navigateKey, nodePICURL);    //�ٴεݹ�
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