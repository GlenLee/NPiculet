using System;
using System.IO;

namespace NPiculet.Toolkit
{
	public static class SystemKit
	{
		/// <summary>
		/// �ж������Ƿ�Ϊ Nullable ���͡�
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool IsNullableType(Type type)
		{
			return (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
		}

		/// <summary>
		/// ��ȡӦ�ó������·����
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
		/// ת��Ϊ����·����
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string ConvertToFullPath(string path)
		{
			if (path == null) {
				throw new ArgumentNullException("path");
			}
			//���������ַ��Ϳ�ʼ
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
					//������ļ�����ȡ�ļ���Ŀ¼
					Uri applicationBaseDirectoryUri = new Uri(applicationBaseDirectory);
					if (applicationBaseDirectoryUri.IsFile) {
						baseDirectory = applicationBaseDirectoryUri.LocalPath;
					}
				}
			} catch { }

			if (baseDirectory != null && baseDirectory.Length > 0) {
				//���·������������Ŀ¼
				return Path.GetFullPath(Path.Combine(baseDirectory, path));
			}
			return Path.GetFullPath(path);
		}

	}
}