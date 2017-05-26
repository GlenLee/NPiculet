<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="PageMemberView.aspx.cs" Inherits="web_PageMemberView" %>
<%@ Register TagPrefix="uc1" TagName="WebQuote" Src="~/web/uc/WebQuote.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="renderer" content="webkit|ie-stand|ie-comp" />
	<uc1:WebQuote runat="server" ID="WebQuote" />
</head>
<body>

	<asp:PlaceHolder ID="editor" runat="server">

		<asp:PlaceHolder runat="server" ID="CorpInfo">
			<table class="sui-table table-primary">
				<tr>
					<th colspan="6">企业资料</th>
				</tr>
				<tr>
					<td class="th">单位名称</td>
					<td class="td">
						<asp:Literal runat="server" ID="CorporationName"></asp:Literal>
					</td>
					<td class="th">经营简称</td>
					<td class="td">
						<asp:Literal runat="server" ID="CorporationBreifName"></asp:Literal>
					</td>
				</tr>

				<tr>
<%--					<td class="th">单位电话</td>
					<td class="td">
						<asp:Literal runat="server" ID="CorporationTel"></asp:Literal>
					</td>--%>
					<td class="th">法人姓名</td>
					<td class="td">
						<asp:Literal runat="server" ID="BodyCorporate"></asp:Literal>
					</td>
					<td class="th">负责人姓名</td>
					<td class="td">
						<asp:Literal runat="server" ID="ChargeMan"></asp:Literal>
					</td>
				</tr>

				<tr>
					<td class="th">企业性质</td>
					<td class="td" colspan="3">
						<asp:Literal ID="CorporationNature" runat="server"></asp:Literal>
					</td>
				</tr>

				<tr>
					<td class="th">经营地址</td>
					<td class="td" colspan="3">
						<asp:Literal runat="server" ID="CorporationAddress"></asp:Literal>
					</td>
				</tr>

				<tr>
					<td class="th">企业简介</td>
					<td class="td" colspan="3">
						<asp:Literal ID="CorporationIntro" runat="server"></asp:Literal>
					</td>
				</tr>

			</table>
		</asp:PlaceHolder>

		<asp:PlaceHolder runat="server" ID="CorpQualification" Visible="false">
			<table class="sui-table table-primary">
				<tr>
					<th colspan="6">企业资质</th>
				</tr>
				<tr>
					<td class="th">营业执照</td>
					<td class="td">
						<asp:Image runat="server" ID="BusinessLicences" />
					</td>
				</tr>
				<tr>
					<td class="th">文化经营许可证</td>
					<td class="td">
						<asp:Image runat="server" ID="InternetCulture" />
					</td>
				</tr>
				<tr>
					<td class="th">公安审核批准文件</td>
					<td class="td">
						<asp:Image runat="server" ID="ApprovalDocument" />
					</td>
				</tr>

				<tr>
					<td class="th">消防安全审查合格证</td>
					<td class="td">
						<asp:Image runat="server" ID="FireSafety" />
					</td>
				</tr>

				<tr>
					<td class="th">法人身份证（正面，头像面）</td>
					<td class="td">
						<asp:Image runat="server" ID="BodyCorporateIdView" />
					</td>
				</tr>
			</table>
			<table class="sui-table table-primary">
				<tr>
					<th colspan="6">企业资料</th>
				</tr>
				<tr>
					<td class="th">招牌图片</td>
					<td class="td">
						<asp:Image runat="server" ID="BillboardView" />
					</td>
				</tr>

				<tr>
					<td class="th">入口招牌</td>
					<td class="td">
						<asp:Image runat="server" ID="EnterView" />
					</td>
				</tr>
				<tr>
					<td class="th">全体员工合影照</td>
					<td class="td">
						<asp:Image runat="server" ID="AllStaffForegroundView" />
					</td>
				</tr>

				<tr>
					<td class="th">负责人吧台照</td>
					<td class="td">
						<asp:Image runat="server" ID="ChargForegroundView" />
					</td>
				</tr>
				<tr>
					<td class="th">前台照片</td>
					<td class="td">
						<asp:Image runat="server" ID="ForegroundView" />
					</td>
				</tr>

				<tr>
					<td class="th">大厅全景照</td>
					<td class="td">
						<asp:Image runat="server" ID="HallPanoramicView" />
					</td>
				</tr>

				<tr>
					<td class="th">大厅照片</td>
					<td class="td">
						<asp:Image runat="server" ID="HallView" />
					</td>
				</tr>
			</table>
		</asp:PlaceHolder>
	</asp:PlaceHolder>

</body>
</html>
