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
	<ul class="searchbar-wrap">
		<li><asp:DropDownList runat="server" ID="ddlDictGroup"/></li>
		<li>关键字：<asp:TextBox ID="txtKeywords" runat="server" placeholder="搜索名称或内容"></asp:TextBox></li>
		<li><asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/></li>
	</ul>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Id,Title"
		OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
		<Columns>
			<asp:BoundField DataField="Title" HeaderText="标题" />
			<asp:TemplateField HeaderText="发布">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><%# GetIsEnabledString() %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="置顶">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><%# GetOrderByString() %></ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="发布时间">
				<HeaderStyle Width="120px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="50"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<a href="InfoContentEdit.aspx?type=List&id=<%# Eval("Id") %>&code=<%= GroupCode %>">编辑</a>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="删除">
				<HeaderStyle Width="50"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" PageSize="15" />
</asp:Content>

