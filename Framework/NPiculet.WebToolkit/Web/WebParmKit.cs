using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using System.Web.UI;

namespace NPiculet.Toolkit
{
	public static class WebParmKit
	{
		#region 获取传入值

		/// <summary>
		/// 获取 GET 方式传入的值，并转换为指定类型。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T GetRequestString<T>(string key, T defaultValue)
		{
			var val = HttpContext.Current.Request.QueryString[key];
			return val == null ? defaultValue : ConvertKit.ConvertValue<T>(val, defaultValue);
		}

		/// <summary>
		/// 获取 POST 方式传入的值，并转换为指定类型。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T GetFormValue<T>(string key, T defaultValue)
		{
			var val = HttpContext.Current.Request.Form[key];
			return val == null ? defaultValue : ConvertKit.ConvertValue<T>(val, defaultValue);
		}

		/// <summary>
		/// 获取 Route 方式传入的值，并转换为指定类型。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T GetRouteValue<T>(string key, T defaultValue) {
			var page = HttpContext.Current.CurrentHandler as Page;
			if (page != null) {
				var val = page.RouteData.Values[key];
				return val == null ? defaultValue : ConvertKit.ConvertValue<T>(val, defaultValue);
			}
			return defaultValue;
		}

		/// <summary>
		/// 获取 GET 方法传入的值数组。
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetRequestStringArray()
		{
			return HttpContext.Current.Request.QueryString;
		}

		/// <summary>
		/// 获取 POST 方法传入的值数组。
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetFormArray()
		{
			return HttpContext.Current.Request.Form;
		}

		/// <summary>
		/// 获取 POST 方法传入的值数组。
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetRouteDataArray()
		{
			NameValueCollection nvc = new NameValueCollection();
			var page = HttpContext.Current.CurrentHandler as Page;
			if (page != null) {
				foreach (KeyValuePair<string, object> data in page.RouteData.Values) {
					nvc.Add(data.Key, Convert.ToString(data.Value));
				}
			}
			return nvc;
		}

		/// <summary>
		/// 先获取 GET 传入的值，如果没有则尝试获取 POST 传入的值。
		/// </summary>
		/// <returns></returns>
		public static T GetQuery<T>(string key, T defaultValue) {
			string val = GetRouteValue<string>(key, null);
			if (string.IsNullOrEmpty(val)) val = HttpContext.Current.Request.QueryString[key];
			if (string.IsNullOrEmpty(val)) val = HttpContext.Current.Request.Form[key];
			return string.IsNullOrEmpty(val) ? defaultValue : ConvertKit.ConvertValue<T>(val, defaultValue);
		}

		/// <summary>
		/// 同时获取 GET 和 POST 方法传入的值数组。
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetQueryArray()
		{
			NameValueCollection collection = new NameValueCollection {
				HttpContext.Current.Request.QueryString,
				HttpContext.Current.Request.Form,
				GetRouteDataArray()
			};
			return collection;
		}

		#endregion
	}
}