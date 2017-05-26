<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPage.master" AutoEventWireup="true" CodeFile="EntAdvEdit.aspx.cs" Inherits="EntAdvEdit" %>

<%@ Register TagPrefix="uc1" TagName="MemberSidebar" Src="~/web/uc/CorporationSideBar.ascx" %>
<%@ Register Src="~/modules/common/Prompt.ascx" TagName="Prompt" TagPrefix="zx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="content" runat="Server">
    <zx:Prompt ID="promptControl" runat="server" />
    <div class="ui-member-content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="sui-row-fluid" style="margin-top: 10px;">
            <div class="span3">
                <uc1:MemberSidebar ID="MemberSidebar1" runat="server" Actived="EntAdvEdit.aspx" />
            </div>
            <div class="span9 sui-form">
                <div class="title">广告位编辑</div>
                <asp:HiddenField ID="Id" runat="server" />
                <asp:PlaceHolder ID="EntAdvEditor" runat="server">
                    <div class="sui-row-fluid">
                        <div class="span1">广告位置：</div>
                        <div class="span6">
                            <asp:DropDownList ID="Type" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">描述：</span>
                        <div class="span6">
                            <asp:TextBox Width="300px" ID="Description" runat="server" CssClass="input-large"></asp:TextBox>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">广告链接：</span>
                        <div class="span10">
                            <asp:TextBox Width="300px" ID="Url" runat="server" CssClass="input-large"></asp:TextBox>&nbsp;需要填写http://
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">广告图片：</span>
                        <div class="span8">
                            <table style="border: 0;">
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="AdvImage" runat="server" Width="400px" />
                                        <div class="caption">注：支持 .jpg .png .bmp .gif 格式的图片，图片大于1024会自动压缩。</div>
                                    </td>
                                    <td style="padding: 4px">
                                        <asp:HyperLink ID="ImageHyperLink" runat="server" CssClass="thumb-link">
                                            <asp:Image ID="PreviewImage" runat="server" Width="100px" Height="100px" Visible="false" CssClass="thumb-image" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">开始时间：</span>
                        <div class="span6">
                            <asp:Calendar DayNameFormat="Full" runat="server" ID="StartDate">
                                <WeekendDayStyle BackColor="#fafad2" ForeColor="#ff0000" />
                                <DayHeaderStyle ForeColor="#0000ff" />
                                <TodayDayStyle BackColor="LightGray" />
                                <SelectedDayStyle BackColor= "DarkOrange"/>
                            </asp:Calendar>
                        </div>
                    </div>
                    <div class="sui-row-fluid">
                        <span class="span1">申请时长：</span>
                        <div class="span6">
                            <asp:TextBox Width="60px" ID="ValidTerm" runat="server" CssClass="input-small"></asp:TextBox>&nbsp;天
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="sui-btn btn-large btn-success">保存编辑</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnGoBack_Click" CssClass="sui-btn btn-large btn-warning">返回</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
