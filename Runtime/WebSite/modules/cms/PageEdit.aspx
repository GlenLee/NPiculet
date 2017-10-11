<%@ Page Title="" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="PageEdit.aspx.cs" Inherits="modules_cms_PageEdit" %>
<%@ Register TagPrefix="zx" TagName="Prompt" Src="~/modules/common/Prompt.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.config.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.all.js"> </script>
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><%= GetBackUrl() %></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="save()"><i class="sui-icon icon-tb-check"></i>保存</asp:LinkButton></li>
			<li><asp:HyperLink ID="btnView" runat="server" Target="_blank"><i class="sui-icon icon-tb-activity"></i>预览</asp:HyperLink></li>
			<li><asp:LinkButton ID="btnPublish" runat="server" OnClick="btnPublish_Click" OnClientClick="return confirm('确定发布？只有在发布后文章才能被看到。');"><i class="sui-icon icon-tb-activity"></i>发布</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<zx:Prompt ID="promptControl" runat="server" />
	<asp:PlaceHolder ID="editor" runat="server">
		<table class="table table-primary">
			<tr>
				<td class="th">栏目</td>
				<td class="td"><asp:Literal ID="GroupName" runat="server"></asp:Literal></td>
			</tr>
			<tr>
				<td class="th">主标题</td>
				<td class="td">
					<asp:TextBox ID="InfoTitle" runat="server" CssClass="form-control" Width="98%" MaxLength="256"></asp:TextBox>
					<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="InfoTitle" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">副标题</td>
				<td class="td">
					<asp:TextBox ID="SubTitle" runat="server" CssClass="form-control" Width="98%" MaxLength="256"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">作者</td>
				<td class="td">
					<asp:TextBox ID="Author" runat="server" CssClass="form-control" Width="98%" MaxLength="256"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="th">来源</td>
				<td class="td">
					<asp:TextBox ID="Source" runat="server" CssClass="form-control" Width="98%" MaxLength="256"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td></td>
				<td>
					<input runat="server" id="teest" class="magic-checkbox"/><label for="<%= this.teest.ClientID %>">发布</label>
				</td>
			</tr>
			<tr>
				<td class="th">设置</td>
				<td class="td">
					<asp:CheckBox runat="server" ID="IsEnabled"/> <label for="<%= this.IsEnabled.ClientID %>">发布</label>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:CheckBox runat="server" ID="OrderBy" CssClass="magic-checkbox"/> <label for="<%= this.OrderBy.ClientID %>">置顶</label>
				</td>
			</tr>
			<asp:PlaceHolder runat="server" ID="phThumb">
				<tr>
					<td class="th">缩略图</td>
					<td class="td">
						<table cellpadding="0" cellspacing="0" style="border:0;">
							<tr>
								<td>
									<asp:FileUpload ID="Thumb" runat="server" Width="400px" />
									<div class="caption">注：支持 .jpg .png .bmp .gif 格式的图片，图片大于1024x1024会自动压缩。</div>
								</td>
								<td style="padding:4px">
									<asp:HyperLink ID="ThumbHyperLink" runat="server" CssClass="thumb-link" Target="_blank">
										<asp:Image ID="PreviewThumb" runat="server" Width="40px" Height="40px" Visible="false" CssClass="thumb-image" />
									</asp:HyperLink>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</asp:PlaceHolder>
			<tr>
				<td class="th">内容</td>
				<td class="td" style="height:300px; overflow:scroll">
					<script id="editorContent" type="text/plain" style="width:90%;height:300px;"></script>
					<asp:HiddenField runat="server" ID="Content"/>
				</td>
			</tr>
		</table>
		<asp:HiddenField ID="Id" runat="server" />
		<script type="text/javascript">
			var editor = UE.getEditor('editorContent');
			var contentControl = document.getElementById("<%= this.Content.ClientID %>");

			editor.addListener("ready", function () {
				editor.setHeight(300);
				editor.setContent(contentControl.value);
			});

			function save() {
				contentControl.value = editor.getContent();
			}
		</script>
	</asp:PlaceHolder>
</asp:Content>
