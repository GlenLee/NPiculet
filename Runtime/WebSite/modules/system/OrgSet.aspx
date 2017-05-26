<%@ Page Title="组织机构管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="OrgSet.aspx.cs" Inherits="modules_system_OrgSet" %>
<%@ Register TagPrefix="uc1" TagName="Prompt" Src="~/modules/common/Prompt.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton ID="btnAuth" runat="server" OnClick="btnAuth_Click">授权</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">保存</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnSame" runat="server" OnClick="btnSame_Click">新增同级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnChild" runat="server" OnClick="btnChild_Click">新增下级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">删除</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnFix" runat="server" OnClick="btnFix_Click" CausesValidation="False">修复结构</asp:LinkButton></li>
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
				<uc1:Prompt ID="promptControl" runat="server" />
<asp:PlaceHolder ID="editor" runat="server">
				<table class="sui-table table-primary">
					<tr>
						<th colspan="2">基本信息</th>
					</tr>
					<tr>
						<td class="th">当前组织</td>
						<td class="td"><asp:Literal ID="CurName" runat="server"></asp:Literal></td>
					</tr>
					<tr>
						<td class="th">名称</td>
						<td class="td"><asp:TextBox ID="OrgName" runat="server" CssClass="input-large" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="OrgName" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">编码</td>
						<td class="td"><asp:TextBox ID="OrgCode" runat="server" CssClass="input-large" Width="200px" MaxLength="64"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">简称</td>
						<td class="td"><asp:TextBox ID="Alias" runat="server" CssClass="input-large" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="Alias" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">显示</td>
						<td class="td"><asp:CheckBox ID="IsEnabled" runat="server" Text="是否启用" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">排序</td>
						<td class="td"><asp:TextBox ID="OrderBy" runat="server" CssClass="input-large" Width="200px" MaxLength="8" Text="0"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">备注</td>
						<td class="td"><asp:TextBox ID="Memo" runat="server" CssClass="input-large" Width="99%" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
					</tr>
				</table>
				<asp:HiddenField ID="Id" runat="server" />
				<asp:HiddenField ID="GroupCode" runat="server" Value="Default" />
				<asp:HiddenField ID="ParentId" runat="server" />
				<asp:HiddenField ID="RootId" runat="server" />
				<asp:HiddenField ID="Level" runat="server" />
				<asp:HiddenField ID="Path" runat="server" />
				<asp:HiddenField ID="OrgType" runat="server" Value="1"/>
				<asp:HiddenField ID="FullName" runat="server"/>
</asp:PlaceHolder>
			</td>
		</tr>
	</table>
</asp:Content>
