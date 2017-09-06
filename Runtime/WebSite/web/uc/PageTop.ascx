<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageTop.ascx.cs" Inherits="web_uc_PageTop" %>
<asp:PlaceHolder runat="server" ID="phBanner">
	<div class="ui-top">
		<asp:HyperLink runat="server" ID="bannerImageLink" Target="_blank"></asp:HyperLink>
		<div class="full-win">
			<asp:Image runat="server" ID="bannerCover" AlternateText=""/>
			<div class="close">
				<a href="#" onclick="$('.full-win').slideUp();return false;"><i class="sui-icon icon-pc-error"></i>&nbsp;关闭</a>
			</div>
		</div>
	</div>
	<asp:Literal runat="server" ID="CssScript"></asp:Literal>
</asp:PlaceHolder>