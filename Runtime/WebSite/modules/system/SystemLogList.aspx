<%@ Page Title="系统日志" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="SystemLogList.aspx.cs" Inherits="modules_system_SystemLogList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
	<div class="searchbar-wrap">
		<asp:DropDownList runat="server" ID="ddlActionType" AutoPostBack="True" OnSelectedIndexChanged="ddlActionType_OnSelectedIndexChanged">
			<asp:ListItem Value="">全部</asp:ListItem>
			<asp:ListItem Value="SendVerifyCode">验证码 (SendVerifyCode)</asp:ListItem>
			<asp:ListItem Value="SyncMember">同步会员 (SyncMember)</asp:ListItem>
			<asp:ListItem Value="Login">后台登陆 (Login)</asp:ListItem>
			<asp:ListItem Value="UpPhoneMoney">充值话费 (UpPhoneMoney)</asp:ListItem>
			<asp:ListItem Value="Lotto">抽奖 (Lotto)</asp:ListItem>
		</asp:DropDownList>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	
	<asp:GridView runat="server" ID="logs" Width="100%" AutoGenerateColumns="False" CssClass="admin-list-table">
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
	<cc1:NPager ID="NPager1" runat="server" />

</asp:Content>

