using System;
using System.Configuration.Provider;

namespace NPiculet.Log
{
	public class LogProviderCollection : ProviderCollection
	{
		/// <summary>
		/// 根据提供器名称获取实例。
		/// </summary>
		/// <param name="name">提供器名称</param>
		public new LogProvider this[string name]
		{
			get {
				return (LogProvider)base[name];
			}
		}

		/// <summary>
		/// 增加一个提供器到集合。
		/// </summary>
		/// <param name="provider"></param>
		public override void Add(ProviderBase provider)
		{
			if (provider == null) {
				throw new ArgumentNullException("provider");
			}
			if (!(provider is LogProvider)) {
				throw new ArgumentException("错误的 Provider 类型！", "provider");
			}
			base.Add(provider);
		}
	}
}