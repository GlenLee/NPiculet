<%@ Page Title="个人会员管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="modules.member.ModulesMemberMemberList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content runat="server" ContentPlaceHolderID="header">
	<script>
		$(document).ready(function() {
			$('.dropdown').dropdown({ transition: 'drop' });
		});
	</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="MemberEdit.aspx"><i class="sui-icon icon-tb-add"></i>新增</a></li>
			<%--<li><asp:LinkButton runat="server" ID="btnDel" Text="删除"></asp:LinkButton></li>--%>
			<%--<li><asp:LinkButton runat="server" ID="btnResetPass" Text="重设密码"></asp:LinkButton></li>--%>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
<div class="searchbar-wrap">
	<ul class="searchbar-wrap">
		<li>
			<asp:Label ID="MemberStatus" runat="server">会员状态：</asp:Label>
			<asp:DropDownList ID="ddlStatus" runat="server"  Width="200px">
			</asp:DropDownList>
		</li>
		<li>
			<asp:TextBox ID="txtKeywords" runat="server" Width="200px" placeholder="帐号/名称"></asp:TextBox>
		</li>
		<li>
			<asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="搜索"></asp:Button>
		</li>
	</ul>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="Account" HeaderText="帐号" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Password" HeaderText="密码" Visible="False">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Name" HeaderText="姓名" />
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="创建时间">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
         
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="60"></HeaderStyle>
				<ItemTemplate>
					<a href="MemberEdit.aspx?key=<%# Eval("Id") %>" CssClass="btn btn-default" >编辑</a>
				</ItemTemplate>
			</asp:TemplateField>
          
			<asp:TemplateField HeaderText="删除">
				<HeaderStyle Width="60"></HeaderStyle>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>
