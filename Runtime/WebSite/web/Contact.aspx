<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="web_Contact" %>
<%@ Register TagPrefix="uc" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" Runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<div class="ui-content-view">
		<ul class="sui-breadcrumb">
			<li>当前位置：</li>
			<li>首页</li>
			<li class="active">联系我们</li>
		</ul>
		<div class="sui-row-fluid">
			<div class="span12 content-info">
				<!-- 内容 开始 -->
				<div class="content-article">
					云南省公安厅经济犯罪侦查总队
				</div>
				<!-- 内容 结束 -->
			</div>
		</div>
	</div>
</asp:Content>
