using System.Configuration;

namespace NPiculet.Core
{
	public class PluginConfigSection : ConfigurationSection
	{
		/// <summary>  
		/// 对应 PluginConfigSection 节点下的 PluginConfig 子节点  
		/// </summary>  
		[ConfigurationProperty("pluginConfig", IsRequired = true)]
		public PluginConfigCollection PluginConfigCollection
		{
			get { return (PluginConfigCollection)base["pluginConfig"]; }
		}
	}
}