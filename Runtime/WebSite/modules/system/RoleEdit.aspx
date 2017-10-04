<%@ Page Title="角色编辑" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="RoleEdit.aspx.cs" Inherits="modules_system_RoleEdit" %>
<%@ Register src="../common/Prompt.ascx" tagname="Prompt" tagprefix="uc" %>

<asp:Content ID="Content0" ContentPlaceHolderID="header" runat="server">
	<style type="text/css">
		.org-list table { width:100%; }
		.org-list table td { width:20%; }
		.role-list table { width:100%; }
		.role-list table td { width:20%; }
	</style>
	<script type="text/javascript">
		var result;
		function addUser() {
			layer.open({
				type: 2,
				title: '选择用户',
				shadeClose: true,
				shade: false,
				maxmin: true,
				area: ['800px', '500px'],
				content: '../common/UserDialog.aspx',
				end: function () {
					if (result && result.length > 0) {
						__doPostBack('addUsers', result);
					}
				}
			});
		}
	</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="RoleList.aspx"><i class="sui-icon icon-tb-back"></i>返回</a></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="sui-icon icon-tb-check"></i>保存</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<uc:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="editor" runat="server">
		<table class="table table-primary">
			<tr>
				<th colspan="2">基本信息</th>
			</tr>
			<tr>
				<td class="th">名称</td>
				<td class="td"><asp:TextBox ID="RoleName" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="RoleName"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td class="th">备注</td>
				<td class="td"><asp:TextBox ID="Comment" runat="server" CssClass="input-large" Width="99%" MaxLength="255"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th">是否启用</td>
				<td class="td"><asp:CheckBox runat="server" ID="IsEnabled" Checked="True"/></td>
			</tr>
		</table>
		<asp:HiddenField ID="Id" runat="server" />

		<blockquote id="_userList" runat="server">
			<div class="quote">
				<h5>拥有用户</h5>
				<span>
					<a href="#" onclick="addUser();">添加</a>
					<asp:LinkButton runat="server" ID="btnDelUser" Text="删除" onclick="btnDelUser_Click"></asp:LinkButton>
				</span>
				<div class="cr"></div>
			</div>
			<div class="content role-list">
				<asp:CheckBoxList runat="server" ID="userList" RepeatColumns="5" RepeatDirection="Horizontal" CellPadding="6"/>
			</div>
		</blockquote>
	</asp:PlaceHolder>
</asp:Content>

