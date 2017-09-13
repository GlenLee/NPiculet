<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavMenu.ascx.cs" Inherits="web_uc_NavMenu" %>
<div class="ui-navbar">
	<div class="layout">
		<ul>
<asp:Repeater runat="server" ID="list">
	<ItemTemplate>
			<li<%# GetBorderStyle(Container.ItemIndex) %>><a<%# GetActive() %> href="<%# GetPageUrl() %>"><%# Eval("GroupName") %></a></li>
	</ItemTemplate>
</asp:Repeater>
		</ul>
	</div>
</div>