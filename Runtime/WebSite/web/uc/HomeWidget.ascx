<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HomeWidget.ascx.cs" Inherits="web_uc_HomeWidget" %>
<div class="ui-widget">
	<div class="header">
		<span class="title"><asp:Literal runat="server" ID="title"></asp:Literal></span> 
		<a class="more" href="<%= ResolveClientUrl("~/web") %>/<%= this.GroupCode %>">更多</a>
		<div class="title-line">
			<div class="gray"></div>
		</div>
	</div>
	<div class="content">
		<ul>
			<asp:Repeater ID="list" runat="server">
				<ItemTemplate>
					<li class="sui-row-fluid">
						<div class="span10"><a href="<%# GetViewUrl() %>" target="_blank"><%# Eval("Title") %></a></div>
						<div class="span2"><span class="date<%# GetNewStyle() %>"><%# GetCreateDate() %></span></div>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
</div>