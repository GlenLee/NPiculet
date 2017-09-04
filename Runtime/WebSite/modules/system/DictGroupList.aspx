<%@ Page Title="字典分组管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true"  CodeFile="DictGroupList.aspx.cs" Inherits="modules_system_DictGroupList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="DictGroupEdit.aspx"><i class="sui-icon icon-tb-add"></i>新增</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
	<ul class="searchbar-wrap">
		<li><asp:TextBox ID="txtKeywords" runat="server" placeholder="搜索名称或编码"></asp:TextBox></li>
		<li><asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/></li>
	</ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="Name" HeaderText="字典组名称" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Code" HeaderText="字典组编码" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="DisplayMode" HeaderText="展示方式">
		        <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Memo" HeaderText="列头备注" >
			</asp:BoundField>
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:D}" HeaderText="创建时间">
		        <HeaderStyle Width="140px" />
            </asp:BoundField>
			<asp:BoundField DataField="IsEnabled" HeaderText="已启用">
		        <HeaderStyle Width="60px" />
            </asp:BoundField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="100px"></HeaderStyle>
				<ItemTemplate>
					<a href="DictGroupEdit.aspx?key=<%# Eval("Id") %>">编辑</a> |
					<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>