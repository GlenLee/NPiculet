<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPage.master" AutoEventWireup="true" CodeFile="CorporationQualification.aspx.cs" Inherits="CorporationQualification" %>

<%@ Register TagPrefix="uc1" TagName="CorporationSidebar" Src="~/web/uc/CorporationSidebar.ascx" %>
<%@ Register Src="~/web/uc/ImageUpload.ascx" TagPrefix="uc1" TagName="ImageUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style type="text/css">
		.form-control {
			border: 1px solid #ccc;
			border-radius: 4px;
			padding: 4px;
		}

		.span4 {
			text-align: right;
		}
		.span6.sui-row-fluid { margin:0; }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<div class="ui-member-content">
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<div class="sui-row-fluid" style="margin-top: 10px;">
			<div class="span3">
				<uc1:CorporationSidebar ID="CorporationSidebar1" runat="server" Actived="CorporationQualification.aspx" />
			</div>

			<div class="span9">

				<asp:PlaceHolder ID="infoEditor" runat="server">

					<div class="title">企业资质</div>

					<div class="sui-row-fluid">
						<div class="span6 sui-row-fluid">
							<div class="span4">营业执照：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="BusinessLicences" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">文化经营许可证：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="InternetCulture" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">公安审核批准文件：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="ApprovalDocument" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">消防安全审查合格证：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="FireSafety" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">法人身份证（正面，头像面）：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="BodyCorporateIdView" />
							</div>
						</div>
					</div>

					<div class="title">企业资料</div>

					<div class="sui-row-fluid">
						<div class="span6 sui-row-fluid">
							<div class="span4">招牌图片：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="BillboardView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">入口招牌：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="EnterView" />
							</div>
						</div>
					</div>

					<div class="title">经营资料</div>

					<div class="sui-row-fluid">
						<div class="span6 sui-row-fluid">
							<div class="span4">全体员工合影照：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="AllStaffForegroundView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">负责人吧台照：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="ChargForegroundView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">前台照片：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="ForegroundView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">大厅全景照：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="HallPanoramicView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">大厅照片：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="HallView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">经营信息：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="ManagerView" />
							</div>
						</div>
						<div class="span6 sui-row-fluid">
							<div class="span4">收费文件：</div>
							<div class="span8">
								<uc1:ImageUpload runat="server" ID="ChargeView" />
							</div>
						</div>
					</div>

					<div class="sui-row-fluid">
						<div class="span5"></div>
						<div class="span7">
							<asp:Button runat="server" ID="btnSaveData" CssClass="sui-btn btn-xlarge btn-warning" Text="保存" OnClick="btnSaveData_Click" />
						</div>
					</div>

				</asp:PlaceHolder>
			</div>

		</div>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
