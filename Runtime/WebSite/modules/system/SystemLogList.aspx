<%@ Page Title="系统日志" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="SystemLogList.aspx.cs" Inherits="modules_system_SystemLogList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
	<ul class="searchbar-wrap">
		<li><asp:DropDownList runat="server" ID="ddlActionType" AutoPostBack="True" OnSelectedIndexChanged="ddlActionType_OnSelectedIndexChanged"></asp:DropDownList></li>
	</ul>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	
	<asp:GridView runat="server" ID="logs" Width="100%" AutoGenerateColumns="False" CssClass="sui-table table-primary">
		<Columns>
			<asp:TemplateField HeaderText="序号">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate><%# Container.DisplayIndex + 1 %></ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="ActionType" HeaderText="类型">
				<HeaderStyle Width="120px" />
			</asp:BoundField>
			<asp:BoundField DataField="ActionAccount" HeaderText="帐号">
				<HeaderStyle Width="120px" />
			</asp:BoundField>
			<asp:BoundField DataField="TargetCode" HeaderText="目标码">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="TargetId" HeaderText="目标值">
				<HeaderStyle Width="100px" />
			</asp:BoundField>
			<asp:BoundField DataField="Comment" HeaderText="说明"></asp:BoundField>
			<asp:BoundField DataField="Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="记录时间">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="nPager" runat="server" PageSize="15" OnPageClick="nPager_OnPageClick" />

</asp:Content>

