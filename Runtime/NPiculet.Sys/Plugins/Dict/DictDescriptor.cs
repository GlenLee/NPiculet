using System;
using NPiculet.Plugin;

namespace NPiculet.Logic.Plugin
{
	public class DictDescriptor : IPluginDescriptor
	{
		public string GetId()
		{
			return "DictModule";
		}

		public Type GetPluginType()
		{
			return typeof (DictManager);
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