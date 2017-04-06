<%@ Page Title="编辑资讯" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="modules_news_NewsEdit" ValidateRequest="false" %>
<%@ Register TagPrefix="zx" TagName="Prompt" Src="~/modules/common/Prompt.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<a href="NewsList.aspx?code=<%= this.GroupCode %>">返回</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<zx:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="editor" runat="server">
		<table border="0" cellpadding="2" cellspacing="0" class="admin-edit-table">
			<tr>
				<td class="th">栏目</td>
				<td class="td"><asp:Literal ID="GroupName" runat="server"></asp:Literal></td>
			</tr>
			<tr>
				<td class="th">标题</td>
				<td class="td">
					<asp:TextBox ID="ContentTitle" runat="server" CssClass="textbox" Width="500px" MaxLength="256"></asp:TextBox>
					<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="ContentTitle" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">缩略图</td>
				<td class="td">
					<table cellpadding="0" cellspacing="0" style="border:0;">
						<tr>
							<td>
								<asp:FileUpload ID="Thumb" runat="server" Width="400px" />
								<div class="caption">注：支持 .jpg .png .bmp .gif 格式的图片，图片大于1024会自动压缩。</div>
							</td>
							<td style="padding:4px">
								<asp:HyperLink ID="ThumbHyperLink" runat="server" CssClass="thumb-link">
									<asp:Image ID="PreviewThumb" runat="server" Width="40px" Height="40px" Visible="false" CssClass="thumb-image" />
								</asp:HyperLink>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td class="th">来源</td>
				<td class="td"><asp:TextBox ID="Source" runat="server" CssClass="textbox" Width="500px" MaxLength="256"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th">内容</td>
				<td class="td"><asp:TextBox ID="Content" runat="server" TextMode="MultiLine" Width="90%" Height="400px"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th"></td>
				<td class="td">
					<asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" OnClientClick="saveContent()">保存</asp:LinkButton>
					<asp:HiddenField ID="Id" runat="server" />
				</td>
			</tr>
		</table>
	</asp:PlaceHolder>
	<script type="text/javascript">
		var control = '<%= this.Content.ClientID %>';
		var editor = UE.getEditor(control);
		function saveContent() {
			document.getElementById(control).value = editor.getContent();
		}
	</script>
</asp:Content>

