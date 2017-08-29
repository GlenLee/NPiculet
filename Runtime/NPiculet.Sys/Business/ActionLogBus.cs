using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Base.EF;
using NPiculet.Logic.Sys;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 操作日志业务
	/// </summary>
	public partial class ActionLogBus : IBusiness
	{
		/// <summary>
		/// 创建一个新日志对象
		/// </summary>
		/// <returns></returns>
		public sys_action_log NewLog()
		{
			return new sys_action_log { ActionType = "Custom" };
		}

		/// <summary>
		/// 创建一个新日志明细对象
		/// </summary>
		/// <returns></returns>
		public sys_action_detail NewDetail()
		{
			return new sys_action_detail();
		}

		/// <summary>
		/// 获取记录列表
		/// </summary>
		/// <param name="count"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<sys_action_log> GetRecordList(out int count, int curPage, int pageSize, Expression<Func<sys_action_log, bool>> predicate = null) {
			using (var db = new NPiculetEntities()) {
				var query = db.sys_action_log;

				count = query.Count();

				if (predicate == null) {
					return query.OrderByDescending(a => a.Date).Pagination(curPage, pageSize).ToList();
				} else {
					return query.Where(predicate).OrderByDescending(a => a.Date).Pagination(curPage, pageSize).ToList();
				}
			}
		}
	}
}
