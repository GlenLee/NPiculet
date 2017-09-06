using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

namespace NPiculet.Cms.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class CmsContentBus : IBusiness
	{
		/// <summary>
		/// 获取组对象
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public cms_content_group GetGroup(Expression<Func<cms_content_group, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_content_group.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取页对象
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public cms_content_page GetPage(Expression<Func<cms_content_page, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_content_page.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取组对象
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		public cms_content_group GetGroup(int groupId) {
			using (var db = new NPiculetEntities()) {
				return db.cms_content_group.FirstOrDefault(a => a.Id == groupId);
			}
		}

		/// <summary>
		/// 获取组对象
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public cms_content_group GetGroup(string groupCode)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_content_group.FirstOrDefault(a => a.GroupCode == groupCode);
			}
		}

		/// <summary>
		/// 获取所有组列表
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<cms_content_group> GetGroupList(Expression<Func<cms_content_group, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				if (predicate == null)
					return db.cms_content_group.OrderBy(a => a.OrderBy).ToList();
				else
					return db.cms_content_group.Where(predicate).OrderBy(a => a.OrderBy).ToList();
			}
		}

		/// <summary>
		/// 获取子列表
		/// </summary>
		/// <param name="parentGroupCode"></param>
		/// <returns></returns>
		public List<cms_content_group> GetSubGroupList(string parentGroupCode)
		{
			using (var db = new NPiculetEntities()) {
				return (from g in db.cms_content_group
					join p in db.cms_content_group on g.ParentId equals p.Id
					where p.GroupCode == parentGroupCode
					orderby g.OrderBy
					select g).ToList();
			}
		}

		/// <summary>
		/// 获取单内容页
		/// </summary>
		/// <param name="groupCode"></param>
		/// <returns></returns>
		public cms_content_page GetContentPage(string groupCode)
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_content_page.FirstOrDefault(a => a.GroupCode == groupCode);
			}
		}

		/// <summary>
		/// 保存组数据
		/// </summary>
		/// <param name="data"></param>
		public void SaveGroup(cms_content_group data)
		{
			using (var db = new NPiculetEntities()) {
				db.cms_content_group.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 删除组数据
		/// </summary>
		/// <param name="groupId"></param>
		public void DeleteGroup(int groupId)
		{
			if (groupId <= 0) return;

			using (var db = new NPiculetEntities()) {
				var g = db.cms_content_group.FirstOrDefault(a => a.Id == groupId);
				if (g != null) {
					db.cms_content_group.Remove(g);
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 删除页数据
		/// </summary>
		/// <param name="pageId"></param>
		public void DeletePage(int pageId)
		{
			if (pageId <= 0) return;

			using (var db = new NPiculetEntities()) {
				var p = db.cms_content_page.FirstOrDefault(a => a.Id == pageId);
				if (p != null) {
					db.cms_content_page.Remove(p);
					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// 保存内容页
		/// </summary>
		/// <param name="data"></param>
		public void SavePage(cms_content_page data)
		{
			using (var db = new NPiculetEntities()) {
				db.cms_content_page.AddOrUpdate(data);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// 获取页面列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<cms_content_page> GetPageList(out int count, int curPage, int pageSize, Expression<Func<cms_content_page, bool>> predicate = null) {
			using (var db = new NPiculetEntities()) {
				if (predicate == null) {
					var query = db.cms_content_page;
					count = query.Count();
					return query.OrderBy(a => a.OrderBy).ThenByDescending(a => a.CreateDate).Pagination(curPage, pageSize).ToList();
				} else {
					var query = db.cms_content_page.Where(predicate);
					count = query.Count();
					return query.OrderBy(a => a.OrderBy).ThenByDescending(a => a.CreateDate).Pagination(curPage, pageSize).ToList();
				}
			}
		}

		/// <summary>
		/// 发布页面
		/// </summary>
		/// <param name="id"></param>
		public void PublishPage(int id) {
			using (var db = new NPiculetEntities()) {
				var p = db.cms_content_page.FirstOrDefault(a => a.Id == id);
				if (p != null) {
					p.IsEnabled = 1;
					db.SaveChanges();
				}
			}
		}
	}
}
