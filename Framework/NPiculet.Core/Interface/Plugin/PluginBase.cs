using System;

namespace NPiculet.Plugin
{
	public abstract class PluginBase : IPlugin
	{
		private PluginStatus _pluginStatus = PluginStatus.Wait;

		private readonly IPluginDescriptor _descriptor;

		public PluginBase(IPluginDescriptor descr)
		{
			_descriptor = descr;
		}

		/// <summary>
		/// 状态
		/// </summary>
		public PluginStatus PluginStatus
		{
			get { return _pluginStatus; }
			set { _pluginStatus = value; }
		}

		/// <summary>
		/// 获取描述对象
		/// </summary>
		/// <returns></returns>
		public IPluginDescriptor GetDescriptor()
		{
			return _descriptor;
		}

		/// <summary>
		/// 启动
		/// </summary>
		public void Start()
		{
			if (this.PluginStatus == PluginStatus.Wait || this.PluginStatus == PluginStatus.Stop) {
				DoStart();
				this.PluginStatus = PluginStatus.Active;
			} else if (this.PluginStatus == PluginStatus.Bad) {
				throw new PluginException("插件损坏，可能是缺少依赖项！");
			}
		}

		/// <summary>
		/// 停止
		/// </summary>
		public void Stop()
		{
			if (this.PluginStatus == PluginStatus.Active) {
				DoStop();
				this.PluginStatus = PluginStatus.Stop;
			}
		}

		/// <summary>
		/// 启动插件，做初始化操作。
		/// </summary>
		protected virtual void DoStart()
		{ }

		/// <summary>
		/// 停止插件，做释放资源操作。
		/// </summary>
		protected virtual void DoStop()
		{ }

		/// <summary>
		/// 是否在活动。
		/// </summary>
		/// <returns></returns>
		public bool IsActive()
		{
			return (this.PluginStatus == PluginStatus.Active);
		}
	}
}