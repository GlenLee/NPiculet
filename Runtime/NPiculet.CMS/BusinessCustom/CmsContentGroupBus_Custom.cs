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
			return this.QueryModel("Id=" + groupId);
		}

		/// <summary>
		/// 获取组对象
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public CmsContentGroup GetGroup(string groupCode)
		{
			return this.QueryModel("GroupCode='" + groupCode + "'");
		}

		/// <summary>
		/// 获取子列表
		/// </summary>
		/// <param name="parentGroupCode"></param>
		/// <returns></returns>
		public List<CmsContentGroup> GetSubGroupList(string parentGroupCode)
		{
			return this.QueryList("ParentId IN (SELECT Id FROM cms_content_group WHERE GroupCode='" + parentGroupCode + "')", "OrderBy");
		}
	}
}
