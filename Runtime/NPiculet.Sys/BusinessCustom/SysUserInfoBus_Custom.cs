using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPiculet.Authorization;
using NPiculet.Base.EF;
using NPiculet.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysUserInfoBus
	{
		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public SysUserInfo GetUserInfo(string account)
		{
			return this.QueryModel("Account='" + account + "'");
		}

		/// <summary>
		/// 用户是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public bool UserExist(string account, string password)
		{
			if (string.IsNullOrEmpty(account)) return false;
			string where = "Account='" + account + "' and Password='" + password + "'";
			return this.RecordCount(where) > 0;
		}

		/// <summary>
		/// 用户是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public bool UserExist(string account)
		{
			if (string.IsNullOrEmpty(account)) return false;
			string where = "Account='" + account + "'";
			return this.RecordCount(where) > 0;
		}

		/// <summary>
		/// 获取用户列表。
		/// </summary>
		/// <returns></returns>
		public DataTable GetUserList(int curPage, int pageSize, string whereString = null, string orderBy = null)
		{
			string sql = @"SELECT * FROM (SELECT u.Id, u.UserSn, u.Type, u.Account, u.Password, u.Name, u.OrgId
	, u.LoginTimes, u.LastLoginDate, u.LastLogoutDate
	, u.FailedCount, u.FailedDate, u.IsEnabled, u.IsDel, u.OrderBy, u.Creator, u.CreateDate
	, d.Nickname, d.Birthday, d.Sex, d.Email, d.Mobile, d.Address, d.MemberCard
	, d.IdCard, d.Education, d.QQ, d.Weixin, d.Weibo, d.Interest, d.PointCurrent, d.PointTotal
	, d.Exp, d.Cash, d.Cost, d.HeadIcon, d.Memo
FROM sys_user_info u
	LEFT JOIN sys_user_data d ON u.Account=d.UserAccount AND d.IsDel=0
WHERE u.IsDel=0) t";
			if (!string.IsNullOrEmpty(whereString)) sql += " WHERE " + whereString;
			sql += (string.IsNullOrEmpty(orderBy)) ? " ORDER BY OrderBy, Id DESC" : " ORDER BY " + orderBy;
			sql += " LIMIT " + pageSize + " OFFSET " + ((curPage - 1) * pageSize);

			return base.QuerySql(sql);
		}

		/// <summary>
		/// 获取用户统计数。
		/// </summary>
		/// <param name="whereString"></param>
		/// <returns></returns>
		public int GetUserCount(string whereString)
		{
			return this.RecordCount(whereString);
		}

		/// <summary>
		/// 获取用户头像
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public string GetUserHeadIcon(int userId)
		{
			SysUserDataBus bus = new SysUserDataBus();
			var user = bus.QueryModel("UserId=" + userId);
			return user == null ? "" : user.HeadIcon;
		}

		/// <summary>
		/// 更改用户密码。
		/// </summary>
		/// <param name="account"></param>
		/// <param name="newpass"></param>
		public bool ChangePassword(string account, string newpass)
		{
			return base.Update(new SysUserInfo() { Password = newpass }, "Account='" + account + "'");
		}

		/// <summary>
		/// 获取用户的最大排序
		/// </summary>
		/// <returns></returns>
		public int GetMaxOrderBy()
		{
			string sql = "SELECT MAX(OrderBy) FROM sys_user_info";
			object val = DbHelper.QueryValue(sql);
			return val == DBNull.Value ? 0 : (int)val;
		}

		/// <summary>
		/// 获取用户的根组织机构
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public sys_org_info GetRootOrg(int userId)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.sys_org_info
					join u in db.sys_user_info on a.Id equals u.OrgId
					select a);
				return query.FirstOrDefault();
			}
		}

		/// <summary>
		/// 获取用户的组织机构列表
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<sys_org_info> GetOrgList(int userId)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.sys_org_info
							 join l in db.sys_link_user_org on a.Id equals l.OrgId
							 where l.UserId == userId
							 select a);
				return query.ToList();
			}
		}

		/// <summary>
		/// 获取用户的角色列表
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<sys_role_info> GetRoleList(int userId)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.sys_role_info
							 join r in db.sys_link_user_role on a.Id equals r.RoleId
							 where r.UserId == userId
							 select a);
				return query.ToList();
			}
		}
	}
}
