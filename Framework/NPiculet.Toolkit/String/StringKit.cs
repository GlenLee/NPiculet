using System;
using System.Text;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 随机数字及随机字符串管理器。
	/// </summary>
	public partial class StringKit
	{
		/// <summary>
		/// 根据字节流生成对应的16进制码字符串。
		/// </summary>
		/// <param name="bytes">字节流</param>
		/// <returns></returns>
		public static string GetHex(byte[] bytes)
		{
			string str = "";
			for (int i = 0; i < bytes.Length; i++) {
				byte b = bytes[i];
				str += b.ToString("X2");
			}
			return str;
		}
	}
}
