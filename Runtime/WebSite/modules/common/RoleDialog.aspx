<%@ Page Title="选择角色" Language="C#" MasterPageFile="~/modules/common/Dialog.master" AutoEventWireup="true" CodeFile="RoleDialog.aspx.cs" Inherits="modules_common_RoleDialog" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

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
	<%--<asp:LinkButton runat="server" ID="btnOk" onclick="btnOk_Click">确定</asp:LinkButton>--%>
	<a href="#" onclick="cancel();">取消</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

	<asp:GridView runat="server" ID="list" Width="100%" AutoGenerateColumns="False">
		<Columns>
			<asp:TemplateField HeaderText="角色名称">
				<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<a href="#" onclick="ok('<%# Eval("Id") %>');"><%# Eval("RoleName") %></a>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="说明" DataField="Comment">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
			</asp:BoundField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>
