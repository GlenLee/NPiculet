using System;

namespace NPiculet.Error
{
	/// <summary>
	/// 框架核心抛出的异常。
	/// </summary>
	public class CoreException : Exception
	{
		public string ClassName { get; set; }
		public object Sender { get; set; }

		public CoreException(string message = null, Exception innerException = null, object target = null)
			: base(message, innerException)
		{
			this.ClassName = target == null ? "" : target.GetType().ToString();
		}
	}
}