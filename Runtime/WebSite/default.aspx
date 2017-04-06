<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>
<%@ Register TagPrefix="uc1" TagName="WebQuote" Src="~/web/uc/WebQuote.ascx" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title></title>
	<uc1:WebQuote ID="WebQuote1" runat="server" />
	<link href="styles/ticket/home.css" rel="stylesheet" type="text/css" />
</head>

<body>
	<div class="ui-layout">
		<div class="ui-header">
			<div class="ui grid">
				<div class="eight wide column">
					<div class="top-login">
						登录 | 注册 您好，欢迎光临！
					</div>
				</div>
				<div class="eight wide column">
					<div class="tr top-link">
						我的订单 | 收藏夹 | 关于我们
					</div>
				</div>
				<div class="four wide column">
					<div style="width:220px;height:90px;background:url(styles/ticket/images/logo.png) no-repeat;margin:10px 30px;"></div>
				</div>
				<div class="eight wide column">
					<div class="ui action input" style="width:400px;margin:30px auto;">
						<input type="text" placeholder="输入XXXXX">
						<div class="ui button" style="padding:0 10px;color:#fff;background-color:#666;"><i class="large icon search"></i></div>
					</div>
				</div>
				<div class="four wide column">
					<div style="width:227px;height:107px;background:url(styles/ticket/images/logo-girls.png) no-repeat;margin-top:10px;"></div>
				</div>
			</div>
		</div>
		<!-- Header END -->

		<div class="ui-nav">
			<div class="ui-menu">
				<div class="ui menu">
					<a class="item">查询<i class="caret down icon"></i></a>

					<div class="right menu">
						<a class="item">首页</a>
						<a class="item">XXX</a>
						<a class="item">XXX</a>
						<a class="item">关于我们</a>
						<a class="item">个人中心</a>
						<a class="item">登录</a>
					</div>
				</div>
			</div>
		</div>
		<!-- Nav END -->

		<div class="ui-body home">

			<div class="home-banner">
				<img src="styles/ticket/images/banner2.png" />
				<form>
					查询表单
				</form>
			</div>

			<div class="home-banner-1">
				<img src="styles/ticket/icon/split-icon-ticket.png" />
				<img src="styles/ticket/icon/split-icon-web.png" />
				<img src="styles/ticket/icon/split-icon-cart.png" />
				<img src="styles/ticket/icon/split-icon-info.png" />
				<img src="styles/ticket/icon/split-icon-other.png" />
			</div>

			<div class="ui grid">
				<div class="four wide column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>限时抢购
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="eight wide column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>热销产品
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="four wide column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
			</div>

			<div class="section-title"><i class="flag icon"></i>热门推荐</div>
			<div class="ui four column grid">
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
			</div>

			<div class="section-title"><i class="flag icon"></i>热门推荐</div>
			<div class="ui four column grid">
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
				<div class="column">
					<div class="widget">
						<div class="title">
							<i class="wait icon"></i>促销专区
						</div>
						<div class="content">
							<img src="styles/ticket/images/banner1.png" style="width:280px;height:120px;" />
						</div>
					</div>
				</div>
			</div>

		</div>
		<!-- Body END -->

		<div class="ui-footer">
			<footer>
				<p class="copyright">骤羽科技 © 版权所有</p>
				<div class="ui grid" style="margin:0 160px;">
					<div class="three wide column">
						<div class="footer-link">关于我们</div>
					</div>
					<div class="three wide column">
						<div class="footer-link">订购指南</div>
					</div>
					<div class="three wide column">
						<div class="footer-link">支付方式</div>
					</div>
					<div class="three wide column">
						<div class="footer-link">售后服务</div>
					</div>
					<div class="four wide column" style="background-color:rgba(255,255,255,.3)">
						<a href="#">订阅</a><br/>
						<a href="#">扫描二维码，订阅微信公众号</a>
						<a href="#">掌握第一手信息</a>
					</div>
				</div>
			</footer>
		</div>
		<!-- Footer END -->
	</div>

</body>

</html>
