<%@ Page Title="选择组织机构" Language="C#" MasterPageFile="~/modules/common/Dialog.master" AutoEventWireup="true" CodeFile="OrgDialog.aspx.cs" Inherits="modules_common_OrgDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<script type="text/javascript">
		function ok(val) {
			window.returnValue = val;
			window.close();
		}
		function cancel() {
			window.close();
		}
	</script>
	<base target="_self"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton runat="server" ID="btnOk" onclick="btnOk_Click">确定</asp:LinkButton>
	<a href="#" onclick="cancel();">取消</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

	<asp:TreeView runat="server" ID="tree"></asp:TreeView>

</asp:Content>
