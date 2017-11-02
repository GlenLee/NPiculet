using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
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
		/// 获取会员信息
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		public sys_member_info GetMemberInfo(int memberId)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_member_info.FirstOrDefault(a => a.IsDel == 0 && a.Id == memberId);
			}
		}

		/// <summary>
		/// 获取会员信息
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
		/// 会员是否存在。
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
		/// 会员是否存在。
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
		/// 会员是否存在。
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public bool MemberInfoExist(Expression<Func<sys_member_info, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_member_info.Any(predicate);
			}
		}

		/// <summary>
		/// 会员是否存在。
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public bool MemberDataExist(Expression<Func<sys_member_data, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_member_data.Any(predicate);
			}
		}

		/// <summary>
		/// 获取会员列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="whereString"></param>
		/// <param name="orderBy"></param>
		/// <returns></returns>
		public DataTable GetMemberList(out int count, int curPage, int pageSize, string whereString = null, string orderBy = null)
		{
			string sql = @"SELECT * FROM (SELECT u.Id, u.MemberSn, u.Account, u.Password, u.Name, u.MemberLevel
	, u.LoginTimes, u.LastLoginDate, u.LastLogoutDate, u.PassQuestion, u.PassAnswer
	, u.FailedCount, u.FailedDate, u.IsEnabled, u.IsDel, u.Status, u.OrderBy, u.Creator, u.CreateDate, u.UpdateDate
	, u.BindSource, u.BindDate
	, d.Nickname, d.Birthday, d.Sex, d.Email, d.Mobile, d.Address, d.MemberCard
	, d.IdCard, d.Education, d.QQ, d.Weixin, d.Weibo, d.Interest, d.PointCurrent, d.PointTotal
	, d.Exp, d.Cash, d.Cost, d.HeadIcon, d.Memo
FROM sys_member_info u
	LEFT JOIN sys_member_data d ON u.Id=d.MemberId AND d.IsDel=0
WHERE u.IsDel=0) t";
			if (!string.IsNullOrEmpty(whereString)) sql += " WHERE " + whereString;
			sql += (string.IsNullOrEmpty(orderBy)) ? " ORDER BY OrderBy, Id DESC" : " ORDER BY " + orderBy;
			sql += " LIMIT " + pageSize + " OFFSET " + ((curPage - 1) * pageSize);

			count = DbHelper.QueryValue<int>("SELECT COUNT(*) FROM sys_member_info WHERE " + whereString);

			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取会员头像
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		public string GetMemberHeadIcon(int memberId)
		{
			using (var db = new NPiculetEntities()) {
				var member = db.sys_member_data.FirstOrDefault(a => a.MemberId == memberId);
				return (member != null) ? member.HeadIcon : "";
			}
		}

		/// <summary>
		/// 更改会员密码。
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
		/// 获取会员资料
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		public sys_member_data GetMemberData(int memberId)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_member_data.FirstOrDefault(a => a.IsDel == 0 && a.MemberId == memberId);
			}
		}

		/// <summary>
		/// 删除会员（标记删除）
		/// </summary>
		/// <param name="memberId"></param>
		public void Delete(int memberId)
		{
			using (var db = new NPiculetEntities()) {
				var member = db.sys_member_info.FirstOrDefault(a => a.Id == memberId);
				if (member != null) {
					member.IsDel = 1;

					var data = db.sys_member_data.FirstOrDefault(a => a.MemberId == memberId);
					if (data != null)
						data.IsDel = 1;

					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 更新状态
		/// </summary>
		/// <param name="memberId"></param>
		/// <param name="status"></param>
		public void UpdateStatus(int memberId, string status)
		{
			using (var db = new NPiculetEntities()) {
				var member = db.sys_member_info.FirstOrDefault(a => a.Id == memberId);
				if (member != null) {
					member.Status = status;
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 保存会员
		/// </summary>
		/// <param name="member"></param>
		public void SaveMember(sys_member_info member)
		{
			using (var db = new NPiculetEntities()) {
				db.sys_member_info.AddOrUpdate(member);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 保存会员资料
		/// </summary>
		/// <param name="data"></param>
		public void SaveMemberData(sys_member_data data)
		{
			using (var db = new NPiculetEntities()) {
				db.sys_member_data.AddOrUpdate(data);
				db.SaveChanges();
			}
		}
	}
}
