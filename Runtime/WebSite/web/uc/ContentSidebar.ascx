<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentSidebar.ascx.cs" Inherits="web_uc_ContentSidebar" %>
<div class="ui-content-sidebar">
	<div class="header">pcx.cn</div>
	<ul>
		<a href="<%= ResolveClientUrl("~/web/PageNew.aspx") %>"><li<%= GetActive("PageNew") %>>新闻</li></a>
		<a href="<%= ResolveClientUrl("~/web/PagePolicy.aspx") %>"><li<%= GetActive("PagePolicy") %>>政策文件</li></a>
		<a href="<%= ResolveClientUrl("~/web/PageAssociationNews.aspx") %>"><li<%= GetActive("PageAssociationNews") %>>协会动态</li></a>
		<a href="<%= ResolveClientUrl("~/web/PageConsultNews.aspx") %>"><li<%= GetActive("PageConsultNews") %>>综合资讯</li></a>
		<a href="<%= ResolveClientUrl("~/web/PageAssociatorShow.aspx") %>"><li<%= GetActive("PageAssociatorShow") %>>会员展示</li></a>
		<a href="<%= ResolveClientUrl("~/web/PageLaw.aspx") %>"><li<%= GetActive("PageLaw") %>>法律专栏</li></a>
		<a href="<%= ResolveClientUrl("~/web/PageBar.aspx") %>"><li<%= GetActive("PageBar") %>>网吧培训</li></a>
		<a href="<%= ResolveClientUrl("~/web/PageJobSeeker.aspx") %>"><li<%= GetActive("PageJobSeeker") %>>人才库</li></a>
	</ul>
</div>