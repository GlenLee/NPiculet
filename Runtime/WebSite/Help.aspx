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

	3:DoPageTable
	<asp:GridView runat="server" ID="gvDoPageTable"></asp:GridView>
	手动分页：<a href="?page=1">1</a> <a href="?page=2">2</a>
	<hr />

	4:AutoPageTable
	<asp:GridView runat="server" ID="gvAutoPageTable" AutoGenerateColumns="false" AllowPaging="True"
		PageSize="5">
		<Columns>
			<asp:BoundField DataField="Id" HeaderText="ID" />
			<asp:BoundField DataField="Name" HeaderText="名字" />
			<asp:BoundField DataField="Path" HeaderText="路径" />
		</Columns>
		<PagerSettings Mode="NumericFirstLast" />
	</asp:GridView>


    5:AutoPageTable
	<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" AllowPaging="True"
		PageSize="5">
		<Columns>
			<asp:BoundField DataField="CompanyName" HeaderText="名字" />
			<asp:BoundField DataField="IsPassAudit" HeaderText="状态" />
		</Columns>
	</asp:GridView>

</form>

</body>
</html>