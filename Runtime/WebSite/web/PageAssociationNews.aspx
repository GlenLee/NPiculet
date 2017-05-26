<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="PageAssociationNews.aspx.cs" Inherits="web_PageAssociationNews" %>
<%@ Register TagPrefix="uc1" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register Src="~/web/uc/ContentPage.ascx" TagPrefix="uc1" TagName="ContentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
    <uc1:NavMenu runat="server" ID="NavMenu1" Active="3" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div class="sui-row sui-row-fluid">
        <div class="span3">
            <!-- 侧边栏 开始 -->
			<uc1:ContentSidebar runat="server" id="ContentSidebar" Active="PageAssociationNews" />
            <!-- 侧边栏 结束 -->
        </div>
        <div class="span9">
	        <div class="ui-content-nav">
				<ul class="sui-breadcrumb">
					<li>当前位置：</li>
					<li><a href="../default.aspx">首页</a></li>
					<li class="active">协会动态</li>
				</ul>
	        </div>
	        <div class="ui-content-split"></div>
            <!-- 列表 开始 -->
			<uc1:ContentPage runat="server" ID="ContentPage1" GroupCode="PageAssociationNews" />
            <!-- 列表 结束 -->
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
