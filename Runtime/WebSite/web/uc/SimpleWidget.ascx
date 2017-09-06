<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SimpleWidget.ascx.cs" Inherits="web_uc_SimpleWidget" %>
<div class="ui-widget ui-widget-simple">
	<div class="header">
		<span class="title"><asp:Literal runat="server" ID="title"></asp:Literal></span>
		<a class="more" href="web/<%= this.GroupCode %>">更多</a>
		<div class="title-line"></div>
	</div>
	<div class="content">
		<ul>
			<asp:Repeater ID="list" runat="server">
				<ItemTemplate>
					<li class="sui-row">
						<div class="span10"><a href="view/<%# Eval("Id") %>"><%# GetNewsTitle() %></a></div>
						<div class="span2" style="text-align: right"><%# Eval("CreateDate", "{0:MM-dd}") %></div>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
</div>