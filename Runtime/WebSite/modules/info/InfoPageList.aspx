<%@ Page Title="信息列表" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="InfoPageList.aspx.cs" Inherits="modules_info_InfoPageList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="InfoContentEdit.aspx?type=List&code=<%= GroupCode %>"><i class="sui-icon icon-tb-add"></i>新增信息</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
		<Columns>
			<asp:BoundField DataField="Title" HeaderText="标题" />
			<asp:BoundField DataField="CreateDate" HeaderText="发布时间">
				<HeaderStyle Width="150px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="60"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<a href="InfoContentEdit.aspx?type=List&key=<%# Eval("Id") %>&code=<%= GroupCode %>">编辑</a>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="删除">
				<HeaderStyle Width="60"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>

