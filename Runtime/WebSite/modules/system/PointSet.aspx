<%@ Page Title="积分管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="PointSet.aspx.cs" Inherits="modules_system_PointSet" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton runat="server" ID="btnSave"><i class="sui-icon icon-tb-edit"></i>修改</asp:LinkButton></li>
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
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="sui-table table-primary">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
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
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="创建时间">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="积分">
				<HeaderStyle Width="140"></HeaderStyle>
				<ItemTemplate>
					<asp:TextBox runat="server" ID="point"></asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>
