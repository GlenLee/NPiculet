<%@ Page Title="留言板管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MsgBoardList.aspx.cs" Inherits="modules_cms_MsgBoardList" %>
<%@ Register TagPrefix="asp" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="MsgBoardEdit.aspx"><i class="fa fa-plus"></i>新增</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" runat="Server">
	<ul class="searchbar-wrap">
		<li><asp:DropDownList runat="server" ID="ddlGroup"/></li>
		<%--<li>关键字：<asp:TextBox ID="txtKeywords" runat="server" placeholder="搜索名称或内容"></asp:TextBox></li>--%>
		<li><asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/></li>
	</ul>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" CssClass="table table-primary">
		<Columns>
			<asp:TemplateField HeaderText="留言板">
				<HeaderStyle Width="140px" />
				<ItemTemplate>
					<%# GetGroupName() %>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Author" HeaderText="作者" />
			<asp:BoundField DataField="Content" HeaderText="内容" />
			<asp:BoundField DataField="Fields" HeaderText="字段" />
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="60px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><a href="MsgBoardEdit.aspx?id=<%# Eval("Id") %>">编辑</a></ItemTemplate>
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
	<asp:NPager runat="server" ID="nPager" PageSize="15" OnPageClick="nPager_OnPageClick" />
</asp:Content>
