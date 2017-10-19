<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="ImagesList.aspx.cs" Inherits="web_ImagesList" %>
<%@ Register TagPrefix="uc" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>
<%@ Register TagPrefix="uc" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register TagPrefix="uc" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="nav" runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<ul class="breadcrumb">
		<li>当前位置：</li>
		<li><a href="<%= ResolveClientUrl("~/web/") %>">首页</a></li>
		<li class="active">图片新闻</li>
	</ul>
	<div class="row ui-content-list">
		<div class="col-md-9">
			<!-- 列表 开始 -->
			<div class="content-list">
				<div class="content-title">
					<i class="glyphicon glyphicon-picture"></i>&nbsp;&nbsp;<asp:Literal ID="title" runat="server"></asp:Literal>
				</div>
<asp:PlaceHolder runat="server" ID="phShowTable">
				<table class="content-table images-table">
					<tbody>
					<tr>
						<th scope="col">标题</th>
						<th scope="col" style="width: 150px;">发布时间</th>
					</tr>
					<asp:Repeater runat="server" ID="list">
						<ItemTemplate>
							<tr>
								<td class="thumb"><img src="<%# GetThumb() %>" alt=""/></td>
								<td class="title">
									<a href="/view/<%# Eval("Id") %>">
										<h4><%# GetNewsTitle() %></h4>
										<span><%# GetDescription() %></span>
									</a>
								</td>
								<td class="date"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></td>
							</tr>
						</ItemTemplate>
					</asp:Repeater>
					</tbody>
				</table>
				<form runat="server">
					<uc:NPager ID="nPager" runat="server" PageSize="15" OnPageClick="nPager_OnPageClick" />
				</form>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phEmpty">
				<div class="data-empty">没有数据</div>
</asp:PlaceHolder>
			</div>
			<!-- 列表 结束 -->
		</div>
		<div class="col-md-3">
			<!-- 侧边栏 开始 -->
			<uc:ContentSidebar runat="server" id="contentSidebar" />
			<!-- 侧边栏 结束 -->
		</div>
	</div>
</asp:Content>