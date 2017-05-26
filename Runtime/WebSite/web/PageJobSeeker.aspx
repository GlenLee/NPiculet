<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="PageJobSeeker.aspx.cs" Inherits="web_PageJobSeeker" %>
<%@ Register TagPrefix="uc1" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register Src="~/web/uc/ContentPage.ascx" TagPrefix="uc1" TagName="ContentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
    <uc1:NavMenu runat="server" ID="NavMenu1" Active="8" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div class="sui-row sui-row-fluid">
        <div class="span3">
            <!-- 侧边栏 开始 -->
			<uc1:ContentSidebar runat="server" id="ContentSidebar" Active="PageJobSeeker" />
            <!-- 侧边栏 结束 -->
        </div>
        <div class="span9">
	        <div class="ui-content-nav">
				<ul class="sui-breadcrumb">
					<li>当前位置：</li>
					<li><a href="../default.aspx">首页</a></li>
					<li class="active">人才库</li>
				</ul>
	        </div>
	        <div class="ui-content-split"></div>
            <!-- 列表 开始 -->
			<div class="ui-job-widget span6">
				<h4 class="sui-row-fluid">
					<div class="span9">
						<img src="../styles/images/job1.png" alt="" />&nbsp;&nbsp;热招职位
					</div>
				</h4>
			</div>
			<uc1:ContentPage runat="server" ID="ContentPage1" GroupCode="EntHire" />
            <!-- 列表 结束 -->
            <!-- 列表 开始 -->
			<div class="ui-job-widget span6">
				<h4 class="sui-row-fluid">
					<div class="span9">
						<img src="../styles/images/job2.png" alt="" />&nbsp;&nbsp;人才简历
					</div>
				</h4>
			</div>
			<uc1:ContentPage runat="server" ID="ContentPage2" GroupCode="PageJobSeeker" />
            <!-- 列表 结束 -->
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
