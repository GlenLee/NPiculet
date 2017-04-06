<%@ Page Title="选择用户" Language="C#" MasterPageFile="~/modules/common/Dialog.master" AutoEventWireup="true" CodeFile="UserDialog.aspx.cs" Inherits="modules_common_UserDialog" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<script type="text/javascript">
		function ok(val) {
			window.returnValue = val;
			window.close();
		}
		function cancel() {
			window.close();
		}
	</script>
	<style type="text/css">
		.ui-dialog-org { position:absolute;top:0;bottom:0;left:0;width:30%; }
		.ui-dialog-user { position:absolute;top:0;bottom:40%;right:0;width:70%; }
		.ui-dialog-selected { position:absolute;top:60%;bottom:0;right:0;width:70%; }
		.wrap { width:100%;height:100%;overflow:auto; }
		.ui-dialog-org, .ui-dialog-user, .ui-dialog-selected { }

		.ui-dialog-table { width:100%;margin-bottom:32px; }

		.npager { position:absolute;bottom:0;width:100%;background-color:#ddd;margin-right:20px; }
		.pagination { margin:0; }
	</style>
	<base target="_self"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton runat="server" ID="btnOk" OnClick="btnOk_Click">确定</asp:LinkButton>
	<a href="#" onclick="cancel();">取消</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>

	<div class="ui-dialog-org">
		<div class="wrap">
			<asp:TreeView runat="server" ID="tree" onselectednodechanged="tree_SelectedNodeChanged"></asp:TreeView>
		</div>
	</div>

	<div class="ui-dialog-user">
		<div class="wrap">

			<asp:GridView runat="server" ID="list" AutoGenerateColumns="False" CssClass="ui-dialog-table">
				<Columns>
					<asp:TemplateField HeaderText="序号">
						<HeaderStyle Width="40px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<HeaderStyle Width="40px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<HeaderTemplate><asp:CheckBox runat="server" ID="cbSelected"/></HeaderTemplate>
						<ItemTemplate>
							<input type="checkbox" value="<%# Eval("Id") %>" onclick="__doPostBack('BtnSelectUser','<%# Eval("Id") %>');" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField HeaderText="名称" DataField="Name"/>
					<asp:BoundField HeaderText="生日" DataField="Birthday"/>
					<asp:BoundField HeaderText="电话" DataField="Mobile"/>
					<asp:BoundField HeaderText="地址" DataField="Address"/>
				</Columns>
			</asp:GridView>
		</div>
		<cc1:NPager ID="NPager1" runat="server" />
	</div>

	<div class="ui-dialog-selected">
		<div class="wrap">
			<asp:GridView runat="server" ID="selectedList" AutoGenerateColumns="False" CssClass="ui-dialog-table">
				<Columns>
					<asp:TemplateField HeaderText="序号">
						<HeaderStyle Width="40px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField HeaderText="名称" DataField="Name"/>

					<asp:TemplateField HeaderText="删除">
						<HeaderStyle Width="40px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<a href="#" onclick="__doPostBack('BtnDeleteSelected','<%# Eval("Id") %>');">删除</a>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>
		</div>
	</div>

		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
