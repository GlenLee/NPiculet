<%@ Page Title="" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="AdvList.aspx.cs" Inherits="system_Modules_AdvList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="admin-menu">
		<a href="AdvEdit.aspx">新增</a>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" AllowPaging="True" CssClass="admin-list-table" PageSize="15">
		<Columns>
			<asp:BoundField DataField="Type" HeaderText="类型" >
				<HeaderStyle Width="80px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="Description" HeaderText="描述" />
			<asp:BoundField DataField="Url" HeaderText="链接" />
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><a href="AdvEdit.aspx?key=<%# Eval("Id") %>">编辑</a></ItemTemplate>
			</asp:TemplateField>
			<asp:CommandField ShowDeleteButton="True" HeaderText="删除" >
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<PagerSettings FirstPageText="第一页" LastPageText="最后页" Mode="NumericFirstLast" NextPageText="上一页" PreviousPageText="下一页" />
	</asp:GridView>
</asp:Content>
