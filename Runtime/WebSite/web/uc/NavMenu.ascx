<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavMenu.ascx.cs" Inherits="web_uc_NavMenu" %>
<div class="ui-navbar"><nav class="navbar navbar-default">
		<div class="container-fluid">
			<!-- Brand and toggle get grouped for better mobile display -->
			<div class="navbar-header">
				<a class="navbar-brand">
					<asp:Image runat="server" ImageUrl="~/styles/web/logo_small.png" AlternateText="Brand"/>
				</a>
			</div>

			<!-- Collect the nav links, forms, and other content for toggling -->
			<div class="collapse navbar-collapse">
				<ul class="nav navbar-nav">
					<li><asp:HyperLink runat="server" NavigateUrl="~/web/">首页</asp:HyperLink></li>
					<asp:Repeater runat="server" ID="list">
						<ItemTemplate>
							<li<%# GetActive() %>><a href="<%# GetPageUrl() %>"><%# Eval("GroupName") %></a></li>
						</ItemTemplate>
					</asp:Repeater>
				</ul>
				<form method="get" action="<%= ResolveClientUrl("~/search") %>" class="navbar-form navbar-right">
					<div class="form-group">
						<input type="search" id="keyword" name="keyword" class="form-control" placeholder="关键字">
					</div>
					<button type="submit" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></button>
				</form>
				<ul class="nav navbar-nav navbar-right">
					<li><a href="/">PCX.CN</a></li>
				</ul>
			</div><!-- /.navbar-collapse -->
		</div><!-- /.container-fluid -->
	</nav>
</div>