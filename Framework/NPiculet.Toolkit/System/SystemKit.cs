using System;
using System.IO;

namespace NPiculet.Toolkit
{
	public static class SystemKit
	{
		/// <summary>
		/// 判断类似是否为 Nullable 类型。
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool IsNullableType(Type type)
		{
			return (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
		}

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

			if (baseDirectory != null && baseDirectory.Length > 0) {
				//组合路径，返回完整目录
				return Path.GetFullPath(Path.Combine(baseDirectory, path));
			}
			return Path.GetFullPath(path);
		}

	}
}