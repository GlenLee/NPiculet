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
	public partial class CmsContentPageBus
	{
		/// <summary>
		/// 获取单内容页
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public CmsContentPage GetContentPage(string groupCode) {
			var param = DbHelper.CreateParameter("GroupCode", "MemberProtocol");
			return QueryModel<CmsContentPage>("GroupCode=@GroupCode", param);
		}
	}
}
