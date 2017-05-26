<%@ Page Title="资讯列表" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="modules_news_NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="NewsEdit.aspx?code=<%= this.GroupCode %>">新增</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" AllowPaging="True" CssClass="sui-table table-primary" PageSize="15">
		<Columns>
			<asp:BoundField DataField="Title" HeaderText="标题" />
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="发布时间" >
				<HeaderStyle Width="120px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><a href="NewsEdit.aspx?id=<%# Eval("Id") %>&code=<%= GroupCode %>">编辑</a></ItemTemplate>
			</asp:TemplateField>
			<asp:CommandField ShowDeleteButton="True" HeaderText="删除" >
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<PagerSettings FirstPageText="第一页" LastPageText="最后页" Mode="NumericFirstLast" NextPageText="上一页" PreviousPageText="下一页" />
	</asp:GridView>
</asp:Content>

