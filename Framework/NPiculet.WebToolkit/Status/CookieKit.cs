using System;
using System.Configuration;
using System.Web;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// Cookies 状态存取类。
	/// </summary>
	public static class CookiesKit
	{
		#region 初始化

		private static readonly string defaultCollectionName = "__cookies__";

		/// <summary>
		/// 获取当前 Cookie 集合，如果没有则初始化一个。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		/// <returns></returns>
		private static HttpCookie GetCurrentCookies(string cookieCollectionName)
		{
			//判断空值
			if (String.IsNullOrEmpty(cookieCollectionName)) {
				return new HttpCookie(defaultCollectionName);
			}
			//返回操作对象
			if (HttpContext.Current.Request.Cookies[cookieCollectionName] == null) {
				return new HttpCookie(cookieCollectionName);
			} else {
				return HttpContext.Current.Request.Cookies[cookieCollectionName];
			}
		}

		/// <summary>
		/// 获取当前 Cookie 集合，如果没有则初始化一个。
		/// </summary>
		/// <returns></returns>
		private static HttpCookie GetCurrentCookies()
		{
			return GetCurrentCookies(defaultCollectionName);
		}

		/// <summary>
		/// 获取过期时间。
		/// </summary>
		/// <returns></returns>
		private static int GetExpiryDateTime()
		{
			int time;
			int.TryParse(ConfigurationManager.AppSettings["CookiesExpiryDateTime"], out time);
			return (time == 0) ? 60 : time;
		}

		#endregion

		#region 储存 Cookies

		/// <summary>
		/// 储存 Cookie 值。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="cookieValue">Cookie 值</param>
		/// <param name="expiryTime">过期时间（分钟）</param>
		public static void SetCookie(string cookieCollectionName, string cookieName, string cookieValue, int expiryTime)
		{
			HttpCookie cok = GetCurrentCookies(cookieCollectionName);
			cok.Values[cookieName.ToLower()] = cookieValue;
			cok.Expires = DateTime.Now.AddMinutes(expiryTime);
			cok.Path = "/";
			HttpContext.Current.Response.Cookies.Add(cok);
		}

		/// <summary>
		/// 储存 Cookie 值。
		/// </summary>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="cookieValue">Cookie 值</param>
		/// <param name="expiryTime">过期时间（分钟）</param>
		public static void SetCookie(string cookieName, string cookieValue, int expiryTime)
		{
			SetCookie(defaultCollectionName, cookieName, cookieValue, expiryTime);
		}

		/// <summary>
		/// 储存 Cookie 值，默认值可配置 web.config 文件中的 CookiesExpiryDateTime 参数，单位（分钟）。
		/// </summary>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="cookieValue">Cookie 值</param>
		public static void SetCookie(string cookieName, string cookieValue)
		{
			SetCookie(cookieName, cookieValue, GetExpiryDateTime());
		}

		#endregion

		#region 获取 Cookies

		/// <summary>
		/// 获取 Cookie 值。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="defaultValue">默认值</param>
		/// <returns></returns>
		public static string GetCookie(string cookieCollectionName, string cookieName, string defaultValue)
		{
			HttpCookie cookies = GetCurrentCookies(cookieCollectionName);
			if (cookies != null) {
				if (cookies[cookieName.ToLower()] != null) {
					return cookies[cookieName];
				}
			}
			return defaultValue;
		}

		/// <summary>
		/// 获取 Cookie 值。
		/// </summary>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="defaultValue">默认值</param>
		/// <returns></returns>
		public static string GetCookie(string cookieName, string defaultValue)
		{
			return GetCookie(defaultCollectionName, cookieName, defaultValue);
		}

		/// <summary>
		/// 取得 Cookie 值，如果没有值则返回 String.Empty 值。
		/// </summary>
		/// <param name="cookieName">Cookie 名称</param>
		/// <returns></returns>
		public static string GetCookie(string cookieName)
		{
			return GetCookie(cookieName, String.Empty);
		}

		#endregion

		#region 检查值

		/// <summary>
		/// 检查 Cookie 值是否相等。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="chkValue">比较值</param>
		/// <returns></returns>
		public static bool CheckCookie(string cookieCollectionName, string cookieName, string chkValue)
		{
			return GetCookie(cookieCollectionName, cookieName, String.Empty) == chkValue;
		}

		/// <summary>
		/// 检查 Cookie 值是否相等。
		/// </summary>
		/// <param name="cookieName">Cookie 名称</param>
		/// <param name="chkValue">比较值</param>
		/// <returns></returns>
		public static bool CheckCookie(string cookieName, string chkValue)
		{
			return GetCookie(cookieName) == chkValue;
		}

		/// <summary>
		/// 检查 Cookie 值是否存在。
		/// </summary>
		/// <param name="cookieName">Cookie 名称</param>
		/// <returns></returns>
		public static bool CheckCookie(string cookieName)
		{
			return !CheckCookie(cookieName, String.Empty);
		}

		#endregion

		#region 刷新及销毁 Cookie

		/// <summary>
		/// 刷新 Cookie 状态。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		/// <param name="expiryTime">过期时间（分钟）</param>
		public static void RefreshCookie(string cookieCollectionName, int expiryTime)
		{
			HttpCookie cok = GetCurrentCookies(cookieCollectionName);
			cok.Expires = DateTime.Now.AddMinutes(expiryTime);
			HttpContext.Current.Response.Cookies.Add(cok);
		}

		/// <summary>
		/// 刷新 Cookie 状态。
		/// </summary>
		/// <param name="expiryTime">过期时间（分钟）</param>
		public static void RefreshCookie(int expiryTime)
		{
			RefreshCookie(defaultCollectionName, expiryTime);
		}

		/// <summary>
		/// 刷新 Cookie 状态，按默认值重置过期时间。
		/// </summary>
		public static void RefreshCookie()
		{
			RefreshCookie(GetExpiryDateTime());
		}

		/// <summary>
		/// 清除 Cookie 值。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		/// <param name="cookieName"></param>
		public static void RemoveCookie(string cookieCollectionName, string cookieName)
		{
			HttpCookie cok = GetCurrentCookies(cookieCollectionName);
			cok.Values.Remove(cookieName.ToLower());
			HttpContext.Current.Response.Cookies.Add(cok);
		}

		/// <summary>
		/// 清除 Cookie 值。
		/// </summary>
		/// <param name="cookieName"></param>
		public static void RemoveCookie(string cookieName)
		{
			RemoveCookie(defaultCollectionName, cookieName);
		}

		/// <summary>
		/// 移除全部 Cookie 值。
		/// </summary>
		/// <param name="cookieCollectionName">Cookie 集合名称</param>
		public static void RemoveAll(string cookieCollectionName)
		{
			HttpCookie cok = GetCurrentCookies(cookieCollectionName);
			foreach (string key in cok.Values.AllKeys) {
				cok.Values.Remove(key);
			}
			cok.Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.Cookies.Add(cok);
		}

		/// <summary>
		/// 移除全部 Cookie 值。
		/// </summary>
		public static void RemoveAll()
		{
			RemoveAll(defaultCollectionName);
		}

		#endregion
	}
}