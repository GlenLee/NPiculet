using System;
using System.IO;

namespace NPiculet.Plugin
{
	/// <summary>
	/// 插件系统抛出的异常。
	/// </summary>
	public class PluginException : Exception
	{
		private IPlugin _plugin;

		public PluginException(string message = null, Exception innerException = null, IPlugin plugin = null)
			: base(message, innerException)
		{
			_plugin = plugin;
		}
	}
}