using System;
using System.Text;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 随机数字及随机字符串管理器。
	/// </summary>
	public partial class StringKit
	{
		private static readonly Random _rnd = new Random();

		/// <summary>
		/// 产生一个由英文字母和数字组成的随机字符串。
		/// </summary>
		/// <param name="n">产生的字符个数</param>
		/// <returns></returns>
		public static string GetRandomString(int n) {
			short chr = 0;
			string str = "";
			for (int i = 0; i < n; i++) {
				switch (_rnd.Next(3)) {
					case 0: chr = (short)_rnd.Next(48, 58); break;
					case 1: chr = (short)_rnd.Next(65, 91); break;
					case 2: chr = (short)_rnd.Next(97, 123); break;
				}
				str += Convert.ToChar(chr).ToString();
			}
			return str;
		}

		/// <summary>
		/// 产生一个由英文字母和数字组成的随机字符串。
		/// </summary>
		/// <param name="n">产生的字符个数</param>
		/// <returns></returns>
		public static string GetRandomStringHex(int n)
		{
			string str = "";
			for (int i = 0; i < n; i++) {
				int j = _rnd.Next(256);
				str += j.ToString("X2");
			}
			return str;
		}

		/// <summary>
		/// 产生一个随机数字。
		/// </summary>
		/// <param name="max">产生的最大数字</param>
		/// <returns></returns>
		public static int GetRandomNumber(int max)
		{
			int m = (max <= 0) ? 1 : max;
			return _rnd.Next(m);
		}

		/// <summary>
		/// 产生一个随机数字。
		/// </summary>
		/// <param name="min">产生的最小数字</param>
		/// <param name="max">产生的最大数字</param>
		/// <returns></returns>
		public static int GetRandomNumber(int min, int max)
		{
			int minV = Math.Min(min, max);
			int maxV = Math.Max(min, max);
			minV = minV < 0 ? 0 : min;
			maxV = (max <= 0) ? 1 : max;
			return _rnd.Next(minV, maxV);
		}

		/// <summary>
		/// 产生一个固定长度，并且由数字组成的随机字符串。
		/// </summary>
		/// <param name="length">产生的字符长度</param>
		/// <returns></returns>
		public static string GetRandomStringByNumber(int length)
		{
			return GetRandomNumber(int.MaxValue - 1).ToString("D" + length).Right(length);
		}

		/// <summary>
		/// 产生一个固定长度，并且由数字组成的随机字符串。
		/// </summary>
		/// <param name="max">产生的最大数字</param>
		/// <param name="length">产生的字符长度</param>
		/// <returns></returns>
		public static string GetRandomStringByNumber(int max, int length) {
			return GetRandomNumber(max).ToString("D" + length);
		}

		/// <summary>
		/// 产生一个固定长度，并且由数字组成的随机字符串。
		/// </summary>
		/// <param name="min">产生的最小数字</param>
		/// <param name="max">产生的最大数字</param>
		/// <param name="length">产生的字符长度</param>
		/// <returns></returns>
		public static string GetRandomStringByNumber(int min, int max, int length)
		{
			return GetRandomNumber(min, max).ToString("D" + length);
		}

		/// <summary>
		/// 根据当前时间产生一个17位的由日期和时间组成的字符串，精确到毫秒。
		/// </summary>
		/// <param name="includeYear">包含年</param>
		/// <param name="includeMonth">包含月</param>
		/// <param name="includeDay">包含日</param>
		/// <param name="includeTime">包含时间</param>
		/// <returns></returns>
		public static string GetStringByDateTime(bool includeYear = true, bool includeMonth = true, bool includeDay = true, bool includeTime = true)
		{
			DateTime d = DateTime.Now;
			string year = includeYear ? d.Year.ToString("0000") : string.Empty;
			string month = includeMonth ? d.Month.ToString("00") : string.Empty;
			string day = includeDay ? d.Day.ToString("00") : string.Empty;
			string today;
			if (includeTime) {
				today = year + month + day
					+ ((char)(d.Hour + 65)).ToString()
					+ d.Minute.ToString("00")
					+ d.Second.ToString("00")
					+ d.Millisecond.ToString("000");
			} else {
				today = year + month + day;
			}
			return today;
		}

		/// <summary>
		/// 根据当前时间产生一个9位的由日期和时间组成的短字符串，第一位起始字母A代表2010年，其中年、月、时均用英文字母表示，以此类推。
		/// </summary>
		/// <param name="includeYear">包含年</param>
		/// <param name="includeMonth">包含月</param>
		/// <param name="includeDay">包含日</param>
		/// <param name="includeTime">包含时间</param>
		/// <returns></returns>
		public static string GetStringByShortDate(bool includeYear = true, bool includeMonth = true, bool includeDay = true, bool includeTime = true)
		{
			DateTime d = DateTime.Now;
			string year = includeYear ? ((char)(d.Year - 2010 + 65)).ToString() : string.Empty;
			string month = includeMonth ? d.Month.ToString("X") : string.Empty;
			string day = includeDay ? d.Day.ToString("00") : string.Empty;
			string today;
			if (includeTime) {
				today = year + month + day
					+ ((char)(d.Hour + 65)).ToString()
					+ d.Minute.ToString("00")
					+ d.Second.ToString("00")
					+ d.Millisecond.ToString("000");
			} else {
				today = year + month + day;
			}
			return today;
		}

		/// <summary>
		/// 获取一个新的 GUID 字符串
		/// </summary>
		/// <param name="length">长度，默认32位</param>
		/// <param name="upper">是否大写</param>
		/// <returns></returns>
		public static string GetGUID(int length = 32, bool upper = false)
		{
			string guid;
			if (length == 32) {
				guid = Guid.NewGuid().ToString().Replace("-", "");
			} else if (length < 32) {
				guid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
			} else {
				guid = string.Empty;
				int count = length % 32 > 0 ? length / 32 + 1 : length / 32;
				for (int i = 0; i < count; i++) {
					guid += Guid.NewGuid().ToString().Replace("-", "");
				}
				guid = guid.Substring(0, length);
			}
			return upper ? guid.ToUpper() : guid.ToLower();
		}
	}
}
