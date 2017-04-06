using System;
using NPiculet.Plugin;

namespace NPiculet.Logic.Sys
{
	public class LoggerDescriptor : IPluginDescriptor
	{
		public string GetId()
		{
			return "LoggerModule";
		}

		public Type GetPluginType()
		{
			return typeof(LoggerManager);
		}

		public Type[] GetDependPlugins()
		{
			return new Type[0];
		}

		public string GetResourceString(string key)
		{
			return null;
		}

		public string GetPluginPath()
		{
			return null;
		}
	}
}