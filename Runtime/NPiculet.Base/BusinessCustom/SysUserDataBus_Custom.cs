using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysUserDataBus
	{
		/// <summary>
		/// 根据用户帐号获取用户资料
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public SysUserData GetUserData(string account)
		{
			return this.QueryModel("UserAccount='" + account + "'");
		}
	}
}
