<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentView.ascx.cs" Inherits="web_uc_ContentView" %>
<div class="content-title"><asp:Literal ID="title" runat="server"></asp:Literal></div>
<div class="content-info">
	发布人：<asp:Literal ID="author" runat="server"></asp:Literal>&nbsp;&nbsp;
	点击数：<asp:Literal ID="clicks" runat="server"></asp:Literal>&nbsp;&nbsp;
	发布时间：<asp:Literal ID="date" runat="server"></asp:Literal>
</div>
<div class="content-paper"><asp:Literal ID="content" runat="server"></asp:Literal></div>
