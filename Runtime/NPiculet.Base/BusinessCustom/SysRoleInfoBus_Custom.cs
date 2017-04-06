using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysRoleInfoBus
	{
		/// <summary>
		/// 角色是否存在
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public bool RoleExist(string roleName)
		{
			string where = "RoleName='" + roleName + "'";
			return this.RecordCount(where) > 0;
		}

		/// <summary>
		/// 获取角色信息
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public SysRoleInfo GetRoleInfo(string roleName)
		{
			return this.QueryModel("RoleName='" + roleName + "'");
		}

		/// <summary>
		/// 获取用户所属角色
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<SysRoleInfo> GetUserRole(int userId)
		{
			string sql = @"SELECT r.* FROM npc_sys_role_info r
	INNER JOIN npc_sys_link_user_role l ON r.Id=l.RoleId
WHERE l.UserId=" + userId;
			return this.QueryList(sql);
		}
	}
}
