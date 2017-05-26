<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavMenu.ascx.cs" Inherits="web_uc_NavMenu" %>
<div class="ui-nav">
	<ul>
		<li<%= GetActive(0) %>><a href="<%= ResolveClientUrl("~/default.aspx") %>">首页</a></li>
		<li<%= GetActive(1) %>><a href="<%= ResolveClientUrl("~/web/PageNew.aspx") %>">新闻</a></li>
		<li<%= GetActive(2) %>><a href="<%= ResolveClientUrl("~/web/PagePolicy.aspx") %>">政策文件</a></li>
		<li<%= GetActive(3) %>><a href="<%= ResolveClientUrl("~/web/PageAssociationNews.aspx") %>">协会动态</a></li>
		<li<%= GetActive(4) %>><a href="<%= ResolveClientUrl("~/web/PageConsultNews.aspx") %>">综合资讯</a></li>
		<li<%= GetActive(5) %>><a href="<%= ResolveClientUrl("~/web/PageAssociatorShow.aspx") %>">会员展示</a></li>
		<li<%= GetActive(6) %>><a href="<%= ResolveClientUrl("~/web/PageLaw.aspx") %>">法律专栏</a></li>
		<li<%= GetActive(7) %>><a href="<%= ResolveClientUrl("~/web/PageBar.aspx") %>">网吧培训</a></li>
		<li<%= GetActive(8) %>><a href="<%= ResolveClientUrl("~/web/PageJobSeeker.aspx") %>">人才库</a></li>
	</ul>
</div>