namespace NPiculet.Plugin
{
	/// <summary>
	/// 插件状态
	/// </summary>
	public enum PluginStatus
	{
		/// <summary>
		/// 等待
		/// </summary>
		Wait = 0,

		/// <summary>
		/// 已激活
		/// </summary>
		Active = 1,

		/// <summary>
		/// 已停止，等待回收
		/// </summary>
		Stop = 2,

		/// <summary>
		/// 已损坏
		/// </summary>
		Bad = 3
	}
}