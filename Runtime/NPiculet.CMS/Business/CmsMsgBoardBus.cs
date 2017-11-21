using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Base.EF;
using NPiculet.Data;
using NPiculet.Logic.Business;

namespace NPiculet.Cms.Business
{
	public class CmsMsgBoardBus : IBusiness
	{

		/// <summary>
		/// 保存留言板组
		/// </summary>
		/// <param name="data"></param>
		public void SaveGroup(cms_msgboard_group data)
		{
			using (var db = new NPiculetEntities()) {
				db.cms_msgboard_group.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 保存广告
		/// </summary>
		/// <param name="gid"></param>
		public void DeleteGroup(int gid)
		{
			using (var db = new NPiculetEntities()) {
				var adv = db.cms_msgboard_group.FirstOrDefault(a => a.Id == gid);
				if (adv != null) {
					db.cms_msgboard_group.Remove(adv);

					db.cms_msgboard_record.Where(a => a.GroupCode == adv.Code).DeleteFromQuery();

					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 保存留言
		/// </summary>
		/// <param name="data"></param>
		public void SaveRecord(cms_msgboard_record data)
		{
			using (var db = new NPiculetEntities()) {
				db.cms_msgboard_record.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 删除留言
		/// </summary>
		/// <param name="rid"></param>
		public void DeleteRecord(int rid)
		{
			using (var db = new NPiculetEntities()) {
				var data = db.cms_msgboard_record.FirstOrDefault(a => a.Id == rid);
				if (data != null) {
					db.cms_msgboard_record.Remove(data);
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 获取留言板组
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public cms_msgboard_group GetGroup(Expression<Func<cms_msgboard_group, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_msgboard_group.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取留言
		/// </summary>
		/// <param name="rid"></param>
		/// <returns></returns>
		public cms_msgboard_record GetRecord(int rid)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_msgboard_record.FirstOrDefault(a => a.Id == rid);
			}
		}

		/// <summary>
		/// 获取留言组列表
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<cms_msgboard_group> GetGroupList(Expression<Func<cms_msgboard_group, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.cms_msgboard_group select a);
				if (predicate != null)
					query = db.cms_msgboard_group.Where(predicate);

				return query.ToList();
			}
		}

		/// <summary>
		/// 获取留言组列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<cms_msgboard_group> GetGroupList(out int count, int curPage, int pageSize, Expression<Func<cms_msgboard_group, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.cms_msgboard_group select a);
				if (predicate != null)
					query = db.cms_msgboard_group.Where(predicate);

				count = query.Count();

				return query.OrderByDescending(a => a.CreateDate).Pagination(curPage, pageSize).ToList();
			}
		}

		/// <summary>
		/// 获取留言列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<cms_msgboard_record> GetRecordList(out int count, int curPage, int pageSize, Expression<Func<cms_msgboard_record, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.cms_msgboard_record select a);
				if (predicate != null)
					query = db.cms_msgboard_record.Where(predicate);

				count = query.Count();

				return query.OrderByDescending(a => a.CreateDate).Pagination(curPage, pageSize).ToList();
			}
		}

		/// <summary>
		/// 更新留言组字段配置信息
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="config"></param>
		public void UpdateGroupConfig(Expression<Func<cms_msgboard_group, bool>> predicate, string config)
		{
			using (var db = new NPiculetEntities()) {
				var query = db.cms_msgboard_group.Where(predicate);
				query.UpdateFromQuery(a => new cms_msgboard_group() { Config = config });
			}
		}
	}
}
