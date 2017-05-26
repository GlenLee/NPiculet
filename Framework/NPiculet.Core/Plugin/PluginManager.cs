using System;
using System.Text;
using NPiculet.Error;

namespace NPiculet.Plugin
{
	public static class PluginManager
	{
		private static readonly object _syncObject = new object();

		private static PluginRegistry _pluginRegistry = null;

		static PluginManager()
		{
			if (_pluginRegistry == null) {
				lock (_syncObject) {
					if (_pluginRegistry == null) {
						//初始化插件注册表
						_pluginRegistry = new PluginRegistry();
					}
				}
			}
		}

		/// <summary>
		/// 是否包含插件。
		/// </summary>
		/// <param name="parentOrSame">插件的接口、父类或同级类</param>
		/// <returns></returns>
		internal static bool ContainsPlugin(Type parentOrSame)
		{
			return _pluginRegistry.ContainsPlugin(parentOrSame);
		}

		/// <summary>
		/// 获取插件。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetPlugin<T>() where T : class, IPlugin
		{
			Type type = typeof(T);
			IPlugin plugin = _pluginRegistry.GetPlugin(type);
			if (plugin == null) {
				throw new PluginException("未找到插件：" + type.ToString());
			}

			return (T)plugin;
		}
	}
}