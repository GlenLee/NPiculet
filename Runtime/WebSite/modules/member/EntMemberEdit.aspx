<%@ Page Title="" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="EntMemberEdit.aspx.cs" Inherits="modules.member.ModulesMemberEntMemberEdit" %>
<%@ Register Src="../common/Prompt.ascx" TagName="Prompt" TagPrefix="prmuc1" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>
<%@ Register Src="~/web/uc/ImageUpload.ascx" TagPrefix="uc1" TagName="ImageUpload" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="header">
	<style type="text/css">
		.org-list table {
			width: 100%;
		}

		.org-list table td {
			width: 20%;
		}

		.role-list table {
			width: 100%;
		}

		.role-list table td {
			width: 20%;
		}

		.form-control {
			border: 1px solid #ccc;
			border-radius: 4px;
			padding: 4px;
		}

		.span2 {
			text-align: right;
		}
		/* UserControl */
		.uc-image-upload { /* width:220px; */
			height: 140px;
			border: 1px dashed #eee;
			overflow: hidden;
		}

		.uc-image-upload img {
			width: 220px;
			border: 0;
			cursor: pointer;
		}

		.uc-image-upload .controls {
			display: none;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$(".chkbox-switch>input").bootstrapSwitch({ onText: '是', offText: '否', offColor: 'danger', size: 'normal' });
		});
		function addOrg() {
			OpenModel("../common/OrgDialog.aspx", 400, 500, function (result) {
				if (result && result.length > 0)
					__doPostBack('addOrg', result);
			});
		}
		function addRole() {
			OpenModel("../common/RoleDialog.aspx", 400, 500, function (result) {
				if (result && result.length > 0)
					__doPostBack('addRole', result);
			});
		}
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="EntMemberList.aspx"><i class="sui-icon icon-tb-back"></i>返回</a></li>
			<li>
				<asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="sui-icon icon-tb-check"></i>保存</asp:LinkButton>
			</li>
			<li>
				<asp:LinkButton ID="btnPass" runat="server" OnClick="btnPass_Click"><i class="sui-icon icon-tb-check"></i>审核</asp:LinkButton>
			</li>
			<li>
				<asp:LinkButton ID="LinkButton3" runat="server" CssClass="sui-btn btn-small btn-danger" OnClick="btnShowQualification_Click">查看资质</asp:LinkButton>
			</li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" runat="Server">
	<prmuc1:Prompt ID="promptControl" runat="server" />
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>

			<asp:PlaceHolder ID="editor" runat="server">
				<table class="sui-table table-primary">
					<tr>
						<th colspan="4">基本信息</th>
					</tr>
					<tr>
						<td class="th">帐号</td>
						<td class="td">
							<asp:TextBox ID="Account" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
								ErrorMessage="必填" ForeColor="red" ControlToValidate="Account"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
								runat="server" ControlToValidate="Account" Display="Dynamic" ErrorMessage="应输入英文或数字，最长32位"
								ValidationExpression="\w+" ForeColor="red"></asp:RegularExpressionValidator>
						</td>
						<td class="th">密码</td>
						<td class="td">
							<asp:TextBox ID="Password" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
								ErrorMessage="必填" ForeColor="red" ControlToValidate="Password"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator2"
								runat="server" ControlToValidate="Password" Display="Dynamic" ErrorMessage="应输入英文或数字，最长32位"
								ValidationExpression="\w+"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">姓名</td>
						<td class="td">
							<asp:TextBox ID="Name" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
								ErrorMessage="必填" ForeColor="red" ControlToValidate="Name"></asp:RequiredFieldValidator></td>
						<td class="th">积分</td>
						<td class="td">
							<asp:Literal runat="server" ID="PointCurrent">0</asp:Literal>
							/
                            <asp:Literal runat="server" ID="PointTotal">0</asp:Literal></td>
					</tr>
					<tr>
						<td class="th">是否启用</td>
						<td class="td">
							<asp:CheckBox runat="server" ID="IsEnabled" Checked="True" CssClass="chkbox-switch" /></td>
					</tr>
				</table>
				<table class="sui-table table-primary">
					<tr>
						<th colspan="6">用户资料</th>
					</tr>
					<tr>
						<td class="th">昵称</td>
						<td class="td">
							<asp:TextBox ID="Nickname" runat="server" CssClass="input-large" Width="200px" MaxLength="64"></asp:TextBox>
						</td>
						<td class="th">性别</td>
						<td class="td">
							<asp:RadioButtonList runat="server" ID="Sex" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem>男</asp:ListItem>
								<asp:ListItem>女</asp:ListItem>
							</asp:RadioButtonList>
						</td>
						<td class="th">生日</td>
						<td class="td">
							<asp:TextBox ID="Birthday" runat="server" CssClass="easyui-datebox" Width="200px" MaxLength="32"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">住址</td>
						<td class="td">
							<asp:TextBox ID="Address" runat="server" CssClass="input-large" Width="200px" MaxLength="255"></asp:TextBox></td>
						<td class="th">手机</td>
						<td class="td">
							<asp:TextBox ID="Mobile" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox></td>
						<td class="th">邮箱</td>
						<td class="td">
							<asp:TextBox ID="Email" runat="server" CssClass="input-large" Width="200px" MaxLength="32"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="格式不正确" ControlToValidate="Email" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">QQ</td>
						<td class="td">
							<asp:TextBox ID="QQ" runat="server" CssClass="input-large" Width="200px" MaxLength="16"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="QQ" Display="Dynamic" ErrorMessage="格式不正确" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
						</td>
						<td class="th">教育程度</td>
						<td class="td">
							<asp:TextBox ID="Education" runat="server" CssClass="input-large" Width="200px" MaxLength="64"></asp:TextBox>
						</td>
					</tr>
				</table>

				<asp:PlaceHolder runat="server" ID="CorpInfo">
					<table class="sui-table table-primary">
						<tr>
							<th colspan="6">企业资料</th>
						</tr>
						<tr>
							<td class="th">单位名称</td>
							<td class="td">
								<asp:TextBox runat="server" ID="CorporationName" CssClass="input-large" placeholder="单位名称"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationName"></asp:RequiredFieldValidator>
							</td>
							<td class="th">经营简称</td>
							<td class="td">
								<asp:TextBox runat="server" ID="CorporationBreifName" CssClass="input-large" placeholder="经营简称"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationBreifName"></asp:RequiredFieldValidator>
							</td>
						</tr>

						<tr>
							<td class="th">单位电话</td>
							<td class="td">
								<asp:TextBox runat="server" ID="CorporationTel" CssClass="input-large" placeholder="单位电话"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationTel"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="RegularExpressionValidator5"
									runat="server" ControlToValidate="CorporationTel" Display="Dynamic" ErrorMessage="请输入正确的号码" ForeColor="red"
									ValidationExpression="\d+"></asp:RegularExpressionValidator>
							</td>
							<td class="th">法人姓名</td>
							<td class="td">
								<asp:TextBox runat="server" ID="BodyCorporate" CssClass="input-large" placeholder="法人姓名"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="BodyCorporate"></asp:RequiredFieldValidator>
							</td>
						</tr>

						<tr>
							<td class="th">法人身份证号</td>
							<td class="td">
								<asp:TextBox runat="server" ID="BodyCorporateIdCard" CssClass="input-large" placeholder="法人身份证号"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="BodyCorporateIdCard"></asp:RequiredFieldValidator>
							</td>
							<td class="th">负责人姓名</td>
							<td class="td">
								<asp:TextBox runat="server" ID="ChargeMan" CssClass="input-large" placeholder="负责人姓名"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="ChargeMan"></asp:RequiredFieldValidator>
							</td>
						</tr>

						<tr>
							<td class="th">负责人电话</td>
							<td class="td">
								<asp:TextBox runat="server" ID="ChargeManTel" CssClass="input-large" placeholder="负责人电话"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="ChargeManTel"></asp:RequiredFieldValidator>
							</td>
							<td class="th">负责人身份证号</td>
							<td class="td">
								<asp:TextBox runat="server" ID="ChargeManIdCard" CssClass="input-large" placeholder="负责人身份证号"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="ChargeManIdCard"></asp:RequiredFieldValidator>
							</td>
						</tr>

						<tr>
							<td class="th">企业性质</td>
							<td class="td">
								<asp:DropDownList ID="CorporationNature" runat="server">
								</asp:DropDownList>
							</td>
							<td class="th">企业简介</td>
							<td class="td">
								<asp:TextBox TextMode="MultiLine" ID="CorporationIntro" runat="server" Width="340px" Height="60px">
								</asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationIntro"></asp:RequiredFieldValidator>
							</td>
						</tr>

						<tr>
							<td class="th">经营地址</td>
							<td class="td">
								<asp:TextBox runat="server" ID="CorporationAddress" CssClass="input-xlarge" placeholder="经营地址"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic"
									ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationAddress"></asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<asp:HiddenField ID="Altitudes" runat="server" />
							<asp:HiddenField ID="longitude" runat="server" />
							<asp:HiddenField ID="CorpColor" runat="server" />

							<td class="th">地图</td>
							<td class="td" colspan="5">
								<div class="sui-row-fluid">
									<div class="span12" style="margin-left: 5px">
									</div>
									<div class="span12" id="baidu-map" style="width: 800px; height: 400px">
									</div>
								</div>
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
								<uc1:ImageUpload runat="server" ID="BusinessLicences" />
							</td>
						</tr>
						<tr>
							<td class="th">文化经营许可证</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="InternetCulture" />
							</td>
						</tr>
						<tr>
							<td class="th">公安审核批准文件</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="ApprovalDocument" />
							</td>
						</tr>

						<tr>
							<td class="th">消防安全审查合格证</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="FireSafety" />
							</td>
						</tr>

						<tr>
							<td class="th">法人身份证（正面，头像面）</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="BodyCorporateIdView" />
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
								<uc1:ImageUpload runat="server" ID="BillboardView" />
							</td>
						</tr>

						<tr>
							<td class="th">入口招牌</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="EnterView" />
							</td>
						</tr>
						<tr>
							<td class="th">全体员工合影照</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="AllStaffForegroundView" />
							</td>
						</tr>

						<tr>
							<td class="th">负责人吧台照</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="ChargForegroundView" />
							</td>
						</tr>
						<tr>
							<td class="th">前台照片</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="ForegroundView" />
							</td>
						</tr>

						<tr>
							<td class="th">大厅全景照</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="HallPanoramicView" />
							</td>
						</tr>

						<tr>
							<td class="th">大厅照片</td>
							<td class="td">
								<uc1:ImageUpload runat="server" ID="HallView" />
							</td>
						</tr>
					</table>
				</asp:PlaceHolder>
			</asp:PlaceHolder>

			<asp:GridView runat="server" ID="details" Width="100%" AutoGenerateColumns="False" CssClass="sui-table table-primary">
				<Columns>
					<asp:TemplateField HeaderText="序号">
						<HeaderStyle Width="50px" />
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate><%# Container.DisplayIndex + 1 %></ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="ActionType" HeaderText="类型">
						<HeaderStyle Width="120px" />
					</asp:BoundField>
					<asp:BoundField DataField="TargetCode" HeaderText="目标码">
						<HeaderStyle Width="160px" />
					</asp:BoundField>
					<asp:BoundField DataField="Comment" HeaderText="日志类型"></asp:BoundField>
					<asp:BoundField DataField="Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="创建时间">
						<HeaderStyle Width="160px" />
					</asp:BoundField>
				</Columns>
			</asp:GridView>
			<cc1:NPager ID="NPager1" runat="server" />
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="baiduMap" runat="Server">
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=B8cb5720f21c85d3174998ae7a400f7c"></script>
	<script type="text/javascript">
		var map;

		var vectorMarker = function (lng, lat, color) {
			return new BMap.Marker(new BMap.Point(lng, lat), {
				// 指定Marker的icon属性为Symbol
				icon: new BMap.Symbol(BMap_Symbol_SHAPE_POINT, {
					scale: 1,//图标缩放大小
					fillColor: color,//填充颜色
					fillOpacity: 0.8//填充透明度
				})
			});
		}

		var addCorpToMap = function (lng, lat, color, corpName, sn) {
			//在地图上面描点
			var marker = vectorMarker(lng, lat, color);
			map.addOverlay(marker);

			//标注企业名称
			var label = new BMap.Label(corpName, { offset: new BMap.Size(25, 5) });
			marker.setLabel(label);
		}

		if ($('#baidu-map').length > 0) {
			map = new BMap.Map("baidu-map");
			map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
			var gectrl = new BMap.GeolocationControl({
				anchor: BMAP_ANCHOR_TOP_LEFT,
				enableAutoLocation: true
			});
			map.addControl(gectrl); //添加定位控件

			var top_right_navigation = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL });
			map.addControl(top_right_navigation); //添加控件

			map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
			map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用.

			var lng = $('#<%=longitude.ClientID%>').val();
            var lat = $('#<%=Altitudes.ClientID%>').val();
        	var name = $('#<%=CorporationBreifName.ClientID%>').val();
        	var color = $('#<%=CorpColor.ClientID%>').val();

        	addCorpToMap(lng, lat, color, name);

        	var point = new BMap.Point(lng, lat); //设置地图中心的位置
        	map.centerAndZoom(point, 14); //设置地图元素的可视层
        }

	</script>
</asp:Content>
