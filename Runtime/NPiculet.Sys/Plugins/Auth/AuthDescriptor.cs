using System;
using NPiculet.Plugin;

namespace NPiculet.Logic.Plugin
{
	public class AuthDescriptor : IPluginDescriptor
	{
		public string GetId()
		{
			return "AuthModule";
		}

		public Type GetPluginType()
		{
			return typeof(AuthManager);
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