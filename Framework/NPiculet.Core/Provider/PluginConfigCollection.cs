using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;

namespace NPiculet.Core
{
	public class PluginConfigCollection : ConfigurationElementCollection
	{
		private IDictionary<string, string> _settings;

		protected override ConfigurationElement CreateNewElement()
		{
			return new PluginConfig();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			PluginConfig el = (PluginConfig)element;

			return el.Name;
		}

		protected override string ElementName
		{
			get {
				return base.ElementName;
			}
		}

		public IDictionary<string, string> Settings
		{
			get {
				if (_settings == null) {
					_settings = new Dictionary<string, string>();
					foreach (PluginConfig e in this) {
						_settings.Add(e.Name, e.Type);
					}
				}
				return _settings;
			}
		}

		public new string this[string key]
		{
			get {
				string t;
				if (_settings.TryGetValue(key, out t)) {
					return t;
				} else {
					throw new ArgumentException("没有对'" + key + "'节点进行配置。");
				}
			}
		}
	}
}