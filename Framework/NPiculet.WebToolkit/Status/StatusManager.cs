using System;
using System.Configuration;
using System.Web;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 状态管理器。
	/// </summary>
	public static class StatusManager
	{
		#region 状态管理

		/// <summary>
		/// 状态存储模式。
		/// </summary>
		public enum StatusMode
		{
			Cookie,
			Session
		}

		/// <summary>
		/// 获取当前存储模式。
		/// </summary>
		/// <returns></returns>
		private static StatusMode GetCurrentMode()
		{
			switch (ConfigurationManager.AppSettings["StatusMode"]) {
				case "Cookie":
					return StatusMode.Cookie;
				case "Session":
					return StatusMode.Session;
				default:
					return StatusMode.Session;
			}
		}

		/// <summary>
		/// 检查状态值。
		/// </summary>
		/// <param name="statusName">状态名称</param>
		/// <returns></returns>
		public static bool CheckStatus(string statusName)
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session: return SessionKit.CheckSession(statusName);
				case StatusMode.Cookie: return CookiesKit.CheckCookie(statusName);
				default: return false;
			}
		}

		/// <summary>
		/// 比较状态值。
		/// </summary>
		/// <param name="statusName">状态名称</param>
		/// <param name="chkValue">比较值</param>
		/// <returns></returns>
		public static bool CheckStatus(string statusName, string chkValue)
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session: return SessionKit.CheckSession(statusName, chkValue);
				case StatusMode.Cookie: return CookiesKit.CheckCookie(statusName, chkValue);
				default: return false;
			}
		}

		/// <summary>
		/// 设置状态值。
		/// </summary>
		/// <param name="statusName">状态名称</param>
		/// <param name="val">状态值</param>
		public static void SetStatus(string statusName, string val)
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session: SessionKit.SetSession(statusName, val); break;
				case StatusMode.Cookie: CookiesKit.SetCookie(statusName, val); break;
				default: break;
			}
		}

		/// <summary>
		/// 设置状态值，并设置状态过期时间。
		/// </summary>
		/// <param name="statusName">状态名称</param>
		/// <param name="val">状态值</param>
		/// <param name="expiryTime">过期时间（分钟）</param>
		public static void SetStatus(string statusName, string val, int expiryTime)
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session:
					SessionKit.SetSession(statusName, val, expiryTime);
					break;

				case StatusMode.Cookie:
					CookiesKit.SetCookie(statusName, val, expiryTime);
					break;

				default: break;
			}
		}

		/// <summary>
		/// 获取登陆状态。
		/// </summary>
		/// <param name="statusName">状态名称</param>
		/// <returns>状态值</returns>
		public static string GetStatus(string statusName)
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session: return SessionKit.GetSession(statusName);
				case StatusMode.Cookie:
					CookiesKit.RefreshCookie();
					return CookiesKit.GetCookie(statusName);
				default: return String.Empty;
			}
		}

		/// <summary>
		/// 刷新状态，使其过期时间重置。
		/// </summary>
		public static void RefreshStatus()
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session:
					foreach (string key in HttpContext.Current.Session.Keys) {
						SessionKit.CheckSession(key);
					}
					break;

				case StatusMode.Cookie:
					CookiesKit.RefreshCookie();
					break;

				default: break;
			}
		}

		/// <summary>
		/// 移除指定状态。
		/// </summary>
		/// <param name="statusName">状态名称</param>
		public static void Remove(string statusName)
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session: HttpContext.Current.Session.Remove(statusName); break;
				case StatusMode.Cookie: CookiesKit.RemoveCookie(statusName); break;
				default: break;
			}
		}

		/// <summary>
		/// 销毁所有状态。
		/// </summary>
		public static void RemoveAll()
		{
			switch (GetCurrentMode()) {
				case StatusMode.Session: HttpContext.Current.Session.RemoveAll(); break;
				case StatusMode.Cookie: CookiesKit.RemoveAll(); break;
				default: break;
			}
		}

		#endregion
	}
}