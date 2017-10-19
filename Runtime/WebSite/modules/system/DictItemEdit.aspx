<%@ Page Title="字典数据管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="DictItemEdit.aspx.cs" Inherits="modules_system_DictItemEdit" %>
<%@ Import Namespace="NPiculet.Toolkit" %>
<%@ Register Src="../common/Prompt.ascx" TagName="Prompt" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="header">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="DictItemList.aspx?group=<%= WebParmKit.GetQuery("group", "") %>&fix=<%= WebParmKit.GetQuery("fix", "") %>"><i class="fa fa-arrow-left"></i>返回</a></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="fa fa-check"></i>保存</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<uc:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="container" runat="server">
		<table class="table table-primary">
			<tr>
				<td class="th">字典组</td>
				<td class="td">
					<asp:DropDownList runat="server" ID="GroupCode" CssClass="form-control"/>
				</td>
			</tr>
			<tr>
				<td class="th">字典项名称</td>
				<td class="td">
					<asp:TextBox ID="Name" runat="server" CssClass="form-control" Width="200px" MaxLength="32"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="Name">
					</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">字典项编码</td>
				<td class="td">
					<asp:TextBox ID="Code" runat="server" CssClass="form-control" Width="200px" MaxLength="32"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="Code"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">属性值</td>
				<td class="td">
					<asp:TextBox ID="Value" runat="server" CssClass="form-control" Width="200px" MaxLength="255"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th">排序</td>
				<td class="td">
					<asp:TextBox ID="OrderBy" runat="server" CssClass="form-control" Width="200px" MaxLength="8"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th">是否启用</td>
				<td class="td">
					<asp:CheckBox runat="server" ID="IsEnabled" Checked="True" />
				</td>
			</tr>
			<tr>
				<td class="th">备注</td>
				<td class="td">
					<asp:TextBox ID="Memo" runat="server" CssClass="form-control" Width="99%"></asp:TextBox>
				</td>
			</tr>
		</table>
		<asp:HiddenField ID="Id" runat="server" />
	</asp:PlaceHolder>
</asp:Content>

