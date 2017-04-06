<%@ Page Title="信息列表" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="InfoPageList.aspx.cs" Inherits="modules_info_InfoPageList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<a href="InfoContentEdit.aspx?type=List&code=<%= GroupCode %>">新增信息</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="admin-list-table">
		<Columns>
			<asp:BoundField DataField="Title" HeaderText="标题" />
			<asp:BoundField DataField="CreateDate" HeaderText="发布时间">
				<HeaderStyle Width="150px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="100"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<a href="InfoContentEdit.aspx?type=List&key=<%# Eval("Id") %>&code=<%= GroupCode %>">编辑</a> |
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>

