<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sidebar.aspx.cs" Inherits="modules_Sidebar" %>
<%@ Register TagPrefix="uc" TagName="CssScriptQuote" Src="~/modules/common/CssScriptQuote.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sidebar</title>
	<uc:CssScriptQuote ID="CssScriptQuote1" runat="server" />
	<style type="text/css">
		body { background-color:#eee; padding:0; margin:0; }
		dl, dt, dd { padding:0; margin:0; list-style-type:none; }
		dd { line-height:2.5em; background-color:#fff; color:#000; border-top:1px dotted #ddd; }
		dt a, dd a { display:block; width:auto; height:100%; text-decoration:none;padding:0 10px; }
		.accordion .title { background-color:#fff; }
		.accordion .content { background-color:#fff; }
	</style>
	<script type="text/javascript" language="javascript">
		$(document).ready(function () {
			$('.accordion').accordion();
			$('.accordion .title').first().addClass("active");
			$('.accordion .content').first().addClass("active");
		});
	</script>
</head>
<body>

<div class="ui styled accordion">

<asp:Repeater ID="menu" runat="server">
	<ItemTemplate>
		<div class="title"><i class="dropdown icon"></i><%# Eval("Name") %></div>
		<div class="content">
			<dl>
<asp:Repeater ID="item" runat="server" DataSource='<%# BuildMenus(Convert.ToInt32(Eval("Id"))) %>'>
	<ItemTemplate><dd><a href="<%# Eval("Url") %>" target="mainFrame"><%# Eval("Name") %></a></dd></ItemTemplate>
</asp:Repeater>
			</dl>
		</div>
	</ItemTemplate>
</asp:Repeater>

</div>

</body>
</html>
