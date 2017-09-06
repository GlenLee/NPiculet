<%@ Page Title="" Language="C#" MasterPageFile="MemberPage.master" AutoEventWireup="true" CodeFile="MemberResume.aspx.cs" Inherits="MemberResume" %>


<%@ Register TagPrefix="uc1" TagName="MemberSidebar" Src="uc/MemberSidebar.ascx" %>
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
                <uc1:MemberSidebar ID="MemberSidebar1" runat="server" Actived="MemberResume.aspx" />
            </div>
            <div class="span9 sui-form">
                <div class="title">我的简历</div>
                <asp:PlaceHolder ID="MemberResumeEditor" runat="server">
                    <asp:HiddenField ID="UserId" runat="server" />
                    <asp:HiddenField ID="GroupCode" runat="server" Value="PageJobSeeker" />

                    <div class="sui-row-fluid">
                        <span class="span1">简历标题：</span>
                        <div class="span6">
                            <asp:TextBox Width="300px" ID="InfoTitle" runat="server" CssClass="input-large"></asp:TextBox>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">简历状态：</span>
                        <div class="span6">
                            <asp:DropDownList ID="IsEnabled" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">个人履历：</span>
                        <div class="span11">
                            <script id="editorContent" type="text/plain" style="width: 90%; height: 800px;"></script>
                            <asp:HiddenField runat="server" ID="Content" />
                        </div>
                    </div>
                </asp:PlaceHolder>
                <div class="sui-row-fluid">
                    <span class="span1"></span>
                    <div class="span11">
                        <asp:LinkButton ID="btnSave" runat="server" OnClientClick="save()" OnClick="btnSave_Click" CssClass="sui-btn btn-large btn-success">保存</asp:LinkButton>
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

