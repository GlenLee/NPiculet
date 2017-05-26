using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysAuthorizationBus
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

			var dt = base.QuerySql(sql);
			return dt;
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

			var dt = base.QuerySql(sql);
			return dt;
		}

		/// <summary>
		/// 更新授权列表
		/// </summary>
		/// <param name="authList"></param>
		/// <param name="targetType"></param>
		/// <param name="targetId"></param>
		public void UpdateAuthList(List<SysAuthorization> authList, string targetType, string targetId)
		{
			this.Delete(string.Format("TargetType='{0}' and TargetId={1}", targetType, targetId));
			this.InsertList(authList);
		}

		/// <summary>
		/// 获取角色链接的用户
		/// </summary>
		/// <returns></returns>
		public DataTable GetRoleLinkUser(int roleId)
		{
			string sql = @"SELECT l.UserId, u.Account, u.Password, u.Name, l.RoleId, r.RoleName
FROM sys_user_info u
	INNER JOIN sys_link_user_role l ON u.Id=l.UserId AND u.IsDel=0
	INNER JOIN sys_role_info r ON l.RoleId=r.Id AND r.IsDel=0";

			sql += " WHERE r.Id=" + roleId;

			sql += " GROUP BY l.UserId, u.Account, u.Password, u.Name, l.RoleId, r.RoleName";

			var dt = base.QuerySql(sql);
			return dt;
		}

		/// <summary>
		/// 获取用户链接的角色
		/// </summary>
		/// <returns></returns>
		public DataTable GetUserLinkRole(int userId)
		{
			string sql = @"SELECT l.UserId, u.Account, u.Password, u.Name, l.RoleId, r.RoleName
FROM sys_user_info u
	INNER JOIN sys_link_user_role l ON u.Id=l.UserId AND u.IsDel=0
	INNER JOIN sys_role_info r ON l.RoleId=r.Id AND r.IsDel=0";
	
			sql += " WHERE u.Id=" + userId;

			sql += " GROUP BY l.UserId, u.Account, u.Password, u.Name, l.RoleId, r.RoleName";

			return base.QuerySql(sql);
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

			var dt = base.QuerySql(sql);
			return dt;
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

			var dt = base.QuerySql(sql);
			return dt;
		}

	}
}
