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
		<ul class="sui-breadcrumb">
			<li>当前位置：</li>
			<li>首页</li>
			<li class="active">技术支持</li>
		</ul>
		<div class="sui-row-fluid">
			<div class="span12 content-info">
				<!-- 内容 开始 -->
				<div class="content-article">
					<ul>
						<li>云南达速科技有限公司</li>
						<li>联系电话：0871-65618058</li>
					</ul>
				</div>
				<!-- 内容 结束 -->
			</div>
		</div>
	</div>
</asp:Content>