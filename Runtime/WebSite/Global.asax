<%@ Application Language="C#" %>
<%@ Import Namespace="NPiculet.Log" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码
		var err = Server.GetLastError();
	    if (err != null) {
			var baseErr = err.GetBaseException();
			//记录事件日志
			Logger.Error("应用程序错误！", err);
			//string msg = "Error Caught in Application_Error event\n"
			//    + "Error in:" + Request.Url.ToString()
			//    + "\nError Message:" + baseErr.Message
			//    + "\nStack Trace:" + baseErr.StackTrace;
			//EventLog.WriteEntry("Sample_WebApp", msg, EventLogEntryType.Error);  
	    }
		//清除错误
		//Server.ClearError(); 
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为 InProc 时，才会引发 Session_End 事件。
        // 如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }
       
</script>
