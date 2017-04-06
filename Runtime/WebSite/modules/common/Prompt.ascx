<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Prompt.ascx.cs" Inherits="system_UserControls_Prompt" %>
<div id="prompt" class="ui green message" runat="server" Visible="False">
	<i class="close icon" onclick="$('.prompt').slideUp();"></i>
	<asp:Literal runat="server" ID="promptContent"></asp:Literal>
</div>
<script type="text/javascript">
	setTimeout(function () {
		$('.prompt').slideUp();
	}, 10000);
</script>