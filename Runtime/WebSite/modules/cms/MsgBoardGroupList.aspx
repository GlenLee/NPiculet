<%@ Page Title="留言板分组管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MsgBoardGroupList.aspx.cs" Inherits="modules_cms_MsgBoardGroupList" %>
<%@ Register TagPrefix="asp" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="MsgBoardGroupEdit.aspx"><i class="fa fa-plus"></i>新增</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" CssClass="table table-primary">
		<Columns>
			<asp:BoundField DataField="Name" HeaderText="名称" />
			<asp:BoundField DataField="Code" HeaderText="编码" />
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="60px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><a href="MsgBoardGroupEdit.aspx?id=<%# Eval("Id") %>">编辑</a></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="删除">
				<HeaderStyle Width="60px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<asp:NPager runat="server" ID="nPager" PageSize="10" OnPageClick="nPager_OnPageClick" />
</asp:Content>
