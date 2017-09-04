using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Base.EF;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class DictBus : IBusiness
	{
		/// <summary>
		/// 保存字典项
		/// </summary>
		/// <param name="data"></param>
		public void SaveItem(bas_dict_item data)
		{
			using (var db = new NPiculetEntities()) {
				db.bas_dict_item.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 保存字典项
		/// </summary>
		/// <param name="itemId"></param>
		public void DeleteItem(int itemId)
		{
			using (var db = new NPiculetEntities()) {
				db.Delete<bas_dict_item>(a => a.Id == itemId);
			}
		}

		/// <summary>
		/// 保存字典组
		/// </summary>
		/// <param name="data"></param>
		public void SaveGroup(bas_dict_group data)
		{
			using (var db = new NPiculetEntities()) {
				db.bas_dict_group.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 保存字典组
		/// </summary>
		/// <param name="data"></param>
		public void DeleteGroup(bas_dict_group data)
		{
			using (var db = new NPiculetEntities()) {
				db.bas_dict_group.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 获取字典组信息
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public bas_dict_group GetDictGroup(Expression<Func<bas_dict_group, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.bas_dict_group.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取字典组列表
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<bas_dict_group> GetDictGroupList(Expression<Func<bas_dict_group, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				if (predicate == null) {
					return db.bas_dict_group.OrderBy(a => a.OrderBy).ThenByDescending(a => a.CreateDate).ToList();
				} else {
					return db.bas_dict_group.Where(predicate).OrderBy(a => a.OrderBy).ThenByDescending(a => a.CreateDate).ToList();
				}
			}
		}

		/// <summary>
		/// 获取字典项
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public bas_dict_item GetDictItem(Expression<Func<bas_dict_item, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.bas_dict_item.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取字典列表
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<bas_dict_item> GetDictItemList(Expression<Func<bas_dict_item, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				if (predicate == null)
					return db.bas_dict_item.OrderBy(a => a.OrderBy).ToList();
				else
					return db.bas_dict_item.Where(predicate).OrderBy(a => a.OrderBy).ToList();
			}
		}

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
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="groupCode"></param>
		/// <param name="keywords"></param>
		/// <returns></returns>
		public object GetDictItemData(out int count, int curPage, int pageSize, string groupCode, string keywords) {

			using (NPiculetEntities db = new NPiculetEntities()) {
				var query = (from i in db.bas_dict_item
					join g in db.bas_dict_group on i.GroupCode equals g.Code
					orderby i.GroupCode, i.OrderBy, i.CreateDate
					select new {i.Id, i.GroupCode, i.Code, i.Name, i.Value, i.OrderBy, i.IsEnabled, i.CreateDate, GroupName = g.Name});

				query = query.WhereIf(!string.IsNullOrEmpty(groupCode), q => q.GroupCode == groupCode);
				query = query.WhereIf(!string.IsNullOrEmpty(keywords), q => q.Name.Contains(keywords) || q.Code.Contains(keywords));

				count = query.Count();

				return query.Pagination(curPage, pageSize).ToList();
			}
		}

		/// <summary>
		/// 更新子表组编码
		/// </summary>
		/// <param name="oldCode"></param>
		/// <param name="newCode"></param>
		public void UpdateDictItemCode(string oldCode, string newCode)
		{
			using (var db = new NPiculetEntities()) {
				var items = db.bas_dict_item.Where(a => a.GroupCode == oldCode).ToList();
				foreach (var item in items) {
					item.GroupCode = newCode;
				}
				db.SaveBatch(items);
			}
		}
	}
}
