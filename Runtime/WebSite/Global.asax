<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Newtonsoft.Json.Linq" %>
<%@ Import Namespace="NPiculet.Log" %>
<%@ Import Namespace="NPiculet.Toolkit" %>

<script runat="server">

	void Application_Start(object sender, EventArgs e)
	{
		// 在应用程序启动时运行的代码
		RegisterRoutes(RouteTable.Routes);
	}

	private void RegisterRoutes(RouteCollection routes) {
		// 载入配置文件
		string json = FileKit.ReadTextFile(Server.MapPath("~/routes.json"), Encoding.ASCII);
		try {
			JObject configs = JsonKit.ToJsonObject(json);
			JArray jroutes = configs["routes"].Value<JArray>();
			// 注册路由
			foreach (JToken jroute in jroutes) {
				string name = jroute["name"].ToString();
				string route = jroute["route"].ToString();
				string url = jroute["url"].ToString();
				routes.MapPageRoute(name,
					route,
					url,
					true);
			}
		} catch (Exception ex) {
			throw new Exception("没有正确读取JSON配置：" + json, ex);
		}
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
			//var baseErr = err.GetBaseException();

			//记录事件日志
			Logger.Error("应用程序错误！", err);
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
