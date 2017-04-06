using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysActionLogBus
	{
		/// <summary>
		/// 创建一个新日志对象
		/// </summary>
		/// <returns></returns>
		public SysActionLog NewLog()
		{
			return new SysActionLog() { ActionType = "Custom" };
		}

		/// <summary>
		/// 创建一个新日志明细对象
		/// </summary>
		/// <returns></returns>
		public SysActionDetail NewDetail()
		{
			return new SysActionDetail();
		}

	}
}
