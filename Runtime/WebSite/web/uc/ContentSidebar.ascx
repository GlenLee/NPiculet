﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentSidebar.ascx.cs" Inherits="web_uc_ContentSidebar" %>
<div class="col-md-3 ui-content-sidebar">
	<div class="ui-widget">
		<div class="header">
			<span class="title">栏目导航</span>
			<div class="title-line"></div>
		</div>
		<div class="content">
			<%--<ul>
				<asp:Repeater ID="navlist" runat="server">
					<ItemTemplate>
						<li>
							<a href="../list/<%# Eval("GroupCode") %>"><%# Eval("GroupName") %></a>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
			<div class="split-line"></div>--%>
			<ul>
				<asp:Repeater ID="list" runat="server">
					<ItemTemplate>
						<li>
							<a href="../list/<%# Eval("GroupCode") %>"><%# Eval("GroupName") %></a>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
			<div class="split-line"></div>
			<ul>
				<asp:Repeater ID="implist" runat="server">
					<ItemTemplate>
						<li>
							<a href="../list/<%# Eval("GroupCode") %>"><%# Eval("GroupName") %></a>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</div>
	</div>
</div>