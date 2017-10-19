<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="ContentList.aspx.cs" Inherits="web_ContentList" %>
<%@ Register TagPrefix="uc" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>
<%@ Register TagPrefix="uc" TagName="ContentSidebar" Src="~/web/uc/ContentSidebar.ascx" %>
<%@ Register TagPrefix="uc" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="nav" runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu1" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
	<ol class="breadcrumb">
		<li>当前位置：</li>
		<li><a href="<%= ResolveClientUrl("~/") %>">首页</a></li>
		<li class="active">信息列表</li>
	</ol>
	
	<div class="row">
		
		<div class="col-md-9 ui-content-list">
			<!-- 列表 开始 -->
			<div class="content-list">
				<div class="content-title">
					<asp:Literal ID="title" runat="server"></asp:Literal>
				</div>
				<asp:PlaceHolder runat="server" ID="phShowTable">
					<table class="content-table">
						<tbody>
						<tr>
							<th>标题</th>
							<th style="width:120px;">发布时间</th>
						</tr>
						<asp:Repeater runat="server" ID="list">
							<ItemTemplate>
								<tr>
									<td class="title"><a href="/view/<%# Eval("Id") %>"><%# GetNewsTitle() %></a></td>
									<td style="width:120px;" class="date"><%# Eval("CreateDate", "{0:yyyy-MM-dd}") %></td>
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
