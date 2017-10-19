<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentView.ascx.cs" Inherits="web_uc_ContentView" %>
<asp:HyperLink runat="server" ID="btnBack" CssClass="btn-back"><i class="glyphicon glyphicon-chevron-left"></i>&nbsp;返回</asp:HyperLink>
<div class="content-title"><asp:Literal ID="title" runat="server"></asp:Literal></div>
<div class="content-from">
	发布人：<asp:Literal ID="author" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
	来源：<asp:Literal ID="source" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
	点击数：<asp:Literal ID="clicks" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
	发布时间：<asp:Literal ID="date" runat="server"></asp:Literal>
</div>
<div class="content-article"><asp:Literal ID="content" runat="server"></asp:Literal></div>