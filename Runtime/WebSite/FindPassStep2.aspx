<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="FindPassStep2.aspx.cs" Inherits="FindPassStep2" %>
<%@ Register TagPrefix="uc1" TagName="NavMenu" Src="~/web/uc/NavMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" Runat="Server">
        <uc1:NavMenu runat="server" ID="NavMenu" Active="-1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <!-- 步骤条 -->
    <div class="sui-steps steps-large steps-auto">
        <div class="wrap">
            <div class="todo">
                <label><span class="round"><i class="sui-icon icon-pc-right"></i></span><span>第一步 填写原注册信息</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
            </div>
        </div>
        <div class="wrap">
            <div class="current">
                <label><span class="round">2</span><span>第二步 展示账号信息</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
            </div>
        </div>
      
    </div>
    <!-- 标签 -->
    <ul class="sui-nav nav-tabs nav-large nav-primary">
        <li class="active"><a>找回账号密码</a></li>
      
    </ul>
    <div class="sui-form ui-reg step1" id="frm">
        <div id="step1" class="step1" runat="server">
            <div class="sui-row-fluid">
            </div>
            <div class="sui-row-fluid">
                <div class="span5" style="text-align: right;"><span style="color: red">*</span>登录帐号：</div>
                <div class="span7">
                    <asp:TextBox ID="Account" CssClass="input-large" placeholder="帐号（只能4-32位的英文、数字或下划线组合）" MaxLength="32" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="必填" ForeColor="red" ControlToValidate="Account"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ControlToValidate="Account" Display="Dynamic" ErrorMessage="应输入4-32位的英文、数字或下划线组合，首位必须是英文"
                        ForeColor="red" ValidationExpression="[a-zA-Z]\w{3,31}"></asp:RegularExpressionValidator>
                </div>
            </div>
            
            
            
            <div class="sui-row-fluid">
                <div class="span5 tx-al-rt"><span style="color: red">*</span>真实姓名：</div>
                <div class="span7">
                    <asp:TextBox ID="Name" CssClass="input-large" placeholder="请输入真实姓名" MaxLength="32" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                        ErrorMessage="必填" ForeColor="red" ControlToValidate="Name"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                        runat="server" ControlToValidate="Name" Display="Dynamic" ErrorMessage="请输入中文汉字" ForeColor="red"
                        ValidationExpression="[\u4e00-\u9fa5]{2,7}"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="sui-row-fluid">
                <div class="span5" style="text-align: right;"><span style="color: red">*</span>手机号码：</div>
                <div class="span7">
                    <asp:TextBox ID="Mobile" CssClass="input-large" placeholder="请输入手机号码" MaxLength="32" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                        ErrorMessage="必填" ForeColor="red" ControlToValidate="Mobile"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        runat="server" ControlToValidate="Mobile" Display="Dynamic" ErrorMessage="请输入正确的手机号码" ForeColor="red"
                        ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="sui-row-fluid">
                <div class="span5" style="text-align: right;"><span style="color: red">*</span>邮箱地址：</div>
                <div class="span7">
                    <asp:TextBox ID="Email" CssClass="input-large" placeholder="请输入邮箱" MaxLength="32" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                        ErrorMessage="必填" ForeColor="red" ControlToValidate="Email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                        runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="请正确地输入邮箱格式" ForeColor="red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            
            <div class="sui-row-fluid">
                <div class="span5"></div>
                <div class="span7">
                </div>
            </div>
        </div>
    </div>
	
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

