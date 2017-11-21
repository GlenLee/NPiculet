<%@ Page Title="外链管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="LinksList.aspx.cs" Inherits="modules.info.LinksList" %>
<%@ Register TagPrefix="uc" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="LinksEdit.aspx"><i class="fa fa-plus"></i>新增</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" CssClass="table table-primary">
		<Columns>
			<asp:BoundField DataField="TypeName" HeaderText="类型" />
			<asp:BoundField DataField="Description" HeaderText="描述" />
			<asp:BoundField DataField="Url" HeaderText="链接" />
			<asp:BoundField DataField="Sort" HeaderText="排序" />
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><a href="LinksEdit.aspx?key=<%# Eval("Id") %>">编辑</a></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="删除">
				<HeaderStyle Width="50px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<uc:NPager ID="nPager" runat="server" PageSize="15" OnPageClick="nPager_OnPageClick"/>
</asp:Content>
