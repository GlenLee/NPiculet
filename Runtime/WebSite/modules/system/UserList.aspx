<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="system_Admin_UserList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="UserEdit.aspx"><i class="sui-icon icon-tb-add"></i>新增</a></li>
			<%--<li><asp:LinkButton runat="server" ID="btnDel"><i class="sui-icon icon-tb-delete"></i>删除</asp:LinkButton></li>
			<li><asp:LinkButton runat="server" ID="btnResetPass"><i class="sui-icon icon-tb-edit"></i>重设密码</asp:LinkButton></li>--%>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
	<ul class="searchbar-wrap">
		<li>
			<table class="admin-search-table">
				<tr>
					<td>关键字</td>
					<td>
						<asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox>
						<asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="sui-icon icon-tb-search"></i>搜索</asp:LinkButton>
					</td>
				</tr>
			</table>
		</li>
	</ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="Type" HeaderText="类型">
				<HeaderStyle Width="60px" />
			</asp:BoundField>
			<asp:BoundField DataField="Account" HeaderText="帐号">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Password" HeaderText="密码" Visible="False">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Name" HeaderText="姓名" />
			<asp:BoundField DataField="PointCurrent" HeaderText="积分">
				<HeaderStyle Width="60px" />
			</asp:BoundField>
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="创建时间">
				<HeaderStyle Width="120px" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="50px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="140"></HeaderStyle>
				<ItemTemplate>
					<a href="AuthSet.aspx?key=<%# Eval("Id") %>&m=User&p=UserList.aspx" CssClass="btn btn-default" >授权</a> |
					<a href="UserEdit.aspx?key=<%# Eval("Id") %>" CssClass="btn btn-default" >编辑</a> |
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="nPager" runat="server" PageSize="15" OnPageClick="nPager_OnPageClick" />
</asp:Content>
