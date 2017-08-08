using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Cache;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class BasDictItemBus {

		/// <summary>
		/// 获取可用字典项列表
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public List<BasDictItem> GetActiveItemList(string groupCode)
		{
			BasDictItemBus bus = new BasDictItemBus();
			return bus.QueryList("IsEnabled=1 and GroupCode='" + groupCode + "'", "OrderBy");
		}

		/// <summary>
		/// 获取字典列表
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public List<BasDictItem> GetDictItemList(string groupCode)
		{
			BasDictItemBus bus = new BasDictItemBus();
			return bus.QueryList("GroupCode='" + groupCode + "'", "OrderBy");
		}

		/// <summary>
		/// 获取字典项
		/// </summary>
		/// <param name="groupCode"></param>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		public BasDictItem GetDictItem(string groupCode, string itemCode)
		{
			BasDictItemBus bus = new BasDictItemBus();
			return bus.QueryModel("GroupCode='" + groupCode + "' and Code='" + itemCode + "'");
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

			//string whereString = "";
			//if (!string.IsNullOrEmpty(groupCode)) whereString = string.Format("`GroupCode`='{0}'", groupCode);
			//if (!string.IsNullOrEmpty(keywords)) {
			//	if (!string.IsNullOrEmpty(whereString)) whereString += " AND ";
			//	whereString += string.Format("(i.Name LIKE '%{0}%' OR i.Code LIKE '%{0}%')", keywords);
			//}

			//string sql = @"SELECT i.*, g.`Name` AS `GroupName` FROM dict_item i INNER JOIN dict_group g ON i.`GroupCode`=g.`Code`";
			//if (!string.IsNullOrEmpty(whereString)) sql += " WHERE " + whereString;
			//sql += " ORDER BY i.`GroupCode`, i.`CreateDate`";
			//sql += " LIMIT " + pageSize + " OFFSET " + (pageSize * (curPage - 1));

			//return this.QuerySql(sql);
		}

	}
}
