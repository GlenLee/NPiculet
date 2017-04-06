using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Provider;
using System.IO;
using System.Linq;
using System.Text;
using NPiculet.Log;

namespace NPiculet.Plugin
{
	public class PluginConfig : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("type", IsRequired = true)]
		public string Type
		{
			get { return (string)this["type"]; }
			set { this["type"] = value; }
		}

		[ConfigurationProperty("description", IsRequired = true)]
		public string Description
		{
			get { return (string)this["description"]; }
			set { this["description"] = value; }
		}
	}
}
