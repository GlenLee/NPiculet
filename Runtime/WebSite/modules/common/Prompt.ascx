<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Prompt.ascx.cs" Inherits="system_UserControls_Prompt" %>
<div id="prompt" class="sui-msg msg-large msg-block" runat="server" Visible="False">
	<div class="msg-con"><asp:Literal runat="server" ID="promptContent"></asp:Literal></div>
	<s class="msg-icon"></s>
</div>
<script type="text/javascript">
	setTimeout(function () {
		$('.sui-msg').slideUp();
	}, 10000);
</script>