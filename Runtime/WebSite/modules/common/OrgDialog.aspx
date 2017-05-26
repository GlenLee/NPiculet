<%@ Page Title="选择组织机构" Language="C#" MasterPageFile="~/modules/common/Dialog.master" AutoEventWireup="true" CodeFile="OrgDialog.aspx.cs" Inherits="modules_common_OrgDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<script type="text/javascript">
		function ok(val) {
			var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
			parent.result = val;
			parent.layer.close(index);
		}
		function cancel() {
			var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
			parent.layer.close(index);
		}
	</script>
	<base target="_self"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton runat="server" ID="btnOk" onclick="btnOk_Click">确定</asp:LinkButton>
	&nbsp;
	<a href="#" onclick="cancel();">取消</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

	<asp:TreeView runat="server" ID="tree" ImageSet="Arrows">
		<HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
		<NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="2px" />
		<ParentNodeStyle Font-Bold="False" />
		<SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
	</asp:TreeView>

</asp:Content>
