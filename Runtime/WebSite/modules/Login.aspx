<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="modules_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>欢迎登录<%= GetPlatformName() %></title>
	<script src="../scripts/lib/jquery-1.11.3.min.js"></script>
	<link href="../styles/sui/css/sui.min.css" rel="stylesheet" />
	<script src="../styles/sui/js/sui.min.js"></script>
	<style type="text/css">
		html, body { padding:0;margin:0;width:100%;height:100%;background-color:#005bea;background-image: linear-gradient(to top, #00c6fb, #005bea); }
		div, p, input, select { box-sizing:border-box; }
		a, a:hover { text-decoration:none; }
		.login {
			color: #ffffff;
			position: relative;
		}
		.login-title {
			margin-top: 120px;
			text-align: center;
			font-family: Arial, "黑体";
			font-size: 36px;
			text-shadow: #00008b 1px 2px 0;
		}
		.login-screen {
			position:relative;
			width:580px;
			margin:0 auto;
			padding: 30px 0 30px 0;
		}
		.login-icon {
			position: absolute;
			top: 60px;
			left: 20px;
			width: 120px;
		}
		.login-icon > img {
			display: block;
			margin-bottom: 6px;
			width: 100%;
		}
		.login-form {
			width: 320px;
			background-color: #edeff1;
			margin:0 0 0 180px;
			padding: 24px 23px 20px;
			position: relative;
			border-radius: 6px;
		}
		.form-group {
			position: relative;
			margin-bottom: 20px;
		}
		.form-group > i {
			position:absolute;
			top:10px;
			right:10px;
			font-size:22px;
			color:#999;
		}
		.login-form .login-field {
			border-color: transparent;
			font-size: 17px;
			text-indent: 3px;
		}
		.login-form .login-field-icon {
			color: #bfc9ca;
			font-size: 16px;
			position: absolute;
			right: 15px;
			top: 3px;
			-webkit-transition: all .25s;
			transition: all .25s;
		}
		.form-control {
			display: block;
			width: 100%;
			height: 34px;
			padding: 6px 12px;
			font-size: 14px;
			line-height: 1.42857143;
			background-color: #fff;
			background-image: none;
			border: 1px solid #ccc;
			border-radius: 4px;
			-webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
			-webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
			-o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
			transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
		}
		.form-control, .select2-search input[type="text"] {
			border: 2px solid #bdc3c7;
			color: #34495e;
			font-family: "Lato", Helvetica, Arial, sans-serif;
			font-size: 15px;
			line-height: 1.467;
			padding: 8px 12px;
			height: 42px;
			border-radius: 6px;
			box-shadow: none;
			-webkit-transition: border 0.25s linear, color 0.25s linear, background-color 0.25s linear;
			transition: border 0.25s linear, color 0.25s linear, background-color 0.25s linear;
		}
		.login-form .login-field-icon {
			color: #bfc9ca;
			font-size: 16px;
			position: absolute;
			right: 15px;
			top: 3px;
			-webkit-transition: all .25s;
			transition: all .25s;
		}
		label {
			font-weight: normal;
			font-size: 15px;
			line-height: 2.3;
			display: inline-block;
			max-width: 100%;
			margin-bottom: 5px;
			font-weight: 700;
		}
		.flat-btn-block {
			display:inline-block;
			white-space: normal;
		}
		.btn-lg, .btn-group-lg > .btn {
			padding: 10px 19px;
			font-size: 17px;
			line-height: 1.471;
			border-radius: 6px;
		}
		.btn-primary {
			color: #ffffff;
			background-color:#005bea;
			background-image: linear-gradient(to top, #0066ff 0%, #005bea 100%);
		}
		.login-link {
			color: #bfc9ca;
			display: block;
			font-size: 13px;
			margin-top: 15px;
			text-align: center;
		}
	</style>
	<script type="text/javascript" src="../scripts/lib/jquery-1.11.3.min.js"></script>
	<script type="text/javascript" src="../scripts/plugin/layer/layer.js"></script>
	<%--<script src="js/cloud.js" type="text/javascript"></script>--%>
	<script type="text/javascript">
		if (window.top.location.href !== window.location.href) {
			window.top.location.href = window.location.href;
		}
	</script>
</head>

<body>

	<form id="frm" runat="server">

		<div class="login">
			<h1 class="login-title"><%= GetPlatformName() %></h1>
			<div class="login-screen">
				<div class="login-icon">
					<img src="../images/logo.png" />
				</div>

				<div class="login-form">
					<div class="form-group">
						<asp:TextBox ID="txtAccount" runat="server" CssClass="form-control login-field" placeholder="请输入登录帐号"></asp:TextBox>
						<i class="sui-icon icon-tb-my"></i>
					</div>

					<div class="form-group">
						<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control login-field" TextMode="Password" placeholder="请输入登录密码"></asp:TextBox>
						<i class="sui-icon icon-tb-unlock"></i>
					</div>

					<asp:Button ID="btnLogin" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;登&nbsp;&nbsp;录&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn-primary btn-lg flat-btn-block" OnClick="btnLogin_Click" />
				</div>
			</div>
		</div>
	</form>

</body>
</html>