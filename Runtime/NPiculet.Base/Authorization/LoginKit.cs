using System;
using System.Configuration;
using System.Web;
using NPiculet.Core;
using NPiculet.Logic.Business;
using NPiculet.Plugin;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Sys {
	/// <summary>
	/// Login : 登陆验证类
	/// </summary>
	public static class LoginKit {
		#region 初始化参数

		private const string _MEMBER_SESSION_CODE_KEY = "MEMBER_SESSION_CODE";
		private const string _ADMIN_SESSION_CODE_KEY = "ADMIN_SESSION_CODE";

		/// <summary>
		/// 获取当前 Session 编码，如果没有则会自动创建并记录。
		/// </summary>
		/// <param name="key"></param>
		/// <param name="expiryTime"></param>
		/// <returns></returns>
		public static string GetSessionCode(string key, int expiryTime) {
			string code = CookiesKit.GetCookie(key);
			if (String.IsNullOrEmpty(code)) {
				code = HttpContext.Current.Session.SessionID;
				CookiesKit.SetCookie(key, code, expiryTime);
			}
			return code;
		}

		/// <summary>
		/// 会员登录地址
		/// </summary>
		public static string MemberLoginUrl { get { return ConfigurationManager.AppSettings["MemberLoginUrl"]; } }

		/// <summary>
		/// 会员登录过期时间（分钟）
		/// </summary>
		public static int MemberLoginTimeout {
			get {
				string timeout = ConfigurationManager.AppSettings["MemberLoginTimeout"];
				return ConvertKit.ConvertValue(timeout, 30);
			}
		}

		/// <summary>
		/// 管理员登录地址
		/// </summary>
		public static string AdminLoginUrl { get { return ConfigurationManager.AppSettings["AdminLoginUrl"]; } }

		/// <summary>
		/// 管理员登录过期时间（分钟）
		/// </summary>
		public static int AdminLoginTimeout {
			get {
				string timeout = ConfigurationManager.AppSettings["AdminLoginTimeout"];
				return ConvertKit.ConvertValue(timeout, 30);
			}
		}

		#endregion

		#region 成员登录

		/// <summary>
		/// 检查会员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static Member MemberExist(string account, string password)
		{
			var member = MemberExist(account);
			return (member != null && member.Password == password) ? member : null;
		}

		/// <summary>
		/// 检查会员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public static Member MemberExist(string account)
		{
			SysMemberInfoBus bus = new SysMemberInfoBus();
			var user = bus.QueryModel(string.Format("Account='{0}' and IsDel=0", account.ToLower()));
			Member member = null;
			if (user != null) {
				member = new Member();
				member.Id = user.Id;
				member.Sn = user.UserSn;
				member.Name = user.Name;
				member.Level = user.MemberLevel;
				member.Account = user.Account;
				member.Password = user.Password;

				SysMemberDataBus dbus = new SysMemberDataBus();
				var data = dbus.QueryModel("UserId=" + user.Id);
				if (data != null) {
					member.Sex = data.Sex;
					member.Mobile = data.Mobile;
					member.Weixin = data.Weixin;
				}

				member.IsEnabled = user.IsEnabled == 1;
			}
			return member;
		}

		/// <summary>
		/// 会员登录
		/// </summary>
		/// <param name="member"></param>
		/// <returns>返回用户本次登录的唯一标识：UserSessionCode</returns>
		public static string MemberLogin(Member member)
		{
			member.SessionCode = GetSessionCode(_MEMBER_SESSION_CODE_KEY, LoginKit.MemberLoginTimeout);

			CacheManager<Member> cache = new CacheManager<Member>();
			TimeSpan ts = new TimeSpan(LoginKit.MemberLoginTimeout * 600000000L);
			cache.Set(member.SessionCode, member, ts, CacheBehavior.Delay);

			//记录登录日志
			ILoggerModule logger = PluginManager.GetPlugin<ILoggerModule>();
			Type rt = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType;
			string className = (rt != null) ? rt.FullName : string.Empty;
			logger.Log("Login", member.Account, className, "", "Member登录成功！");

			return member.SessionCode;
		}

		/// <summary>
		/// 获取当前会员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Member GetCurrentMember()
		{
			string code = GetSessionCode(_MEMBER_SESSION_CODE_KEY, LoginKit.MemberLoginTimeout);
			CacheManager<Member> cache = new CacheManager<Member>();
			return cache.Get(code).Value;
		}

		/// <summary>
		/// 获取指定会员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Member GetCurrentMember(string userSessionCode)
		{
			CacheManager<Member> cache = new CacheManager<Member>();
			return cache.Get(userSessionCode).Value;
		}

		#endregion

		#region 管理员登录

		/// <summary>
		/// 检查管理员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static Administrator AdminExist(string account, string password)
		{
			var admin = AdminExist(account);
			return (admin != null && admin.Password == password) ? admin : null;
		}

		/// <summary>
		/// 检查管理员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public static Administrator AdminExist(string account)
		{
			SysUserInfoBus bus = new SysUserInfoBus();
			var user = bus.QueryModel(string.Format("Account='{0}' and IsDel=0", account.ToLower()));
			Administrator admin = null;
			if (user != null) {
				admin = new Administrator();
				admin.Id = user.Id;
				admin.Sn = user.UserSn;
				admin.Name = user.Name;
				admin.Account = user.Account;
				admin.Password = user.Password;

				SysUserDataBus dbus = new SysUserDataBus();
				var data = dbus.QueryModel("UserId=" + user.Id);
				if (data != null) {
					admin.Sex = data.Sex;
					admin.Mobile = data.Mobile;
					admin.Weixin = data.Weixin;
				}

				admin.IsEnabled = user.IsEnabled == 1;
			}
			return admin;
		}

		/// <summary>
		/// 管理员登录
		/// </summary>
		/// <param name="admin"></param>
		/// <returns>返回用户本次登录的唯一标识：UserSessionCode</returns>
		public static string AdminLogin(Administrator admin)
		{
			admin.SessionCode = GetSessionCode(_ADMIN_SESSION_CODE_KEY, LoginKit.AdminLoginTimeout);

			CacheManager<Administrator> cache = new CacheManager<Administrator>();
			TimeSpan ts = new TimeSpan(LoginKit.MemberLoginTimeout * 600000000L);
			cache.Set(admin.SessionCode, admin, ts, CacheBehavior.Delay);

			//记录登录日志
			ILoggerModule logger = PluginManager.GetPlugin<ILoggerModule>();
			Type rt = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType;
			string className = (rt != null) ? rt.FullName : string.Empty;
			logger.Log("Login", admin.Account, className, "", "Administrator登录成功！");

			return admin.SessionCode;
		}

		/// <summary>
		/// 获取当前管理员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Administrator GetCurrentAdmin()
		{
			string code = GetSessionCode(_ADMIN_SESSION_CODE_KEY, LoginKit.AdminLoginTimeout);
			CacheManager<Administrator> cache = new CacheManager<Administrator>();
			return cache.Get(code).Value;
		}

		/// <summary>
		/// 获取指定管理员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Administrator GetCurrentAdmin(string userSessionCode)
		{
			CacheManager<Administrator> cache = new CacheManager<Administrator>();
			return cache.Get(userSessionCode).Value;
		}

		#endregion

		#region 通用方法

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void Logout() {
			MemberLogout();
			AdminLogout();
        }

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void MemberLogout()
		{
			Logout(GetSessionCode(_MEMBER_SESSION_CODE_KEY, LoginKit.MemberLoginTimeout));
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void AdminLogout() {
			Logout(GetSessionCode(_ADMIN_SESSION_CODE_KEY, LoginKit.AdminLoginTimeout));
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void Logout(string userSessionCode)
		{
			var user = GetUserInfo(userSessionCode);

			if (user != null) {
				//记录登出日志
				ILoggerModule logger = PluginManager.GetPlugin<ILoggerModule>();
				string className = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName;
				logger.Log("Logout", user.Account, className, "", "用户登出");

				var memberCache = new CacheManager<Member>();
				memberCache.Remove(userSessionCode);

				var adminCache = new CacheManager<Administrator>();
				adminCache.Remove(userSessionCode);
			}

			HttpContext.Current.Session.Clear();
			HttpContext.Current.Session.Abandon();
		}

		/// <summary>
		/// 检查验证码是否正确
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static bool CheckVerifyCode(string code)
		{
			return !string.IsNullOrEmpty(code) && (code == Convert.ToString(HttpContext.Current.Session["_VerifyCode_"]));
		}

		#endregion

		#region 用户的 UserSessionCode 缓存及逻辑

		/// <summary>
		/// 根据 flag 和 userSessionCode 验证是否已授权
		/// </summary>
		/// <param name="context">根据 HttpContext 上下文对象来获取 Session</param>
		/// <param name="flag">请求验证哪种权限，参数值：any、admin、member</param>
		/// <param name="userSessionCode"></param>
		/// <returns></returns>
		public static bool IsAuthorized(HttpContext context, string flag, string userSessionCode)
		{
			if (string.IsNullOrEmpty(userSessionCode)) return false;

			if (flag == "any" || flag == "member") {
				var cache = new CacheManager<Member>();
				var member = cache.Get(userSessionCode);
				return member != null;
			}

			if (flag == "any" || flag == "admin") {
				var cache = new CacheManager<Administrator>();
				var admin = cache.Get(userSessionCode);
				return admin != null;
			}

			return false;
		}

		/// <summary>
		/// 根据 flag 和 userSessionCode 验证是否已授权
		/// </summary>
		/// <param name="flag">请求验证哪种权限，参数值：any、admin、member</param>
		/// <param name="userSessionCode"></param>
		/// <returns></returns>
		public static bool IsAuthorized(string flag, string userSessionCode)
		{
			return IsAuthorized(HttpContext.Current, flag, userSessionCode);
		}

		/// <summary>
		/// 获取当前用户唯一标识
		/// </summary>
		/// <returns></returns>
		public static string GetUserSessionCode()
		{
			return HttpContext.Current.Session.SessionID;
		}

		/// <summary>
		/// 获取授权用户的信息
		/// </summary>
		/// <param name="userSessionCode"></param>
		/// <returns></returns>
		public static User GetUserInfo(string userSessionCode)
		{
			if (string.IsNullOrEmpty(userSessionCode)) return null;

			var memberCache = new CacheManager<Member>();
			var member = memberCache.Get(userSessionCode).Value;
			if (member != null) return member;

			var adminCache = new CacheManager<Administrator>();
			var admin = adminCache.Get(userSessionCode).Value;
			if (admin != null) return admin;

			return null;
		}

		#endregion
	}
}