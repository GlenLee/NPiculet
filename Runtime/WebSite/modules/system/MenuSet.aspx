<%@ Page Title="系统菜单管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MenuSet.aspx.cs" Inherits="System_MenuSet" %>
<%@ Register TagPrefix="uc1" TagName="Prompt" Src="~/modules/common/Prompt.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">保存</asp:LinkButton>
	<asp:LinkButton ID="btnSame" runat="server" OnClick="btnSame_Click">新增同级</asp:LinkButton>
	<asp:LinkButton ID="btnChild" runat="server" OnClick="btnChild_Click">新增下级</asp:LinkButton>
	<asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return confirm('是否确定要删除菜单项？');">删除</asp:LinkButton>
	<asp:LinkButton ID="btnFix" runat="server" OnClick="btnFix_Click" CausesValidation="False">修复路径</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
	<table cellpadding="0" cellspacing="2" style="border:0;width:100%;">
		<tr style="vertical-align:top;">
			<td style="width:300px;padding:4px;">
				<div style="width:100%;height:100%;overflow:auto;"><asp:TreeView ID="tree" runat="server" onselectednodechanged="tree_SelectedNodeChanged"></asp:TreeView></div>
			</td>
			<td>
				<uc1:Prompt ID="promptControl" runat="server" />
<asp:PlaceHolder ID="editor" runat="server">
				<table border="0" cellpadding="2" cellspacing="0" class="admin-edit-table">
					<tr>
						<th colspan="2">基本信息</th>
					</tr>
					<tr>
						<td class="th">当前菜单</td>
						<td class="td"><asp:Literal ID="CurName" runat="server"></asp:Literal></td>
					</tr>
					<tr>
						<td class="th">名称</td>
						<td class="td"><asp:TextBox ID="Name" runat="server" CssClass="textbox" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="Name" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">编码</td>
						<td class="td"><asp:TextBox ID="Code" runat="server" CssClass="textbox" Width="200px" MaxLength="64"></asp:TextBox></td>
					</tr>
					<tr style="display:none;">
						<td class="th">类型</td>
						<td class="td"><asp:DropDownList ID="Type" runat="server">
							<asp:ListItem Value="0">无</asp:ListItem>
							<asp:ListItem Value="1">内容页</asp:ListItem>
							<asp:ListItem Value="2">普通列表</asp:ListItem>
						</asp:DropDownList></td>
					</tr>
					<tr>
						<td class="th">显示窗口</td>
						<td class="td"><asp:DropDownList ID="Target" runat="server">
							<asp:ListItem Value="mainFrame">主窗口</asp:ListItem>
							<asp:ListItem Value="_blank">新窗口</asp:ListItem>
						</asp:DropDownList></td>
					</tr>
					<tr>
						<td class="th">图标</td>
						<td class="td"><asp:TextBox ID="Icon" runat="server" CssClass="textbox" Width="99%" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">链接</td>
						<td class="td"><asp:TextBox ID="Url" runat="server" CssClass="textbox" Width="99%" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">显示</td>
						<td class="td"><asp:CheckBox ID="IsEnabled" runat="server" Text="是否启用" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">排序</td>
						<td class="td">
							<asp:TextBox ID="OrderBy" runat="server" CssClass="textbox" Width="200px" MaxLength="8" Text="0"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="OrderBy" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="re2" runat="server" ControlToValidate="OrderBy" Display="Dynamic" ErrorMessage="只能是英文及数字" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">说明</td>
						<td class="td"><asp:TextBox ID="Comment" runat="server" CssClass="textbox" Width="99%" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
					</tr>
				</table>
				<asp:HiddenField ID="Id" runat="server" />
				<asp:HiddenField ID="ParentId" runat="server" />
				<asp:HiddenField ID="RootId" runat="server" />
				<asp:HiddenField ID="Depth" runat="server" />
				<asp:HiddenField ID="Path" runat="server" />
</asp:PlaceHolder>
			</td>
		</tr>
	</table>
</asp:Content>
