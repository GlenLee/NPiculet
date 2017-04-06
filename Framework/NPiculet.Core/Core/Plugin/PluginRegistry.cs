using System.Collections.Generic;
using System;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Linq;
using System.Reflection;
using NPiculet.Core;

namespace NPiculet.Plugin
{
	/// <summary>
	/// 插件注册表，负责管理插件的注册。
	/// </summary>
	public class PluginRegistry
	{
		private static readonly Dictionary<Type, IPlugin> _plugins = new Dictionary<Type, IPlugin>();

		internal PluginRegistry()
		{
			//检查插件是否已注册成功
			//根据依赖关系检查插件状态
			InitPlugins();
		}

		/// <summary>
		/// 初始化插件列表。
		/// </summary>
		private void InitPlugins()
		{
			//从配置文件读取插件列表导入注册表
			lock (_plugins) {
				//获取插件配置
				PluginConfigSection section = ConfigurationManager.GetSection("NPiculet/plugins") as PluginConfigSection;
				if (section != null) {
					var keys = section.PluginConfigCollection.Settings.Keys;
					foreach (string key in keys) {
						string typeName = section.PluginConfigCollection.Settings[key];

						//检查默认插件
						Type type = Type.GetType(typeName);
						if (type != null) {
							//激活插件
							IPluginDescriptor descr = Activator.CreateInstance(type) as IPluginDescriptor;
							ActivatePlugin(descr);
						} else {
							throw new PluginException(typeName + "插件对象不存在！");
						}
					}
				}
			}
		}

		/// <summary>
		/// 检查依赖插件。
		/// </summary>
		/// <param name="descr"></param>
		private bool CheckPrerequisites(IPluginDescriptor descr)
		{
			Type[] plugins = descr.GetDependPlugins();
			foreach (Type type in plugins) {
				if (!ContainsPlugin(type)) return false;
			}
			return true;
		}

		private IPlugin ActivatePlugin(IPluginDescriptor descr)
		{
			IPlugin plugin = null;
			lock (_plugins) {
				//实例化插件
				Type type = descr.GetPluginType();
				if (type != null) {
					plugin = Activator.CreateInstance(type, descr) as IPlugin;

					//检查依赖插件是否已存在
					if (plugin != null) {

						//注册插件
						Register(plugin);

						if (CheckPrerequisites(descr)) {
							plugin.Start();
						} else {
							plugin.PluginStatus = PluginStatus.Bad;
							throw new PluginException("插件缺少依赖项，无法激活！", null, plugin);
						}
					}
				}
			}

			return plugin;
		}

		/// <summary>
		/// 注册插件
		/// </summary>
		/// <param name="plugin"></param>
		internal void Register(IPlugin plugin)
		{
			lock (_plugins) {
				_plugins.Add(plugin.GetType(), plugin);
			}
		}

		/// <summary>
		/// 移除插件
		/// </summary>
		/// <param name="type"></param>
		internal void Remove(Type type)
		{
			lock (_plugins) {
				_plugins.Remove(type);
			}
		}

		internal void Remove(IPlugin plugin)
		{
			Remove(plugin.GetType());
		}

		/// <summary>
		/// 是否包含插件。
		/// </summary>
		/// <param name="parentOrSame">插件的接口、父类型或同类型</param>
		/// <returns></returns>
		internal bool ContainsPlugin(Type parentOrSame)
		{
			lock (_plugins) {
				var keys = _plugins.Keys;
				foreach (Type type in keys) {
					if (type.IsAssignableFrom(parentOrSame))
						return true;
				}
				return false;
			}
		}

		internal bool ContainsPlugin(IPlugin plugin)
		{
			return ContainsPlugin(plugin.GetType());
		}

		/// <summary>
		/// 根据接口、父类型或同类型获取插件.
		/// </summary>
		/// <param name="parentOrSame">插件的接口、父类型或同类型</param>
		/// <returns></returns>
		internal IPlugin GetPlugin(Type parentOrSame)
		{
			lock (_plugins) {
				var keys = _plugins.Keys;
				foreach (Type type in keys) {
					if (parentOrSame.IsAssignableFrom(type))
						return _plugins[type];
				}
				return null;
			}
		}
	}
}