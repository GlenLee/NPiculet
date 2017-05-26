<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPage.master" AutoEventWireup="true" CodeFile="EntHireList.aspx.cs" Inherits="EntHireList" %>

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
                <uc1:MemberSidebar ID="MemberSidebar1" runat="server" Actived="EntHireList.aspx" />
            </div>
            <div class="span9">
                <div class="title">招聘管理</div>
                <a href="EntHireEdit.aspx" class="sui-btn btn-large btn-success" style="float: right; margin-bottom: 5px; margin-top: 5px">新建招聘</a>

                <table class="sui-table table-bordered">
                    <thead>
                        <tr>
                            <th>招聘标题</th>
                            <th>创建时间</th>
                            <th>当前状态</th>
                            <th>删除</th>
                            <th>编辑</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="EntHireListView" runat="server" OnItemCommand="EntHireList_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("Title") %>
                                    </td>
                                    <td>
                                        <%# Eval("CreateDate") %>
                                    </td>
                                    <td>
                                        <%# Eval("Status")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandName="Delete" OnClientClick="if(confirm('确定删除？')){return true;}return false;"
                                            CommandArgument='<%# Eval("Id")%>' runat="server">删除</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandName="Edit" CommandArgument='<%# Eval("Id") %>' runat="server">编辑</asp:LinkButton>
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
