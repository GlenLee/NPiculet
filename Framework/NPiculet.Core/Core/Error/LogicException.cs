using System;

namespace NPiculet.Error
{
	/// <summary>
	/// 框架内业务逻辑处理时抛出的异常。
	/// </summary>
	public class LogicException : Exception
	{
		public object State { get; set; }

		public LogicException(string message = null, Exception innerException = null, object state = null)
			: base(message, innerException)
		{
			this.State = state;
		}
	}
}