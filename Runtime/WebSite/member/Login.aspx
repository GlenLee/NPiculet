<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Src="~/web/uc/NavMenu.ascx" TagPrefix="uc" TagName="NavMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style type="text/css">
		body {
			background: url(styles/images/login-bg.jpg) no-repeat center 200px;
		}

		.ui-body {
			height: 325px;
			position: relative;
		}

		div.sui-form {
			position: absolute;
			top: 30px;
			right: 100px;
			background-color: #fff;
			width: 260px;
		}

		div.sui-form .title {
			background: url(styles/images/wl0.jpg);
			font-size: 16px;
			text-align: center;
			color: #2A7BC4;
			line-height: 50px;
			border-bottom: 2px dotted #eee;
			margin-bottom: 10px;
		}
		div.sui-form table tr td { padding:6px 4px; }
		div.sui-form .th { text-align: right;width: 70px; }
		div.sui-form .td input { text-align: left;width: 140px; }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
	<uc:NavMenu runat="server" ID="NavMenu" Active="-1" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<form runat="server" ID="frm">
	<div class="sui-form form-horizontal">
		<div class="title">
			<i class="sui-icon icon-touch-user3-sign"></i>&nbsp;用户登录
		</div>
		<table style="width:100%;">
			<tr>
				<td class="th">账&nbsp;&nbsp;&nbsp;号：</td>
				<td class="td"><asp:TextBox ID="account" placeholder="账号" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
						ErrorMessage="用户名不能为空" ForeColor="red" ControlToValidate="account" /></td>
			</tr>
			<tr>
				<td class="th">密&nbsp;&nbsp;&nbsp;码：</td>
				<td class="td"><asp:TextBox ID="pwd" placeholder="密码" runat="server" TextMode="Password"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
						ErrorMessage="密码不能为空" ForeColor="red" ControlToValidate="pwd" /></td>
			</tr>
			<tr>
				<td class="th">验证码：</td>
				<td class="td"><asp:TextBox ID="vcode" runat="server" Width="40px"></asp:TextBox>
					<img src="modules/common/verifycode.aspx" alt="验证码" style="height: 24px;" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
						ErrorMessage="不能为空" ForeColor="red" ControlToValidate="vcode" /></td>
			</tr>
			<tr>
				<td colspan="2" style="padding:10px;text-align:center;">
					<asp:Button runat="server" ID="btnLogin" Text="登  录" CssClass="sui-btn btn-large btn-primary" OnClick="btnLogin_Click" />
					&nbsp;
					<a href="./EntRegStep1.aspx">
						<input type="button" class="sui-btn btn-large btn-warning" value="注  册" />
					</a>
				</td>
			</tr>
		</table>
	</div>
	</form>
</asp:Content>
