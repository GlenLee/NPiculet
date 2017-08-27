using NPiculet.Authorization;
using NPiculet.Logic.Business;
using NPiculet.Plugin;

namespace NPiculet.Logic.Plugin
{
	public class AuthManager : PluginBase, IAuthModule
	{
		#region 初始化

		public AuthManager(IPluginDescriptor descr) : base(descr)
		{ }

		protected override void DoStart()
		{ }

		protected override void DoStop()
		{ }

		#endregion

		private readonly UserBus _userBus = new UserBus();
		private readonly RoleBus _roleBus = new RoleBus();

		/// <summary>
		/// 用户是否已存在
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public bool UserExist(string account)
		{
			return _userBus.UserExist(account);
		}

		/// <summary>
		/// 用户是否已存在
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public bool UserExist(string account, string password)
		{
			return _userBus.UserExist(account, password);
		}

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public User<int> GetUserInfo(string account) {
			User<int> u = null;
			var user = _userBus.GetUserInfo(account);
			if (user != null) {
				u = new User<int>();
				u.Id = user.Id;
				u.Type = user.Type;
				u.Sn = user.UserSn;
				u.Name = user.Name;
				//u.Level = "";
				u.Account = user.Account;
				u.Password = user.Password;
				u.StateCode = user.IsEnabled == 1 ? "启用" : "停用";
			}
			return u;
		}

		/// <summary>
		/// 角色是否已存在
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public bool RoleExist(string roleName)
		{
			return _roleBus.RoleExist(roleName);
		}

		/// <summary>
		/// 获取角色信息
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public Role GetRoleInfo(string roleName) {
			Role r = null;
			var role = _roleBus.GetRoleInfo(roleName);
			if (role != null) {
				r = new Role();
				r.Id = role.Id;
				r.Name = role.RoleName;
			}
			return r;
		}
	}
}