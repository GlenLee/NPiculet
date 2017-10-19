<%@ Page Title="角色列表" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="RoleList.aspx.cs" Inherits="modules_system_RoleList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="RoleEdit.aspx"><i class="fa fa-plus"></i>新增</a></li>
			<%--<asp:LinkButton runat="server" ID="btnDel" Text="删除"></asp:LinkButton>--%>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
	<ul class="searchbar-wrap">
		<li>
			<asp:TextBox ID="txtKeywords" runat="server" placeholder="搜索名称"></asp:TextBox>
			<asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/>
		</li>
	</ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="table table-primary">
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="RoleName" HeaderText="名称" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Comment" HeaderText="备注" />
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="140px"></HeaderStyle>
				<ItemTemplate>
					<a href="AuthSet.aspx?key=<%# Eval("Id") %>&m=Role&p=RoleList.aspx">权限</a> |
					<a href="RoleEdit.aspx?key=<%# Eval("Id") %>">编辑</a> |
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
					<input type="hidden" name="dataId" value="<%# Eval("Id") %>"/>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="nPager" runat="server" PageSize="15" OnPageClick="nPager_OnPageClick" />
</asp:Content>

