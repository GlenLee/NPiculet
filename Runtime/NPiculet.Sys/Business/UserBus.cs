using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Authorization;
using NPiculet.Base.EF;
using NPiculet.Data;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class UserBus : IBusiness
	{
		/// <summary>
		/// 创建一个加密密码字符串
		/// </summary>
		/// <param name="account"></param>
		/// <param name="pwd"></param>
		/// <returns></returns>
		public string CreateEncodePassword(string account, string pwd)
		{
			return pwd;
			//return EncryptKit.ToSHA1(account + pwd);
		}

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public sys_user_info GetUserInfo(int userId)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_user_info.FirstOrDefault(a => a.IsDel == 0 && a.Id == userId);
			}
		}

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public sys_user_info GetUserInfo(string account)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_user_info.FirstOrDefault(a => a.IsDel == 0 && a.Account == account);
			}
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

			using (var db = new NPiculetEntities()) {
				string pwd = CreateEncodePassword(account, password);
				return db.sys_user_info.Any(a => a.IsDel == 0 && a.Account == account && a.Password == pwd);
			}
		}

		/// <summary>
		/// 用户是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public bool UserExist(string account)
		{
			if (string.IsNullOrEmpty(account)) return false;

			using (var db = new NPiculetEntities()) {
				return db.sys_user_info.Any(a => a.IsDel == 0 && a.Account == account);
			}
		}

		/// <summary>
		/// 获取用户列表。
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="whereString"></param>
		/// <param name="orderBy"></param>
		/// <returns></returns>
		public DataTable GetUserList(out int count, int curPage, int pageSize, string whereString = null, string orderBy = null)
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

			using (var db = DbHelper.Create()) {
				var val = db.GetDataValue("SELECT COUNT(*) FROM sys_user_info WHERE IsDel=0" + (string.IsNullOrEmpty(whereString) ? "" : " and (" + whereString + ")"));
				count = ConvertKit.ConvertValue(val, 0);

				sql += " LIMIT " + pageSize + " OFFSET " + ((curPage - 1) * pageSize);

				return db.GetDataTable(sql);
			}
		}

		/// <summary>
		/// 获取用户头像
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public string GetUserHeadIcon(int userId)
		{
			using (var db = new NPiculetEntities()) {
				var user = db.sys_user_data.FirstOrDefault(a => a.UserId == userId);
				return (user != null) ? user.HeadIcon : "";
			}
		}

		/// <summary>
		/// 更改用户密码。
		/// </summary>
		/// <param name="account"></param>
		/// <param name="newpass"></param>
		public bool ChangePassword(string account, string newpass)
		{
			using (var db = new NPiculetEntities()) {
				var user = db.sys_user_info.FirstOrDefault(a => a.IsDel == 0 && a.Account == account);
				if (user != null) {
					user.Password = CreateEncodePassword(account, newpass);
					return db.SaveChanges() > 0;
				}
			}
			return false;
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

		/// <summary>
		/// 根据用户帐号获取用户资料
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public sys_user_data GetUserData(int userId)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_user_data.FirstOrDefault(a => a.UserId == userId);
			}
		}

		/// <summary>
		/// 根据用户帐号获取用户资料
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public sys_user_data GetUserData(string account)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_user_data.FirstOrDefault(a => a.UserAccount == account);
			}
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="uid"></param>
		public void Delete(int uid)
		{
			using (var db = new NPiculetEntities()) {
				var user = db.sys_user_data.FirstOrDefault(a => a.Id == uid);
				if (user != null) {
					user.IsDel = 1;
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 保存用户
		/// </summary>
		/// <param name="user"></param>
		public void SaveUser(sys_user_info user) {
			using (var db = new NPiculetEntities()) {
				db.Save(user);
			}
		}

		/// <summary>
		/// 保存用户资料
		/// </summary>
		/// <param name="data"></param>
		public void SaveData(sys_user_data data) {
			using (var db = new NPiculetEntities()) {
				db.Save(data);
			}
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="data"></param>
		/// <param name="predicate"></param>
		public void SaveData(sys_user_data data, Expression<Func<sys_user_data, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				var current = db.sys_user_data.FirstOrDefault(predicate);
				if (current == null) {
					db.sys_user_data.Add(data);
				} else {
					data.Id = current.Id;
					db.sys_user_data.AddOrUpdate(data);
				}
				db.SaveChanges();
			}
		}
	}
}
