using NPiculet.Authorization;
using NPiculet.Plugin;

namespace NPiculet.Logic.Plugin
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
		User<int> GetUserInfo(string account);

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
		Role GetRoleInfo(string roleName);
	}
}