using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class CmsAdvInfoBus
	{
		/// <summary>
		/// 根据类型获取单个广告
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		public cms_adv_info GetSingleAd(string position) {
			using (var db = new NPiculetEntities()) {
				return db.cms_adv_info.FirstOrDefault(a => a.IsEnabled == 1 && a.Position == position);
			}
		}

		/// <summary>
		/// 根据类型获取广告集合
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		public List<cms_adv_info> GetAdList(string position)
		{
			using (var db = new NPiculetEntities()) {
				return (from a in db.cms_adv_info
					where a.IsEnabled == 1 && a.Position == position
						select a).ToList();
			}
		}
	}
}
