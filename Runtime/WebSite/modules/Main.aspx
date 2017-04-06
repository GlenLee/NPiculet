<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="modules_Main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>管理后台</title>
</head>

<frameset rows="100,*" frameborder="no" border="0" framespacing="0">
	<frame src="Header.aspx" name="headFrame" scrolling="No" noresize="noresize" id="headFrame" title="headFrame" />
	<frameset cols="220,*" frameborder="no" border="0" framespacing="0">
		<frame src="WaitingList.aspx" name="sideFrame" scrolling="auto" noresize="noresize" id="sideFrame" title="sideFrame" />
		<frame src="DashBoard.aspx" name="mainFrame" id="mainFrame" scrolling="auto" title="mainFrame" />
	</frameset>
</frameset>

</html>
