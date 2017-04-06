using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 字符串或数值的通用处理管理器。
	/// </summary>
	public static class StringExtension
	{
		/// <summary>
		/// 检查字符串是否由数字组成。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns></returns>
		public static Boolean IsNumeric(this string str)
		{
			Regex rx = new Regex(@"^\-?\d+(\.\d+)?$");
			return rx.IsMatch(str);
		}

		/// <summary>
		/// 检查字符串是否由整数组成。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns></returns>
		public static Boolean IsInt(this string str)
		{
			Regex rx = new Regex(@"^\-?\d+$");
			return rx.IsMatch(str);
		}

		/// <summary>
		/// 从左至右截取指定长度的字符串。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <param name="len">截取长度</param>
		/// <returns></returns>
		public static string Left(this string str, int len)
		{
			if (str.Length > len) {
				return str.Substring(0, len);
			} else {
				return str;
			}
		}

		/// <summary>
		/// 从左至右截取指定长度的字符串。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <param name="len">截取长度</param>
		/// <param name="omission">省略符号</param>
		/// <returns></returns>
		public static string Left(this string str, int len, string omission)
		{
			if (str.Length > len) {
				return str.Substring(0, len) + omission;
			} else {
				return str;
			}
		}

		/// <summary>
		/// 从右至左截取指定长度的字符串。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <param name="len">截取长度</param>
		/// <returns></returns>
		public static string Right(this string str, int len)
		{
			if (str.Length > len) {
				return str.Substring(str.Length - len);
			} else {
				return str;
			}
		}

		/// <summary>
		/// 返回短日期的文本。
		/// </summary>
		/// <param name="date">日期</param>
		/// <returns></returns>
		public static string ToShortDateString(this DateTime date)
		{
			return date.Year.ToString() + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00");
		}

		/// <summary>
		/// 返回格式化的日期和短时间文本。
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string ToShortDateTimeString(this DateTime date)
		{
			return date.Year.ToString() + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00") + " " + date.Hour.ToString() + ":" + date.Minute.ToString();
		}

		/// <summary>
		/// 返回格式化的日期和短时间文本。
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string ToRomanDateString(this DateTime date)
		{
			string m = String.Empty;
			switch (date.Month) {
				case 1: m = "January"; break;
				case 2: m = "February"; break;
				case 3: m = "March"; break;
				case 4: m = "April"; break;
				case 5: m = "May"; break;
				case 6: m = "June"; break;
				case 7: m = "July"; break;
				case 8: m = "August"; break;
				case 9: m = "September"; break;
				case 10: m = "October"; break;
				case 11: m = "November"; break;
				case 12: m = "December"; break;
			}
			return m + date.ToString(" dd, yyyy");
		}

		/// <summary>
		/// 返回正整数，若值小于1，则返回整数0。
		/// </summary>
		/// <param name="i">整数值</param>
		/// <returns></returns>
		public static int ToPositiveInt(this int i)
		{
			if (i < 1) { i = 0; }
			return i;
		}

		/// <summary>
		/// 根据字符串返回正整数，若值非数字或小于1，则返回整数0。
		/// </summary>
		/// <param name="input">内容为整数值的字符串</param>
		/// <returns></returns>
		public static int ToPositiveInt(this string input)
		{
			int i = 0;
			if (IsNumeric(input)) {
				i = Convert.ToInt32(input);
				if (i < 1) { i = 0; }
			}
			return i;
		}

		/// <summary>
		/// 限定格式化为只包含英文、数字、下划线的参数内容。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns></returns>
		public static string ToSqlParm(this string str)
		{
			Regex x = new Regex("\\w+");
			str = str.Replace("'", "''");
			str = str.Trim();
			return x.Match(str).Value;
		}

		/// <summary>
		/// 检查提交内容并替换关键字符，使其符合写入数据库的规范，不允许的字符：'、%、空格、/、\。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns></returns>
		public static string FormatSqlParm(this string str)
		{
			str = str.Replace("'", "");
			str = str.Replace("%", "");
			str = str.Replace(" ", "");
			str = str.Replace("/", "");
			str = str.Replace("\\", "");
			str = str.Trim();
			return str;
		}

		/// <summary>
		/// 将内容格式化为标准的 HTML。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string FormatHtml(this string str)
		{
			str = str.Replace("'", "''");
			str = str.Replace("&", "&amp;");
			str = str.Replace("\"", "&qout;");
			str = str.Replace("<", "&lt;");
			str = str.Replace(">", "&gt;");
			str = str.Replace("\r\n", "<br />");
			return str;
		}

		/// <summary>
		/// 将字符串中的特殊符号格式化为Json认可的格式。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string FormatJson(this string str)
		{
			str = str.Replace("\\", "\\\\");
			str = str.Replace("'", "\\'");
			str = str.Replace("\"", "\\\"");
			return str;
		}

		/// <summary>
		/// 清理 HTML 标签。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ClearHtmlTag(this string str)
		{
			Regex x = new Regex(@"<[^>]+>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			return x.Replace(str, "");
		}
	}
}
