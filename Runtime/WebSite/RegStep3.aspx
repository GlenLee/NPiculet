<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="RegStep3.aspx.cs" Inherits="RegStep3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
	<!-- 步骤条 -->
	<div class="sui-steps steps-large steps-auto">
		<div class="wrap">
			<div class="finished">
				<label><span class="round"><i class="sui-icon icon-pc-right"></i></span><span>第一步 填写注册信息</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
			</div>
		</div>
		<div class="wrap">
			<div class="finished">
				<label><span class="round">2</span><span>第二步 完善基本资料</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
			</div>
		</div>
		<div class="wrap">
			<div class="current">
				<label><span class="round">3</span><span>第三步 注册成功</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
			</div>
		</div>
	</div>
	<!-- 标签 -->
	<ul class="sui-nav nav-tabs nav-large nav-primary">
		<li class="active"><a>个人会员注册</a></li>
		<li><a href="EntRegStep1.aspx">单位会员注册</a></li>
	</ul>
	<!-- 注册 -->
	<div class="ui-reg step3">
		<h1>您的确认邮箱是：xxxxx@mail.com</h1>
		<p>请登录您的邮箱，点击其中验证链接，激活您的账号。</p>
		<div>
			<input type="button" value="登录邮箱" class="sui-btn btn-xlarge btn-warning"/>
		</div>
		<p>没有收到验证邮件？</p>
		<ol>
			<li>请检查邮箱是否将激活邮件错误归到垃圾邮件中；</li>
			<li>登录邮箱...</li>
		</ol>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
