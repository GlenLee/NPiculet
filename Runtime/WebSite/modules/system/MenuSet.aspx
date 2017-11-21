<%@ Page Title="系统菜单管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MenuSet.aspx.cs" Inherits="System_MenuSet" %>
<%@ Register TagPrefix="uc" TagName="Prompt" Src="~/modules/common/Prompt.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="fa fa-check"></i>保存</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnSame" runat="server" OnClick="btnSame_Click"><i class="fa fa-plus"></i>新增同级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnChild" runat="server" OnClick="btnChild_Click"><i class="fa fa-plus"></i>新增下级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return confirm('是否确定要删除菜单项？');"><i class="fa fa-close"></i>删除</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnFix" runat="server" OnClick="btnFix_Click" CausesValidation="False"><i class="fa fa-wrench"></i>修复路径</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
	<table cellpadding="0" cellspacing="2" style="border:0;width:100%;">
		<tr style="vertical-align:top;">
			<td style="width:300px;padding:4px;">
				<div style="width:100%;height:100%;overflow:auto;"><asp:TreeView ID="tree" runat="server" CssClass="admin-tree" OnSelectedNodeChanged="tree_SelectedNodeChanged"></asp:TreeView></div>
			</td>
			<td>
				<uc:Prompt ID="promptControl" runat="server" />
<asp:PlaceHolder ID="editor" runat="server">
				<table class="table table-primary">
					<tr>
						<th colspan="2">基本信息</th>
					</tr>
					<tr>
						<td class="th">当前菜单</td>
						<td class="td"><asp:Literal ID="CurName" runat="server"></asp:Literal></td>
					</tr>
					<tr>
						<td class="th">所属</td>
						<td class="td"><asp:DropDownList ID="Belong" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="Belong_SelectedIndexChanged">
							<asp:ListItem Value="1">普通菜单</asp:ListItem>
							<asp:ListItem Value="2">栏目</asp:ListItem>
							<asp:ListItem Value="3">字典</asp:ListItem>
						</asp:DropDownList></td>
					</tr>
<asp:PlaceHolder ID="phNormalMenu" runat="server" Visible="false">
					<tr>
						<td class="th">名称</td>
						<td class="td">
							<asp:TextBox ID="Name" runat="server" CssClass="form-control" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="Name" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">编码</td>
						<td class="td"><asp:TextBox ID="Code" runat="server" CssClass="form-control" Width="200px" MaxLength="64"></asp:TextBox></td>
					</tr>
</asp:PlaceHolder>
<asp:PlaceHolder ID="phInfoGroup" runat="server" Visible="false">
					<tr>
						<td class="th">选择栏目</td>
						<td class="td">
							<asp:DropDownList ID="InfoGroupCategory" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="InfoGroupCategory_SelectedIndexChanged"></asp:DropDownList>
							&nbsp;
							<asp:DropDownList ID="InfoGroupList" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="InfoGroupList_SelectedIndexChanged"></asp:DropDownList>
						</td>
					</tr>
</asp:PlaceHolder>
<asp:PlaceHolder ID="phDict" runat="server" Visible="false">
					<tr>
						<td class="th">选择字典</td>
						<td class="td">
							<asp:DropDownList ID="DictList" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="DictList_SelectedIndexChanged"></asp:DropDownList>
						</td>
					</tr>
</asp:PlaceHolder>
					<tr>
						<td class="th">显示窗口</td>
						<td class="td"><asp:DropDownList ID="Target" runat="server" CssClass="form-control" Width="200px">
							<asp:ListItem Value="mainFrame">主窗口</asp:ListItem>
							<asp:ListItem Value="_blank">弹出窗口</asp:ListItem>
						</asp:DropDownList></td>
					</tr>
					<tr>
						<td class="th">图标</td>
						<td class="td"><asp:TextBox ID="Icon" runat="server" CssClass="form-control" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">链接</td>
						<td class="td"><asp:TextBox ID="Url" runat="server" CssClass="form-control" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">显示</td>
						<td class="td"><asp:CheckBox ID="IsEnabled" runat="server" Text="是否启用" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">排序</td>
						<td class="td">
							<asp:TextBox ID="Sort" runat="server" CssClass="form-control" Width="200px" MaxLength="8" Text="0"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="Sort" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="re2" runat="server" ControlToValidate="Sort" Display="Dynamic" ErrorMessage="只能是英文及数字" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">说明</td>
						<td class="td"><asp:TextBox ID="Comment" runat="server" CssClass="form-control" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
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
