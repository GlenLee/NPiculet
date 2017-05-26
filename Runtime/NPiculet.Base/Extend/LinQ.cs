using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Linq
{
	public static class IQueryableExtension
	{
		/// <summary>
		/// 返回分页的LinQ集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int curPage, int pageSize)
		{
			return query.Skip(pageSize*(curPage - 1)).Take(pageSize);
		}

		/// <summary>
		/// 返回带判断的LinQ集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="condition"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
		{
			return condition ? query.Where(predicate): query;
		}
	}
}
