using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Web;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Sys
{
	/// <summary>
	/// 系统配置管理器
	/// </summary>
	public class ConfigManager
	{
		public static ConcurrentDictionary<string, string> configs = null;

		/// <summary>
		/// 初始化缓存
		/// </summary>
		private void InitCache()
		{
			if (configs == null) {
				configs = new ConcurrentDictionary<string, string>();

				var bus = new SysConfigBus();
				var dt = bus.Query();
				foreach (DataRow dr in dt.Rows) {
					var code = Convert.ToString(dr["ConfigCode"]);
					var val = Convert.ToString(dr["ConfigValue"]);
					if (!configs.ContainsKey(code))
						configs[code] = val;
				}
			}
		}

		/// <summary>
		/// 获取配置列表
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> GetWebConfigList()
		{
			InitCache();
			var dict = new Dictionary<string, string>();
			foreach (var item in configs) {
				dict.Add(item.Key, item.Value);
			}
			return dict;
		}

		/// <summary>
		/// 获取配置项
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public string GetWebConfig(string code)
		{
			InitCache();
			if (configs.ContainsKey(code)) {
				return configs[code];
			} else {
				return "";
			}
		}

		/// <summary>
		/// 清除配置项
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public void RemoveWebConfig(string code)
		{
			InitCache();
			if (configs.ContainsKey(code)) {
				string val;
				configs.TryRemove(code, out val);
			}
		}

		/// <summary>
		/// 清除配置缓存
		/// </summary>
		public void ClearWebConfigCache()
		{
			if (configs != null) {
				configs.Clear();
				configs = null;
				InitCache();
			}
		}
	}
}