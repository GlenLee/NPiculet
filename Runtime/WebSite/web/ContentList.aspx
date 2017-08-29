<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="ContentList.aspx.cs" Inherits="web_ContentList" %>
<%@ Register Src="~/web/uc/ContentList.ascx" TagPrefix="uc1" TagName="ContentList" %>
<%@ Register Src="~/web/uc/NavMenu.ascx" TagPrefix="uc1" TagName="NavMenu" %>
<%@ Register Src="~/web/uc/ContentSidebar.ascx" TagPrefix="uc1" TagName="ContentSidebar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="nav" runat="Server">
    <uc1:NavMenu runat="server" ID="NavMenu1" Active="1" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="sui-row sui-row-fluid">
        <div class="span3">
            <!-- 侧边栏 开始 -->
			<uc1:ContentSidebar runat="server" id="ContentSidebar" />
            <!-- 侧边栏 结束 -->
        </div>
        <div class="span9">
	        <div class="ui-content-nav">
				<ul class="sui-breadcrumb">
					<li>当前位置：</li>
					<li><a href="../default.aspx">首页</a></li>
					<li class="active">新闻</li>
				</ul>
	        </div>
	        <div class="ui-content-split"></div>
            <!-- 列表 开始 -->
            <uc1:ContentList runat="server" ID="ContentPage" />
            <!-- 列表 结束 -->
        </div>
    </div>
</asp:Content>
