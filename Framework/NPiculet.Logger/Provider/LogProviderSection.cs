using System.Configuration;

namespace NPiculet.Log
{
	public class LogProviderSection : ConfigurationSection
	{
		/// <summary>
		/// 获取默认提供器名称。
		/// </summary>
		[StringValidator(MinLength = 1)]
		[ConfigurationProperty("defaultProvider", DefaultValue = "FileLogProvider")]
		public string DefaultProvider
		{
			get {
				return (string)base["defaultProvider"];
			}
			set {
				base["defaultProvider"] = value;
			}
		}

		/// <summary>
		/// 获取注册的提供器集合。
		/// </summary>
		[ConfigurationProperty("providers")]
		public ProviderSettingsCollection Providers
		{
			get {
				return (ProviderSettingsCollection)base["providers"];
			}
		}
	}
}