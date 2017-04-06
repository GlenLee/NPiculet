using System;

namespace NPiculet.Logic.Sys
{
	public interface IExceptionModule
	{
		/// <summary>
		/// 统一处理异常。
		/// </summary>
		/// <param name="msg">附加信息</param>
		/// <param name="ex">异常</param>
		void ProcessException(string msg, Exception ex);
	}
}