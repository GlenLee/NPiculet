<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Header.aspx.cs" Inherits="modules_Header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Header</title>
	<link href="../styles/fonts/font-awesome.min.css" rel="stylesheet" />
	<link href="../styles/sui/css/sui.min.css" rel="stylesheet" />
	<script src="../scripts/lib/jquery-1.11.3.min.js" type="text/javascript"></script>
	<style type="text/css">
		html, body { margin:0;padding:0;width:100%;height:100%;font-size:14px;color:#666;background-color:#fff; }
		div, p, input { box-sizing:border-box; }
		a, a:hover, a:focus { text-decoration:none;color:#666; }
		a:hover, a:focus { background-color:#F4F8FB; }
		.ui-header { position:relative;height:45px;border-top:2px solid #DE5454;border-bottom:1px solid #ddd; }
		.topleft { float:left;height:42px;line-height:42px;width:50%; }
		.topleft, .topleft i, .topleft span, .topright, .topright ul, .topright li { height:42px;line-height:42px;vertical-align:top; }
		.topleft .icon { display:inline-block;width:38px;height:36px;margin:3px 5px 3px 20px;background-image:url(../styles/images/logo.png);background-size:36px;border-radius:18px; }
		.topleft span { display:inline-block; }
		.topright { float:right;height:42px;line-height:42px;width:50%; }
		.topright ul, .topright li { margin:0;padding:0;list-style-type:none; }
		.topright ul { font-size:0;text-align:right; }
		.topright ul li { display:inline-block;font-size:1rem; }
		.topright ul li.button a, .topright ul li.button a i { display:block;width:42px;height:42px;line-height:42px;text-align:center;font-size:16px; }
		.topright ul li.info { padding:0 20px;background-color:#F4F8FB; }
		.topright ul li.info i { font-size:22px;margin-right:10px; }
	</style>
</head>

<body>

<div class="ui-header">
	<div class="topleft">
		<i class="icon"></i>
		<span><%= GetPlatformName() %></span>
	</div>

	<div class="topright">
		<ul>
			<li class="button"><a href="../AboutUs.aspx" target="_blank"><i class="fa fa-info"></i></a></li>
			<li class="button"><a href="Logout.aspx" target="_top"><i class="fa fa-sign-out"></i></a></li>
			<li class="info"><i class="sui-icon icon-tb-myfill"></i>您好，<asp:Label ID="loginName" runat="server"></asp:Label></li>
		</ul>
	</div>
</div>

</body>
</html>
