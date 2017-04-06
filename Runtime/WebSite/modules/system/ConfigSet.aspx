<%@ Page Title="系统配置项管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="ConfigSet.aspx.cs" Inherits="system_Admin_ConfigSet" %>
<%@ Register src="~/modules/common/Prompt.ascx" tagname="Prompt" tagprefix="zx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">保存</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
	<zx:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="container" runat="server">
		<table border="0" cellpadding="2" cellspacing="0" class="admin-edit-table">
			<tr>
				<td class="th">平台名称</td>
				<td class="td">
					<asp:TextBox ID="PlatformName" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：管理平台的展示名称</div>
				</td>
			</tr>
			<tr>
				<td class="th">站点名称</td>
				<td class="td">
					<asp:TextBox ID="WebSiteName" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：首页的标题，以及所有页面的前缀</div>
				</td>
			</tr>
			<tr>
				<td class="th">微网站名称</td>
				<td class="td">
					<asp:TextBox ID="WapSiteName" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：微网站的标题</div>
				</td>
			</tr>
			<tr>
				<td class="th">微信AppID</td>
				<td class="td">
					<asp:TextBox ID="WeixinAppID" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：微信的应用ID</div>
				</td>
			</tr>
			<tr>
				<td class="th">微信AppSecret</td>
				<td class="td">
					<asp:TextBox ID="WeixinAppSecret" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：微信的应用密匙</div>
				</td>
			</tr>
			<tr>
				<td class="th">企业名称</td>
				<td class="td">
					<asp:TextBox ID="CompanyName" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：名称会显示在后台及版权申明中</div>
				</td>
			</tr>
			<tr>
				<td class="th">系统域名</td>
				<td class="td">
					http://<asp:TextBox ID="DomainName" runat="server" CssClass="textbox" Width="300px" MaxLength="255"></asp:TextBox>
					<div class="caption">注：系统访问的地址</div>
				</td>
			</tr>
			<tr>
				<td class="th">备案号</td>
				<td class="td">
					<asp:TextBox ID="ICP" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
					<div class="caption">注：域名访问备案号，例如：滇ICP备00000000号</div>
				</td>
			</tr>
			<tr>
				<td class="th">联系电话</td>
				<td class="td">
					<asp:TextBox ID="Tel" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">服务电话</td>
				<td class="td">
					<asp:TextBox ID="ServiceTel" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">邮编</td>
				<td class="td">
					<asp:TextBox ID="PostCode" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">电子邮箱</td>
				<td class="td">
					<asp:TextBox ID="EMail" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">公司地址</td>
				<td class="td">
					<asp:TextBox ID="Address" runat="server" CssClass="textbox" Width="99%" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
		</table>
	</asp:PlaceHolder>
</asp:Content>
