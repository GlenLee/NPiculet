<%@ Page Title="" Language="C#" MasterPageFile="~/IndexPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/web/uc/NavMenu.ascx" TagPrefix="uc" TagName="NavMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style type="text/css">
		img { display: block; margin: 0 auto; border: 2px solid #f7f7f7; border-radius: 64px; }
	</style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="nav">
	<uc:NavMenu runat="server" ID="NavMenu" Active="0" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<img src="styles/web/logo.png" alt=""/>
<asp:Repeater ID="news" runat="server">
	<ItemTemplate>
		<li class="sui-row-fluid">
			<div class="span10"><a href="view/<%# Eval("Id") %>" target="_blank"><%# Eval("Title") %></a></div>
			<div class="span2" style="text-align: right"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
		</li>
	</ItemTemplate>
</asp:Repeater>
</asp:Content>