<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="EntRegStep2.aspx.cs" Inherits="EntRegStep2" %>

<%@ Register TagPrefix="uc1" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
	<uc1:NavMenu runat="server" ID="NavMenu" Active="-1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<!-- 步骤条 -->
	<div class="sui-steps steps-large steps-auto">
		<div class="wrap">
			<div class="current">
				<label><span class="round"><i class="sui-icon icon-pc-right"></i></span><span>第一步 填写注册信息</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
			</div>
		</div>
		<div class="wrap">
			<div class="current">
				<label><span class="round">2</span><span>第二步 完善基本资料</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
			</div>
		</div>
		<div class="wrap">
			<div class="todo">
				<label><span class="round">3</span><span>第三步 注册成功</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
			</div>
		</div>
	</div>
	<!-- 标签 -->
	<ul class="sui-nav nav-tabs nav-large nav-primary">
		<li class="active"><a>单位会员注册</a></li>
		<li><a href="RegStep1.aspx">个人会员注册</a></li>
	</ul>

	<!-- 企业注册 第二步 -->
	<div class="sui-form ui-reg step2" id="frm" runat="server">
		<div class="sui-row-fluid">
			<div class="span3 tx-al-rt"></div>
			<div class="span9">
				您好，您的账号[<asp:Literal runat="server" ID="UserAccount"></asp:Literal>]已建立，请继续填写企业相关信息！
			</div>
		</div>
		<div class="sui-row-fluid ui-member-content">
			<div class="span1"></div>
			<div class="span11 title">单位信息</div>
		</div>
		<asp:PlaceHolder runat="server" ID="CorpInfo">
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>单位名称：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="CorporationName" CssClass="input-large" placeholder="单位名称"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationName"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>经营简称：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="CorporationBreifName" CssClass="input-large" placeholder="经营简称"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationBreifName"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>单位电话：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="CorporationTel" CssClass="input-large" placeholder="单位电话"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationTel"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator3"
						runat="server" ControlToValidate="CorporationTel" Display="Dynamic" ErrorMessage="请输入正确的号码" ForeColor="red"
						ValidationExpression="\d+"></asp:RegularExpressionValidator>
				</div>
			</div>

			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>法人姓名：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="BodyCorporate" CssClass="input-large" placeholder="法人姓名"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="BodyCorporate"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>法人身份证号：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="BodyCorporateIdCard" CssClass="input-large" placeholder="法人身份证号"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="BodyCorporateIdCard"></asp:RequiredFieldValidator>
				</div>
			</div>

			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>负责人姓名：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="ChargeMan" CssClass="input-large" placeholder="法人姓名"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="ChargeMan"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>负责人电话：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="ChargeManTel" CssClass="input-large" placeholder="法人身份证号"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="ChargeManTel"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>负责人身份证号：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="ChargeManIdCard" CssClass="input-large" placeholder="法人身份证号"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="ChargeManIdCard"></asp:RequiredFieldValidator>
				</div>
			</div>

			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>企业性质：</div>
				<div class="span8">
					<asp:DropDownList ID="CorporationNature" runat="server">
					</asp:DropDownList>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>企业简介：</div>
				<div class="span8">
					<asp:TextBox TextMode="MultiLine" ID="CorporationIntro" runat="server" Width="340px" Height="60px">
					</asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationIntro"></asp:RequiredFieldValidator>
				</div>
			</div>

			<div class="sui-row-fluid">
				<div class="span4 tx-al-rt"><span style="color: red">*</span>经营地址：</div>
				<div class="span8">
					<asp:TextBox runat="server" ID="CorporationAddress" CssClass="input-xlarge" placeholder="经营地址"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
						ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationAddress"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="sui-row-fluid">
				<div class="span12" style="margin-left: 5px">
					缩放/移动地图，鼠标右键可设置位置：
				</div>
				<div class="span12" id="baidu-map" style="width: 800px; height: 400px">
				</div>
			</div>

		</asp:PlaceHolder>
		<div class="sui-row-fluid">
			<div class="span5"></div>
			<div class="span7">
				<asp:Button runat="server" ID="btnNext" CssClass="sui-btn btn-xlarge btn-warning" Text="保存" OnClick="btnNext_Click" />
			</div>
		</div>
		<div class="sui-row-fluid">
			<asp:HiddenField ID="corpRegLng" runat="server" />
			<asp:HiddenField ID="corpRegLat" runat="server" />
		</div>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=B8cb5720f21c85d3174998ae7a400f7c"></script>
	<script type="text/javascript">
		var vectorMarker = function (point) {
			return new BMap.Marker(new BMap.Point(point.lng, point.lat), {
				// 指定Marker的icon属性为Symbol
				icon: new BMap.Symbol(BMap_Symbol_SHAPE_POINT, {
					scale: 1,//图标缩放大小
					fillColor: "red",//填充颜色
					fillOpacity: 0.8//填充透明度
				})
			});
		}

		var getCorpName = function () {
			var corpName = $('#content_CorporationName').val().trim();
			if (corpName.length <= 0)
				return "您的位置";
			else
				return corpName;
		}

		if ($('#baidu-map').length > 0) {
			var map = new BMap.Map("baidu-map");
			map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
			var gectrl = new BMap.GeolocationControl({
				anchor: BMAP_ANCHOR_TOP_LEFT,
				enableAutoLocation: true
			});
			map.addControl(gectrl); //添加定位控件

			var top_right_navigation = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL });
			map.addControl(top_right_navigation); //添加控件

			var point = new BMap.Point(102.71460114, 25.0491531); //设置地图中心的位置
			map.centerAndZoom(point, 14); //设置地图元素的可视层

			map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
			map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用

			//var geolocation = new BMap.Geolocation();
			//geolocation.getCurrentPosition(function (result) {
			//    if (this.getStatus() == BMAP_STATUS_SUCCESS) {
			//        //alert("定位成功！" + result.point.lng + "," + result.point.lat);
			//        //定位
			//        var point = new BMap.Point(result.point.lng, result.point.lat);
			//        map.centerAndZoom(point, 14);
			//        //创建标注
			//        var marker = vectorMarker(point);
			//        map.addOverlay(marker);
			//        var label = new BMap.Label("您的位置", { offset: new BMap.Size(20, -10) });
			//        marker.setLabel(label);
			//    }
			//    else {
			//        alert('定位失败，请在移动地图至您的位置，单击鼠标右键进行设置。');
			//    }
			//}, { enableHighAccuracy: true });

			//var i = 0;
			//点击获取坐标
			map.addEventListener("rightclick", function (result) {

				//清除覆盖物
				map.clearOverlays();

				//在地图上面描点
				var marker = vectorMarker(result.point);  // 创建标注
				map.addOverlay(marker);
				marker.enableDragging();    //可拖拽
				var corpName = getCorpName();
				//标注企业名称
				var label = new BMap.Label(corpName, { offset: new BMap.Size(25, 5) });
				marker.setLabel(label);
				$('#content_corpRegLng').val(result.point.lng);
				$('#content_corpRegLat').val(result.point.lat);
			});
		}
	</script>
</asp:Content>
