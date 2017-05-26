<%@ Page Title="选择角色" Language="C#" MasterPageFile="~/modules/common/Dialog.master" AutoEventWireup="true" CodeFile="RoleDialog.aspx.cs" Inherits="modules_common_RoleDialog" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<style type="text/css">
		th, td { padding:6px 4px;border:0; }
	</style>
	<script type="text/javascript">
		function ok() {
			var val = '';
			$('input[type=checkbox]').each(function (i, o) {
				if (o.checked) {
					if (val.length > 0) val += ',';
					val += o.value;
				}
			});
			var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
			parent.result = val;
			parent.layer.close(index);
		}
		function cancel() {
			var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
			parent.layer.close(index);
		}
	</script>
	<base target="_self"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<a href="#" onclick="ok()">确定</a>
	&nbsp
	<a href="#" onclick="cancel();">取消</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

	<asp:GridView runat="server" ID="list" Width="100%" AutoGenerateColumns="False"
		BorderWidth="0" CssClass="sui-table table-bordered-simple">
		<Columns>
			<asp:TemplateField>
				<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<label class="checkbox-pretty inline">
						<input type="checkbox" value="<%# Eval("Id") %>"/><span></span>
					</label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="角色名称">
				<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<a href="#" onclick="ok('<%# Eval("Id") %>');"><%# Eval("RoleName") %></a>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="说明" DataField="Comment">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
			</asp:BoundField>
		</Columns>
	</asp:GridView>
	<cc1:NPager ID="NPager1" runat="server" Mode="Simple" />
</asp:Content>
