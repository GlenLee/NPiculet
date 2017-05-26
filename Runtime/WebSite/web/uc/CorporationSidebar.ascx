<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CorporationSidebar.ascx.cs" Inherits="web_uc_CorporationSidebar" %>
<div class="ui-member-sidebar">
    <div class="header">
        <img src="../../styles/images/head-pic.png" alt="" />
        个人中心
    </div>
    <ul>
        <li>
            <div>
                <a href="CorporationCenter.aspx" <%= GetActived("CorporationCenter.aspx") %>>企业资料</a>
            </div>
        </li>
        <li>
            <div>
                <a href="CorporationQualification.aspx" <%= GetActived("CorporationQualification.aspx") %>>资质材料</a>
            </div>
        </li>
        
        <li>
            <div>
                <a href="EntAdvList.aspx" <%= GetActived("EntAdvList.aspx") %>>广告管理</a>
            </div>
        </li>
<%--        <li>
            <div>
                <a href="EntArticle.aspx" <%= GetActived("EntArticle.aspx") %>>企业文章</a>
            </div>
        </li>--%>
        <li>
            <div>
                <a href="EntHireList.aspx" <%= GetActived("EntHireList.aspx") %>>企业招聘</a>
            </div>
        </li>
    </ul>
</div>

