<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentPage.ascx.cs" Inherits="web_uc_ContentPage" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>
<div class="content-title">
	<asp:Literal ID="title" runat="server"></asp:Literal>
</div>
<div class="content-paper">
	<table class="ui-content-list">
		<tbody>
			<tr>
				<th scope="col">标题</th>
				<th scope="col" style="width: 150px;">发布时间</th>
			</tr>
			<asp:Repeater runat="server" ID="list">
				<ItemTemplate>
					<tr onclick="window.location.href='/web/ContentView.aspx?groupCode=<%# Eval("GroupCode") %>&id=<%# Eval("Id") %>'" style="cursor:pointer;">
						<td><a href="/web/ContentView.aspx?groupCode=<%# Eval("GroupCode") %>&id=<%# Eval("Id") %>"><%# Eval("Title") %></a></td>
						<td style="text-align: center; width: 120px;">【<%# Eval("CreateDate", "{0:yyyy-MM-dd}") %>】</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
		</tbody>
	</table>
	<cc1:NPager ID="NPager1" runat="server" />
</div>
