<%@ Page Title="" Language="C#" MasterPageFile="~/IndexPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="NPiculet.Toolkit" %>
<%@ Register Src="~/web/uc/NavMenu.ascx" TagPrefix="uc1" TagName="NavMenu" %>
<%@ Register Src="~/web/uc/HomeWidget.ascx" TagPrefix="uc" TagName="HomeWidget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style type="text/css">
		 #myCarousel { box-sizing: border-box; background-color: #fff; border: 1px solid #ccc; }
		.sui-carousel { margin: 0; }
		.carousel-control { background-color:transparent;border:0;border-image-width:0; }
		.carousel-caption { background-color:rgba(0,0,0,.3);padding:5px 10px; }
		.carousel-inner {
			height: 330px;
		}
		.carousel-inner img {
			width: 100%;
			height: 330px;
		}
	</style>
	<script type="text/javascript">
		function showPointsTable(me, i) {
			$(me).parent().parent().find('li').removeClass('active');
			$(me).parent().addClass('active');
			$('table.points').hide();
			$('table.pointslist' + i).show();
			console.log('table.pointslist' + i);
		}
	</script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="nav">
	<uc1:NavMenu runat="server" ID="NavMenu" Active="0" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<div class="ui-body-row sui-row-fluid">
		<div class="span5">
			<!-- 滚动图片 开始 -->
			<div id="myCarousel" data-ride="carousel" data-interval="4000" class="sui-carousel slide">
				<ol class="carousel-indicators">
					<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
					<li data-target="#myCarousel" data-slide-to="1"></li>
					<li data-target="#myCarousel" data-slide-to="2"></li>
				</ol>
				<div class="carousel-inner">
					<asp:Repeater ID="newsImages" runat="server">
						<ItemTemplate>
							<div class="<%#Container.ItemIndex == 0 ? "active" : "" %> item">
								<a href="view/<%# Eval("Id") %>" target="_blank">
									<img src="<%# ResolveClientUrl(Convert.ToString(Eval("Thumb"))) %>" alt="" />
								</a>
								<div class="carousel-caption">
									<h4><%#Eval("Title") %></h4>
								</div>
							</div>
						</ItemTemplate>
					</asp:Repeater>
				</div>
				<a href="#myCarousel" data-slide="prev" class="carousel-control left">‹</a><a href="#myCarousel" data-slide="next" class="carousel-control right">›</a>
			</div>
			<!-- 滚动图片 结束 -->
		</div>
		<div class="span7">
			<!-- Widget 开始 -->
			<div class="ui-widget main-news">
				<div class="header">
					<span class="title">图片新闻</span> 
					<a class="more" href="web/images">更多</a>
					<div class="title-line">
						<div class="gray" style="width: 85%"></div>
					</div>
				</div>
				<div class="content" style="min-height: 300px;">
					<div class="top-news">
						<h3><asp:HyperLink ID="hotNewsTitleLink" runat="server" Target="_blank"></asp:HyperLink></h3>
						<p><asp:Literal ID="hotNewsInfo" runat="server"></asp:Literal>……<asp:HyperLink ID="hotNewsTitleMore" runat="server">[详情]</asp:HyperLink></p>
					</div>
					<div class="split-line"></div>
						<ul>
							<asp:Repeater ID="newslist" runat="server">
								<ItemTemplate>
									<li class="sui-row-fluid">
										<div class="span10"><a href="view/<%# Eval("Id") %>" target="_blank"><%# GetMainNewsTitle() %></a></div>
										<div class="span2" style="text-align: right"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
									</li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
				</div>
			</div>
			<!-- Widget 结束 -->
		</div>
	</div>
	<!-- 顶部宣传 -->
	<div class="ui-body-row sui-row-fluid">
		<div class="span12 banner-top">
			<%= GetTopAd() %>
		</div>
	</div>

	<!-- 图片新闻 -->
	<div class="ui-body-row sui-row-fluid images-news">
<asp:Repeater runat="server" ID="imagesList">
	<ItemTemplate>
		<div class="span2">
			<a href="view/<%# Eval("Id") %>" target="_blank">
				<img src="<%# ResolveClientUrl(Convert.ToString(Eval("Thumb"))) %>" alt=""/>
				<span><%# Convert.ToString(Eval("Title")).Left(22, "…") %></span>
			</a>
		</div>
	</ItemTemplate>
</asp:Repeater>
	</div>

	<!-- 中部内容 开始 -->
	<div class="ui-body-row sui-row-fluid">
		<asp:Repeater runat="server" ID="news1">
			<ItemTemplate>
				<div class="span4"><uc:HomeWidget runat="server" ID="HomeWidget12" GroupCode='<%# Eval("GroupCode") %>' /></div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
	<div class="ui-body-row sui-row-fluid">
		<asp:Repeater runat="server" ID="news2">
			<ItemTemplate>
				<div class="span4"><uc:HomeWidget runat="server" ID="HomeWidget12" GroupCode='<%# Eval("GroupCode") %>' /></div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
		
	<div class="banner-middle">
		<%= GetMiddleAd() %>
	</div>

	<!-- 分栏内容 开始 -->
	<div class="ui-body-row sui-row-fluid">
		<div class="span8">
			<!-- 新闻栏 Start -->
			<asp:Repeater runat="server" ID="news3">
				<ItemTemplate>
					<%# Container.ItemIndex % 2 == 0 ? "<div class=\"ui-body-row sui-row-fluid\">" : "" %>
						<div class="span6"><uc:HomeWidget runat="server" ID="homeWidget" GroupCode='<%# Eval("GroupCode") %>' /></div>
					<%# Container.ItemIndex % 2 == 1 || Container.ItemIndex == count - 1 ? "</div>" : "" %>
				</ItemTemplate>
			</asp:Repeater>
			<!-- 新闻栏 End -->
			
			<!-- 专题导航栏 Start -->
			<div class="ui-body-row sui-row-fluid zhuangti">
				<div class="span6"><a href="list/guangrong"><img src="styles/web/page/btn_nav_honor.png" alt=""/></a></div>
				<div class="span6"><a href="list/tashanzhishi"><img src="styles/web/page/btn_nav_stone.png" alt=""/></a></div>
			</div>
			<div class="ui-body-row sui-row-fluid zhuangti">
				<div class="span6"><a href="list/jingwulianluo"><img src="styles/web/page/btn_nav_contact.png" alt=""/></a></div>
				<div class="span6"><a href="list/qingbao"><img src="styles/web/page/btn_nav_info.png" alt=""/></a></div>
			</div>
			<!-- 专题导航栏 End -->

		</div>

		<!-- 侧边栏 Start -->
		<div class="span4">
			<div>
				<!-- 快捷导航 Start -->
				<div class="ui-widget ui-widget-simple">
					<div class="header">
						<span class="title">业务平台</span> 
						<div class="title-line"></div>
					</div>
					<div class="content">
						<ul class="quick-nav">
							<li class="bb br"><a href="<%= GetBusLinkUrl("业务平台", 0) %>" target="_blank"><i class="icons sprite1"></i><span>经侦信息系统</span></a></li>
							<li class="bb br"><a href="<%= GetBusLinkUrl("业务平台", 1) %>" target="_blank"><i class="icons sprite2"></i><span>云南省综合<br/>信息查询系统</span></a></li>
							<li class="bb"><a href="<%= GetBusLinkUrl("业务平台", 2) %>" target="_blank"><i class="icons sprite3"></i><span>信息化自动<br/>预警系统</span></a></li>
							<li class="br"><a href="<%= GetBusLinkUrl("业务平台", 3) %>" target="_blank"><i class="icons sprite4"></i><span>全国公安信<br/>息综合查询</span></a></li>
							<li class="br"><a href="<%= GetBusLinkUrl("业务平台", 4) %>" target="_blank"><i class="icons sprite5"></i><span>经侦民警<br/>信息系统</span></a></li>
							<li><a href="<%= GetBusLinkUrl("业务平台", 5) %>" target="_blank"><i class="icons sprite6"></i><span>泛亚专案系统</span></a></li>
						</ul>
					</div>
				</div>
				<!-- 快捷导航 End -->
				<div style="height:20px;"></div>
<!--
				<div>
					<a href="list/guangrong"><img src="styles/web/page/btn_nav_honor.png" alt="" style="display: block; margin-bottom: 10px;"/></a>
					<a href="list/tashanzhishi"><img src="styles/web/page/btn_nav_stone.png" alt="" style="display: block; margin-bottom: 10px;"/></a>
					<a href="list/jingwulianluo"><img src="styles/web/page/btn_nav_contact.png" alt="" style="display: block; margin-bottom: 10px;"/></a>
					<a href="list/qingbao"><img src="styles/web/page/btn_nav_info.png" alt="" style="display: block; margin-bottom: 10px;"/></a>
				</div>
				<div style="height:20px;"></div>
-->
				<!-- 积分统计 Start -->
				<div class="ui-widget ui-widget-simple">
					<div class="header">
						<span class="title">积分排名</span> 
						<div class="title-line"></div>
					</div>
					<div class="content">
						<ul class="sui-nav nav-tabs nav-large">
							<li class="active"><a onclick="showPointsTable(this, 1)">各州市排名</a></li>
							<li><a onclick="showPointsTable(this, 2)">各处室排名</a></li>
						</ul>
						<table class="table points pointslist1">
							<thead>
							<tr>
								<th>名称</th>
								<th>积分</th>
								<th>名次</th>
							</tr>
							</thead>
							<tbody>
							<asp:Repeater ID="placePointsList" runat="server">
								<ItemTemplate>
									<tr>
										<td><%# Eval("OrgName") %></td>
										<td><%# Eval("Point") %></td>
										<td><%# ShowRanking() %></td>
									</tr>
								</ItemTemplate>
							</asp:Repeater>
							</tbody>
						</table>
						<table class="table points pointslist2">
							<thead>
							<tr>
								<th>名称</th>
								<th>积分</th>
								<th>名次</th>
							</tr>
							</thead>
							<tbody>
							<asp:Repeater ID="deptPointsList" runat="server">
								<ItemTemplate>
									<tr>
										<td><%# Eval("OrgName") %></td>
										<td><%# Eval("Point") %></td>
										<td><%# ShowRanking() %></td>
									</tr>
								</ItemTemplate>
							</asp:Repeater>
							</tbody>
						</table>
					</div>
				</div>
				<!-- 积分统计 End -->
			</div>
		</div>
		<!-- 侧边栏 End -->
	</div>
	<!-- 分栏内容 结束 -->

	<!-- 浮动导航 Start -->
	<div class="float-nav">
		<ul class="buttons">
			<li onmouseout="$('.float-more-1').stop().fadeOut();" onmouseover="$('.float-more-1').stop().fadeIn();">
				<a href="#" class="item"><i><img src="styles/web/page/float_icon_1.png" alt=""/></i><span>省厅各<br/>直属部门</span></a>
				<div class="ui-widget ui-widget-simple float-more-1">
					<div class="header">
						<span class="title">应用地址</span>
						<div class="title-line"></div>
					</div>
					<div class="content">
						<ul>
							<asp:Repeater runat="server" ID="float_link_1">
								<ItemTemplate>
									<li><a href="<%# GetExtUrl() %>" title="<%# Eval("Description") %>" target="_blank"><%# Eval("Description") %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
			</li>
			<li onmouseout="$('.float-more-2').stop().fadeOut();" onmouseover="$('.float-more-2').stop().fadeIn();">
				<a href="#" class="item"><i><img src="styles/web/page/float_icon_2.png" alt=""/></i><span>全国经侦</span></a>
				<div class="ui-widget ui-widget-simple float-more-2">
					<div class="header">
						<span class="title">应用地址</span>
						<div class="title-line"></div>
					</div>
					<div class="content">
						<ul>
							<asp:Repeater runat="server" ID="float_link_2">
								<ItemTemplate>
									<li><a href="<%# GetExtUrl() %>" title="<%# Eval("Description") %>" target="_blank"><%# Eval("Description") %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
			</li>
			<li onmouseout="$('.float-more-3').stop().fadeOut();" onmouseover="$('.float-more-3').stop().fadeIn();">
				<a href="#" class="item"><i><img src="styles/web/page/float_icon_3.png" alt=""/></i><span>全省经侦</span></a>
				<div class="ui-widget ui-widget-simple float-more-3">
					<div class="header">
						<span class="title">应用地址</span>
						<div class="title-line"></div>
					</div>
					<div class="content">
						<ul>
							<asp:Repeater runat="server" ID="float_link_3">
								<ItemTemplate>
									<li><a href="<%# GetExtUrl() %>" title="<%# Eval("Description") %>" target="_blank"><%# Eval("Description") %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
			</li>
			<li onmouseout="$('.float-more-4').stop().fadeOut();" onmouseover="$('.float-more-4').stop().fadeIn();">
				<a href="#" class="item"><i><img src="styles/web/page/float_icon_4.png" alt=""/></i><span>各业务处室</span></a>
				<div class="ui-widget ui-widget-simple float-more-4">
					<div class="header">
						<span class="title">应用地址</span>
						<div class="title-line"></div>
					</div>
					<div class="content">
						<ul>
							<asp:Repeater runat="server" ID="float_link_4">
								<ItemTemplate>
									<li><a href="<%# GetExtUrl() %>" title="<%# Eval("Description") %>" target="_blank"><%# Eval("Description") %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
			</li>
		</ul>

	</div>
	<div class="btn-go-top">
		<a href="#"><img src="styles/web/page/btn_go_top.png" alt=""/></a>
	</div>
	<!-- 浮动导航 End -->
</asp:Content>