<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberSidebar.ascx.cs" Inherits="web_uc_MemberSidebar" %>
<div class="ui-member-sidebar">
    <div class="header">
        <img src="../../styles/images/head-pic.png" alt="" />
        个人中心
    </div>
    <ul>
        <li>
            <div>
                <a href="MemberCenter.aspx" <%= GetActived("MemberCenter.aspx") %>>个人资料</a>
            </div>
        </li>
        <li>
            <div>
                <a href="MemberResume.aspx" <%= GetActived("MemberResume.aspx") %>>我的简历</a>
            </div>
        </li>
<%--        <li>
            <div>
                <a href="MemberHire.aspx" <%= GetActived("MemberArticle.aspx") %>>我的招聘</a>
            </div>
        </li>--%>
    </ul>
</div>
