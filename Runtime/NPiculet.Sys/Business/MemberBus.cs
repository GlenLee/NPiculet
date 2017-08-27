using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Data;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class MemberBus : IBusiness
	{
		/// <summary>
		/// 创建一个加密密码字符串
		/// </summary>
		/// <param name="account"></param>
		/// <param name="pwd"></param>
		/// <returns></returns>
		public string CreateEncodePassword(string account, string pwd) {
			return pwd;
			//return EncryptKit.ToSHA1(account + pwd);
		}

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public sys_member_info GetMemberInfo(string account)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_member_info.FirstOrDefault(a => a.IsDel == 0 && a.Account == account);
			}
		}

		/// <summary>
		/// 用户是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public bool MemberExist(string account, string password)
		{
			if (string.IsNullOrEmpty(account)) return false;

			using (var db = new NPiculetEntities()) {
				string pwd = CreateEncodePassword(account, password);
				return db.sys_member_info.Any(a => a.IsDel == 0 && a.Account == account && a.Password == pwd);
			}
		}

		/// <summary>
		/// 用户是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public bool MemberExist(string account)
		{
			if (string.IsNullOrEmpty(account)) return false;

			using (var db = new NPiculetEntities()) {
				return db.sys_member_info.Any(a => a.IsDel == 0 && a.Account == account);
			}
		}

		/// <summary>
		/// 获取用户列表。
		/// </summary>
		/// <returns></returns>
		public DataTable GetMemberList(int curPage, int pageSize, string whereString = null, string orderBy = null)
		{
			string sql = @"SELECT * FROM (SELECT u.Id, u.UserSn, u.Account, u.Password, u.Name
	, u.LoginTimes, u.LastLoginDate, u.LastLogoutDate, u.PassQuestion, u.PassAnswer
	, u.FailedCount, u.FailedDate, u.IsEnabled, u.IsDel, u.Status, u.OrderBy, u.Creator, u.CreateDate, u.UpdateDate
	, u.BindSource, u.BindDate
	, d.Nickname, d.Birthday, d.Sex, d.Email, d.Mobile, d.Address, d.MemberCard
	, d.IdCard, d.Education, d.QQ, d.Weixin, d.Weibo, d.Interest, d.PointCurrent, d.PointTotal
	, d.Exp, d.Cash, d.Cost, d.HeadIcon, d.Memo
FROM sys_member_info u
	LEFT JOIN sys_member_data d ON u.Account=d.UserAccount AND d.IsDel=0
WHERE u.IsDel=0) t";
			if (!string.IsNullOrEmpty(whereString)) sql += " WHERE " + whereString;
			sql += (string.IsNullOrEmpty(orderBy)) ? " ORDER BY OrderBy, Id DESC" : " ORDER BY " + orderBy;
			sql += " LIMIT " + pageSize + " OFFSET " + ((curPage - 1) * pageSize);

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取用户头像
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		public string GetMemberHeadIcon(int memberId)
		{
			using (var db = new NPiculetEntities()) {
				var member = db.sys_member_data.FirstOrDefault(a => a.UserId == memberId);
				return (member != null) ? member.HeadIcon : "";
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
				var member = db.sys_member_info.FirstOrDefault(a => a.IsDel == 0 && a.Account == account);
				if (member != null) {
					member.Password = CreateEncodePassword(account, newpass);
					return db.SaveChanges() > 0;
				}
			}
			return false;
		}

		/// <summary>
		/// 获取会员的最大排序
		/// </summary>
		/// <returns></returns>
		public int GetMaxOrderBy()
		{
			string sql = "SELECT MAX(OrderBy) FROM sys_member_info";
			return DbHelper.QueryValue<int>(sql);
		}

		/// <summary>
		/// 获取用户资料
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public sys_member_data GetMemberData(int userId)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_member_data.FirstOrDefault(a => a.IsDel == 0 && a.UserId == userId);
			}
		}
	}
}
