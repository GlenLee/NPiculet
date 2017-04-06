using System;

namespace NPiculet.Plugin
{
	public interface IPluginDescriptor
	{
		/// <summary>
		/// 获取插件ID。
		/// </summary>
		/// <returns></returns>
		string GetId();

		/// <summary>
		/// 获取插件类型。
		/// </summary>
		/// <returns></returns>
		Type GetPluginType();

		/// <summary>
		/// 获取依赖插件数组。
		/// </summary>
		/// <returns></returns>
		Type[] GetDependPlugins();

		/// <summary>
		/// 获取资源。
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		string GetResourceString(string key);

		/// <summary>
		/// 获取插件路径。
		/// </summary>
		/// <returns></returns>
		string GetPluginPath();
	}
}