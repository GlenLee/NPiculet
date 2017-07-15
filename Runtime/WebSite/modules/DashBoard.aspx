<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="modules_DashBoard" %>
<%@ Register Src="common/CssScriptQuote.ascx" TagName="CssScriptQuote" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>DashBoard</title>
	<uc:CssScriptQuote ID="CssScriptQuote1" runat="server" />
	<style type="text/css">
		.dashboard-warp { padding: 10px; }
		ul li { line-height: 2em; color: #666; }
		.htitle { height: 38px; background-color: #e9f2f7; padding-top: 5px; font-size: 16px; padding-left: 10px; color: #3386e8; }
		.widget { border: 1px solid #c2c2c2; margin-bottom: 10px; margin-right: 5px; margin-top: 30px; }
		#total td { border-bottom: 1px #c2c2c2 dashed; }
	</style>
</head>

<body>

<form id="frm" runat="server">
	<p style="text-align:center;padding:100px 0;font-size:24px;color:#ddd">欢迎进入管理系统，请在左侧菜单选择操作功能</p>
</form>

</body>
</html>