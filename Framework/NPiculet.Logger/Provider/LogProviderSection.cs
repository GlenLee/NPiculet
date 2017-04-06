using System.Configuration;

namespace NPiculet.Log
{
	public class LogProviderSection : ConfigurationSection
	{
		/// <summary>
		/// ��ȡĬ���ṩ�����ơ�
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
		/// ��ȡע����ṩ�����ϡ�
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