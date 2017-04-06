using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class SysMenuBus
	{
		/// <summary>
		/// 获取主菜单
		/// </summary>
		/// <returns></returns>
		public List<SysMenu> GetMainMenu(int userId) {
			string whereString = "RootId=0 and IsDel=0 and IsEnabled=1";
			if (userId > 2)
				whereString += @" and (
  EXISTS(SELECT * FROM npc_sys_authorization WHERE npc_sys_menu.Id=FunctionId AND TargetType='User' AND FunctionType='Menu' AND TargetId=" + userId + @")
  or EXISTS(SELECT * FROM npc_sys_authorization A
   INNER JOIN npc_sys_link_user_role R ON A.TargetId=R.RoleId AND R.UserId=" + userId + @"
  WHERE npc_sys_menu.Id=FunctionId AND A.TargetType='Role' AND A.FunctionType='Menu')
 )";
			return this.QueryList(whereString, "OrderBy");
		}

		/// <summary>
		/// 获取子菜单
		/// </summary>
		/// <param name="parentId"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public DataTable GetSubMenu(int parentId, int userId) {
			string whereString = "IsExternal=0 and IsEnabled=1 and IsDel=0 and RootId=" + parentId;
			if (userId > 2)
				whereString += @" and (
  EXISTS(SELECT * FROM npc_sys_authorization WHERE npc_sys_menu.Id=FunctionId AND TargetType='User' AND FunctionType='Menu' AND TargetId=" + userId + @")
  or EXISTS(SELECT * FROM npc_sys_authorization A
   INNER JOIN npc_sys_link_user_role R ON A.TargetId=R.RoleId AND R.UserId=" + userId + @"
  WHERE npc_sys_menu.Id=FunctionId AND A.TargetType='Role' AND A.FunctionType='Menu')
 )";
			return this.Query(whereString, "OrderBy");
		}

		/// <summary>
		/// 获取菜单项
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public SysMenu GetMenuItem(int id)
		{
			return this.QueryModel("Id=" + id);
		}

		/// <summary>
		/// 修复菜单项路径及层次信息。
		/// </summary>
		public int FixMenuPath()
		{
			var data = this.QueryList("IsDel=0");
			var updateList = new List<SysMenu>();
			//修复第一层
			var root = (from a in data where a.ParentId == 0 select a);
			for (int i = 0; i < root.Count(); i++) {
				var menu = root.ElementAt(i);
				if (!(menu.Depth == 0 && menu.RootId == 0 && menu.Path == "")) {
					menu.Depth = 0;
					menu.RootId = 0;
					menu.Path = "";

					updateList.Add(menu);
				}
				//检查下层菜单
				FixSubMenuPath(data, menu, updateList);
			}
			this.UpdateList(updateList);
			return updateList.Count;
		}

		private static void FixSubMenuPath(List<SysMenu> data, SysMenu parent, List<SysMenu> updateList)
		{
			var layer = (from a in data where a.ParentId == parent.Id select a);
			foreach (SysMenu menu in layer) {
				string curPath = parent.Path + "/" + parent.Id;
				int curRootId = parent.RootId == 0 ? parent.Id : parent.RootId;
				int curDepth = parent.Depth.Value + 1;

				if (!(menu.Depth == curDepth && menu.RootId == curRootId && menu.Path == curPath)) {
					menu.Depth = curDepth;
					menu.RootId = curRootId;
					menu.Path = curPath;

					updateList.Add(menu);
				}
				FixSubMenuPath(data, menu, updateList);
			}
		}

	}
}
