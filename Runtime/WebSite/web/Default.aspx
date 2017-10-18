<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="web_Default" %>
<%@ Register Src="~/web/uc/NavMenu.ascx" TagPrefix="uc" TagName="NavMenu" %>
<%@ Register Src="~/web/uc/LoginWidget.ascx" TagPrefix="uc" TagName="LoginWidget" %>
<%@ Register TagPrefix="uc" TagName="PageTop" Src="~/web/uc/PageTop.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="nav">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<ol class="breadcrumb">
		<li>pcx.cn</li>
		<li><%= GetWebSiteName() %></li>
	</ol>
	<div class="ui-sidebar">
		
		<form runat="server">
			<uc:LoginWidget runat="server" id="LoginWidget1" />
		</form>

	</div>
	<div class="ui-content">

		<div class="ui-widget">
			<div class="header">
				<div class="title">新闻</div>
			</div>
			<div class="content">
				<ul>
					<asp:Repeater ID="news" runat="server">
						<ItemTemplate>
							<li class="row">
								<div class="col-md-10"><a href="../view/<%# Eval("Id") %>" target="_blank"><%# Eval("Title") %></a></div>
								<div class="col-md-2" style="text-align: right"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
							</li>
						</ItemTemplate>
					</asp:Repeater>
				</ul>
			</div>
		</div>

	</div>
</asp:Content>