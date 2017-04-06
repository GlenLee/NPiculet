<%@ Page Title="信息组设置" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="InfoGroupSet.aspx.cs" Inherits="modules_info_InfoGroupSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-default">保存</asp:LinkButton>
	<asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-default">新增同级</asp:LinkButton>
	<asp:LinkButton ID="btnChild" runat="server" OnClick="btnChild_Click" CssClass="btn btn-default">新增下级</asp:LinkButton>
	<asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="btn btn-default">删除</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<table cellpadding="0" cellspacing="2" style="border:0;width:100%;">
		<tr style="vertical-align:top;">
			<td style="width:300px;border:1px solid #ccc;padding:4px;">
				<div style="width:100%;height:100%;overflow:auto;"><asp:TreeView ID="tree" runat="server" onselectednodechanged="tree_SelectedNodeChanged"></asp:TreeView></div>
			</td>
			<td>
<asp:PlaceHolder ID="editor" runat="server">
				<table border="0" cellpadding="2" cellspacing="0" class="admin-edit-table">
					<tr>
						<td class="th">编码</td>
						<td class="td"><asp:TextBox ID="GroupCode" runat="server" CssClass="textbox" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RegularExpressionValidator ID="re1" runat="server" ControlToValidate="GroupCode" Display="Dynamic" ErrorMessage="只能是英文及数字" ForeColor="Red" ValidationExpression="\w*"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">名称</td>
						<td class="td"><asp:TextBox ID="GroupName" runat="server" CssClass="textbox" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="GroupName" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">类型</td>
						<td class="td"><asp:DropDownList ID="GroupType" runat="server">
							<asp:ListItem Value="">无</asp:ListItem>
							<asp:ListItem Value="Content">内容页</asp:ListItem>
							<asp:ListItem Value="List">普通列表</asp:ListItem>
							<%--<asp:ListItem Value="3">分类内容</asp:ListItem>
							<asp:ListItem Value="4">分类列表</asp:ListItem>--%>
						</asp:DropDownList></td>
					</tr>
					<tr>
						<td class="th">外部</td>
						<td class="td"><asp:CheckBox ID="IsExternal" runat="server" Text="是否外部链接" onclick="if (this.checked) { $('#externalUrl').show() } else { $('#externalUrl').hide() }" /></td>
					</tr>
					<tr id="externalUrl" style="display:none;">
						<td class="th">链接</td>
						<td class="td"><asp:TextBox ID="Url" runat="server" CssClass="textbox" Width="500px" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">显示</td>
						<td class="td"><asp:CheckBox ID="IsShow" runat="server" Text="是否显示" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">排序</td>
						<td class="td"><asp:TextBox ID="OrderBy" runat="server" CssClass="textbox" Width="200px" MaxLength="8" Text="0"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">说明</td>
						<td class="td"><asp:TextBox ID="Memo" runat="server" CssClass="textbox" Width="99%" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
					</tr>
				</table>
				<asp:HiddenField ID="Id" runat="server" />
				<asp:HiddenField ID="ParentId" runat="server" Value="0" />
				<asp:HiddenField ID="Layer" runat="server" Value="0" />
				<asp:HiddenField ID="Path" runat="server" />
</asp:PlaceHolder>
			</td>
		</tr>
	</table>
</asp:Content>

