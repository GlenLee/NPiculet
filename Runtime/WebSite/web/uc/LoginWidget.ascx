<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginWidget.ascx.cs" Inherits="web_uc_LoginWidget" %>
<div class="panel panel-primary">
<asp:PlaceHolder runat="server" ID="phLogin">
	<div class="panel-heading">
		<h3 class="panel-title"><i class="glyphicon glyphicon-user"></i>&nbsp;&nbsp;用户登录</h3>
	</div>
	<div class="panel-body">
		<div class="form-group">
			<label for="<%= this.tbUserName.ClientID %>">用户名：</label>
			<asp:TextBox runat="server" ID="tbUserName" CssClass="form-control" />
			<asp:RequiredFieldValidator ID="r1" runat="server" Display="Dynamic" ErrorMessage="用户名不能为空" ForeColor="red" ControlToValidate="tbUserName" />
		</div>

		<div class="form-group">
			<label for="<%= this.tbPassword.ClientID %>">密　码：</label>
			<asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" TextMode="Password" />
			<asp:RequiredFieldValidator ID="r2" runat="server" Display="Dynamic" ErrorMessage="密码不能为空" ForeColor="red" ControlToValidate="tbPassword" />
		</div>
		
		<div class="form-group">
			<label for="<%= this.tbVerifyCode.ClientID %>">验证码：</label>
			<div class="row">
				<div class="col-xs-6">
					<asp:TextBox runat="server" ID="tbVerifyCode" CssClass="form-control" Width="100px" />
					<asp:RequiredFieldValidator ID="r3" runat="server" Display="Dynamic" ErrorMessage="不能为空" ForeColor="red" ControlToValidate="tbVerifyCode" />
				</div>
				<div class="col-xs-6">
					<img class="verifycode" src="<%= ResolveClientUrl("~/web/verifycode.aspx") %>" onclick="this.src = '<%= ResolveClientUrl("~/web/verifycode.aspx") %>?' + Math.random()" alt="验证码" />
				</div>
			</div>
		</div>

		<div class="row">
			<div class="col-xs-3">
				<a href="FindPassStep1.aspx">
					<asp:Button runat="server" ID="btnLogin" Text="登  录" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
				</a>
			</div>
			<div class="col-xs-3">
				<a href="./EntRegStep1.aspx">
					<input type="button" class="btn btn-warning" value="注册" />
				</a>
			</div>
			<div class="col-xs-6" style="text-align: right;">
				<a href="FindPassStep1.aspx">忘记密码</a>
			</div>
		</div>
	</div>
</asp:PlaceHolder>

<asp:PlaceHolder runat="server" ID="phUserInfo">
	<div class="panel-heading">
		<h3 class="panel-title"><i class="glyphicon glyphicon-user"></i>&nbsp;&nbsp;用户信息</h3>
	</div>
	<div class="panel-body">
		<table class="table">
			<tbody>
				<tr>
					<td>登陆名：</td>
					<td><asp:Literal runat="server" ID="txtAccount" /></td>
				</tr>
				<tr>
					<td>用户名：</td>
					<td><asp:Literal runat="server" ID="txtName" /></td>
				</tr>
				<tr>
					<td>会员等级：</td>
					<td><asp:Label runat="server" ID="txtLevel" /></td>
				</tr>
				<tr>
					<td><asp:HyperLink runat="server" NavigateUrl="~/member/Logout.aspx" CssClass="btn btn-default">退出</asp:HyperLink></td>
					<td>&nbsp;</td>
				</tr>
			</tbody>
		</table>
	</div>
</asp:PlaceHolder>
</div>