using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysMemberInfoBus
	{
		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public SysMemberInfo GetMemberInfo(string account)
		{
			return this.QueryModel("Account='" + account + "'");
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
			string where = "Account='" + account + "' and Password='" + password + "'";
			return this.RecordCount(where) > 0;
		}

		/// <summary>
		/// 用户是否存在。
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public bool MemberExist(string account)
		{
			if (string.IsNullOrEmpty(account)) return false;
			string where = "Account='" + account + "'";
			return this.RecordCount(where) > 0;
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
FROM npc_sys_member_info u
	LEFT JOIN npc_sys_member_data d ON u.Account=d.UserAccount AND d.IsDel=0
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
		public int GetMemberCount(string whereString)
		{
			return this.RecordCount(whereString);
		}

		/// <summary>
		/// 获取用户头像
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		public string GetMemberHeadIcon(int memberId)
		{
			SysMemberDataBus bus = new SysMemberDataBus();
			var member = bus.QueryModel("UserId=" + memberId);
			return member == null ? "" : member.HeadIcon;
		}

		/// <summary>
		/// 更改用户密码。
		/// </summary>
		/// <param name="account"></param>
		/// <param name="newpass"></param>
		public bool ChangePassword(string account, string newpass)
		{
			return this.Update(new SysMemberInfo() { Password = newpass }, "Account='" + account + "'");
		}

		public int GetMaxOrderBy()
		{
			string sql = "SELECT MAX(OrderBy) FROM npc_sys_member_info";
			object val = DbHelper.QueryValue(sql);
			return val == DBNull.Value ? 0 : (int)val;
		}

	}
}
