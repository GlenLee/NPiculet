<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPage.master" AutoEventWireup="true" CodeFile="EntAdvList.aspx.cs" Inherits="EntAdvList" %>

<%@ Register TagPrefix="uc1" TagName="MemberSidebar" Src="~/web/uc/CorporationSidebar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="content" runat="Server">
    <div class="ui-member-content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="sui-row-fluid" style="margin-top: 10px;">
            <div class="span3">
                <uc1:MemberSidebar ID="MemberSidebar1" runat="server" Actived="EntAdvList.aspx" />
            </div>
            <div class="span9">
                <div class="title">广告位管理</div>
                <a href="EntAdvEdit.aspx" class="sui-btn btn-large btn-success" style="float: right; margin-bottom: 5px; margin-top: 5px">申请广告</a>

                <table class="sui-table table-bordered">
                    <thead>
                        <tr>
                            <th>广告位置</th>
                            <th>描述</th>
                            <th>广告链接</th>
                            <th>审核状态</th>
                            <th>开始时间</th>
                            <th>申请时长(天)</th>
                            <th>到期时间</th>
                            <th>删除</th>
                            <th>编辑</th>
                            <th>提交审核</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="AdvList" runat="server" OnItemCommand="AdvList_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("Type") %>
                                    </td>
                                    <td>
                                        <%# Eval("Description") %>
                                    </td>
                                    <td>
                                        <%# Eval("Url") %>
                                    </td>
                                    <td>
                                        <%# Eval("Status")%>
                                    </td>
                                    <td>
                                        <%# Eval("StartDate")%>
                                    </td>
                                     <td>
                                        <%# Eval("ValidTerm")%>
                                    </td>
                                    <td>
                                        <%#Eval("EndDate")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandName="Delete" CommandArgument='<%# Eval("Id")%>' runat="server">删除</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandName="Edit" CommandArgument='<%# Eval("Id") %>' runat="server">编辑</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandName="PostToAudit" CommandArgument='<%# Eval("Id") %>' runat="server">提交审核</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
