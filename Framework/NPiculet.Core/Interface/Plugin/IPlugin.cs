namespace NPiculet.Plugin
{
	/// <summary>
	/// 插件接口。
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// 插件状态。
		/// </summary>
		PluginStatus PluginStatus { get; set; }

		/// <summary>
		/// 获取描述对象。
		/// </summary>
		/// <returns></returns>
		IPluginDescriptor GetDescriptor();

		/// <summary>
		/// 开始插件。
		/// </summary>
		void Start();

		/// <summary>
		/// 停止插件。
		/// </summary>
		void Stop();
	}
}