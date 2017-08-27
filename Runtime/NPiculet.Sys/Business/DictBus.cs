using System;
using System.Collections.Generic;
using System.Linq;
using NPiculet.Base.EF;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class DictBus : IBusiness
	{

		/// <summary>
		/// 获取可用字典项列表
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public List<bas_dict_item> GetActiveItemList(string groupCode)
		{
			using (var db = new NPiculetEntities()) {
				return db.bas_dict_item.Where(a => a.IsEnabled == 1 && a.GroupCode == groupCode).OrderBy(a => a.OrderBy).ToList();
			}
		}

		/// <summary>
		/// 获取字典列表
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public List<bas_dict_item> GetDictItemList(string groupCode)
		{
			using (var db = new NPiculetEntities()) {
				return db.bas_dict_item.Where(a => a.GroupCode == groupCode).OrderBy(a => a.OrderBy).ToList();
			}
		}

		/// <summary>
		/// 获取字典项
		/// </summary>
		/// <param name="groupCode"></param>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		public bas_dict_item GetDictItem(string groupCode, string itemCode)
		{
			using (var db = new NPiculetEntities()) {
				return db.bas_dict_item.FirstOrDefault(a => a.Code == itemCode && a.GroupCode == groupCode);
			}
		}

		/// <summary>
		/// 获取字典项数据
		/// </summary>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="groupCode"></param>
		/// <param name="keywords"></param>
		/// <returns></returns>
		public object GetDictItemData(int curPage, int pageSize, string groupCode, string keywords) {

			NPiculetEntities db = new NPiculetEntities();
			var query = (from i in db.bas_dict_item
				join g in db.bas_dict_group on i.GroupCode equals g.Code
				orderby i.GroupCode, i.OrderBy, i.CreateDate
				select new { i.Id, i.GroupCode, i.Code, i.Name, i.Value, i.OrderBy, i.IsEnabled, i.CreateDate, GroupName = g.Name });

			query = query.WhereIf(!string.IsNullOrEmpty(groupCode), q => q.GroupCode == groupCode);
			query = query.WhereIf(!string.IsNullOrEmpty(keywords), q => q.Name.Contains(keywords) || q.Code.Contains(keywords));

			return query.Pagination(curPage, pageSize).ToList();
		}

	}
}
