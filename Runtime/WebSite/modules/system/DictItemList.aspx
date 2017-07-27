<%@ Page Title="字典数据管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" CodeFile="DictItemList.aspx.cs" Inherits="modules_system_DictItemList" %>
<%@ Import Namespace="NPiculet.Toolkit" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li>
				<a href="DictItemEdit.aspx?group=<%= WebParmKit.GetQuery("group", "") %>&fix=<%= WebParmKit.GetQuery("fix", "") %>">
					<i class="sui-icon icon-tb-add"></i>新增
				</a>
			</li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
	<ul class="searchbar-wrap">
		<li><asp:DropDownList runat="server" ID="ddlDictGroup"/></li>
		<li>关键字：<asp:TextBox ID="txtKeywords" runat="server" placeholder="搜索名称或编码"></asp:TextBox></li>
		<li><asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/></li>
	</ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDeleting="list_RowDeleting"  CssClass="sui-table table-primary">
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="GroupName" HeaderText="字典组">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Name" HeaderText="字典项名称">
				<HeaderStyle Width="160px" />
            </asp:BoundField>
			<asp:BoundField DataField="Code" HeaderText="字典项编码">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
            <asp:BoundField DataField="Value" HeaderText="属性值">
			</asp:BoundField>
			<asp:BoundField DataField="OrderBy" HeaderText="排序">
				<HeaderStyle Width="70px" />
			</asp:BoundField>
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:D}" HeaderText="创建时间">
		        <HeaderStyle Width="140px" />
            </asp:BoundField>
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="100px" />
				<ItemTemplate>
					<a href="DictItemEdit.aspx?key=<%# Eval("Id") %>&group=<%= WebParmKit.GetQuery("group", "") %>&fix=<%= WebParmKit.GetQuery("fix", "") %>">编辑</a> |
					<asp:LinkButton ID="btnDel" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>
