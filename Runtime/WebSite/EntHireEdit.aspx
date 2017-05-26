<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPage.master" AutoEventWireup="true" CodeFile="EntHireEdit.aspx.cs" Inherits="EntHireEdit" %>

<%@ Register TagPrefix="uc1" TagName="MemberSidebar" Src="~/web/uc/CorporationSideBar.ascx" %>
<%@ Register Src="~/modules/common/Prompt.ascx" TagName="Prompt" TagPrefix="zx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" charset="utf-8" src="modules/../scripts/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="modules/../scripts/ueditor/ueditor.all.js"> </script>
    <script type="text/javascript" charset="utf-8" src="modules/../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="content" runat="Server">
    <zx:Prompt ID="promptControl" runat="server" />
    <div class="ui-member-content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="sui-row-fluid" style="margin-top: 10px;">
            <div class="span3">
                <uc1:MemberSidebar ID="MemberSidebar1" runat="server" Actived="EntHireList.aspx" />
            </div>
            <div class="span9 sui-form">
                <div class="title">招聘信息</div>
                <asp:PlaceHolder ID="EntHireEditor" runat="server">
                    <asp:HiddenField ID="Id" runat="server" />
                    <asp:HiddenField ID="GroupCode" runat="server" Value="EntHire" />

                    <div class="sui-row-fluid">
                        <span class="span1">招聘标题：</span>
                        <div class="span6">
                            <asp:TextBox Width="300px" ID="InfoTitle" runat="server" CssClass="input-large"></asp:TextBox>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">招聘状态：</span>
                        <div class="span6">
                            <asp:DropDownList ID="IsEnabled" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">招聘要求：</span>
                        <div class="span11">
                            <script id="editorContent" type="text/plain" style="width: 90%; height: 800px;"></script>
                            <asp:HiddenField runat="server" ID="Content" />
                        </div>
                    </div>
                </asp:PlaceHolder>
                <div class="sui-row-fluid">
                    <span class="span1"></span>
                    <div class="span11">
                        <asp:LinkButton ID="btnSave" runat="server" OnClientClick="save()" OnClick="btnSave_Click" CssClass="sui-btn btn-large btn-success">保存编辑</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnGoBack_Click" CssClass="sui-btn btn-large btn-warning">返回</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        var editor = UE.getEditor('editorContent');
        var contentControl = document.getElementById("<%= this.Content.ClientID %>");

        editor.addListener("ready", function () {
            editor.setHeight(300);
            editor.setContent(contentControl.value);
        });

        function save() {
            contentControl.value = editor.getContent();
        }
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
