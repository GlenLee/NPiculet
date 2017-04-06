using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;

namespace NPiculet.Toolkit
{
	public static class WebParmKit
	{
		#region ��ȡ����ֵ

		/// <summary>
		/// ��ȡ GET ��ʽ�����ֵ����ת��Ϊָ�����͡�
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
		/// ��ȡ POST ��ʽ�����ֵ����ת��Ϊָ�����͡�
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
		/// ��ȡ GET ���������ֵ���顣
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetRequestStringArray()
		{
			return HttpContext.Current.Request.QueryString;
		}

		/// <summary>
		/// ��ȡ POST ���������ֵ���顣
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetFormArray()
		{
			return HttpContext.Current.Request.Form;
		}

		/// <summary>
		/// �Ȼ�ȡ GET �����ֵ�����û�����Ի�ȡ POST �����ֵ��
		/// </summary>
		/// <returns></returns>
		public static T GetQuery<T>(string key, T defaultValue)
		{
			string val = HttpContext.Current.Request.QueryString[key];
			if (string.IsNullOrEmpty(val)) val = HttpContext.Current.Request.Form[key];
			return val == null ? defaultValue : ConvertKit.ConvertValue<T>(val, defaultValue);
		}

		/// <summary>
		/// ͬʱ��ȡ GET �� POST ���������ֵ���顣
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