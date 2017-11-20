<%@ Page Title="留言板组编辑" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MsgBoardGroupEdit.aspx.cs" Inherits="modules_cms_MsgBoardGroupEdit" %>
<%@ Register Src="../common/Prompt.ascx" TagName="Prompt" TagPrefix="zx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="MsgBoardGroupList.aspx"><i class="fa fa-arrow-left"></i>返回</a></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="fa fa-check"></i>保存</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">
	<zx:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="editor" runat="server">
		<table class="table table-primary">
			<tr>
				<td class="th">名称</td>
				<td class="td">
					<asp:TextBox ID="Name" runat="server" CssClass="form-control" MaxLength="64"></asp:TextBox>
					<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="Name" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">编码</td>
				<td class="td">
					<asp:TextBox ID="Code" runat="server" CssClass="form-control" MaxLength="64"></asp:TextBox>
					<asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="Code" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
				</td>
			</tr>
		</table>
		<asp:HiddenField ID="Id" runat="server" />
		<asp:HiddenField ID="Config" runat="server" />
	</asp:PlaceHolder>

	<asp:PlaceHolder ID="phFields" runat="server">
		<asp:GridView runat="server" ID="fields" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="Type"
			CssClass="table table-primary" OnRowDataBound="fields_OnRowDataBound" OnRowDeleting="fields_OnRowDeleting" OnRowCommand="fields_OnRowCommand">
			<Columns>
				<asp:TemplateField HeaderText="自定义字段">
					<ItemTemplate>
						<asp:TextBox runat="server" ID="Name" CssClass="form-control" Text='<%# Eval("Name") %>'></asp:TextBox>
					</ItemTemplate>
					<FooterTemplate>
						<asp:TextBox runat="server" ID="Name" CssClass="form-control"></asp:TextBox>
					</FooterTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="编码">
					<ItemTemplate>
						<asp:TextBox runat="server" ID="Code" CssClass="form-control" Text='<%# Eval("Code") %>'></asp:TextBox>
					</ItemTemplate>
					<FooterTemplate>
						<asp:TextBox runat="server" ID="Code" CssClass="form-control"></asp:TextBox>
					</FooterTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="类型">
					<ItemTemplate>
						<asp:DropDownList runat="server" ID="Type" CssClass="form-control"></asp:DropDownList>
						<%--<asp:TextBox runat="server" ID="Type" CssClass="form-control" Text='<%# Eval("Type") %>'></asp:TextBox>--%>
					</ItemTemplate>
					<FooterTemplate>
						<asp:DropDownList runat="server" ID="Type" CssClass="form-control"></asp:DropDownList>
					</FooterTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="展示">
					<ItemTemplate>
						<asp:CheckBox runat="server" ID="Show" Checked='<%# Eval("Show") %>'/>
					</ItemTemplate>
					<FooterTemplate>
						<asp:CheckBox runat="server" ID="Show" Checked="True"/>
					</FooterTemplate>
				</asp:TemplateField>
				<asp:TemplateField>
					<ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
					<ItemTemplate>
						<asp:LinkButton runat="server" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' Text="删除" OnClientClick="return confirm('确定要删除吗？');"></asp:LinkButton>
					</ItemTemplate>
					<HeaderTemplate>
						<asp:LinkButton ID="btnSaveField" runat="server" OnClick="btnSaveField_Click">保存</asp:LinkButton>
					</HeaderTemplate>
					<FooterStyle Width="80px" HorizontalAlign="Center"></FooterStyle>
					<FooterTemplate>
						<asp:LinkButton runat="server" CommandName="Add" Text="新增"></asp:LinkButton>
					</FooterTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</asp:PlaceHolder>
</asp:Content>
