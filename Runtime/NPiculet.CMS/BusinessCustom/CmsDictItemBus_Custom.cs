using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class CmsDictItemBus {
		/// <summary>
		/// 获取字典列表
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public List<CmsDictItem> GetDictItemList(string groupCode) {
			CmsDictItemBus bus = new CmsDictItemBus();
			return bus.QueryList("GroupCode='" + groupCode + "'");
		}

		/// <summary>
		/// 获取字典项
		/// </summary>
		/// <param name="groupCode"></param>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		public CmsDictItem GetDictItem(string groupCode, string itemCode) {
			CmsDictItemBus bus = new CmsDictItemBus();
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
		public DataTable GetDictItemData(int curPage, int pageSize, string groupCode, string keywords) {
			string whereString = "";
			if (!string.IsNullOrEmpty(groupCode)) whereString = string.Format("`GroupCode`='{0}'", groupCode);
			if (!string.IsNullOrEmpty(keywords)) {
				if (!string.IsNullOrEmpty(whereString)) whereString += " AND ";
				whereString += string.Format("(i.Name LIKE '%{0}%' OR i.Code LIKE '%{0}%')", keywords);
			}

			string sql = @"SELECT i.*, g.`Name` AS `GroupName` FROM dict_item i INNER JOIN dict_group g ON i.`GroupCode`=g.`Code`";
			if (!string.IsNullOrEmpty(whereString)) sql += " WHERE " + whereString;
			sql += " ORDER BY i.`GroupCode`, i.`CreateDate`";
			sql += " LIMIT " + pageSize + " OFFSET " + (pageSize * (curPage - 1));

			return this.QuerySql(sql);
		}

	}
}
