<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WaitingList.aspx.cs" Inherits="modules_WaitingList" %>
<%@ Register TagPrefix="uc" TagName="CssScriptQuote" Src="~/modules/common/CssScriptQuote.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>待办事项</title>
	<uc:CssScriptQuote ID="CssScriptQuote1" runat="server" />
	<style type="text/css">
		body { background-color:#eee; padding:0; margin:0; }
		dl, dt, dd { padding:0; margin:0; list-style-type:none; }
		dd { line-height:2.5em; background-color:#fff; color:#000; border-top:1px dotted #ddd; }
		dt a, dd a { display:block; width:auto; height:100%; text-decoration:none;padding:0 10px; }
		.accordion .title { background-color:#fff;padding-top:12px;font-weight:bold; }
		.accordion .content { background-color:#fff; }
		.selected { background-color:#e8f6ff; }
	</style>
	<script type="text/javascript" language="javascript">
		$(document).ready(function () {
			$('dd>a').bind('click', function () {
				$('dd>a').removeClass('selected');
				$(this).addClass('selected');
			});
		});
	</script>
</head>
<body>


<div class="ui accordion">

	<div class="title active"><i class="dropdown icon"></i>常用功能</div>
	<div class="content active">
		<dl>
			<dd><a href="DashBoard.aspx" target="mainFrame">首页面板</a></dd>
		</dl>
	</div>

</div>

</body>
</html>
