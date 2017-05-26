<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="EntRegStep3.aspx.cs" Inherits="EntRegStep3" %>

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
        <li class="active"><a>单位会员注册</a></li>
        <li><a href="RegStep1.aspx">个人会员注册</a></li>
    </ul>
    <!-- 注册 -->
    <div class="ui-reg step3">
        <h1>您已经完成注册，正在为您审核！</h1>
        <div>
            <a href="Login.aspx">
                <input type="button" value="登录" class="sui-btn btn-xlarge btn-warning" />
            </a>
            <a href="default.aspx">
                <input type="button" value="返回首页" class="sui-btn btn-xlarge" /></a>
        </div>
		<h4>感谢您的注册！</h4>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

