using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
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
		/// <param name="roleId"></param>
		/// <returns></returns>
		public sys_role_info GetRoleInfo(int roleId)
		{
			if (roleId > 0) return null;

			using (var db = new NPiculetEntities()) {
				return db.sys_role_info.FirstOrDefault(a => a.IsDel == 0 && a.Id == roleId);
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
		/// 获取角色列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<sys_role_info> GetRoleList(out int count, int curPage, int pageSize, Expression<Func<sys_role_info, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.sys_role_info
					where a.IsDel == 0 && a.IsEnabled == 1
					select a);

				if (predicate != null)
					query = query.Where(predicate);

				count = query.Count();

				return query.OrderByDescending(a => a.CreateDate).Pagination(curPage, pageSize).ToList();
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

		/// <summary>
		/// 保存角色
		/// </summary>
		/// <param name="data"></param>
		public void Save(sys_role_info data)
		{
			using (var db = new NPiculetEntities()) {
				db.sys_role_info.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 删除角色（标记删除）
		/// </summary>
		/// <param name="roleId"></param>
		public void Delete(int roleId)
		{
			using (var db = new NPiculetEntities()) {
				var role = db.sys_role_info.FirstOrDefault(a => a.Id == roleId);
				if (role != null) {
					role.IsDel = 1;
					db.SaveChanges();
				}
			}
		}
	}
}
