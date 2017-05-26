using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Plugin;

namespace NPiculet.Logic.Sys
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

		private readonly SysUserInfoBus _userBus = new SysUserInfoBus();
		private readonly SysRoleInfoBus _roleBus = new SysRoleInfoBus();

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
		public SysUserInfo GetUserInfo(string account)
		{
			return _userBus.GetUserInfo(account);
		}

		/// <summary>
		/// 获取用户资料
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public SysUserData GetUserData(string account)
		{
			SysUserDataBus dbus = new SysUserDataBus();
			return dbus.QueryModel("UserAccount='" + account + "'");
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
		public SysRoleInfo GetRoleInfo(string roleName)
		{
			return _roleBus.GetRoleInfo(roleName);
		}

		/// <summary>
		/// 更新用户信息
		/// </summary>
		/// <param name="user"></param>
		public void UpdateUserInfo(SysUserInfo user)
		{
			_userBus.Update(user);
		}

		/// <summary>
		/// 更新用户资料
		/// </summary>
		/// <param name="data"></param>
		public void UpdateUserData(SysUserData data)
		{
			SysUserDataBus bus = new SysUserDataBus();
			bus.Update(data);
		}
	}
}