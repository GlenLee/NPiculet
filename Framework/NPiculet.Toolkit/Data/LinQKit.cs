using System;
using System.Data.Entity.Validation;
using System.Linq.Expressions;

namespace NPiculet.Toolkit
{
	public class LinQKit
	{
		/// <summary>
		/// 根据 LinQ 返回的错误，读取错误的具体提示信息
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static string GetErrorMessage(DbEntityValidationException ex)
		{
			string msg = string.Empty;
			foreach (DbEntityValidationResult result in ex.EntityValidationErrors) {
				foreach (DbValidationError err in result.ValidationErrors) {
					msg += err.ErrorMessage;
				}
			}
			return msg;
		}

		/// <summary>
		/// 创建一个查询条件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> CreateWhere<T>(Expression<Func<T, bool>> predicate)
		{
			return predicate;
		}

		/// <summary>
		/// 创建一个总是返回 true 的条件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Expression<Func<T, bool>> True<T>() {
			return a => true;
		}


		/// <summary>
		/// 创建一个总是返回 false 的条件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Expression<Func<T, bool>> False<T>()
		{
			return a => false;
		}
	}
}