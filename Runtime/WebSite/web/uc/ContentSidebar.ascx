<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentSidebar.ascx.cs" Inherits="web_uc_ContentSidebar" %>
<div class="ui-content-sidebar">
	<div class="ui-widget">
		<div class="header">
			<span class="title"><i class="glyphicon glyphicon-th-large"></i>&nbsp;&nbsp;栏目导航</span>
			<div class="title-line"></div>
		</div>
		<div class="content">
			<ul>
				<asp:Repeater ID="list" runat="server">
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