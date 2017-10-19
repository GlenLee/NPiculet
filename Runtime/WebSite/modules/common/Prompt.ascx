<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Prompt.ascx.cs" Inherits="system_UserControls_Prompt" %>
<div id="prompt" runat="server" Visible="False" role="alert">
	<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
	<asp:Literal runat="server" ID="promptContent"></asp:Literal>
</div>
<script type="text/javascript">
	setTimeout(function () {
		$('.alert').slideUp();
	}, 6000);
</script>