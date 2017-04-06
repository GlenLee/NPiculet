using NPiculet.Logic.Data;
using NPiculet.Plugin;

namespace NPiculet.Logic.Sys
{
	public interface IAuthModule : IPlugin
	{
		/// <summary>
		/// 用户帐号是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		bool UserExist(string account);

		/// <summary>
		/// 用户账号是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		bool UserExist(string account, string password);

		/// <summary>
		/// 获取用户信息。
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		SysUserInfo GetUserInfo(string account);

		/// <summary>
		/// 获取用户资料
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		SysUserData GetUserData(string account);

		/// <summary>
		/// 角色是否存在。
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		bool RoleExist(string roleName);

		/// <summary>
		/// 获取角色信息。
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		SysRoleInfo GetRoleInfo(string roleName);

		/// <summary>
		/// 更新用户信息
		/// </summary>
		/// <param name="user"></param>
		void UpdateUserInfo(SysUserInfo user);

		/// <summary>
		/// 更新用户资料
		/// </summary>
		/// <param name="data"></param>
		void UpdateUserData(SysUserData data);
	}
}