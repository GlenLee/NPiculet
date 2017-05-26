<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageHeader.ascx.cs" Inherits="web.uc.WebUcPageHeader" %>
<div class="ui-top">
    <div class="wrap">
        <ul>
            <li>今日天气：-</li>
            <li>SUN</li>
            <li>空气：良</li>
            <li>PM：2.5</li>
            <li>风力：西南风1级</li>
        </ul>
        <div class="toolbar">
            <%=GetLoginStatus()%>
        </div>
    </div>
</div>
