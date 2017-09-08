using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using NPiculet.Base.EF;
using NPiculet.Cache;
using NPiculet.Logic.Business;
using NPiculet.Logic.Plugin;
using NPiculet.Plugin;
using NPiculet.Toolkit;

namespace NPiculet.Authorization
{
	/// <summary>
	/// Login : 登陆验证类
	/// </summary>
	public static class LoginKit {
		#region 初始化参数

		private const string _ASP_SESSION_KEY = "ASP.NET_SessionId";
		private const string _MEMBER_STATE_CODE_KEY = "MEMBER_STATE_CODE";
		private const string _ADMIN_STATE_CODE_KEY = "ADMIN_STATE_CODE";

		/// <summary>
		/// 获取当前用户唯一标识
		/// </summary>
		/// <returns></returns>
		public static string GetCookie(string key)
		{
			var cookies = HttpContext.Current.Request.Cookies;
			var cookie = cookies[key];
			if (cookie != null) {
				return cookie.Value;
			}
			return string.Empty;
		}

		/// <summary>
		/// 获取当前用户唯一标识
		/// </summary>
		/// <returns></returns>
		public static void SetCookie(string key, string value, int expiryTime)
		{
			HttpCookie cok = new HttpCookie("__cookies__");
			cok.Values[key] = value;
			cok.Expires = DateTime.Now.AddMinutes(expiryTime);
			cok.Path = "/";
			HttpContext.Current.Response.Cookies.Add(cok);
		}

		/// <summary>
		/// 获取当前 Session 编码，如果没有则会自动创建并记录。
		/// </summary>
		/// <param name="key"></param>
		/// <param name="expiryTime"></param>
		/// <returns></returns>
		public static string GetStateCode(string key, int expiryTime)
		{
			string code = GetCookie(key);
			if (String.IsNullOrEmpty(code)) {
				code = GetCookie(_ASP_SESSION_KEY);
				if (string.IsNullOrEmpty(code)) code = StringKit.GetRandomString(32);
				SetCookie(key, code, expiryTime);
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
			get
			{
				int timeout = ConvertKit.ConvertValue(ConfigurationManager.AppSettings["MemberLoginTimeout"], 30);
				return timeout <= 0 ? 30 : timeout;
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
				int timeout = ConvertKit.ConvertValue(ConfigurationManager.AppSettings["AdminLoginTimeout"], 30);
				return timeout <= 0 ? 30 : timeout;
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
		public static Member<int> MemberExist(string account, string password)
		{
			var member = MemberExist(account);
			return (member != null && member.Password == password) ? member : null;
		}

		/// <summary>
		/// 检查会员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public static Member<int> MemberExist(string account)
		{
			MemberBus bus = new MemberBus();
			var user = bus.GetMemberInfo(account);
			Member<int> member = null;
			if (user != null) {
				member = new Member<int>();
				member.Id = user.Id;
				member.Type = user.Type;
				member.Sn = user.MemberSn;
				member.Name = user.Name;
				member.Level = user.MemberLevel;
				member.Account = user.Account;
				member.Password = user.Password;
				member.StateCode = user.Status;

				var data = bus.GetMemberData(user.Id);
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
		/// <returns>返回用户本次登录的唯一标识：UserStateCode</returns>
		public static string MemberLogin(Member<int> member)
		{
			member.StateCode = GetStateCode(_MEMBER_STATE_CODE_KEY, LoginKit.MemberLoginTimeout);

			var cache = new CacheManager<Member<int>>();
			TimeSpan ts = new TimeSpan(LoginKit.MemberLoginTimeout * 600000000L);
			cache.Set(member.StateCode, member, ts, CacheBehavior.Delay);

			//记录登录日志
			//ILoggerModule logger = PluginManager.GetPlugin<ILoggerModule>();
			//Type rt = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType;
			//string className = (rt != null) ? rt.FullName : string.Empty;
			//logger.Log("Login", member.Account, className, "", "Member登录成功！");

			return member.StateCode;
		}

		/// <summary>
		/// 获取当前会员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Member<int> GetCurrentMember()
		{
			string code = GetStateCode(_MEMBER_STATE_CODE_KEY, LoginKit.MemberLoginTimeout);
			var cache = new CacheManager<Member<int>>().Get(code);
			return cache.IsValid ? cache.Value : null;
		}

		/// <summary>
		/// 获取指定会员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Member<int> GetCurrentMember(string userStateCode)
		{
			var cache = new CacheManager<Member<int>>().Get(userStateCode);
			return cache.IsValid ? cache.Value : null;
		}

		#endregion

		#region 管理员登录

		/// <summary>
		/// 检查管理员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static Administrator<int> AdminExist(string account, string password)
		{
			var admin = AdminExist(account);
			return (admin != null && admin.Password == password) ? admin : null;
		}

		/// <summary>
		/// 检查管理员是否存在
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public static Administrator<int> AdminExist(string account)
		{
			UserBus ubus = new UserBus();
			var user = ubus.GetUser(account);
			Administrator<int> admin = null;
			if (user != null) {
				admin = new Administrator<int>();
				admin.Id = user.Id;
				admin.Type = user.Type;
				admin.Sn = user.UserSn;
				admin.Name = user.Name;
				admin.Account = user.Account;
				admin.Password = user.Password;

				//获取用户的资料信息
				var data = ubus.GetUserData(user.Id);
				if (data != null) {
					admin.Sex = data.Sex;
					admin.Mobile = data.Mobile;
					admin.Weixin = data.Weixin;
				}

				//获取用户所属部门
				var rootOrg = ubus.GetRootOrg(admin.Id);
				if (rootOrg != null) {
					var o = new Organization();
					o.Id = rootOrg.Id;
					o.Name = rootOrg.OrgName;
					o.FullName = rootOrg.FullName;
					o.Layer = rootOrg.Level ?? 0;
					o.RootId = rootOrg.RootId;
					o.ParentId = rootOrg.ParentId;
					o.Path = rootOrg.Path;
					admin.Organization = o;
				}

				//获取组织机构
				var orgList = ubus.GetOrgList(admin.Id);
				var orgs = new List<Organization>();
				foreach (sys_org_info org in orgList) {
					var o = new Organization();
					o.Id = org.Id;
					o.Name = org.OrgName;
					o.FullName = org.FullName;
					o.Layer = org.Level ?? 0;
					o.RootId = org.RootId;
					o.ParentId = org.ParentId;
					o.Path = org.Path;
					orgs.Add(o);
				}
				admin.Orgs = orgs;

				//获取用户的角色信息
				var roleList = ubus.GetRoleList(admin.Id);
				var roles = new List<Role>();
				foreach (sys_role_info role in roleList) {
					var r = new Role();
					r.Id = role.Id;
					r.Name = role.RoleName;
					roles.Add(r);
				}
				if (roles.Count > 0) {
					admin.Roles = roles;
				}

				admin.IsEnabled = user.IsEnabled == 1;
			}
			return admin;
		}

		/// <summary>
		/// 管理员登录
		/// </summary>
		/// <param name="admin"></param>
		/// <returns>返回用户本次登录的唯一标识：UserStateCode</returns>
		public static string AdminLogin(Administrator<int> admin)
		{
			admin.StateCode = GetStateCode(_ADMIN_STATE_CODE_KEY, LoginKit.AdminLoginTimeout);

			var cache = new CacheManager<Administrator<int>>();
			TimeSpan ts = new TimeSpan(LoginKit.MemberLoginTimeout * 600000000L);
			cache.Set(admin.StateCode, admin, ts, CacheBehavior.Delay);

			//记录登录日志
			ILoggerModule logger = PluginManager.GetPlugin<ILoggerModule>();
			Type rt = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType;
			string className = (rt != null) ? rt.FullName : string.Empty;
			logger.Log("Login", admin.Account, className, "", "Administrator登录成功！");

			return admin.StateCode;
		}

		/// <summary>
		/// 获取当前管理员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Administrator<int> GetCurrentAdmin()
		{
			string code = GetStateCode(_ADMIN_STATE_CODE_KEY, LoginKit.AdminLoginTimeout);
			var cache = new CacheManager<Administrator<int>>().Get(code);
			return cache.IsValid ? cache.Value : null;
		}

		/// <summary>
		/// 获取指定管理员帐号信息
		/// </summary>
		/// <returns></returns>
		public static Administrator<int> GetCurrentAdmin(string userStateCode)
		{
			var cache = new CacheManager<Administrator<int>>().Get(userStateCode);
			return cache.IsValid ? cache.Value : null;
		}

		#endregion

		#region 通用方法

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void Logout()
		{
			MemberLogout();
			AdminLogout();
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void MemberLogout()
		{
			Logout(GetStateCode(_MEMBER_STATE_CODE_KEY, LoginKit.MemberLoginTimeout));
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void AdminLogout()
		{
			Logout(GetStateCode(_ADMIN_STATE_CODE_KEY, LoginKit.AdminLoginTimeout));
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		public static void Logout(string userStateCode)
		{
			var user = GetUserInfo(userStateCode);

			if (user != null) {
				//记录登出日志
				//ILoggerModule logger = PluginManager.GetPlugin<ILoggerModule>();
				//string className = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName;
				//logger.Log("Logout", user.Account, className, "", "用户登出");

				var memberCache = new CacheManager<Member<int>>();
				memberCache.Remove(userStateCode);

				var adminCache = new CacheManager<Administrator<int>>();
				adminCache.Remove(userStateCode);
			}

			if (HttpContext.Current != null && HttpContext.Current.Session != null) {
				HttpContext.Current.Session.Clear();
				HttpContext.Current.Session.Abandon();
			}
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

		#region 用户的 UserStateCode 缓存及逻辑

		/// <summary>
		/// 根据 flag 和 userStateCode 验证是否已授权
		/// </summary>
		/// <param name="context">根据 HttpContext 上下文对象来获取状态值</param>
		/// <param name="flag">请求验证哪种权限，参数值：any、admin、member</param>
		/// <param name="userStateCode"></param>
		/// <returns></returns>
		public static bool IsAuthorized(HttpContext context, string flag, string userStateCode)
		{
			if (string.IsNullOrEmpty(userStateCode)) return false;

			if (flag == "any" || flag == "member") {
				var cache = new CacheManager<Member<int>>();
				var member = cache.Get(userStateCode);
				return member != null;
			}

			if (flag == "any" || flag == "admin") {
				var cache = new CacheManager<Administrator<int>>();
				var admin = cache.Get(userStateCode);
				return admin != null;
			}

			return false;
		}

		/// <summary>
		/// 根据 flag 和 userStateCode 验证是否已授权
		/// </summary>
		/// <param name="flag">请求验证哪种权限，参数值：any、admin、member</param>
		/// <param name="userStateCode"></param>
		/// <returns></returns>
		public static bool IsAuthorized(string flag, string userStateCode)
		{
			return IsAuthorized(HttpContext.Current, flag, userStateCode);
		}

		/// <summary>
		/// 获取授权用户的信息
		/// </summary>
		/// <param name="userStateCode"></param>
		/// <returns></returns>
		public static User<int> GetUserInfo(string userStateCode)
		{
			if (string.IsNullOrEmpty(userStateCode)) return null;

			var memberCache = new CacheManager<Member<int>>().Get(userStateCode);
			var member = memberCache.IsValid ? memberCache.Value : null;
			if (member != null) return member;

			var adminCache = new CacheManager<Administrator<int>>().Get(userStateCode);
			var admin = adminCache.IsValid ? adminCache.Value : null;
			return admin;
		}

		#endregion
	}
}