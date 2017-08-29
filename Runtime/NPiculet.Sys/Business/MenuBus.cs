using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Base.EF;
using NPiculet.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class MenuBus : IBusiness
	{
		/// <summary>
		/// 获取菜单列表
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<sys_menu> GetMenuList(Expression<Func<sys_menu, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_menu.Where(predicate).OrderBy(a => a.OrderBy).ToList();
			}
		}

		/// <summary>
		/// 获取菜单
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public sys_menu GetMenu(Expression<Func<sys_menu, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_menu.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 获取主菜单
		/// </summary>
		/// <returns></returns>
		public DataTable GetMainMenu(int userId) {
			string sql = "SELECT * FROM sys_menu WHERE RootId=0 and IsDel=0 and IsEnabled=1";
			if (userId > 2)
				sql += @" and (
  EXISTS(SELECT * FROM sys_authorization WHERE sys_menu.Id=FunctionId AND TargetType='User' AND FunctionType='Menu' AND TargetId=" + userId + @")
  or EXISTS(SELECT * FROM sys_authorization A
   INNER JOIN sys_link_user_role R ON A.TargetId=R.RoleId AND R.UserId=" + userId + @"
  WHERE sys_menu.Id=FunctionId AND A.TargetType='Role' AND A.FunctionType='Menu')
 )";
			sql += " ORDER BY OrderBy";
			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取子菜单
		/// </summary>
		/// <param name="parentId"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public DataTable GetSubMenu(int parentId, int userId) {
			string sql = "SELECT * FROM sys_menu WHERE IsExternal=0 and IsEnabled=1 and IsDel=0 and RootId=" + parentId;
			if (userId > 2)
				sql += @" and (
  EXISTS(SELECT * FROM sys_authorization WHERE sys_menu.Id=FunctionId AND TargetType='User' AND FunctionType='Menu' AND TargetId=" + userId + @")
  or EXISTS(SELECT * FROM sys_authorization A
   INNER JOIN sys_link_user_role R ON A.TargetId=R.RoleId AND R.UserId=" + userId + @"
  WHERE sys_menu.Id=FunctionId AND A.TargetType='Role' AND A.FunctionType='Menu')
 )";
			sql += " ORDER BY OrderBy";
			return DbHelper.Query(sql);
		}

		/// <summary>
		/// 获取菜单项
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public sys_menu GetMenuItem(int id)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_menu.FirstOrDefault(a => a.IsDel == 0 && a.Id == id);
			}
		}

		/// <summary>
		/// 修复菜单项路径及层次信息。
		/// </summary>
		public int FixMenuPath()
		{
			using (var db = new NPiculetEntities()) {
				var data = db.sys_menu.Where(a => a.IsDel == 0).ToList();
				//修复第一层
				var root = (from a in data where a.ParentId == 0 select a).ToList();
				for (int i = 0; i < root.Count(); i++) {
					var menu = root.ElementAt(i);
					if (!(menu.Depth == 0 && menu.RootId == 0 && menu.Path == "")) {
						menu.Depth = 0;
						menu.RootId = 0;
						menu.Path = "";
					}
					//检查下层菜单
					FixSubMenuPath(data, menu);
				}
				return db.SaveChanges();
			}
		}

		private static void FixSubMenuPath(List<sys_menu> data, sys_menu parent)
		{
			var layer = (from a in data where a.ParentId == parent.Id select a);
			foreach (sys_menu menu in layer) {
				string curPath = parent.Path + "/" + parent.Id;
				int curRootId = parent.RootId == 0 ? parent.Id : parent.RootId;
				int curDepth = (parent.Depth?? 0) + 1;

				if (!(menu.Depth == curDepth && menu.RootId == curRootId && menu.Path == curPath)) {
					menu.Depth = curDepth;
					menu.RootId = curRootId;
					menu.Path = curPath;
				}
				FixSubMenuPath(data, menu);
			}
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="data"></param>
		public void Save(sys_menu data) {
			using (var db = new NPiculetEntities()) {
				db.sys_menu.AddOrUpdate(data);
				db.SaveChanges();
			}
		}
	}
}
