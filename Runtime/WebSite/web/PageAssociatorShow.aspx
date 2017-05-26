<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="PageAssociatorShow.aspx.cs" Inherits="web_PageAssociatorShow" %>
<%@ Register TagPrefix="uc1" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register Src="~/web/uc/ContentPage.ascx" TagPrefix="uc1" TagName="ContentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src="<%= ResolveClientUrl("~/scripts/plugin/layer/layer.js?moth=201512019") %>" type="text/javascript" ></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
	<uc1:NavMenu runat="server" ID="NavMenu1" Active="5" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<div class="sui-row sui-row-fluid">
		<div class="span3">
			<!-- 侧边栏 开始 -->
			<uc1:ContentSidebar runat="server" ID="ContentSidebar" Active="PageAssociatorShow" />
			<!-- 侧边栏 结束 -->
		</div>
		<div class="span9">
			<div class="ui-content-nav">
				<ul class="sui-breadcrumb">
					<li>当前位置：</li>
					<li><a href="../default.aspx">首页</a></li>
					<li class="active">会议展示</li>
				</ul>
			</div>
			<div class="ui-content-split"></div>

			<asp:HiddenField ID="corpItems" runat="server" />
			<asp:PlaceHolder runat="server" ID="memberMap" Visible="false">
				<h5>颜色：<%= GetColorString() %></h5>
				<div id="memberMapView" style="width: 95%; height: 650px">
				</div>
			</asp:PlaceHolder>

			<!-- 列表 开始 -->
			<uc1:ContentPage runat="server" ID="ContentPage1" GroupCode="PageAssociatorShow" />
			<!-- 列表 结束 -->
		</div>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
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

			//标注企业名称
			var label = new BMap.Label(corpName, { offset: new BMap.Size(25, 5) });
			marker.setLabel(label);

			var openCorpDetail = function () {
				layer.open({
					type: 2,
					title: '查看会员',
					shadeClose: true,
					shade: false,
					maxmin: true,
					area: ['600px', '500px'],
					content: 'PageMemberView.aspx?key=' + sn
				});
			}

			marker.addEventListener('click', openCorpDetail);
			map.addOverlay(marker);
		}

		var showCorpsOnMap = function () {
			<%--var btn = $("#<%= btnMapView.ClientID %>");
			btn.click();--%>
			var $corpItems = $("#content_corpItems").val();
			if ($corpItems != null && $corpItems !== '') {
				var dataObj = eval("(" + $corpItems + ")"); //转换为json对象

				//遍历json数组
				$.each(dataObj, function (i, item) {
					addCorpToMap(item.lng, item.lat, item.color, item.name, item.sn);
				});
			}
		};

		$(document).ready(function () {
			if ($('#memberMapView').length > 0) {
				map = new BMap.Map("memberMapView");
				map.addControl(new BMap.MapTypeControl()); //添加地图类型控件
				var gectrl = new BMap.GeolocationControl({
					anchor: BMAP_ANCHOR_TOP_LEFT,
					enableAutoLocation: true
				});
				map.addControl(gectrl); //添加定位控件

				var top_right_navigation = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL });
				map.addControl(top_right_navigation); //添加控件

				var point = new BMap.Point(102.71460114, 25.0491531); //设置地图中心的位置
				map.centerAndZoom(point, 14); //设置地图元素的可视层

				map.enableScrollWheelZoom(); //启用滚轮放大缩小，默认禁用
				map.enableContinuousZoom(); //启用地图惯性拖拽，默认禁用

				showCorpsOnMap();
			}
		});

	</script>
</asp:Content>
