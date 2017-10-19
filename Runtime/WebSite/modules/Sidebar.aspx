<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sidebar.aspx.cs" Inherits="modules_Sidebar" %>
<%@ Register TagPrefix="uc" TagName="CssScriptQuote" Src="~/modules/common/CssScriptQuote.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Sidebar</title>
	<link href="../styles/fonts/font-awesome.min.css" rel="stylesheet" />
	<script src="../scripts/libs/jquery/jquery-1.12.4.min.js" type="text/javascript"></script>
	<style type="text/css">
		html, body { margin:0;padding:0;width:100%;height:100%;font-size:14px;background-color:#E7E8ED;color:#666; }
		dl, dt, dd, ul, li { margin:0;padding:0;list-style-type:none; }
		.leftmenu .title, .menuson li, i { height:38px;line-height:38px; }
		.leftmenu .title, .menuson li { padding-left:15px; }
		.leftmenu .title { background-color:#666;color:#fff;border-left:3px solid #3B90DC;border-bottom:1px dotted #999; }
		.leftmenu .menuson { display:none; }
		.leftmenu .menuson li { border-left:3px solid #4B98DC;border-right:1px solid #ddd;border-bottom:1px solid #ddd; }
		i { width:38px; }
		a { display:block;text-decoration:none;color:#666; }
		a:hover, a:focus { text-decoration:none;color:#3B90DC; }
	</style>
	<script type="text/javascript">
		$(function () {
			//导航切换
			$(".menuson .header").click(function () {
				var $parent = $(this).parent();
				$(".menuson>li.active").not($parent).removeClass("active open").find('.sub-menus').hide();
				$parent.addClass("active");
				if (!!$(this).next('.sub-menus').size()) {
					if ($parent.hasClass("open")) {
						$parent.removeClass("open").find('.sub-menus').hide();
					} else {
						$parent.addClass("open").find('.sub-menus').show();
					}
				}
			});

			// 三级菜单点击
			$('.sub-menus li').click(function (e) {
				$(".sub-menus li.active").removeClass("active");
				$(this).addClass("active");
			});

			$('.title').click(function () {
				var $ul = $(this).next('ul');
				$('dd').find('.menuson').slideUp();
				if ($ul.is(':visible')) {
					$(this).next('.menuson').slideUp();
				} else {
					$(this).next('.menuson').slideDown();
				}
			});
			var colors = ['#bbb'];
			$('.menuson').each(function (mi, m) {
				if (mi === 0) {
					$(m).show();
				}
				$(m).find('li').each(function (i, o) {
					o.style.borderLeftColor = colors[i % colors.length];
				});
			});
		})
	</script>
</head>

<body>
	<dl class="leftmenu">
<asp:Repeater ID="menu" runat="server">
	<ItemTemplate>
		<dd>
			<div class="title">
				<i></i><%# Eval("Name") %>
			</div>
			<ul class="menuson">
<asp:Repeater ID="item" runat="server" DataSource='<%# BuildMenus(Convert.ToInt32(Eval("Id"))) %>'>
	<ItemTemplate>
				<a href="<%# Eval("Url") %>" target="mainFrame">
					<li><i></i><%# Eval("Name") %></li>
				</a>
	</ItemTemplate>
</asp:Repeater>
			</ul>
		</dd>
	</ItemTemplate>
</asp:Repeater>
	</dl>

</body>
</html>
