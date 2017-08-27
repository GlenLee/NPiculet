using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Sys
{
	/// <summary>
	/// 系统配置管理器
	/// </summary>
	public class ConfigManager
	{
		/// <summary>
		/// 所有配置项
		/// </summary>
		private static ConcurrentDictionary<string, string> _configs = null;

		/// <summary>
		/// 初始化缓存
		/// </summary>
		private void InitCache()
		{
			if (_configs == null) {
				_configs = new ConcurrentDictionary<string, string>();

				using (var db = new NPiculetEntities()) {
					var rows = db.sys_config.ToList();
					foreach (var dr in rows) {
						var code = Convert.ToString(dr.ConfigCode);
						var val = Convert.ToString(dr.ConfigValue);
						if (!_configs.ContainsKey(code))
							_configs[code] = val;
					}
				}
			}
		}

		/// <summary>
		/// 获取配置列表
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> GetConfigList()
		{
			InitCache();
			var dict = new Dictionary<string, string>();
			foreach (var item in _configs) {
				dict.Add(item.Key, item.Value);
			}
			return dict;
		}

		/// <summary>
		/// 获取配置项
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public string GetConfig(string code)
		{
			InitCache();
			if (_configs.ContainsKey(code)) {
				return _configs[code];
			} else {
				return "";
			}
		}

		/// <summary>
		/// 获取配置项，并直接转换为需要的类型
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public T GetConfig<T>(string code)
		{
			InitCache();
			if (_configs.ContainsKey(code)) {
				return ConvertKit.ConvertValue<T>(_configs[code]);
			} else {
				return default(T);
			}
		}

		/// <summary>
		/// 清除配置项
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public void RemoveConfig(string code)
		{
			InitCache();
			if (_configs.ContainsKey(code)) {
				string val;
				_configs.TryRemove(code, out val);
			}
		}

		/// <summary>
		/// 清除配置缓存
		/// </summary>
		public void ClearConfigCache()
		{
			if (_configs != null) {
				_configs.Clear();
				_configs = null;
			}
		}
	}
}