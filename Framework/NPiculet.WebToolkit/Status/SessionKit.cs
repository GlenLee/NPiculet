using System;
using System.Web;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// Session 状态存取类。
	/// </summary>
	public class SessionKit
	{
		#region 储存 Session

		/// <summary>
		/// 储存 Session 值。
		/// </summary>
		/// <param name="sessionName">Session 名称</param>
		/// <param name="sessionValue">Session 值</param>
		/// <param name="expiryTime">过期时间（分钟）</param>
		public static void SetSession(string sessionName, string sessionValue, int expiryTime)
		{
			HttpContext.Current.Session.Timeout = Convert.ToInt32(expiryTime);
			HttpContext.Current.Session[sessionName] = sessionValue;
		}

		/// <summary>
		/// 储存 Session 值。
		/// </summary>
		/// <param name="sessionName">Session 名称</param>
		/// <param name="sessionValue">Session 值</param>
		public static void SetSession(string sessionName, string sessionValue)
		{
			HttpContext.Current.Session[sessionName] = sessionValue;
		}

		#endregion

		#region 获取 Session

		/// <summary>
		/// 获取 Session 值，如果没有值则返回 String.Empty 值。
		/// </summary>
		/// <param name="sessionName">Session 名称</param>
		/// <returns></returns>
		public static string GetSession(string sessionName)
		{
			if (HttpContext.Current.Session[sessionName] != null) {
				return HttpContext.Current.Session[sessionName].ToString();
			} else {
				return String.Empty;
			}
		}

		#endregion

		#region 检查值

		/// <summary>
		/// 检查 Cookie 值是否相等。
		/// </summary>
		/// <param name="sessionName">Session 名称</param>
		/// <param name="chkValue">比较值</param>
		/// <returns></returns>
		public static bool CheckSession(string sessionName, string chkValue)
		{
			return GetSession(sessionName) == chkValue;
		}

		/// <summary>
		/// 检查 Cookie 值是否存在。
		/// </summary>
		/// <param name="sessionName">Session 名称</param>
		/// <returns></returns>
		public static bool CheckSession(string sessionName)
		{
			return !CheckSession(sessionName, String.Empty);
		}

		#endregion

		#region 销毁 Session

		/// <summary>
		/// 清除 Session 值。
		/// </summary>
		/// <param name="sessionName">Session 名称</param>
		public static void RemoveSession(string sessionName)
		{
			try {
				HttpContext.Current.Session.Remove(sessionName);
			} catch { }
		}

		/// <summary>
		/// 移除全部 Session 值。
		/// </summary>
		public static void RemoveAll()
		{
			HttpContext.Current.Session.Clear();
			HttpContext.Current.Session.RemoveAll();
			HttpContext.Current.Session.Abandon();
		}

		#endregion
	}
}