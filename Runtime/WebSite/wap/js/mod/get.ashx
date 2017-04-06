<%@ WebHandler Language="C#" Class="get" %>

using System;
using System.Net;
using System.Text;
using System.Web;

public class get : IHttpHandler {

	public void ProcessRequest(HttpContext context)
	{
		try {
			string url = context.Request.QueryString["u"];
			string code = context.Request.QueryString["code"];
			code = string.IsNullOrWhiteSpace(code) ? "UTF-8" : code;

			url = System.Text.RegularExpressions.Regex.Unescape(url);

			WebClient wc = new WebClient();

			byte[] bytes = wc.DownloadData(url);
			string content = Encoding.GetEncoding(code).GetString(bytes);

			PrintResult(context, content);
			PrintResult(context, content);
		} catch (Exception ex) {
			PrintResult(context, ex.Message);
		}
	}

	#region 通用类

	public bool IsReusable
	{
		get
		{
			return false;
		}
	}

	private void PrintResult(HttpContext _context, string result)
	{
		_context.Response.ClearContent();
		_context.Response.ContentType = "text/plain";
		_context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
		_context.Response.AddHeader("Access-Control-Allow-Origin", "*");
		_context.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
		_context.Response.Write(result);
		//_context.Response.End();
	}

	#endregion

}