<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginWidget.ascx.cs" Inherits="web_uc_LoginWidget" %>
<asp:PlaceHolder runat="server" ID="phLogin">
	<h5>
		<i class="glyphicon glyphicon-user"></i>&nbsp;&nbsp;用户登录
	</h5>

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
</asp:PlaceHolder>

<asp:PlaceHolder runat="server" ID="phUserInfo">
	<h5>
		<i class="glyphicon glyphicon-user"></i>&nbsp;&nbsp;用户信息
	</h5>
<div class="ui-widget" style="height:250px;position:relative;">
	<div class="content" style="padding:0;">
		<div class=" row">
			<div class="col-xs-4">
				<img src="styles/images/head-pic.jpg" alt="" style="width:80px;margin:20px 5px 5px 5px;" />
			</div>
			<div class="col-xs-8">
				<div>&nbsp;</div>
				<div class="row" style="margin: 0em 0em 1em 0em">
					<div class="col-xs-4">登陆名：</div>
					<div class="col-xs-8">
						<asp:Literal runat="server" ID="txtAccount" />
					</div>
				</div>
				<div class="row" style="margin: 0em 0em 1em 0em">
					<div class="col-xs-4">用户名：</div>
					<div class="col-xs-8">
						<asp:Literal runat="server" ID="txtName" />
					</div>
				</div>
				<div class="row" style="margin: 1em 0em 1em 0em">
					<div class="col-xs-4">会员等级：</div>
					<div class="col-xs-8">
						<asp:Label runat="server" ID="txtLevel" />
					</div>
				</div>
			</div>
		</div>
		<div class="row" style="position:absolute;bottom:0;width:100%;">
			<div class="col-xs-12" style="text-align:center;background-color:#eee;line-height:50px;font-size:16px;">
				<asp:HyperLink runat="server" NavigateUrl="~/member/Logout.aspx">退出</asp:HyperLink>
			</div>
		</div>
	</div>
</div>
</asp:PlaceHolder>