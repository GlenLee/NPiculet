<%@ Page Title="" Language="C#" MasterPageFile="~/ContentPage.master" AutoEventWireup="true" CodeFile="RegStep2.aspx.cs" Inherits="RegStep2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .btn-primary {
            height: 21px;
        }
    </style>
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
            <div class="current">
                <label><span class="round">2</span><span>第二步 完善基本资料</span></label><i class="triangle-right-bg"></i><i class="triangle-right"></i>
            </div>
        </div>
        <div class="wrap">
            <div class="todo">
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
    <div class="sui-form" id="frm" runat="server">
        <h1>完善个人资料</h1>
        <div id="step2" class="step2" runat="server">
            <div style="text-align: center;">
                <asp:Literal runat="server" ID="txtName"></asp:Literal>您好，您的账号[<asp:Literal runat="server" ID="txtAccount"></asp:Literal>]已建立，请牢记！
            </div>
            <%--<div class="form-group">
			<label for="<%= this.CcfbCode.ClientID %>" class="col-sm-2 control-label">春城风暴号：</label>
			<div class="col-sm-8">
				<asp:TextBox runat="server" ID="CcfbCode" ReadOnly="True" CssClass="form-control"></asp:TextBox>
			</div>
		</div>--%>
            <div class="form-group">
                <label for="<%= this.QQ.ClientID %>" class="col-sm-2 control-label">QQ/微信：</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="QQ" CssClass="form-control" placeholder="请输入QQ/微信号码" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%= this.Email.ClientID %>" class="col-sm-2 control-label">电子邮箱：</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="Email" CssClass="form-control" placeholder="请输入电子邮箱" MaxLength="64" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%= this.Address.ClientID %>" class="col-sm-2 control-label">住址：</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="Address" CssClass="form-control" placeholder="请输入住址" MaxLength="255" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%= this.IdCard.ClientID %>" class="col-sm-2 control-label">身份证号：</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="IdCard" CssClass="form-control" placeholder="请输入身份证号" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="<%= this.Sex.ClientID %>" class="col-sm-2 control-label">性别：</label>
                <div class="col-sm-8">
                    <asp:DropDownList ID="Sex" CssClass="form-control" runat="server">
                        <asp:ListItem>保密</asp:ListItem>
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label for="<%= this.Interest.ClientID %>" class="col-sm-2 control-label">兴趣：</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="Interest" CssClass="form-control" placeholder="请输入兴趣" MaxLength="128" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button runat="server" ID="btnSave" CssClass="sui-btn btn-xlarge btn-warning" Text="保存" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
