using System.Data.Entity.Validation;

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
	}
}