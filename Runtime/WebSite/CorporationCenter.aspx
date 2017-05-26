<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPage.master" AutoEventWireup="true" CodeFile="CorporationCenter.aspx.cs" Inherits="CorporationCenter" %>

<%@ Register TagPrefix="uc1" TagName="CorporationSidebar" Src="~/web/uc/CorporationSidebar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .form-control {
            border: 1px solid #ccc;
            border-radius: 4px;
            padding: 4px;
        }

        .span2 {
            text-align: right;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div class="ui-member-content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="sui-row-fluid" style="margin-top: 10px;">
            <div class="span3">
                <uc1:CorporationSidebar ID="CorporationSidebar1" runat="server" Actived="CorporationCenter.aspx" />
            </div>
            <div class="span9">
                <div class="title">个人资料</div>

                <asp:PlaceHolder ID="infoEditor" runat="server">
                    <div class="sui-row-fluid">
                        <div class="span3" style="text-align: right">
                            <img src="styles/images/head-pic.jpg" alt="" />
                        </div>
                        <div class="span9">
                            头像上传
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <div class="span2">企业简称：</div>
                        <div class="span10">
                            <asp:TextBox Width="300px" ID="CorporationBreifName" runat="server" class="form-control" MaxLength="32" BackColor="#eeeeee"></asp:TextBox>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <div class="span2">企业全称：</div>
                        <div class="span10">
                            <asp:TextBox Width="300px" ID="CorporationName" runat="server" ReadOnly="true" class="form-control" MaxLength="32"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="必填" ForeColor="red" ControlToValidate="CorporationName"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="CorporationName" Display="Dynamic" ErrorMessage="请输入中文汉字" ForeColor="red" ValidationExpression="[\u4e00-\u9fa5]{2,7}"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="split"></div>

                    <div class="sui-row-fluid">
                        <div class="span2">企业性质</div>
                        <div class="span10">
                            <asp:RadioButtonList runat="server" ID="CorporationNature" Width="215px" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                
                            </asp:RadioButtonList>
                        </div>
                    </div>
                     <div class="sui-row-fluid">
                        <div class="span2">负责人：</div>
                        <div class="span10">
                            <asp:TextBox ID="chargeMan" runat="server" Width="215px" class="form-control" required="true" MaxLength="16"></asp:TextBox>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <div class="span2">负责人手机号码：</div>
                        <div class="span10">
                            <asp:TextBox Width="300px" ID="chargeManTel" runat="server" class="form-control" MaxLength="32"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="必填" ForeColor="red" ControlToValidate="Mobile"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="chargeManTel" Display="Dynamic" ErrorMessage="请输入正确的手机号码" ForeColor="red" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <div class="span2">法人名称：</div>
                        <div class="span10">
                            <asp:TextBox ID="laywer" runat="server" Width="215px" class="form-control" required="true" MaxLength="16"></asp:TextBox>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <div class="span2">法人手机号码：</div>
                        <div class="span10">
                            <asp:TextBox Width="300px" ID="Mobile" runat="server" class="form-control" MaxLength="32"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ErrorMessage="必填" ForeColor="red" ControlToValidate="Mobile"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mobile" Display="Dynamic" ErrorMessage="请输入正确的手机号码" ForeColor="red" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                  
                    <div class="sui-row-fluid">
                        <div class="span2">地址：</div>
                        <div class="span10">
                            <asp:TextBox ID="CorporationAddress" runat="server" class="form-control" TextMode="MultiLine" MaxLength="550"></asp:TextBox>
                        </div>
                    </div>
                   
                   <%-- <div class="sui-row-fluid">
                        <div class="span2"></div>
                        <div class="span10">
                            <asp:Button runat="server" class="btn btn-info" ID="btnSave" OnClick="btnSave_Click" Text="保存" />
                        </div>
                    </div>--%>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
