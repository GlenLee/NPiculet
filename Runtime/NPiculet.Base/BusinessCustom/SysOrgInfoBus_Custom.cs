using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysOrgInfoBus
	{
		/// <summary>
		/// 获取组织机构信息。
		/// </summary>
		/// <param name="orgId"></param>
		/// <returns></returns>
		public SysOrgInfo GetOrgInfo(int orgId)
		{
			return this.QueryModel("Id=" + orgId);
		}

		/// <summary>
		/// 根据用户ID获取组织机构信息
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<SysOrgInfo> GetUserOrg(int userId)
		{
			string sql = @"SELECT o.* FROM npc_sys_org_info o
	INNER JOIN sys_link_user_org l ON o.Id=l.OrgId
WHERE l.UserId=" + userId;
			return this.QueryList(sql);
		}

	}
}
