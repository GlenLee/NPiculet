<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Header.aspx.cs" Inherits="modules_Header" %>
<%@ Register TagPrefix="uc" TagName="CssScriptQuote" Src="~/modules/common/CssScriptQuote.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Header</title>
	<uc:CssScriptQuote ID="CssScriptQuote1" runat="server" />
	<script src="../scripts/lib/jquery-1.11.1.min.js" type="text/javascript"></script>
	<style type="text/css">
		* { font-size:12px;list-style-type:none;padding:0;margin:0; }
		html, body { padding:0; margin:0; background-color:#000; }
		a:link { color:#fff; text-decoration:none; }
		a:visited { color:#fff; text-decoration:none; }
		a:hover { color:#fff; text-decoration:none; background-color:#eee; color:#000; }
		a:active { color:#fff; text-decoration:none; }

		.wrapper { position:relative;width:100%; }
		#title { float:left;padding:15px;color:#ffffff;font-size:24px; }
		#topnav { float:right;padding:10px;color:#fff; }
		#topnav a { color:#87ceeb; }

		nav#menu { position:absolute;left:10px;bottom:0; }
		nav#menu ul.sf-menu { list-style-type:none; }
		nav#menu ul.sf-menu li { float:left;padding:10px 20px;background-color:#266DBB;border-left:1px solid #000;border-top-left-radius:5px;border-top-right-radius:5px; }
		nav#menu ul.sf-menu li:first-child { border:0; }
		nav#menu ul.sf-menu li.current { background-color:#fff;color:#266dbb; }
		nav#menu ul.sf-menu li.current a { color:#266dbb;display:block;width:100%;height:100%;text-align:center; }
	</style>
	<script type="text/javascript">
		function logout() {
			window.top.location = "../Logout.aspx";
			return false;
		}

		function showSidebar(target, url) {
			$(".sf-menu li").each(function(i, o) { $(o).removeClass("current"); });
			$(target).parent().addClass("current");
			window.parent.document.getElementById("sideFrame").src = url;
		}
	</script>
</head>
<body>

	<!-- Header -->
	<header id="top">
		<div class="wrapper">
			<!-- Title/Logo -->
			<div id="title"><%= GetPlatformName() %></div>
			<!-- 顶部导航 -->
			<div id="topnav">
				欢迎你：<b><%= this.CurrentUserName %></b>
				<%--| <a href="#">个人资料</a>--%>
				| <a href="javascript:logout();">退出</a><br />
				<small><a href="#" class="high">你有 <b>0</b> 条新消息！</a></small>
			</div>
			<!-- 顶部导航 END -->
		</div>

		<!-- 导航菜单 -->
		<nav id="menu">
			<ul class="sf-menu">
				<li class="current"><a href="DashBoard.aspx" target="mainFrame" onclick="showSidebar(this, 'WaitingList.aspx');">首页</a></li>
				<li><a href="#" onclick="showSidebar(this, 'NavInfoPage.aspx');">信息管理</a></li>
				<%= GetMenuList() %>
			</ul>
		</nav>
		<!-- 导航菜单 END -->
	</header>
	<!-- End of Header -->

<script type="text/javascript">
	var _clock = $("aside");
	var _timer = setInterval(function () {
		var date = new Date();
		_clock.text(date.getFullYear() + "年" + (date.getMonth() + 1) + "月" + date.getDate() + "日" + " " + date.toLocaleTimeString());
	}, 1000);
</script>

</body>
</html>
