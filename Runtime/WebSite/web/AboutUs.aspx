<%@ Page Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="web_AboutUs" %>
<%@ Register TagPrefix="uc" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<style type="text/css">
		.content-article ul { list-style-type: none; }
		.content-article ul li { font-size: 14px; line-height: 2em; text-align: center; }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" Runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<div class="ui-content-view">
		<ul class="breadcrumb">
			<li>当前位置：</li>
			<li>首页</li>
			<li class="active">技术支持</li>
		</ul>
		<div class="content-info">
			<!-- 内容 开始 -->
			<div class="content-article">
				<ul>
					<li>作者：李萨</li>
					<li>官方网站：<a href="http://pcx.cn" target="_blank">http://pcx.cn</a></li>
				</ul>
				<p>&nbsp;</p>
			</div>
			<!-- 内容 结束 -->
		</div>
	</div>
</asp:Content>