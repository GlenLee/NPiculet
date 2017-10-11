<%@ Page Title="" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="ContentTmplEdit.aspx.cs" Inherits="modules_cms_ContentTmplEdit" %>
<%@ Register Src="../common/Prompt.ascx" TagName="Prompt" TagPrefix="zx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.config.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.all.js"> </script>
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="ContentTmplList.aspx">返回</a></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="save()" CssClass="link-btn">保存</asp:LinkButton></li>
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
					<asp:TextBox ID="Name" runat="server" CssClass="form-control" Width="500px" MaxLength="512"></asp:TextBox>
					<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="Name" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">启用</td>
				<td class="td"><asp:CheckBox ID="IsEnabled" runat="server" Checked="True"></asp:CheckBox></td>
			</tr>
			<tr>
				<td class="th">排序</td>
				<td class="td"><asp:TextBox ID="Sort" runat="server" CssClass="form-control" Width="500px" MaxLength="6"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th">模板</td>
				<td class="td" style="height:300px; overflow:scroll">
					<script id="editorContent" type="text/plain" style="width:90%;height:300px;"></script>
					<asp:HiddenField runat="server" ID="Template"/>
				</td>
			</tr>
		</table>
		<script type="text/javascript">
			var editor = UE.getEditor('editorContent');
			var contentControl = document.getElementById("<%= this.Template.ClientID %>");

			editor.addListener("ready", function () {
				editor.setHeight(300);
				editor.setContent(contentControl.value);
			});

			function save() {
				contentControl.value = editor.getContent();
			}
		</script>
		<asp:HiddenField ID="Id" runat="server" />
	</asp:PlaceHolder>
	<asp:PlaceHolder ID="phFields" runat="server">
		<div class="panel panel-info" id="_userList" runat="server">
			<div class="panel-heading">
				<h4 class="panel-title">自定义字段</h4>
			</div>
			<div class="panel-body">
				<asp:GridView runat="server" ID="fields" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="Id"
					CssClass="table table-primary" OnRowDeleting="fields_OnRowDeleting" OnRowCommand="fields_OnRowCommand">
					<Columns>
						<asp:TemplateField HeaderText="名称">
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
								<asp:TextBox runat="server" ID="Type" CssClass="form-control" Text='<%# Eval("Type") %>'></asp:TextBox>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox runat="server" ID="Type" CssClass="form-control"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField>
							<ItemTemplate>
								<asp:HiddenField runat="server" ID="Id" Value='<%# Eval("Id") %>'/>
								<asp:LinkButton runat="server" CommandName="Delete" Text="删除" OnClientClick="return confirm('确定要删除吗？');"></asp:LinkButton>
							</ItemTemplate>
							<FooterTemplate>
								<asp:LinkButton runat="server" CommandName="Add" Text="新增"></asp:LinkButton>
							</FooterTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
			</div>
			<div class="panel-footer">
				<asp:LinkButton ID="btnSaveField" runat="server" OnClick="btnSaveField_Click" CssClass="link-btn">保存</asp:LinkButton>
			</div>
		</div>
	</asp:PlaceHolder>
	<script>
			$("input[type=checkbox]").iCheck("check");
			$(document).ready(function () {
				$('input[type=checkbox]').iCheck({
					checkboxClass: 'icheckbox_minimal-blue',
					radioClass: 'iradio_minimal-blue',
					increaseArea: '20%'
				});
			});
	</script>
</asp:Content>
