using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NPiculet.Toolkit
{
	public class NetKit
	{
		#region 处理 WebClient 方法

		/// <summary>
		/// 下载字符串
		/// </summary>
		/// <param name="url"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static string DownloadString(string url, string encoding = null)
		{
			using (WebClient wc = new WebClient()) {
				wc.Encoding = string.IsNullOrEmpty(encoding) ? Encoding.UTF8 : Encoding.GetEncoding(encoding);
				return wc.DownloadString(url);
			}
		}

		/// <summary>
		/// 下载字符串
		/// </summary>
		/// <param name="url"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static byte[] DownloadData(string url, string encoding = null)
		{
			using (WebClient wc = new WebClient()) {
				wc.Encoding = string.IsNullOrEmpty(encoding) ? Encoding.UTF8 : Encoding.GetEncoding(encoding);
				return wc.DownloadData(url);
			}
		}

		#endregion

		#region 处理 GET 和 POST 请求

		/// <summary>
		/// 验证证书
		/// </summary>
		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			if (errors == SslPolicyErrors.None)
				return true;
			return false;
		}

		/// <summary>
		/// 统一初始化 Request 格式，防止访问时变化
		/// </summary>
		/// <param name="url">地址</param>
		/// <param name="isHtml">是否是HTML请求，否则不会为 UserAgent, Accept 参数赋值</param>
		/// <returns></returns>
		public static HttpWebRequest CreateHttpRequest(string url, bool isHtml = true)
		{
			Uri target = new Uri(url);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(target);
			if (isHtml) {
				request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; zh-CN; rv:1.9.2.2) Gecko/20100316 Firefox/3.6.2 (.NET CLR 3.5.30729)";
				request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			}
			request.AllowAutoRedirect = true;
			request.KeepAlive = true;
			request.Referer = url;
			return request;
		}

		/// <summary>  
		/// 创建GET方式的HTTP请求  
		/// </summary>  
		public static HttpWebResponse CreateHttpResponse(string method, string url, IDictionary<string, string> parameters, int timeout = 0, string userAgent = null, CookieContainer cookies = null)
		{
			HttpWebRequest request = null;
			string args = CreateDataString(parameters);

			//本地化地址变量
			string u = url;

			//处理 GET 方式传参
			if (method == "GET" && args.Length > 0) {
				if (u.IndexOf("?") > -1) {
					u += "&" + args;
				} else {
					u += "?" + args;
				}
			}

			//处理 HTTPS 授权，并创建 HTTP 对象
			if (u.StartsWith("https", StringComparison.OrdinalIgnoreCase)) {
				//对服务端证书进行有效性校验（非第三方权威机构颁发的证书，如自己生成的，不进行验证，这里返回true）
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request = CreateHttpRequest(u);
				request.ProtocolVersion = HttpVersion.Version10;    //http版本，默认是1.1,这里设置为1.0
			} else {
				request = CreateHttpRequest(u);
			}

			//设置提交方式
			request.Credentials = CredentialCache.DefaultCredentials;
			request.Method = method;

			//处理 POST 方式传参				
			if (method == "POST") {
				if (args.Length > 0) {
					byte[] data = Encoding.ASCII.GetBytes(args);
					using (Stream stream = request.GetRequestStream()) {
						stream.Write(data, 0, data.Length);
					}
				}
				//处理内容类型
				request.ContentType = "application/x-www-form-urlencoded";
			}

			//设置代理UserAgent
			if (!string.IsNullOrEmpty(userAgent))
				request.UserAgent = userAgent;

			//设置超时
			if (timeout > 0) {
				request.Timeout = timeout;
				request.ReadWriteTimeout = timeout;
			}

			//设置Cookies
			if (cookies != null) {
				request.CookieContainer = cookies;
			}

			return request.GetResponse() as HttpWebResponse;
		}

		/// <summary>
		/// 创建数据字符串
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		private static string CreateDataString(IDictionary<string, string> parameters)
		{
			StringBuilder args = new StringBuilder();

			//处理参数
			if (parameters != null && parameters.Count > 0) {
				foreach (KeyValuePair<string, string> pair in parameters) {
					if (args.Length > 0) args.Append("&");
					args.AppendFormat("{0}={1}", pair.Key, pair.Value);
				}
			}
			return args.ToString();
		}

		/// <summary>
		/// 获取 POST 请求的数据
		/// </summary>
		public static string POST(string url, Encoding encoding, IDictionary<string, string> parameters = null, int timeout = 0, string userAgent = null, CookieContainer cookies = null)
		{
			var webresponse = CreateHttpResponse("POST", url, parameters, timeout, userAgent, cookies);
			using (Stream s = webresponse.GetResponseStream()) {
				StreamReader reader = new StreamReader(s, encoding);
				return reader.ReadToEnd();

			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <param name="parameters"></param>
		/// <param name="timeout"></param>
		/// <param name="userAgent"></param>
		/// <param name="cookies"></param>
		/// <returns></returns>
		public static string POST(string url, IDictionary<string, string> parameters = null, int timeout = 0, string userAgent = null, CookieContainer cookies = null)
		{
			return POST(url, Encoding.UTF8, parameters, timeout, userAgent, cookies);
		}

		/// <summary>
		/// 获取 GET 请求的数据
		/// </summary>
		public static string GET(string url, Encoding encoding, IDictionary<string, string> parameters = null, int timeout = 0, string userAgent = null, CookieContainer cookies = null)
		{
			var webresponse = CreateHttpResponse("GET", url, parameters, timeout, userAgent, cookies);
			using (Stream s = webresponse.GetResponseStream()) {
				StreamReader reader = new StreamReader(s, encoding);
				return reader.ReadToEnd();

			}
		}

		public static string GET(string url, IDictionary<string, string> parameters = null, int timeout = 0, string userAgent = null, CookieContainer cookies = null)
		{
			return GET(url, Encoding.UTF8, parameters, timeout, userAgent, cookies);
		}

		#endregion

		#region Cookie 操作

		/// <summary>
		/// 获取提交后返回的 Cookie 容器，以及结果内容
		/// </summary>
		/// <param name="url"></param>
		/// <param name="encoding"></param>
		/// <param name="result"></param>
		/// <param name="parameters"></param>
		/// <param name="cookies"></param>
		/// <returns></returns>
		public static CookieContainer GetCookieContainer(string url, Encoding encoding, out string result, IDictionary<string, string> parameters = null, CookieContainer cookies = null)
		{
			result = string.Empty;

			CookieContainer container = cookies ?? new CookieContainer();

			HttpWebRequest request = CreateHttpRequest(url);
			request.Method = "POST";

			var args = CreateDataString(parameters);
			byte[] data = Encoding.ASCII.GetBytes(args);

			request.ContentLength = data.Length;
			request.CookieContainer = container;

			using (Stream stream = request.GetRequestStream()) {
				stream.Write(data, 0, data.Length);
			}

			try {
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				response.Cookies = container.GetCookies(request.RequestUri);

				using (Stream s = response.GetResponseStream()) {
					StreamReader reader = new StreamReader(s, encoding);
					result = reader.ReadToEnd();
				}
			} catch { }

			return container;
		}

		//public static void SaveCookie(CookieContainer cookies)
		//{
		//    //cookies.
		//}

		#endregion
	}
}