<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberSimpleInfo.ascx.cs" Inherits="web.uc.WebUcMemberSimpleInfo" %>
<div class="ui-widget" style="height:250px;position:relative;">
    <div class="title">
        <i class="sui-icon icon-touch-user3-sign"></i>&nbsp;&nbsp;用户信息
    </div>
    <div class="content" style="padding:0;">
		<div class="sui-row-fluid">
			<div class="span4">
				<img src="styles/images/head-pic.jpg" alt="" style="width:80px;margin:20px 5px 5px 5px;" />
			</div>
			<div class="span8">
				<div>&nbsp;</div>
				<div class="sui-row" style="margin: 0em 0em 1em 0em">
					<div class="span4">登陆名:</div>
					<div class="span8">
						<asp:Label runat="server" ID="lblAccount" CssClass="input-large" />
					</div>
				</div>
				<div class="sui-row" style="margin: 0em 0em 1em 0em">
					<div class="span4">用户名:</div>
					<div class="span8">
						<asp:Label runat="server" ID="lblName" CssClass="input-large" />
					</div>
				</div>
				<div class="sui-row" style="margin: 1em 0em 1em 0em">
					<div class="span4">行业评分：</div>
					<div class="span8">
						<asp:Label runat="server" ID="lblExp" CssClass="input-large" />
					</div>
				</div>
				<div class="sui-row" style="margin: 1em 0em 1em 0em">
					<div class="span4">会员类型:</div>
					<div class="span8">
						<asp:Label runat="server" ID="lblMemberLevel" CssClass="input-small" />
					</div>
				</div>
			</div>
		</div>
        <div class="sui-row-fluid" style="position:absolute;bottom:0;width:100%;">
            <div class="span12" style="text-align:center;background-color:#eee;line-height:50px;font-size:16px;">
                <asp:LinkButton ID="btn_center" runat="server" Text="个人中心" OnClick="btn_center_Click" ></asp:LinkButton>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="../../Logout.aspx">退出</a>
            </div>
        </div>
    </div>
</div>
