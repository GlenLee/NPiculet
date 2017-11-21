using System.Linq.Expressions;

namespace System.Linq
{
	/// <summary>
	/// 扩展 IQueryable 对象
	/// </summary>
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
			return query.Skip(pageSize * (curPage - 1)).Take(pageSize);
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

		/// <summary>
		/// 组合Where条件，避免 Expression 组合时报错（解决直接组合查询条件时报“Invoke异常”或“找不到变量异常”）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IQueryable<T> SafeWhere<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
		{
			return predicate == null ? query : query.Where(predicate.Compile()).AsQueryable();
		}

	}
}
