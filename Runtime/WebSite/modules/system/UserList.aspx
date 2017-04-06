<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="system_Admin_UserList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<a href="UserEdit.aspx">新增</a>
	<asp:LinkButton runat="server" ID="btnDel" Text="删除"></asp:LinkButton>
	<asp:LinkButton runat="server" ID="btnResetPass" Text="重设密码"></asp:LinkButton>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
	<div class="searchbar-wrap">
		<table cellpadding="0" cellspacing="0" class="admin-search-table">
			<tr>
				<td>权限</td>
				<td>
					<asp:DropDownList runat="server" ID="dropFlag">
						<asp:ListItem Value="0">全部</asp:ListItem>
						<asp:ListItem Value="1">普通用户</asp:ListItem>
						<asp:ListItem Value="2">管理员</asp:ListItem>
					</asp:DropDownList>
				</td>
				<td></td>
				<td>
					<asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox>
					<asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="admin-list-table">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="Account" HeaderText="帐号" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Password" HeaderText="密码" Visible="False">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Name" HeaderText="姓名" />
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="创建时间">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="100"></HeaderStyle>
				<ItemTemplate>
					<a href="AuthSet.aspx?key=<%# Eval("Id") %>&m=User&p=UserList.aspx" CssClass="btn btn-default" >授权</a> |
					<a href="UserEdit.aspx?key=<%# Eval("Id") %>" CssClass="btn btn-default" >编辑</a> |
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>
