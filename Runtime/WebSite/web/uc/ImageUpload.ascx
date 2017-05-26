<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageUpload.ascx.cs" Inherits="web_uc_ImageUpload" %>
<div class="uc-image-upload">
	<asp:Image runat="server" ID="img"  />
	<div class="controls">
		<asp:FileUpload runat="server" ID="fileUpload" />
		<asp:Button runat="server" ID="btnFileUpload" OnClick="btnFileUpload_OnClick" />
	</div>
</div>
