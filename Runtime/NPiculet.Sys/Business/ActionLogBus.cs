using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Base.EF;
using NPiculet.Logic.Sys;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 操作日志业务
	/// </summary>
	public partial class ActionLogBus : IBusiness
	{
		/// <summary>
		/// 创建一个新日志对象
		/// </summary>
		/// <returns></returns>
		public sys_action_log NewLog()
		{
			return new sys_action_log { ActionType = "Custom" };
		}

		/// <summary>
		/// 创建一个新日志明细对象
		/// </summary>
		/// <returns></returns>
		public sys_action_detail NewDetail()
		{
			return new sys_action_detail();
		}

	}
}
