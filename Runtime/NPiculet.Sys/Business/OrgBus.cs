using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class OrgBus : IBusiness
	{
		/// <summary>
		/// 获取组织机构信息。
		/// </summary>
		/// <param name="orgId"></param>
		/// <returns></returns>
		public sys_org_info GetOrgInfo(int orgId)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_org_info.FirstOrDefault(a => a.IsDel == 0 && a.Id == orgId);
			}
		}

		/// <summary>
		/// 根据用户ID获取组织机构信息
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<sys_org_info> GetUserOrg(int userId)
		{
			using (var db = new NPiculetEntities()) {
				return (from o in db.sys_org_info
					join l in db.sys_link_user_org on o.Id equals l.OrgId
					where o.IsDel == 0 && l.UserId == userId
					select o).ToList();
			}
		}

		/// <summary>
		/// 获取组织机构树
		/// </summary>
		/// <returns></returns>
		public DataTable GetOrgTreeData()
		{
			string sql = @"SELECT o.* FROM sys_org_info o WHERE IsDel=0";
			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取组织机构列表
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<sys_org_info> GetOrgList(Func<sys_org_info, bool> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				if (predicate == null) {
					return db.sys_org_info.ToList();
				} else {
					return db.sys_org_info.Where(predicate).ToList();
				}
			}
		}
	}
}
