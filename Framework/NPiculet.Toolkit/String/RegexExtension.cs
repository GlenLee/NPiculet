using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 正则表达式管理器。
	/// </summary>
	public static class RegexExtension
	{
		/// <summary>
		/// 检查字符串是否包含正则表达式验证的内容。
		/// </summary>
		/// <param name="str">将要验证的字符串</param>
		/// <param name="regexStr">正则表达式</param>
		/// <returns></returns>
		public static bool Test(this string str, string regexStr) {
			Regex rx = new Regex(regexStr);
			return rx.IsMatch(str);
		}

		/// <summary>
		/// 返回正则表达式所匹配的内容。
		/// </summary>
		/// <param name="str">将要验证的字符串</param>
		/// <param name="regexStr">正则表达式</param>
		/// <returns></returns>
		public static Match GetMatch(this string str, string regexStr) {
			Regex rx = new Regex(regexStr, RegexOptions.IgnoreCase);
			return rx.Match(str);
		}

		/// <summary>
		/// 返回正则表达式所匹配的内容集合。
		/// </summary>
		/// <param name="str"></param>
		/// <param name="regexStr"></param>
		/// <returns></returns>
		public static MatchCollection GetMatches(this string str, string regexStr) {
			Regex rx = new Regex(regexStr, RegexOptions.IgnoreCase);
			return rx.Matches(str);
		}

		/// <summary>
		/// 返回正则表达式所替换的内容。
		/// </summary>
		/// <param name="str">将要替换的字符串</param>
		/// <param name="regexStr">正则表达式</param>
		/// <param name="replaceStr">替换结果的字符串</param>
		/// <returns>替换完成的字符串</returns>
		public static string Replace(this string str, string regexStr, string replaceStr) {
			Regex rx = new Regex(regexStr);
			return rx.Replace(str, replaceStr);
		}

		/// <summary>
		/// 返回内容中包含的 Url 字符串的集合。
		/// </summary>
		/// <param name="str">内容</param>
		/// <returns></returns>
		public static string[] GetUrl(this string str) {
			MatchCollection mc = GetMatches(str, @"(http|https|ftp)://((\w[\w\-]+\.)+(net|com|cn|org|cc|tv|jp|info|name|biz|tw)|(\d{1,3}\.){3}\d{1,3})(\:\d{2,5})?([/\w\-\(\)\[\]\._~]+)(\?(&?\w+\=[\w,~%^?<>_:/\\\.\(\)\[\]\-\+]*&?)*)*(#\w*)?");
			string[] strings = new string[mc.Count];
			for (int i = 0; i < mc.Count; i++) {
				strings[i] = mc[i].Value;
			}
			return strings;
		}

		/// <summary>
		/// 检查字符串是否为一个 Url。
		/// </summary>
		/// <param name="str">内容</param>
		/// <returns></returns>
		public static bool IsUrl(this string str) {
			return Test(str, @"^(http|https|ftp)://((\w[\w\-]+\.)+(net|com|cn|org|cc|tv|jp|info|name|biz|tw)|(\d{1,3}\.){3}\d{1,3})(\:\d{2,5})?([/\w\-\(\)\[\]\._~]+)(\?(&?\w+\=[\w,~%^?<>_:/\\\.\(\)\[\]\-\+]*&?)*)*(#\w*)?$");
		}

		/// <summary>
		/// 返回内容中包含的图片地址的集合。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string[] GetImages(this string str) {
			MatchCollection mc = GetMatches(str, @"(http|https|ftp)://((\w[\w\-]+\.)+(net|com|cn|org|cc|tv|jp|info|name|biz|tw)|(\d{1,3}\.){3}\d{1,3})(\:\d{2,5})?/[0-9a-zA-z\.\-,_/\\]+\.(jpg|jpeg|gif|png|bmp)");
			string[] strings = new string[mc.Count];
			for (int i = 0; i < mc.Count; i++) {
				strings[i] = mc[i].Value;
			}
			return strings;
		}

		/// <summary>
		/// 检查字符串是否为一个图片链接。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsImageUrl(this string str) {
			return Test(str, @"^(http|https|ftp)://((\w[\w\-]+\.)+(net|com|cn|org|cc|tv|jp|info|name|biz|tw)|(\d{1,3}\.){3}\d{1,3})(\:\d{2,5})?/[0-9a-zA-z\.\-,_/\\]+\.(jpg|jpeg|gif|png|bmp)$");
		}
	}
}
