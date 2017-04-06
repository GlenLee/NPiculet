using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class CmsContentGroupBus
	{
		/// <summary>
		/// 获取组对象
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		public CmsContentGroup GetGroup(int groupId) {
			CmsContentGroupBus bus = new CmsContentGroupBus();
			return bus.QueryModel("Id=" + groupId);
		}

	}
}
