<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberLoginOfIndex.ascx.cs" Inherits="web.uc.WebUcMemberLoginOfIndex" %>
<div class="ui-widget" style="height: 250px;">
	<div class="title">
		<i class="sui-icon icon-touch-user3-sign"></i>&nbsp;&nbsp;用户登录
	</div>
	<div class="content">
		<div class="sui-row" style="margin: 0em 0em 1em 0em">
			<div class="span3">用户名:</div>
			<div class="span6">
				<asp:TextBox runat="server" ID="tbUserName" CssClass="input-large" />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
					ErrorMessage="用户名不能为空" ForeColor="red" ControlToValidate="tbUserName" />
			</div>
		</div>
		<div class="sui-row" style="margin: 1em 0em 1em 0em">
			<div class="span3">密  码:</div>
			<div class="span6">
				<asp:TextBox runat="server" ID="tbPassword" CssClass="input-large" TextMode="Password" />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
					ErrorMessage="密码不能为空" ForeColor="red" ControlToValidate="tbPassword" />
			</div>
		</div>
		<div class="sui-row" style="margin: 1em 0em 1em 0em">
			<div class="span3">验证码:</div>
			<div class="span3">
				<asp:TextBox runat="server" ID="tbVerifyCode" CssClass="input-small" />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
					ErrorMessage="不能为空" ForeColor="red" ControlToValidate="tbVerifyCode" />
			</div>
			<div class="span4">
				<img style="width: 80px; height: 30px" src="/modules/common/verifycode.aspx" onclick="this.src = '/modules/common/verifycode.aspx?' + Math.random()" alt="验证码" />
			</div>
		</div>
		<div class="sui-row">
			<div class="span6" style="float: right">
				<a href="FindPassStep1.aspx">忘记密码，点击这里找回</a>
			</div>
		</div>
		<div class="sui-row" style="margin: 1em 0em 1em 0em">
			<div class="span3">
			</div>
			<div class="span3">
				<asp:Button runat="server" ID="btnLogin" Text="登  录" CssClass="sui-btn btn-large btn-primary" OnClick="btnLogin_Click" />
			</div>
			<div class="span1">
			</div>
			<div class="span3">
				<a href="./EntRegStep1.aspx">
					<input type="button" class="sui-btn btn-large btn-warning" value="注册" />
				</a>
			</div>
		</div>
	</div>
</div>
