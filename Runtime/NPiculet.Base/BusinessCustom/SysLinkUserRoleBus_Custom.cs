using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysLinkUserRoleBus
	{
		/// <summary>
		/// 更新用户所属角色信息
		/// </summary>
		/// <param name="urList"></param>
		/// <param name="userId"></param>
		public void UpdateUserOrgList(List<SysLinkUserRole> urList, int userId)
		{
			this.Delete(string.Format(" UserId={0}", userId));
			this.InsertList(urList);
		}

	}
}
