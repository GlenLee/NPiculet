<%@ Page Title="字典分组管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="DictGroupEdit.aspx.cs" Inherits="modules_system_DictGroupEdit" %>
<%@ Register src="../common/Prompt.ascx" tagname="Prompt" tagprefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="DictGroupList.aspx"><i class="sui-icon icon-tb-back"></i>返回</a></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="sui-icon icon-tb-check"></i>保存</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <uc:Prompt ID="promptControl" runat="server" />
    <asp:PlaceHolder ID="container" runat="server">
		<table class="table table-primary">
			<tr>
				<td class="th">字典组名称</td>
				<td class="td"><asp:TextBox ID="Name" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="Name"></asp:RequiredFieldValidator>
			</tr>
			<tr>
				<td class="th">字典组编码</td>
				<td class="td"><asp:TextBox ID="Code" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
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
				<td class="th">列头备注</td>
				<td class="td">
                    <asp:TextBox ID="Memo" runat="server" CssClass="input-large" Width="99%"></asp:TextBox>
                </td>
			</tr>
		</table>
		<asp:HiddenField ID="Id" runat="server" />
		<asp:HiddenField ID="OldCode" runat="server" />
	</asp:PlaceHolder>
</asp:Content>

