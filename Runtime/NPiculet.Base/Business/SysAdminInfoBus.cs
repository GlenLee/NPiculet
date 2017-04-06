using System;
using System.Collections.Generic;
using System.Data;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Business
{
	public partial class SysAdminInfoBus : DataDao, IBusiness<SysAdminInfo>
	{
		#region 获取数据访问类

		/// <summary>
		/// 创建数据实体类
		/// </summary>
		/// <returns></returns>
		public SysAdminInfo CreateModel()
		{
			return new SysAdminInfo();
		}

		#endregion

		#region 常用数据维护方法

		/// <summary>
		/// 新增数据
		/// </summary>
		/// <param name="model">实体类</param>
		/// <returns></returns>
		public bool Insert(SysAdminInfo model)
		{
			return base.Insert(model);
		}
		
		/// <summary>
		/// 新增数据，并返回自增ID
		/// </summary>
		/// <param name="model">实体类</param>
		/// <returns></returns>
		public int InsertIdentity(SysAdminInfo model)
		{
			return base.InsertIdentity(model);
		}

		/// <summary>
		/// 更新数据
		/// </summary>
		/// <param name="model">实体类</param>
		/// <param name="whereString">可选，更新条件</param>
		/// <returns></returns>
		public bool Update(SysAdminInfo model, string whereString = null)
		{
			return base.Update(model, whereString);
		}

		/// <summary>
		/// 删除数据
		/// </summary>
		/// <param name="whereString">查询条件</param>
		/// <returns></returns>
		public bool Delete(string whereString)
		{
			return base.Delete<SysAdminInfo>(whereString);
		}

		#endregion

		#region 常用查询方法

		/// <summary>
		/// 查询数据表
		/// </summary>
		/// <param name="whereString">查询条件</param>
		/// <param name="orderBy">排序字段</param>
		/// <returns></returns>
		public DataTable Query(string whereString = null, string orderBy = null)
		{
			return base.Query<SysAdminInfo>(whereString, orderBy);
		}

		/// <summary>
		/// 查询数据表，并分页返回
		/// </summary>
		/// <param name="curPage">当前页码</param>
		/// <param name="pageSize">分页大小</param>
		/// <param name="whereString">查询条件</param>
		/// <param name="orderBy">排序字段</param>
		/// <returns></returns>
		public DataTable Query(int curPage, int pageSize = 10, string whereString = null, string orderBy = null)
		{
			return base.Query<SysAdminInfo>(curPage, pageSize, whereString, orderBy);
		}

		/// <summary>
		/// 查询实体类
		/// </summary>
		/// <param name="whereString">查询条件</param>
		/// <returns></returns>
		public SysAdminInfo QueryModel(string whereString)
		{
			return base.QueryModel<SysAdminInfo>(whereString);
		}

		/// <summary>
		/// 查询实体类列表
		/// </summary>
		/// <param name="curPage">当前页码</param>
		/// <param name="pageSize">每页大小</param>
		/// <param name="whereString">查询条件</param>
		/// <param name="orderBy">排序</param>
		/// <returns></returns>
		public List<SysAdminInfo> QueryList(int curPage, int pageSize = 10, string whereString = null, string orderBy = null)
		{
			return base.QueryList<SysAdminInfo>(curPage, pageSize, whereString, orderBy);
		}

		/// <summary>
		/// 查询实体类列表
		/// </summary>
		/// <param name="whereString">查询条件</param>
		/// <param name="orderBy">排序</param>
		/// <returns></returns>
		public List<SysAdminInfo> QueryList(string whereString, string orderBy = null)
		{
			return base.QueryList<SysAdminInfo>(whereString, orderBy);
		}

		/// <summary>
		/// 记录统计
		/// </summary>
		/// <param name="whereString">查询条件</param>
		/// <returns></returns>
		public int RecordCount(string whereString)
		{
			return base.RecordCount<SysAdminInfo>(whereString);
		}

		#endregion
	}
}
