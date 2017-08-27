using System;
using NPiculet.Log;
using NPiculet.Plugin;

namespace NPiculet.Logic.Plugin
{
	public class ExceptionManager : PluginBase, IExceptionModule
	{
		#region 初始化

		public ExceptionManager(IPluginDescriptor descr)
			: base(descr)
		{ }

		protected override void DoStart()
		{ }

		protected override void DoStop()
		{ }

		#endregion

		public void ProcessException(string msg, Exception ex)
		{
			Logger.Error(msg, ex);
		}
	}
}