<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="ContentView.aspx.cs" Inherits="web_ContentView" %>
<%@ Register TagPrefix="zx" TagName="Breadcrumb" Src="~/web/uc/Breadcrumb.ascx" %>
<%@ Register TagPrefix="zx" TagName="ContentView" Src="~/web/uc/ContentView.ascx" %>
<%@ Register TagPrefix="zx" TagName="WebMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nav" runat="Server">
	<zx:WebMenu ID="WebMenu1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<div class="ui-content-view">
		<zx:Breadcrumb ID="Breadcrumb1" runat="server"/>
		<div>
			<div class="content-info">
				<!-- 内容 开始 -->
				<zx:ContentView ID="ContentView1" runat="server" />
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

