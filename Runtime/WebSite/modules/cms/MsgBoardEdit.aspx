<%@ Page Title="留言板信息" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="MsgBoardEdit.aspx.cs" Inherits="modules_cms_MsgBoardEdit" %>
<%@ Register Src="../common/Prompt.ascx" TagName="Prompt" TagPrefix="zx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.config.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.all.js"> </script>
	<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="MsgBoardList.aspx"><i class="fa fa-arrow-left"></i>返回</a></li>
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
				<td class="th">广告位置</td>
				<td class="td">
					<asp:DropDownList ID="Position" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Position_OnSelectedIndexChanged"></asp:DropDownList></td>
			</tr>
			<tr>
				<td class="th">名称</td>
				<td class="td">
					<asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
					<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="th">头部Banner</td>
				<td class="td">
					<table cellpadding="0" cellspacing="0" style="border: 0;">
						<tr>
							<td>
								<asp:FileUpload ID="BannerImage" runat="server" Width="400px" />
								<div class="caption">注：支持 .jpg .png .bmp .gif 格式的图片。</div>
							</td>
							<td style="padding: 4px">
								<asp:HyperLink ID="ImageHyperLink" runat="server" CssClass="thumb-link" Target="_blank">
									<asp:Image ID="PreviewImage" runat="server" Width="70px" Height="40px" Visible="false" CssClass="thumb-image" />
								</asp:HyperLink>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td class="th">宣传大图</td>
				<td class="td">
					<table cellpadding="0" cellspacing="0" style="border: 0;">
						<tr>
							<td>
								<asp:FileUpload ID="BannerCover" runat="server" Width="400px" />
								<div class="caption">注：支持 .jpg .png .bmp .gif 格式的图片。</div>
							</td>
							<td style="padding: 4px">
								<asp:HyperLink ID="CoverHyperLink" runat="server" CssClass="thumb-link" Target="_blank">
									<asp:Image ID="PreviewCover" runat="server" Width="70px" Height="40px" Visible="false" CssClass="thumb-image" />
								</asp:HyperLink>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td class="th">链接</td>
				<td class="td">
					<asp:TextBox ID="Url" runat="server" CssClass="form-control" MaxLength="1024"></asp:TextBox></td>
			</tr>
			<tr>
				<td class="th">排序</td>
				<td class="td">
					<asp:TextBox ID="Sort" runat="server" CssClass="form-control" Width="100px" MaxLength="6"></asp:TextBox></td>
			</tr>
			<asp:PlaceHolder runat="server" ID="phCover" Visible="False">
				<tr>
					<td class="th">时效</td>
					<td class="td">
						开始时间：<asp:TextBox ID="StartDate" runat="server" CssClass="form-control" Width="120px"></asp:TextBox> - 结束时间：<asp:TextBox ID="EndDate" runat="server" CssClass="form-control" Width="120px"></asp:TextBox>
						<script type="text/javascript">
							$('#<%= this.StartDate.ClientID %>').datepicker({});
							$('#<%= this.EndDate.ClientID %>').datepicker({});
						</script>
					</td>
				</tr>
				<tr>
					<td class="th">附加样式</td>
					<td class="td">
						<asp:TextBox ID="Css" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox></td>
				</tr>
				<tr>
					<td class="th">附加脚本</td>
					<td class="td">
						<asp:TextBox ID="Script" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox></td>
				</tr>
			</asp:PlaceHolder>
		</table>
		<asp:HiddenField ID="Id" runat="server" />
	</asp:PlaceHolder>
</asp:Content>

