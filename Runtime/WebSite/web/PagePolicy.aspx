<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="PagePolicy.aspx.cs" Inherits="web_PagePolicy" %>
<%@ Register TagPrefix="uc1" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register Src="~/web/uc/ContentList.ascx" TagPrefix="uc1" TagName="ContentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
    <uc1:NavMenu runat="server" ID="NavMenu1" Active="2" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div class="sui-row sui-row-fluid">
        <div class="span3">
            <!-- 侧边栏 开始 -->
			<uc1:ContentSidebar runat="server" id="ContentSidebar" Active="PagePolicy" />
            <!-- 侧边栏 结束 -->
        </div>
        <div class="span9">
	        <div class="ui-content-nav">
				<ul class="sui-breadcrumb">
					<li>当前位置：</li>
					<li><a href="../default.aspx">首页</a></li>
					<li class="active">政策文件</li>
				</ul>
	        </div>
	        <div class="ui-content-split"></div>
            <!-- 列表 开始 -->
			<uc1:ContentList runat="server" ID="ContentPage1" GroupCode="PagePolicy" />
            <!-- 列表 结束 -->
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
