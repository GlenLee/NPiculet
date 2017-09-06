using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Toolkit;

namespace System.Data.Entity
{
	/// <summary>
	/// 实例扩展方法
	/// </summary>
	public static class EntityExtension {

		#region DbContext 相关扩展

		/// <summary>
		/// 保存实例，根据主键自动判断更新或新增，并自动调用 SaveChanges()
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="db"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static bool Save<TEntity>(this DbContext db, TEntity entity) where TEntity : class
		{
			try {
				db.Set<TEntity>().AddOrUpdate(entity);
				return db.SaveChanges() > 0;
			} catch (DbEntityValidationException ex) {
				throw new Exception(LinQKit.GetErrorMessage(ex), ex);
			}
		}

		/// <summary>
		/// 删除实例，并自动调用 SaveChanges()
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="db"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static bool Delete<TEntity>(this DbContext db, Expression<Func<TEntity, bool>> predicate) where TEntity : class
		{
			var data = db.Set<TEntity>().Where(predicate);
			db.Set<TEntity>().RemoveRange(data);
			return db.SaveChanges() > 0;
		}

		/// <summary>
		/// 执行SQL语句
		/// </summary>
		/// <param name="db"></param>
		/// <param name="sql"></param>
		/// <param name="parms"></param>
		/// <returns></returns>
		public static bool ExecuteSql(this DbContext db, string sql, params object[] parms)
		{
			return db.Database.ExecuteSqlCommand(sql, parms) > 0;
		}

		/// <summary>
		/// 执行SQL语句，并返回集合
		/// </summary>
		/// <param name="db"></param>
		/// <param name="sql"></param>
		/// <param name="parms"></param>
		/// <returns></returns>
		public static IEnumerable<TEntity> QuerySql<TEntity>(this DbContext db, string sql, params object[] parms)
		{
			return db.Database.SqlQuery<TEntity>(sql, parms);
		}

		#endregion
	}
}