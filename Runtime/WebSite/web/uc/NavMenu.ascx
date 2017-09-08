<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavMenu.ascx.cs" Inherits="web_uc_NavMenu" %>
<div class="ui-nav">
	<div class="controls">
		<ul class="menus">
<asp:Repeater runat="server" ID="list">
	<ItemTemplate>
			<li<%# GetBorderStyle(Container.ItemIndex) %>><a<%# GetActive() %> href="<%# GetPageUrl() %>"><%# Eval("GroupName") %></a></li>
	</ItemTemplate>
</asp:Repeater>
		</ul>
		<form method="get" action="<%= ResolveClientUrl("~/search") %>" class="search-bar">
			<input type="search" id="keyword" name="keyword" class="search-keyword" placeholder="请输入您要搜索的内容"/>
			<input type="submit" class="search-button" value="搜索"/>
		</form>
	</div>
</div>