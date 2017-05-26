<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="web_Test" %>
<%@ Register Src="~/web/uc/ImageUpload.ascx" TagPrefix="uc1" TagName="ImageUpload" %>
<%@ Register TagPrefix="uc1" TagName="WebQuote" Src="~/web/uc/WebQuote.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:WebQuote runat="server" ID="WebQuote" />
</head>
<body>
    <form id="frm" runat="server">
		<uc1:ImageUpload runat="server" ID="ImageUpload" />
		<uc1:ImageUpload runat="server" ID="ImageUpload1" />
    </form>
</body>
</html>
