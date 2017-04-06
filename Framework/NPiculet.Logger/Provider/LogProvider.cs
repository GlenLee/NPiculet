using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Provider;
using System.IO;

namespace NPiculet.Log
{
	public abstract class LogProvider : ProviderBase
	{
		/// <summary>
		/// 提供器名称
		/// </summary>
		public override string Name { get { return "LogProvider"; } }

		/// <summary>
		/// 日志储存地址
		/// </summary>
		public abstract string Address { get; set; }

		public abstract void Error(string msg, Exception ex);
		public abstract void Info(string msg);
		public abstract void Debug(string msg);

		#region 判断日志是否需要记录

		private readonly List<LogType> _types = new List<LogType>();

		/// <summary>
		/// 初始化日志供应器
		/// </summary>
		protected LogProvider()
		{
			string types = ConfigurationManager.AppSettings["LogType"];
			if (string.IsNullOrWhiteSpace(types)) {
				_types.Add(LogType.Info);
				_types.Add(LogType.Error);
				_types.Add(LogType.Debug);
			} else {
				foreach (var type in types.Split('|')) {
					_types.Add(ConvertValue<LogType>(type, LogType.Info));
				}
			}
		}

		/// <summary>
		/// 检查是否日志类型需要记录
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public virtual bool CheckEnabled(LogType type)
		{
			return _types.Contains(type);
		}

		/// <summary>
		/// 判断类似是否为 Nullable 类型。
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool IsNullableType(Type type)
		{
			return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
		}

		/// <summary>
		/// 将值转为指定的数据类型。
		/// </summary>
		/// <param name="val">需要转换类型的值</param>
		/// <param name="defaultValue">数据类型</param>
		public static T ConvertValue<T>(object val, T defaultValue)
		{
			Type type = typeof(T);
			try {
				if (IsNullableType(type)) {
					var nullableConverter = new NullableConverter(type);
					return (T)nullableConverter.ConvertFrom(val);
				} else if (type == typeof(Guid)) {
					var guidConverter = new GuidConverter();
					return (T)guidConverter.ConvertFrom(val);
				} else if (type.IsEnum) {
					return (T)Enum.Parse(type, val.ToString());
				} else if (type.IsValueType || type == typeof(String)) {
					return (T)(val == null ? Activator.CreateInstance(type) : Convert.ChangeType(val, type));
				} else {
					return (T)Convert.ChangeType(val, type);
				}
			} catch {
				//return (T)(type.IsValueType ? Activator.CreateInstance(type) : null);
				return defaultValue;
			}
		}

		#endregion

		/// <summary>
		/// 获取应用程序基础路径。
		/// </summary>
		public static string ApplicationBaseDirectory
		{
			get
			{
#if NETCF
				return System.IO.Path.GetDirectoryName(SystemInfo.EntryAssemblyLocation) + System.IO.Path.DirectorySeparatorChar;
#else
				return AppDomain.CurrentDomain.BaseDirectory;
#endif
			}
		}

		/// <summary>
		/// 转换为完整路径。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string ConvertToFullPath(string path)
		{
			if (path == null) {
				throw new ArgumentNullException("path");
			}
			//处理特殊字符和开始
			if (path.Length > 0) {
				if (path[0] == '~') {
					path = path.Replace("~/", "").Replace("~\\", "");
				} else if (path[0] == '/' || path[0] == '\\') {
					path = path.Substring(1, path.Length - 1);
				}
			}

			string baseDirectory = "";
			try {
				string applicationBaseDirectory = ApplicationBaseDirectory;
				if (applicationBaseDirectory != null) {
					//如果是文件，则取文件的目录
					Uri applicationBaseDirectoryUri = new Uri(applicationBaseDirectory);
					if (applicationBaseDirectoryUri.IsFile) {
						baseDirectory = applicationBaseDirectoryUri.LocalPath;
					}
				}
			} catch { }

			if (baseDirectory.Length > 0) {
				//组合路径，返回完整目录
				return Path.GetFullPath(Path.Combine(baseDirectory, path));
			}
			return Path.GetFullPath(path);
		}

	}
}