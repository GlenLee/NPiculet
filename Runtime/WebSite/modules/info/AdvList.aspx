<%@ Page Title="" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="AdvList.aspx.cs" Inherits="modules.info.AdvList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
    <div class="tools">
        <ul class="toolbar">
            <li><a href="AdvEdit.aspx"><i class="sui-icon icon-tb-add"></i>新增</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">
    <asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
        DataKeyNames="Id"
        OnRowDeleting="list_RowDeleting"
        AllowPaging="True"
        CssClass="sui-table table-primary"
        PageSize="15"
        OnRowCommand="list_RowCommand"
        OnPageIndexChanging="list_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Type" HeaderText="广告位置">
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="描述" />
            <asp:BoundField DataField="Url" HeaderText="链接" />
            <asp:BoundField DataField="StartDate" HeaderText="开始时间" />
            <asp:BoundField DataField="ValidTerm" HeaderText="申请时长(天)" />
            <asp:BoundField DataField="EndDate" HeaderText="结束时间" />
            <asp:TemplateField HeaderText="当前状态" HeaderStyle-Width="50px">
                <ItemTemplate>
                    <%#Eval("Status")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核通过" HeaderStyle-Width="70px">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        OnClientClick='if(confirm("您确定要修改状态为【通过】吗?")) return true; else return false;'
                        CommandArgument='<%# Eval("Id") + "," + Eval("IsEnabled") %>'
                        CommandName="PassAudit"
                        Text="审核通过" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核不通过" HeaderStyle-Width="70px">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        OnClientClick='if(confirm("您确定要修状态为【不通过】吗?")) return true; else return false;'
                        CommandArgument='<%# Eval("Id") + "," + Eval("IsEnabled") %>'
                        CommandName="RejectAudit"
                        Text="审核不通过" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑">
                <HeaderStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate><a href="AdvEdit.aspx?key=<%# Eval("Id") %>">编辑</a></ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" HeaderText="删除">
                <HeaderStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Columns>
        <PagerSettings FirstPageText="第一页" LastPageText="最后页" Mode="NumericFirstLast" NextPageText="上一页" PreviousPageText="下一页" />
    </asp:GridView>
</asp:Content>
