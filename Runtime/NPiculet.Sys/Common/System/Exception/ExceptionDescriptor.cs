using System;
using NPiculet.Plugin;

namespace NPiculet.Logic.Sys
{
	public class ExceptionDescriptor : IPluginDescriptor
	{
		public string GetId()
		{
			return "ExceptionModule";
		}

		public Type GetPluginType()
		{
			return typeof(ExceptionManager);
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