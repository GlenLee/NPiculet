<%@ Page Title="信息组设置" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="InfoGroupSet.aspx.cs" Inherits="modules_info_InfoGroupSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">保存</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click">新增同级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnChild" runat="server" OnClick="btnChild_Click">新增下级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">删除</asp:LinkButton></li>
		</ul>
	</div>
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
				<table class="sui-table table-primary">
					<tr>
						<td class="th">编码</td>
						<td class="td"><asp:TextBox ID="GroupCode" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">名称</td>
						<td class="td"><asp:TextBox ID="GroupName" runat="server" CssClass="input-large" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="GroupName" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">类型</td>
						<td class="td"><asp:DropDownList ID="GroupType" runat="server">
							<asp:ListItem Value="">无</asp:ListItem>
							<asp:ListItem Value="Content">单页</asp:ListItem>
							<asp:ListItem Value="List">列表</asp:ListItem>
							<asp:ListItem Value="Image">图片列表</asp:ListItem>
						</asp:DropDownList></td>
					</tr>
					<tr>
						<td class="th">外部</td>
						<td class="td"><asp:CheckBox ID="IsExternal" runat="server" Text="是否外部链接" onclick="if (this.checked) { $('#externalUrl').show() } else { $('#externalUrl').hide() }" /></td>
					</tr>
					<tr id="externalUrl" style="display:none;">
						<td class="th">链接</td>
						<td class="td"><asp:TextBox ID="Url" runat="server" CssClass="input-large" Width="500px" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">显示</td>
						<td class="td"><asp:CheckBox ID="IsShow" runat="server" Text="是否显示" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">开启</td>
						<td class="td"><asp:CheckBox ID="IsEnabled" runat="server" Text="是否开启" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">排序</td>
						<td class="td">
							<asp:TextBox ID="OrderBy" runat="server" CssClass="input-large" Width="200px" MaxLength="8" Text="0"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="OrderBy" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="re2" runat="server" ControlToValidate="OrderBy" Display="Dynamic" ErrorMessage="只能是英文及数字" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">说明</td>
						<td class="td"><asp:TextBox ID="Memo" runat="server" CssClass="input-large" Width="99%" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
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

