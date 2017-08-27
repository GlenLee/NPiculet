using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;

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
		/// <returns></returns>
		public List<cms_content_group> GetGroupList()
		{
			using (var db = new NPiculetEntities()) {
				return db.cms_content_group.OrderBy(a => a.OrderBy).ToList();
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
	}
}
