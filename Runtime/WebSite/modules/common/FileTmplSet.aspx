<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTmplSet.aspx.cs" Inherits="modules_common_FileTmplSet" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/lib/jquery-1.11.3.min.js") %>" type="text/javascript"></script>
	<style type="text/css">
		* { font-size:14px; }
		html, body { padding:0;margin:0; }
		form { padding:10px; }
		table { width:100%; }
		.text { padding:6px;border-radius:3px;border:1px solid #ccc;width:300px; }
		.btn { display:block;padding:8px 12px;border-radius:3px;width:60px;background-color:#CC0020;text-align:center;color:#fff;text-decoration:none; }
	</style>
	<script type="text/javascript">
		function closeWin() {
			if (window.parent.loadfiles) {
				window.parent.loadfiles();
			} else {
				window.parent.location = window.parent.location;
			}
			if (window.parent.layer) {
				window.parent.layer.close();
			}
		}
	</script>
</head>
<body>
    <form id="frm" runat="server">
	    <table cellpadding="2" cellspacing="2">
		    <tr>
				<td>文件名称：</td>
				<td><asp:TextBox runat="server" ID="FileName" CssClass="text"></asp:TextBox></td>
		    </tr>
			<tr>
				<td></td>
				<td><asp:LinkButton runat="server" ID="btnSave" CssClass="btn" Text="保存" OnClick="btnSave_OnClick"></asp:LinkButton></td>
			</tr>
	    </table>
    </form>
</body>
</html>
