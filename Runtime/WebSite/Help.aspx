<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="web_Help" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

<form id="frm" runat="server">

	1:SingleTable
	<asp:GridView runat="server" ID="gvSingleTable"></asp:GridView>
	<hr />

	2:JoinTable
	<asp:GridView runat="server" ID="gvJoinTable"></asp:GridView>
	<hr />

</form>

</body>
</html>