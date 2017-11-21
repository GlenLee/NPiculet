using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class AuthorizationBus : IBusiness
	{
		/// <summary>
		/// 获取授权列表
		/// </summary>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		public DataTable GetAuthList(string targetType, string targetId)
		{
			string sql = @"SELECT DISTINCT sm.`Id`, sm.`Name`, sm.`ParentId`, sm.`RootId`, sm.`Path`, sm.`Depth`, sm.`Sort`, 1 AS `IsAuth` FROM sys_menu sm
	INNER JOIN (SELECT m.`Id`, m.`Name`, m.`ParentId`, m.`RootId`, m.`Path`, m.`Depth` FROM sys_menu m
WHERE m.`IsDel`=0 and m.`IsEnabled`=1 and EXISTS(SELECT * FROM sys_authorization a WHERE m.`Id`=a.`FunctionId`";

			sql += string.Format(" and a.`TargetType`='{0}' and a.`TargetId`='{1}'", targetType, targetId);

			sql += ")) t ON sm.`Id`=t.`Id` OR sm.`Id`=t.`ParentId` OR sm.`Id`=t.`RootId`";
			sql += " ORDER BY sm.`Sort`";

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取授权菜单列表
		/// </summary>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		/// <returns></returns>
		public List<sys_menu> GetAuthMenuList(string targetType, int targetId) {
			using (var db = new NPiculetEntities()) {
				var query = (from all in db.sys_menu
					from t in (from m in db.sys_menu
						where (from a in db.sys_authorization where a.TargetType == targetType && a.TargetId == targetId select a.FunctionId).Contains(m.Id)
						select m)
					where all.Id == t.Id || all.Id == t.ParentId || all.Id == t.RootId
					orderby all.Sort
					select all);

				return query.ToList();
			}
		}

		/// <summary>
		/// 获取全部授权列表
		/// </summary>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		/// <returns></returns>
		public DataTable GetFullAuthList(string targetType, string targetId)
		{
			string sql = @"SELECT DISTINCT m.`Id`, m.`Name`, m.`ParentId`, m.`RootId`, m.`Path`, m.`Depth`, m.`Sort`, Count(a.`Id`) AS `IsAuth` FROM sys_menu m
	LEFT JOIN sys_authorization a ON m.`Id`=a.`FunctionId`";

			sql += string.Format(" and a.`TargetType`='{0}' and a.`TargetId`='{1}'", targetType, targetId);

			sql += " WHERE m.`IsDel`=0";
			sql += " GROUP BY m.`Id`, m.`Name`, m.`ParentId`, m.`RootId`, m.`Path`, m.`Depth`, m.`Sort`";
			sql += " ORDER BY m.`Sort`";

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取角色链接的用户
		/// </summary>
		/// <returns></returns>
		public DataTable GetRoleLinkUser(int roleId)
		{
			string sql = @"SELECT l.UserId, u.Account, u.Password, u.Name AS UserName, l.RoleId, r.RoleName
FROM sys_user_info u
	INNER JOIN sys_link_user_role l ON u.Id=l.UserId AND u.IsDel=0
	INNER JOIN sys_role_info r ON l.RoleId=r.Id AND r.IsDel=0";

			sql += " WHERE r.Id=" + roleId;

			sql += " GROUP BY l.UserId, u.Account, u.Password, u.Name, l.RoleId, r.RoleName";

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取用户链接的角色
		/// </summary>
		/// <returns></returns>
		public DataTable GetUserLinkRole(int userId)
		{
			string sql = @"SELECT l.UserId, u.Account, u.Password, u.Name AS UserName, l.RoleId, r.RoleName
FROM sys_user_info u
	INNER JOIN sys_link_user_role l ON u.Id=l.UserId AND u.IsDel=0
	INNER JOIN sys_role_info r ON l.RoleId=r.Id AND r.IsDel=0";
	
			sql += " WHERE u.Id=" + userId;

			sql += " GROUP BY l.UserId, u.Account, u.Password, u.Name, l.RoleId, r.RoleName";

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取组织链接的用户
		/// </summary>
		/// <returns></returns>
		public DataTable GetOrgLinkUser(int orgId)
		{
			string sql = @"SELECT l.`UserId`, u.`Account`, u.`Password`, u.`Name`, l.`OrgId`, o.`OrgName`, o.`OrgCode`, o.`OrgType`, o.`FullName`, o.`Path`
FROM sys_user_info u
	INNER JOIN sys_link_user_org l ON u.`Id`=l.`UserId` AND u.`IsDel`=0
	INNER JOIN sys_org_info o ON l.`OrgId`=o.`Id` AND o.`IsDel`=0";

			sql += " WHERE o.`Id`=" + orgId;

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取用户链接的组织
		/// </summary>
		/// <returns></returns>
		public DataTable GetUserLinkOrg(int userId)
		{
			string sql = @"SELECT l.`UserId`, u.`Account`, u.`Password`, u.`Name`, l.`OrgId`, o.`OrgName`, o.`OrgCode`, o.`OrgType`, o.`FullName`, o.`Path`
FROM sys_user_info u
	INNER JOIN sys_link_user_org l ON u.`Id`=l.`UserId` AND u.`IsDel`=0
	INNER JOIN sys_org_info o ON l.`OrgId`=o.`Id` AND o.`IsDel`=0";

			sql += " WHERE u.`Id`=" + userId;

			return DbHelper.Query(sql);
		}

		private class AuthCompare : IEqualityComparer<sys_authorization>
		{
			public bool Equals(sys_authorization x, sys_authorization y) {
				if (ReferenceEquals(x, y)) return true;
				return x != null && y != null
					&& x.TargetType == y.TargetType
					&& x.TargetId == y.TargetId
					&& x.FunctionType == y.FunctionType
					&& x.FunctionId == y.FunctionId;
			}

			public int GetHashCode(sys_authorization obj) {
				int hCode = obj.TargetId.GetHashCode() ^ obj.FunctionId.GetHashCode();
				return hCode.GetHashCode();
			}
		}

		/// <summary>
		/// 更新授权列表
		/// </summary>
		/// <param name="authList"></param>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		public void UpdateAuthList(List<sys_authorization> authList, string targetType, int targetId)
		{
			using (var db = new NPiculetEntities()) {
				var data = db.sys_authorization.Where(a => a.TargetType == targetType && a.TargetId == targetId).ToList();
				//计算差集新增
				var except = authList.Except(data, new AuthCompare()).ToList();
				db.sys_authorization.AddRange(except);
				//删除多余数据
				var delete = data.Except(authList, new AuthCompare());
				db.sys_authorization.RemoveRange(delete);
				db.BulkSaveChanges();
			}
		}

		/// <summary>
		/// 更新用户所属组织机构信息
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="uoList"></param>
		public void UpdateUserOrgList(int userId, List<sys_link_user_org> uoList)
		{
			using (var db = new NPiculetEntities()) {
				var data = db.sys_link_user_role.Where(a => a.UserId == userId).ToList();
				if (data.Count > 0) {
					db.sys_link_user_role.RemoveRange(data);
				}
				db.sys_link_user_org.AddRange(uoList);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 更新用户所属角色信息
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="urList"></param>
		public void UpdateUserRoleList(int userId, List<sys_link_user_role> urList)
		{
			using (var db = new NPiculetEntities()) {
				db.ExecuteSql(string.Format("DELETE FROM sys_link_user_role WHERE UserId={0}", userId));
				db.sys_link_user_role.AddRange(urList);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 删除用户角色关联
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="roleId"></param>
		public void DeleteUserRole(int userId, int roleId)
		{
			using (var db = new NPiculetEntities()) {
				var data = db.sys_link_user_role.Where(a => a.UserId == userId && a.RoleId == roleId).ToList();
				if (data.Count > 0) {
					db.sys_link_user_role.RemoveRange(data);
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 删除用户角组织关联
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="orgId"></param>
		public void DeleteUserOrg(int userId, int orgId)
		{
			using (var db = new NPiculetEntities()) {
				var data = db.sys_link_user_org.Where(a => a.UserId == userId && a.OrgId == orgId).ToList();
				if (data.Count > 0) {
					db.sys_link_user_org.RemoveRange(data);
					db.SaveChanges();
				}
			}
		}
	}
}
