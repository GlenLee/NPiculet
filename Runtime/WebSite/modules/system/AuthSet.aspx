<%@ Page Title="授权管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="AuthSet.aspx.cs" Inherits="modules_system_AuthSet" %>
<%@ Import Namespace="NPiculet.Toolkit" %>

<asp:Content ID="Content4" ContentPlaceHolderID="header" Runat="Server">
	<style type="text/css">
		.fun-table { border-collapse:collapse;border:0 !important;width:100%; }
		.fun-table td, th { padding:0; }
		.fun-subtable { border-collapse:collapse;border-bottom:1px solid #ddd;width:100%; }
		.fun-subtable td, th { border:0 !important;padding:2px 4px; }

		.fun-table > tr > th { padding:0; }
		.fun-table > tr > td { padding:0; }
		.fun-title { padding:2px 4px;font-weight:bold;background-color:#ddd; }
		.fun-subtitle { width:120px;font-weight:bold; }
		.fun-content { }

		.fun-list table { width:100%; }
		.fun-list table td { width:25%; }
	</style>
	<script>
		function selectAll(me) {
			var val = me.checked;
			$(me).parent().parent().find("input[type=checkbox]").each(function(i, o) {
				o.checked = val;
			});
		}
	</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="<%= WebParmKit.GetQuery("p", "") %>"><i class="sui-icon icon-tb-back"></i>返回</a></li>
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click"><i class="sui-icon icon-tb-check"></i>保存</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnAuth" runat="server" OnClick="btnAuth_Click"><i class="sui-icon icon-tb-unlock"></i>授权</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<table class="sui-table table-primary">
		<tr>
			<th colspan="2">目标信息</th>
		</tr>
		<tr>
			<td class="th">类型</td>
			<td class="td"><asp:Literal runat="server" ID="TargetTypeName"></asp:Literal></td>
		</tr>
		<tr>
			<td class="th">名称</td>
			<td class="td"><asp:Literal runat="server" ID="TargetName"></asp:Literal></td>
		</tr>
		<tr>
			<td class="th">备注</td>
			<td class="td"><asp:Literal runat="server" ID="TargetMemo"></asp:Literal></td>
		</tr>
		<tr>
			<th colspan="2">授权信息</th>
		</tr>
		<tr>
			<td class="th">已授权限</td>
			<td class="td">
				<!-- 已授权清单 -->
				<asp:DataList runat="server" ID="authFunList" onitemdatabound="authMain_ItemDataBound" CssClass="fun-table">
					<ItemTemplate>
						<!-- 子级目录 -->
						<div class="fun-title"><%# Eval("Name") %></div>
						<div class="fun-content">
							<asp:DataList runat="server" ID="authSub" onitemdatabound="authSub_ItemDataBound" CssClass="fun-subtable">
								<ItemTemplate>
									<!-- 功能列表 -->
									<table cellpadding="0" cellspacing="0" class="fun-subtable">
										<tr>
											<td class="fun-subtitle"><%# Eval("Name") %></td>
											<td class="fun-list"><asp:CheckBoxList runat="server" ID="authItems" RepeatColumns="4" RepeatDirection="Horizontal"/></td>
										</tr>
									</table>
								</ItemTemplate>
							</asp:DataList>
						</div>
					</ItemTemplate>
				</asp:DataList>
				<!-- 所有权限清单 -->
				<asp:DataList runat="server" ID="authAllList" onitemdatabound="authMain_ItemDataBound" CssClass="fun-table">
					<ItemTemplate>
						<!-- 子级目录 -->
						<div class="fun-title"><%# Eval("Name") %></div>
						<div class="fun-content">
							<asp:DataList runat="server" ID="authSub" onitemdatabound="authSub_ItemDataBound" CssClass="fun-subtable">
								<ItemTemplate>
									<!-- 功能列表 -->
									<table cellpadding="0" cellspacing="0" class="fun-subtable">
										<tr>
											<td class="fun-subtitle"><input type="checkbox" onclick="selectAll(this);"/> <%# Eval("Name") %></td>
											<td class="fun-list"><asp:CheckBoxList runat="server" ID="authItems" RepeatColumns="4" RepeatDirection="Horizontal"/></td>
										</tr>
									</table>
								</ItemTemplate>
							</asp:DataList>
						</div>
					</ItemTemplate>
				</asp:DataList>
				<%--<asp:CheckBoxList runat="server" ID="authList" Width="100%" RepeatColumns="5" RepeatDirection="Horizontal"/>--%>
			</td>
		</tr>
	</table>
	<asp:HiddenField runat="server" ID="Id" />
	<asp:HiddenField runat="server" ID="TargetId" />
	<asp:HiddenField runat="server" ID="TargetType" />
</asp:Content>
