<%@ Page Title="企业会员管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="EntMemberList.aspx.cs" Inherits="modules.member.ModulesMemberEntMemberList" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content runat="server" ContentPlaceHolderID="header">
	<script>
		$(document).ready(function () {
			$('.dropdown').dropdown({ transition: 'drop' });
		});
	</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton runat="server" ID="btnListView" OnClick="btnListView_Click" Text="列表"></asp:LinkButton></li>
			<li><asp:LinkButton runat="server" ID="btnMapView" OnClick="btnMapView_Click" Text="地图"></asp:LinkButton></li>
			<li><a href="MemberEdit.aspx"><i class="sui-icon icon-tb-add"></i>新增</a></li>
			<li><asp:LinkButton runat="server" ID="btnBatchApprove" OnClick="btnBatchApprove_Click" Text="批量审批"></asp:LinkButton></li>
			<%--<li><asp:LinkButton runat="server" ID="btnDel" Text="删除"></asp:LinkButton></li>--%>
			<%--<li><asp:LinkButton runat="server" ID="btnResetPass" Text="重设密码"></asp:LinkButton></li>--%>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" runat="Server">
	<div class="searchbar-wrap">
		<ul class="searchbar-wrap">
			<li>
				<asp:Label ID="MemberStatus" runat="server">会员状态：</asp:Label>
				<asp:DropDownList ID="ddlStatus" runat="server" Width="200px">
				</asp:DropDownList>
			</li>
			<li>
				<asp:TextBox ID="txtKeywords" runat="server" Width="200px" placeholder="帐号/名称"></asp:TextBox>
			</li>
			<li>
				<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索"></asp:Button>
			</li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<asp:PlaceHolder runat="server" ID="memberList">

		<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id"
			OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
			<PagerSettings Mode="NumericFirstLast" />
			<RowStyle HorizontalAlign="Center" />
			<Columns>
				<asp:TemplateField>
					<HeaderStyle Width="30px" />
					<ItemTemplate>
						<asp:CheckBox ID="checkBox" runat="server" Checked="false" />
					</ItemTemplate>
					<HeaderTemplate>
						<input id="CheckAll" type="checkbox" onclick="selectAll(this);" />
					</HeaderTemplate>
				</asp:TemplateField>

				<asp:BoundField DataField="Id" HeaderText="Id" Visible="false">
					<HeaderStyle Width="160px" />
				</asp:BoundField>
				<asp:BoundField DataField="Account" HeaderText="帐号">
					<HeaderStyle Width="100px" />
				</asp:BoundField>
				<asp:BoundField DataField="Password" HeaderText="密码" Visible="False">
					<HeaderStyle Width="160px" />
				</asp:BoundField>
				<asp:BoundField DataField="CorporationName" HeaderText="企业全称"></asp:BoundField>
				<asp:BoundField DataField="CorporationBreifName" HeaderText="企业简称"></asp:BoundField>
				<asp:BoundField DataField="Name" HeaderText="姓名">
					<HeaderStyle Width="60px" />
				</asp:BoundField>
				<asp:BoundField DataField="Mobile" HeaderText="电话">
					<HeaderStyle Width="90px" />
				</asp:BoundField>
				<asp:BoundField DataField="ChargeMan" HeaderText="负责人">
					<HeaderStyle Width="60px" />
				</asp:BoundField>
				<asp:BoundField DataField="ChargeManTel" HeaderText="电话">
					<HeaderStyle Width="90px" />
				</asp:BoundField>
				<asp:TemplateField HeaderText="评分">
					<HeaderStyle Width="50px" />
					<ItemTemplate><a href="EntMemberExp.aspx?id=<%# Eval("Id") %>" onclick="return openExpWin(this.href);"><%# GetExp() %></a></ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="创建时间">
					<HeaderStyle Width="120px" />
				</asp:BoundField>
				<asp:TemplateField HeaderText="启用">
					<HeaderStyle Width="50px" />
					<ItemTemplate><%# GetStatusString(Eval("IsEnabled").ToString()) %></ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="审核状态">
					<HeaderStyle Width="60px" />
					<ItemTemplate><%# GetStatus(Eval("Status").ToString()) %></ItemTemplate>
				</asp:TemplateField>
                 <%--<asp:TemplateField HeaderText="会员状态">
				<HeaderStyle Width="60px" />
				<ItemTemplate><%# GetMemberStatus(Convert.ToString(Eval("MemberLevelStatus"))) %></ItemTemplate>
			</asp:TemplateField>--%>
				<asp:TemplateField HeaderText="编辑">
					<HeaderStyle Width="50"></HeaderStyle>
					<ItemTemplate>
						<a href="EntMemberEdit.aspx?key=<%# Eval("Id") %>" cssclass="btn btn-default">编辑</a>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="审核">
					<HeaderStyle Width="50"></HeaderStyle>
					<ItemTemplate>
						<a href="EntMemberEdit.aspx?key=<%# Eval("Id") %>" cssclass="btn btn-default">审核</a>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="删除">
					<HeaderStyle Width="50"></HeaderStyle>
					<ItemTemplate>
						<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
		<cc1:NPager ID="NPager1" runat="server" />
	</asp:PlaceHolder>

	<asp:HiddenField ID="corpItems" runat="server" />

	<asp:PlaceHolder runat="server" ID="memberMap" Visible="false">
		<h5>颜色：<%= GetColorString() %></h5>
		<div id="memberMapView" style="width: 95%; height: 650px">
		</div>
	</asp:PlaceHolder>
	
	<script type="text/javascript">
		function openExpWin(url) {
			layer.open({
				type: 2,
				title: '选择组织机构',
				shadeClose: true,
				shade: false,
				maxmin: true,
				area: ['600px', '500px'],
				content: url,
				end: function () {
					window.reload();
				}
			});
			return false;
		}
	</script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="baiduMap" runat="Server">
	<script language="javascript" type="text/javascript">
		function selectAll(obj) {
			var theTable = obj.parentElement.parentElement.parentElement;
			var i;
			var j = obj.parentElement.cellIndex;

			for (i = 0; i < theTable.rows.length; i++) {
				var objCheckBox = theTable.rows[i].cells[j].firstElementChild;
				if (objCheckBox.checked != null)
					objCheckBox.checked = obj.checked;
			}
		}
	</script>
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
				window.location.href = 'EntMemberEdit.aspx?key=' + sn;
			}

			marker.addEventListener('click', openCorpDetail);
			map.addOverlay(marker);
		}

		var showCorpsOnMap = function () {
            <%--var btn = $("#<%= btnMapView.ClientID %>");
            btn.click();--%>
        	var $corpItems = $("#content_corpItems").val();
        	var dataObj = eval("(" + $corpItems + ")");//转换为json对象   

        	//遍历json数组
        	$.each(dataObj, function (i, item) {
        		addCorpToMap(item.lng, item.lat, item.color, item.name, item.sn);
        	});
        }

        if ($('#memberMapView').length > 0) {
        	map = new BMap.Map("memberMapView");
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
        }

	</script>
</asp:Content>
