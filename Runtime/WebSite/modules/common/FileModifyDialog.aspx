<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileModifyDialog.aspx.cs" Inherits="modules_common_FileModifyDialog" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <link href="" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/modules/css/style.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/modules/css/agent.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/modules/css/select.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveClientUrl("~/scripts/lib/jquery-1.11.3.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/modules/js/overlay.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/modules/js/select-ui.min.js") %>" type="text/javascript"></script>
    <style type="text/css">
        form {
            clear: both;
        }
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
    <form id="round" runat="server">
        <div class="formbody">
            <ul class="forminfo">
                <li>
                    <div class="vocation">
                        <label>名称</label>
                        <asp:TextBox ID="name" runat="server" CssClass="dfinput" Width="180px"></asp:TextBox>
                    </div>
                </li>
                <li class="clear"></li>
                <li>
                    <div class="vocation">
                        <label>所在目录</label>
                        <asp:DropDownList runat="server" ID="curDir" CssClass="scinput1" Width="180px"/>
                    </div>
                </li>
                 <li class="clear"></li>
                <li>
                    <div class="vocation">
                        <asp:Button ID="btnModify" runat="server" Text="修改" CssClass="btn" OnClick="btnModify_Click"/>
                    </div>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>



