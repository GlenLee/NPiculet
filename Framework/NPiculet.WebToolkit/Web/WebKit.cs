using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace NPiculet.Toolkit
{
	public class WebKit
	{
		/// <summary> 
		/// 取得客戶端简单主机地址 
		/// </summary> 
		public static string GetSimpleIP()
		{
			if (null != HttpContext.Current.Request.ServerVariables["HTTP_VIA"]) {
				return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			} else {
				return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
		}

		/// <summary> 
		/// 取得客戶端主机 IPv4 地址 
		/// </summary> 
		/// <returns></returns> 
		public static string GetClientIPv4()
		{
			string ipv4 = String.Empty;
			foreach (IPAddress ip in Dns.GetHostAddresses(GetClientIP())) {
				if (ip.AddressFamily.ToString() == "InterNetwork") {
					ipv4 = ip.ToString();
					break;
				}
			}
			if (ipv4 != String.Empty) {
				return ipv4;
			}
			// 原代码使用 Dns.GetHostName 方法取回的是 Server 端资料，非 Client 端。 
			// 改为利用 Dns.GetHostEntry 方法，由获取的 IPv6 位址反查 DNS 记录， 
			// 再逐一判断是否属于 IPv4 协议定，如果是转换为 IPv4 地址。 
			foreach (IPAddress ip in Dns.GetHostEntry(GetClientIP()).AddressList)
			//foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName())) 
            {
				if (ip.AddressFamily.ToString() == "InterNetwork") {
					ipv4 = ip.ToString();
					break;
				}
			}
			return ipv4;
		}

		/// <summary>
		/// 取得可穿透代理的客戶端主机地址
		/// </summary>
		public static string GetClientIP()
		{
			string result = String.Empty;

			result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (result != null && result != String.Empty) {
				//可能有代理 
				if (result.IndexOf(".") == -1)    //没有“.”肯定是非IPv4格式 
					result = null;
				else {
					if (result.IndexOf(",") != -1) {
						//有“,”，估计多个代理。取第一个不是内网的IP。 
						result = result.Replace(" ", "").Replace("'", "");
						string[] temparyip = result.Split(",;".ToCharArray());
						for (int i = 0; i < temparyip.Length; i++) {
							if (IsIPv4(temparyip[i])
								&& temparyip[i].Substring(0, 3) != "10."
								&& temparyip[i].Substring(0, 7) != "192.168"
								&& temparyip[i].Substring(0, 7) != "172.16.") {


								return temparyip[i];    //找到不是内网的地址 
							}
						}
					} else if (IsIPv4(result)) //代理即是IP格式 
						return result;
					else
						result = null;    //代理中的内容 非IP，取IP 
				}

			}

			string ipAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

			if (null == result || result == String.Empty)
				result = ipAddress;

			if (result == null || result == String.Empty)
				result = HttpContext.Current.Request.UserHostAddress;

			return result;
		}

		/// <summary>
		/// 判断是否是IPv4地址
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		public static bool IsIPv4(string ip)
		{
			if (ip == null || ip == string.Empty || ip.Length < 7 || ip.Length > 15) return false;
			string pattern = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			return regex.IsMatch(ip);
		}
	}
}