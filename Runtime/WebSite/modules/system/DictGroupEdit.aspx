<%@ Page Title="字典分组管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="DictGroupEdit.aspx.cs" Inherits="modules_system_DictGroupEdit" %>
<%@ Register src="../common/Prompt.ascx" tagname="Prompt" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<a href="DictGroupList.aspx">返回</a>
	<asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">保存</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <uc1:Prompt ID="promptControl" runat="server" />
    <asp:PlaceHolder ID="container" runat="server">
		<table border="0" cellpadding="2" cellspacing="0" class="admin-edit-table">
			<tr>
				<td class="th">字典组名称</td>
				<td class="td"><asp:TextBox ID="Name" runat="server" CssClass="textbox" Width="200px" MaxLength="32"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="Name"></asp:RequiredFieldValidator>
			</tr>
			<tr>
				<td class="th">字典组编码</td>
				<td class="td"><asp:TextBox ID="Code" runat="server" CssClass="textbox" Width="200px" MaxLength="32"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="Code"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
							runat="server" ControlToValidate="Code" Display="Dynamic" ErrorMessage="应输入英文或数字，最长32位"
							ValidationExpression="\w+"></asp:RegularExpressionValidator></td>
			</tr>
			<tr>
				<td class="th">展示方式</td>
				<td class="td">
                    <asp:DropDownList ID="DisplayMode" runat="server">
						<asp:ListItem Text="DropDownList">下拉列表</asp:ListItem>
                    </asp:DropDownList>
                 </td>
			</tr>
			<tr>
				<td class="th">是否启用</td>
				<td class="td">
					<asp:CheckBox runat="server" ID="IsEnabled" Checked="True"/>
                 </td>
			</tr>
            <tr>
				<td class="th">备注</td>
				<td class="td">
                    <asp:TextBox ID="Memo" runat="server" CssClass="textbox" Width="99%"></asp:TextBox>
                </td>
			</tr>
		</table>
		<asp:HiddenField ID="Id" runat="server" />
		<asp:HiddenField ID="OldCode" runat="server" />
	</asp:PlaceHolder>
</asp:Content>

