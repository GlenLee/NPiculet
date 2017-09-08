<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="Active.aspx.cs" Inherits="web_Active" %>
<%@ Register TagPrefix="uc" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="Breadcrumb" Src="~/web/uc/Breadcrumb.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" Runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">	<div class="ui-content-view">
		<uc:Breadcrumb ID="Breadcrumb1" runat="server" GroupCode="Post" />
		<div class="sui-row-fluid">
			<div class="span12 content-info">
				<!-- 内容 开始 -->
				<div class="content-title"><asp:Literal ID="title" runat="server"></asp:Literal></div>
				<div class="content-from">
					发布人：<asp:Literal ID="author" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
					点击数：<asp:Literal ID="clicks" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
					发布时间：<asp:Literal ID="date" runat="server"></asp:Literal>
				</div>
				<div class="content-article"><asp:Literal ID="content" runat="server"></asp:Literal></div>
				<!-- 内容 结束 -->
				<div class="split-line"></div>
				<!-- 导读 -->
				<ul class="quote">
					<asp:PlaceHolder runat="server" ID="phPrevLink" Visible="False"><li><a>上一条：<asp:Literal runat="server" ID="btnPrevTitle"></asp:Literal></a></li></asp:PlaceHolder>
					<asp:PlaceHolder runat="server" ID="phNextLink" Visible="False"><li><a>下一条：<asp:Literal runat="server" ID="btnNextTitle"></asp:Literal></a></li></asp:PlaceHolder>
				</ul>
			</div>
		</div>
	</div>
</asp:Content>
