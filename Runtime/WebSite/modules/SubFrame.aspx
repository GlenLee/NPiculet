<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubFrame.aspx.cs" Inherits="modules_SubFrame" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>管理后台</title>
    <script type="text/javascript" language="javascript">
    	//if (window.top != window.self) { window.top.location = "Main.aspx"; }

    	function init() {
    	}
    </script>
</head>

<frameset cols="182,*" frameborder="no" border="0" framespacing="0">
	<frame src="<%= GetPageUrl() %>" name="sideFrame" scrolling="auto" noresize="noresize" id="sideFrame" title="sideFrame" />
	<frame src="DashBoard.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />
</frameset>

</html>
