<%@ Page Title="审核会员" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MemberVerify.aspx.cs" Inherits="modules_member_MemberVerify" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="header">
	<script>
		$(document).ready(function () {
			$('.dropdown').dropdown({ transition: 'drop', width: '100%' });
		});
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton runat="server" ID="btnVerify" Text="充值" OnClientClick="return confirm('您确定要为选择账号充值吗？');" onclick="btnVerify_Click"></asp:LinkButton>
	<asp:LinkButton runat="server" ID="btnRobot" Text="标记为外挂" OnClientClick="return confirm('选中账号将被标记为“外挂”！');" onclick="btnRobot_Click"></asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
	<div class="searchbar-wrap">
		<div class="ui four column grid">
			<div class="column">
				<asp:DropDownList runat="server" ID="ddlStatus" CssClass="ui search dropdown">
					<asp:ListItem Value="">会员状态</asp:ListItem>
					<asp:ListItem Value="全部">全部</asp:ListItem>
					<asp:ListItem Value="已注册-未充值">已注册-未充值</asp:ListItem>
					<asp:ListItem Value="已注册-已充值">已注册-已充值</asp:ListItem>
					<asp:ListItem Value="外挂">外挂</asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="column ui form">
				<asp:TextBox ID="txtKeywords" runat="server" CssClass="field" placeholder="帐号/名称"></asp:TextBox>
			</div>
			<div class="column">
				<asp:Button ID="btnSearch" runat="server" CssClass="ui button" onclick="btnSearch_Click" Text="搜索"></asp:Button>
			</div>
		</div>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
		OnRowDeleting="list_RowDeleting" CssClass="admin-list-table">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:TemplateField HeaderText="">
				<HeaderStyle Width="40px"></HeaderStyle>
				<HeaderTemplate>
					<input type="checkbox" onclick="var val=this.checked;$('input[type=checkbox]').each(function(){this.checked=val;});"/>
				</HeaderTemplate>
				<ItemTemplate>
					<input type="checkbox" id="chkBox" runat="server" value='<%# Eval("Id") %>'/>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Account" HeaderText="帐号" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Name" HeaderText="姓名" />
			<asp:BoundField DataField="Mobile" HeaderText="电话" >
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="创建时间">
				<HeaderStyle Width="160px" />
			</asp:BoundField>
			<asp:BoundField DataField="Status" HeaderText="状态">
				<HeaderStyle Width="120px" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="启用">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作">
				<HeaderStyle Width="100"></HeaderStyle>
				<ItemTemplate>
					<a href="MemberEdit.aspx?key=<%# Eval("Id") %>" CssClass="btn btn-default">编辑</a> |
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" />
</asp:Content>
