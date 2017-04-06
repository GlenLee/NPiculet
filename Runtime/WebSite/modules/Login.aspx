<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="member_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title><%= GetPlatformName() %></title>
	<link href="../styles/fonts/font-awesome.css" rel="stylesheet" type="text/css" />
	<script src="../scripts/kissy/seed.js" type="text/javascript"></script>
	<style type="text/css">
		* { font-family:"微软雅黑","Microsoft YaHei",'Helvetica Neue', Helvetica, Arial, sans-serif; }
		html, body { width:100%;height:100%;padding:0;margin:0; }
		html, body { background-color:#333333; }
		.login-wrap { padding-top:60px; }
		.login-header { text-align:center;padding:10px;color:#ffffff; }
		.login-content { width:320px;margin:0 auto;padding:15px 60px 0 60px;background-color:#ffffff;border-radius:10px; }

		.form-group  { padding:10px;text-align:center; }
		.form-group span:before { color:#999999;width:30px;font-size:20px; }
		.form-control { border:1px solid #dddddd;border-radius:3px;padding:5px;width:240px;height:26px;line-height:26px; }

		.btn-login { border-radius:3px;border:1px solid #ccc;padding:6px 12px;color:#ffffff;
			background-color:#0076A3;
			background-image: -webkit-linear-gradient(top,#00ADED,#0076A3);
			background-image: -moz-linear-gradient( top, #00ADED, #0076A3);
			background-image: -o-linear-gradient( top, #00ADED, #0076A3);
			background-image: linear-gradient(top,#00ADED,#0076A3);
		}
	</style>
	<script type="text/javascript">
		if (window.top.location.href != window.location.href) {
			window.top.location.href = window.location.href;
		}
	</script>
</head>
 
<body>

<div class="login-wrap">

	<!-- login-header start -->
	<div class="login-header">
		<h1 style="text-align:center;font-size:x-large;padding:10px;"><%= GetPlatformName() %></h1>
	</div>
	<!-- login-header end -->
	<!-- login-content start -->
	<div class="login-content">
		<!-- login-form start -->
		<form id="frm" runat="server" style="padding:20px 0;">
			<div class="form-group">
				<span class="fa fa-user"></span>
				<asp:TextBox ID="txtAccount" runat="server" CssClass="form-control" placeholder="请输入登录帐号"></asp:TextBox>
			</div>
			<div class="form-group">
				<span class="fa fa-key"></span>
				<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="请输入登录密码"></asp:TextBox>
			</div>
			<div style="padding:20px 5px;text-align:center;">
				<asp:Button ID="btnLogin" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;登&nbsp;&nbsp;录&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn-login" onclick="btnLogin_Click" />
			</div>
		</form>
		<!-- login-form end -->
	</div>
	<!-- login-content end -->

</div>

</body>
</html>
