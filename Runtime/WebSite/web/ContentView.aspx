<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="ContentView.aspx.cs" Inherits="web_ContentView" %>

<%@ Register TagPrefix="zx" TagName="LocationTip" Src="~/web/uc/LocationTip.ascx" %>
<%@ Register TagPrefix="zx" TagName="ContentView" Src="~/web/uc/ContentView.ascx" %>
<%@ Register TagPrefix="zx" TagName="WebMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nav" runat="Server">
    <zx:WebMenu ID="WebMenu1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="ui-content">
        <div class="sui-row-fluid">
            <div class="span9 ui-content-info">
                <!-- 内容 开始 -->
                <zx:LocationTip ID="LocationTip1" runat="server" GroupCode="Post" />
                <zx:ContentView ID="ContentView1" runat="server" GroupCode="Post" />
                <!-- 内容 结束 -->
            </div>
            <div class="span3">
                <!-- 侧边栏 开始 -->
                <div class="ui-widget">
                    <div class="title">
                        &nbsp;&nbsp;会员展示 <a href="PageAssociatorShow.aspx">MORE</a>
                    </div>
                    <div class="content">
                        <ul>
                            <asp:Repeater ID="Associators" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="ContentView.aspx?id=<%# Eval("Id") %>"><%# Eval("Title") %></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!-- 侧边栏 结束 -->
                <asp:Repeater ID="ContentPageAdvs" runat="server">
                    <ItemTemplate>
                        <div>&nbsp;</div>
                        <a href="<%# Eval("Url") %>" target="_blank">
                            <img src="<%# ResolveClientUrl(Convert.ToString(Eval("Image"))) %>"
                                alt="" /></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

