using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;

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
		/// 先获取 GET 传入的值，如果没有则尝试获取 POST 传入的值。
		/// </summary>
		/// <returns></returns>
		public static T GetQuery<T>(string key, T defaultValue)
		{
			string val = HttpContext.Current.Request.QueryString[key];
			if (string.IsNullOrEmpty(val)) val = HttpContext.Current.Request.Form[key];
			return val == null ? defaultValue : ConvertKit.ConvertValue<T>(val, defaultValue);
		}

		/// <summary>
		/// 同时获取 GET 和 POST 方法传入的值数组。
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetQueryArray()
		{
			NameValueCollection collection = new NameValueCollection();
			collection.Add(HttpContext.Current.Request.QueryString);
			collection.Add(HttpContext.Current.Request.Form);
			return collection;
		}

		#endregion
	}
}