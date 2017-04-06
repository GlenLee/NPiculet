<%@ Page Title="" Language="C#" MasterPageFile="~/wap/ContentPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="wap_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
	<div title="红云创投" id="bag" class="panel" selected="true">

		<form id="frm" runat="server" class="form-wrap">
			<div>
				<label>用户名称</label>
				<asp:TextBox runat="server" ID="username" placeholder="请填写用户名称"/>
			</div>
			<div class="button-grouped flex">
				<asp:LinkButton runat="server" ID="btnSave" Text="提交" CssClass="button red"></asp:LinkButton>
			</div>
		</form>

	</div>
</asp:Content>
