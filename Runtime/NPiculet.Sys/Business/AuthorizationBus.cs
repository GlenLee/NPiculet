using System;
using System.Collections.Generic;
using System.Data;
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
			string sql = @"SELECT DISTINCT sm.`Id`, sm.`Name`, sm.`ParentId`, sm.`RootId`, sm.`Path`, sm.`Depth`, sm.`OrderBy`, 1 AS `IsAuth` FROM sys_menu sm
	INNER JOIN (SELECT m.`Id`, m.`Name`, m.`ParentId`, m.`RootId`, m.`Path`, m.`Depth` FROM sys_menu m
WHERE m.`IsDel`=0 and m.`IsEnabled`=1 and EXISTS(SELECT * FROM sys_authorization a WHERE m.`Id`=a.`FunctionId`";

			sql += string.Format(" and a.`TargetType`='{0}' and a.`TargetId`='{1}'", targetType, targetId);

			sql += ")) t ON sm.`Id`=t.`Id` OR sm.`Id`=t.`ParentId` OR sm.`Id`=t.`RootId`";
			sql += " ORDER BY sm.`OrderBy`";

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取全部授权列表
		/// </summary>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		/// <returns></returns>
		public DataTable GetFullAuthList(string targetType, string targetId)
		{
			string sql = @"SELECT DISTINCT m.`Id`, m.`Name`, m.`ParentId`, m.`RootId`, m.`Path`, m.`Depth`, m.`OrderBy`, Count(a.`Id`) AS `IsAuth` FROM sys_menu m
	LEFT JOIN sys_authorization a ON m.`Id`=a.`FunctionId`";

			sql += string.Format(" and a.`TargetType`='{0}' and a.`TargetId`='{1}'", targetType, targetId);

			sql += " WHERE m.`IsDel`=0";
			sql += " GROUP BY m.`Id`, m.`Name`, m.`ParentId`, m.`RootId`, m.`Path`, m.`Depth`, m.`OrderBy`";
			sql += " ORDER BY m.`OrderBy`";

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

		/// <summary>
		/// 更新授权列表
		/// </summary>
		/// <param name="authList"></param>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		public void UpdateAuthList(List<sys_authorization> authList, string targetType, string targetId)
		{
			DbHelper.Execute(string.Format("DELETE FROM sys_authorization WHERE TargetType='{0}' and TargetId={1}", targetType, targetId));
			using (var db = new NPiculetEntities()) {
				db.sys_authorization.AddRange(authList);
			}
		}

		/// <summary>
		/// 更新用户所属组织机构信息
		/// </summary>
		/// <param name="uoList"></param>
		/// <param name="userId"></param>
		public void UpdateUserOrgList(List<sys_link_user_org> uoList, int userId)
		{
			DbHelper.Execute(string.Format("DELETE FROM sys_link_user_org WHERE UserId={0}", userId));
			using (var db = new NPiculetEntities()) {
				db.sys_link_user_org.AddRange(uoList);
			}
		}

		/// <summary>
		/// 更新用户所属角色信息
		/// </summary>
		/// <param name="urList"></param>
		/// <param name="userId"></param>
		public void UpdateUserRoleList(List<sys_link_user_role> urList, int userId)
		{
			DbHelper.Execute(string.Format("DELETE FROM sys_link_user_role WHERE UserId={0}", userId));
			using (var db = new NPiculetEntities()) {
				db.sys_link_user_role.AddRange(urList);
			}
		}
	}
}
