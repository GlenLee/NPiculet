using System;
using System.Collections.Generic;
using System.Linq;
using NPiculet.Base.EF;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class RoleBus : IBusiness
	{
		/// <summary>
		/// 角色是否存在
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public bool RoleExist(string roleName)
		{
			if (string.IsNullOrEmpty(roleName)) return false;

			using (var db = new NPiculetEntities()) {
				return db.sys_role_info.Any(a => a.IsDel == 0 && a.RoleName == roleName);
			}
		}

		/// <summary>
		/// 获取角色信息
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public sys_role_info GetRoleInfo(string roleName)
		{
			if (string.IsNullOrEmpty(roleName)) return null;

			using (var db = new NPiculetEntities()) {
				return db.sys_role_info.FirstOrDefault(a => a.IsDel == 0 && a.RoleName == roleName);
			}
		}

		/// <summary>
		/// 获取用户所属角色
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<sys_role_info> GetUserRole(int userId)
		{
			using (var db = new NPiculetEntities()) {
				return (from r in db.sys_role_info
					from l in db.sys_link_user_role
					where r.IsDel == 0 && r.Id == l.RoleId && l.UserId == userId
					select r).ToList();
			}
		}
	}
}
