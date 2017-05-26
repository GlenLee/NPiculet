<%@ Page Title="" Language="C#" MasterPageFile="~/IndexPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/web/uc/NavMenu.ascx" TagPrefix="uc1" TagName="NavMenu" %>
<%@ Register Src="~/web/uc/MemberLoginOfIndex.ascx" TagPrefix="mli" TagName="MemberLogin" %>
<%@ Register Src="~/web/uc/MemberSimpleInfo.ascx" TagPrefix="mli" TagName="MemberInfo" %>
<%@ Register Src="~/web/uc/FriendLinks.ascx" TagPrefix="fl" TagName="FriendLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style type="text/css">
		.carousel-inner {
			height: 250px;
		}

		.sui-form {
			margin: 0;
		}
	</style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="nav">
	<uc1:NavMenu runat="server" ID="NavMenu" Active="0" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<div id="conetentBody" runat="server" class="sui-form">
		<div class="ui-body-row sui-row-fluid">
			<div class="span3">
				<form id="LoginForm" runat="server" class="sui-form">
					<!-- Widget 开始 -->
					<asp:PlaceHolder runat="server" ID="indexLoginForm">
						<mli:MemberLogin runat="server"></mli:MemberLogin>
					</asp:PlaceHolder>
					<asp:PlaceHolder runat="server" ID="indexUserInfo">
						<mli:MemberInfo runat="server"></mli:MemberInfo>
					</asp:PlaceHolder>
				</form>
				<!-- Widget 结束 -->
			</div>
			<div class="span6">
				<!-- 滚动图片 开始 -->
				<div id="myCarousel" data-ride="carousel" data-interval="4000" class="sui-carousel slide">
					<ol class="carousel-indicators">
						<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
						<li data-target="#myCarousel" data-slide-to="1"></li>
						<li data-target="#myCarousel" data-slide-to="2"></li>
					</ol>
					<div class="carousel-inner">
						<asp:Repeater ID="AdvertisingOfTop" runat="server">
							<ItemTemplate>
								<div class="<%#Container.ItemIndex == 0 ? "active" : "" %> item">
									<a href="<%# Eval("Url") %>" target="_blank">
										<img src="<%# ResolveClientUrl(Convert.ToString(Eval("Image"))) %>" alt="" />
									</a>
									<div class="carousel-caption">
										<h4><%#Eval("Description") %></h4>
									</div>
								</div>
							</ItemTemplate>
						</asp:Repeater>
					</div>
					<a href="#myCarousel" data-slide="prev" class="carousel-control left">‹</a><a href="#myCarousel" data-slide="next" class="carousel-control right">›</a>
				</div>
				<!-- 滚动图片 结束 -->
			</div>
			<div class="span3">
				<!-- Widget 开始 -->
				<div class="ui-widget blue-icon" style="height: 250px">
					<div class="title">
						&nbsp;&nbsp;会员展示
						<a href="web/PageAssociatorShow.aspx">MORE</a>
					</div>
					<div class="content">
						<ul>
							<asp:Repeater ID="AssociatorShowList" runat="server">
								<ItemTemplate>
									<li><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
		</div>
		<div class="ui-body-row sui-row-fluid">
			<div class="span3">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title square">
						&nbsp;&nbsp;法律专栏
						<a href="web/PageLaw.aspx">MORE</a>
					</div>
					<div class="content" style="min-height: 300px;">
						<ul>
							<asp:Repeater ID="LawList" runat="server">
								<ItemTemplate>
									<li><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
			<div class="span6">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title square">
						&nbsp;&nbsp;&nbsp;&nbsp;新&nbsp;&nbsp;闻
						<a href="web/PageNew.aspx">MORE</a>
					</div>
					<div class="content" style="min-height: 300px;">
						<div class="sui-row">
							<div class="span3">
								<div style="padding: 0 10px 10px 10px;">
									<asp:HyperLink ID="hotNewsImgLink" runat="server">
										<asp:Image runat="server" ID="hotNewsImg" BorderWidth="0" />
									</asp:HyperLink>
								</div>
							</div>
							<div class="span8">
								<asp:HyperLink ID="hotNewsTitleLink" runat="server">
									<asp:Label runat="server" ID="hotNewsTitle" Font-Size="Medium" ForeColor="#2A7BC4" />
								</asp:HyperLink>
								<br />
								<asp:HyperLink ID="hotNewsInfo" runat="server"></asp:HyperLink>
							</div>
							<div class="span12">
								<div style="text-align: right; padding-right: 20px;">
									<asp:HyperLink ID="hotNewsTitleMore" runat="server" Style="color: #FF9934">【查看详情】</asp:HyperLink>
								</div>
								<hr class="split" />
							</div>
							<div class="span12">
								<ul>
									<asp:Repeater ID="newslist" runat="server">
										<ItemTemplate>
											<li class="sui-row-fluid">
												<div class="span10"><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></div>
												<div class="span2"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
							</div>
						</div>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
			<div class="span3">
				<!-- Widget 开始 -->
				<div class="ui-widget ui-news">
					<div class="title square">
						&nbsp;&nbsp;综合资讯 <a href="web/PageConsultNews.aspx">MORE</a>
					</div>
					<div class="content" style="min-height: 300px;">
						<ul>
							<asp:Repeater ID="ConsultNewsList" runat="server">
								<ItemTemplate>
									<li><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a><%# IsNewIcon() %></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
		</div>

		<!-- 人才库 -->
		<div class="ui-body-row sui-row-fluid">
			<div class="span12">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title shading">
						<span>&nbsp;&nbsp;人才库</span> <a href="web/PageJobSeeker.aspx">MORE</a>
					</div>
					<div class="content">
						<div class="sui-row">
							<!-- 热招职位 -->
							<div class="ui-job-widget span6">
								<h4 class="sui-row-fluid">
									<div class="span9">
										<img src="styles/images/job1.png" alt="" />&nbsp;&nbsp;热招职位
										<%--<a href="#" class="icon1">发布招聘职位</a>--%>
									</div>
									<div class="span3">
										<a href="#">更多职位 &gt;&gt;</a>
									</div>
								</h4>
								<ul>
									<asp:Repeater ID="TopEntHireList" runat="server">
										<ItemTemplate>
											<li class="sui-row-fluid">
												<div class="span10"><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></div>
												<div class="span2"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
							</div>
							<!-- 人才简历 -->
							<div class="ui-job-widget span6">
								<h4 class="sui-row-fluid">
									<div class="span9">
										<img src="styles/images/job2.png" alt="" />&nbsp;&nbsp;人才简历
										<%--<a href="#" class="icon2">发布求职简历</a>--%>
									</div>
									<div class="span3">
										<a href="#">更多简历 &gt;&gt;</a>
									</div>
								</h4>
								<ul>
									<asp:Repeater ID="TopJobSeekers" runat="server">
										<ItemTemplate>
											<li class="sui-row-fluid">
												<div class="span10"><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></div>
												<div class="span2"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
							</div>
						</div>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
		</div>
		<!-- 人才库 END -->

		<div class="ui-body-row sui-row-fluid">
			<div class="span3">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title square">
						&nbsp;&nbsp;网吧培训 <a href="web/PageBar.aspx">MORE</a>
					</div>
					<div class="content" style="min-height: 355px;">
						<ul>
							<asp:Repeater ID="BarList" runat="server">
								<ItemTemplate>
									<li><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
			<div class="span6">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title square">
						&nbsp;&nbsp;协会动态 <a href="web/PageAssociationNews.aspx">MORE</a>
					</div>
					<div class="content" style="min-height: 355px;">
						<div class="sui-row">
							<div class="span3">
								<div style="padding: 0 10px 10px 10px;">
									<asp:HyperLink ID="anLink" runat="server">
										<asp:Image runat="server" ID="anImage" ImageUrl="~/styles/images/noimage.jpg" BorderWidth="0" />
									</asp:HyperLink>
								</div>
							</div>
							<div class="span8">
								<asp:HyperLink ID="anLink2" runat="server">
									<asp:Label runat="server" ID="anTitle" Font-Size="Medium" ForeColor="#2A7BC4" />
								</asp:HyperLink>
								<br />
								<asp:HyperLink ID="anLink3" runat="server"></asp:HyperLink>
							</div>
							<div class="span12">
								<div style="text-align: right; padding-right: 20px;">
									<asp:HyperLink ID="anLink4" runat="server" Style="color: #FF9934">【查看详情】</asp:HyperLink>
								</div>
								<hr class="split" />
							</div>
							<div class="span12">
								<ul>
									<asp:Repeater ID="AssociationNewsList" runat="server">
										<ItemTemplate>
											<li class="sui-row-fluid">
												<div class="span10"><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></div>
												<div class="span2"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></div>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
							</div>
						</div>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
			<div class="span3">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title square">
						&nbsp;&nbsp;政策文件 <a href="web/PagePolicy.aspx">MORE</a>
					</div>
					<div class="content" style="min-height: 355px;">
						<ul>
							<asp:Repeater ID="PagePolicyList" runat="server">
								<ItemTemplate>
									<li>
										<a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
		</div>
		<div class="ui-body-row sui-row-fluid">
			<div class="span9">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title">
						&nbsp;&nbsp;推荐品牌
					</div>
					<div class="content">
						<div class="sui-row-fluid">
							<asp:Repeater ID="RecommendBrands" runat="server">
								<ItemTemplate>
									<div class="span2" style="width: 140px; height: 80px; margin: 2px; line-height: 80px;">
										<a href="<%# ResolveClientUrl(Convert.ToString(Eval("Url"))) %>" target="_blank">
											<img src="<%# ResolveClientUrl(Convert.ToString(Eval("Image"))) %>" alt="" style="width: 140px;" />
										</a>
									</div>
								</ItemTemplate>
							</asp:Repeater>
						</div>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
			<div class="span3">
				<!-- Widget 开始 -->
				<div class="ui-widget">
					<div class="title square">
						&nbsp;&nbsp;网吧交易区 <a href="web/PageSale.aspx">MORE</a>
					</div>
					<div class="content">
						<ul>
							<asp:Repeater ID="salelist" runat="server">
								<ItemTemplate>
									<li><a href="web/ContentView.aspx?id=<%# Eval("Id") %>"><%# GetGameTitle() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
				</div>
				<!-- Widget 结束 -->
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="footer">

	<asp:Repeater runat="server" ID="BottomBanner">
		<ItemTemplate>
			<div class="ui-adb">
				<a href="<%# Eval("Url") %>" target="_blank">
					<img src="<%# ResolveClientUrl(Convert.ToString(Eval("Image"))) %>" alt="" />
				</a>
			</div>
		</ItemTemplate>
	</asp:Repeater>

	<asp:PlaceHolder runat="server" ID="FriendLinks">
		<fl:FriendLinks runat="server"></fl:FriendLinks>
	</asp:PlaceHolder>

<script>
var _hmt = _hmt || [];
(function() {
  var hm = document.createElement("script");
  hm.src = "//hm.baidu.com/hm.js?6a4289932a1d5208efc892cc8b5eb3e5";
  var s = document.getElementsByTagName("script")[0]; 
  s.parentNode.insertBefore(hm, s);
})();
</script>
</asp:Content>
