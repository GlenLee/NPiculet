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
	public class CmsAdvBus : IBusiness
	{

		/// <summary>
		/// 保存广告
		/// </summary>
		/// <param name="data"></param>
		public void Save(cms_adv_info data)
		{
			using (var db = new NPiculetEntities()) {
				db.cms_adv_info.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 保存广告
		/// </summary>
		/// <param name="aid"></param>
		public void Delete(int aid)
		{
			using (var db = new NPiculetEntities()) {
				var adv = db.cms_adv_info.FirstOrDefault(a => a.Id == aid);
				if (adv != null) {
					db.cms_adv_info.Remove(adv);
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 获取广告信息
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public cms_adv_info GetAdv(Expression<Func<cms_adv_info, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_adv_info.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取广告信息
		/// </summary>
		/// <param name="advId"></param>
		/// <returns></returns>
		public cms_adv_info GetAdv(int advId)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_adv_info.FirstOrDefault(a => a.Id == advId);
			}
		}

		/// <summary>
		/// 根据类型获取单个广告
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		public cms_adv_info GetSingleAd(string position)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_adv_info.FirstOrDefault(a => a.IsEnabled == 1 && a.Position == position);
			}
		}

		/// <summary>
		/// 获取广告列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<cms_adv_info> GetAdList(out int count, int curPage, int pageSize, Expression<Func<cms_adv_info, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				var query = (from a in db.cms_adv_info select a);
				if (predicate != null)
					query = db.cms_adv_info.Where(predicate);

				count = query.Count();

				return query.OrderByDescending(a => a.CreateDate).ThenBy(a => a.OrderBy).Pagination(curPage, pageSize).ToList();
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
