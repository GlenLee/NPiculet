﻿<%@ Page Title="系统配置项管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="ConfigSet.aspx.cs" Inherits="system_Admin_ConfigSet" %>
<%@ Register src="~/modules/common/Prompt.ascx" tagname="Prompt" tagprefix="zx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="fa fa-check"></i>保存</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
	<zx:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="container" runat="server">
		<table class="table table-primary">
			<tr>
				<td class="th">平台名称</td>
				<td class="td">
					<asp:TextBox ID="PlatformName" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
					<div class="caption">注：管理平台的展示名称</div>
				</td>
			</tr>
			<tr>
				<td class="th">站点名称</td>
				<td class="td">
					<asp:TextBox ID="WebSiteName" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
					<div class="caption">注：首页的标题，以及所有页面的前缀</div>
				</td>
			</tr>
			<tr>
				<td class="th">企业名称</td>
				<td class="td">
					<asp:TextBox ID="CompanyName" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
					<div class="caption">注：名称会显示在后台及版权申明中</div>
				</td>
			</tr>
			<tr>
				<td class="th">系统域名</td>
				<td class="td">
					<div class="input-group">
						<div class="input-group-addon">http://</div>
						<asp:TextBox ID="DomainName" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
					</div>
					<div class="caption">注：系统访问的地址</div>
				</td>
			</tr>
			<tr>
				<td class="th">备案号</td>
				<td class="td">
					<asp:TextBox ID="ICP" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
					<div class="caption">注：域名访问备案号，例如：滇ICP备00000000号</div>
				</td>
			</tr>
			<tr>
				<td class="th">联系电话</td>
				<td class="td">
					<asp:TextBox ID="Tel" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">举报电话</td>
				<td class="td">
					<asp:TextBox ID="ServiceTel" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">邮编</td>
				<td class="td">
					<asp:TextBox ID="PostCode" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">电子邮箱</td>
				<td class="td">
					<asp:TextBox ID="EMail" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">地址</td>
				<td class="td">
					<asp:TextBox ID="Address" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">编辑限制</td>
				<td class="td">
					<asp:DropDownList ID="NewsEditLimit" runat="server" CssClass="form-control">
						<asp:ListItem Value="">无限制</asp:ListItem>
						<asp:ListItem Value="Org">只允许编辑所属组织的新闻</asp:ListItem>
						<asp:ListItem Value="User">只允许编辑用户自己的新闻</asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td class="th">图片宽度</td>
				<td class="td">
					<asp:TextBox ID="ImageWidth" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
					<div class="caption">注：新闻图片超过此宽度会被压缩</div>
				</td>
			</tr>
		</table>
	</asp:PlaceHolder>
</asp:Content>
