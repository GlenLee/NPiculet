using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;

namespace NPiculet.Log
{
	public static class Logger
	{
		#region 初始化

		private static readonly object SyncRoot = new object();
		private static LogProvider _provider;
		//private static LogProviderCollection _providers;

		private static LogProvider Provider
		{
			get
			{
				LoadProviders();
				return _provider;
			}
		}

		/// <summary>
		/// 从 web.config 中获取提供器集合。
		/// </summary>
		private static void LoadProviders()
		{
			if (_provider == null) {
				lock (SyncRoot) {
					//重新检测变量是否被其他线程实例化。
					if (_provider == null) {
						//获取配置节引用。
						var section = (LogProviderSection)ConfigurationManager.GetSection("NPiculet/logProvider");

						//载入默认提供器。
						//_providers = new LogProviderCollection();

						foreach (ProviderSettings settings in section.Providers) {
							//只生产默认提供器的实例
							if (settings.Name == section.DefaultProvider) {
								var instance = Activator.CreateInstance(Type.GetType(settings.Type)) as LogProvider;
								if (instance == null) {
									throw new Exception("在 Web.config 文件没有正确配置 Provider 属性！");
								}
								//_providers.Add(instance);
								//初始化参数
								instance.Address = settings.Parameters["address"] ?? "";

								_provider = instance;
							}
						}

						//_provider = _providers[section.DefaultProvider];

						if (_provider == null) {
							throw new ProviderException("默认的 Provider 没有找到，请检查 Web.config 的配置！");
						}
					}
				}
			}
		}

		#endregion

		#region 记录日志

		/// <summary>
		/// 记录异常日志，延迟执行消息产生方法，解决已关闭的日志类型消也会耗性能
		/// </summary>
		/// <param name="fn"></param>
		/// <param name="ex"></param>
		public static void Error(Func<string> fn, Exception ex)
		{
			if (Provider.CheckEnabled(LogType.Info)) {
				Provider.Error(fn(), ex);
			}
		}

		/// <summary>
		/// 记录信息日志，延迟执行消息产生方法，解决已关闭的日志类型消也会耗性能
		/// </summary>
		/// <param name="fn"></param>
		public static void Info(Func<string> fn)
		{
			if (Provider.CheckEnabled(LogType.Info)) {
				Provider.Info(fn());
			}
		}

		/// <summary>
		/// 记录调试日志，延迟执行消息产生方法，解决已关闭的日志类型消也会耗性能
		/// </summary>
		/// <param name="fn"></param>
		public static void Debug(Func<string> fn)
		{
			if (Provider.CheckEnabled(LogType.Info)) {
				Provider.Debug(fn());
			}
		}

		/// <summary>
		/// 记录异常日志
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="ex"></param>
		public static void Error(string msg, Exception ex)
		{
			Provider.Error(msg, ex);
		}

		/// <summary>
		/// 记录信息日志
		/// </summary>
		/// <param name="msg"></param>
		public static void Info(string msg)
		{
			Provider.Info(msg);
		}

		/// <summary>
		/// 记录调试日志
		/// </summary>
		/// <param name="msg"></param>
		public static void Debug(string msg)
		{
			Provider.Debug(msg);
		}

		#endregion

	}
}