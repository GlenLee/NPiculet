<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="ContentOrg.aspx.cs" Inherits="web_ContentOrg" %>
<%@ Register TagPrefix="uc" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register TagPrefix="uc" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="HomeWidget" Src="~/web/uc/HomeWidget.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="nav" runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<ul class="breadcrumb">
		<li>当前位置：</li>
		<li><a href="<%= ResolveClientUrl("~/") %>">首页</a></li>
		<li class="active"><asp:Literal runat="server" ID="orgTitle"></asp:Literal></li>
	</ul>
	<div class="row ui-content-list">
		<div class="col-md-9">
			<asp:Repeater runat="server" ID="news">
				<ItemTemplate>
					<%# Container.ItemIndex % 2 == 0 ? "<div class=\"ui-body-row sui-row-fluid\">" : "" %>
					<div class="col-md-6"><uc:HomeWidget runat="server" ID="homeWidget" GroupCode='<%# Eval("GroupCode") %>' /></div>
					<%# Container.ItemIndex % 2 == 1 || Container.ItemIndex == count - 1 ? "</div>" : "" %>
				</ItemTemplate>
			</asp:Repeater>
		</div>
		<div class="col-md-3">
			<!-- 侧边栏 开始 -->
			<uc:ContentSidebar runat="server" id="contentSidebar" />
			<!-- 侧边栏 结束 -->
		</div>
	</div>
</asp:Content>
