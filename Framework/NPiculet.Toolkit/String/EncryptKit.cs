using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 加解密管理器。
	/// </summary>
	public static class EncryptKit
	{
		/// <summary>
		/// 使用 MD5 算法加密数据流。
		/// </summary>
		/// <param name="bytes">输入加密数据流</param>
		/// <returns>加密后的字符串</returns>
		public static byte[] ToMD5(byte[] bytes)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			return md5.ComputeHash(bytes);
		}

		/// <summary>
		/// 使用 MD5 算法加密字符串。
		/// </summary>
		/// <param name="str">输入字符串</param>
		/// <returns>加密后的字符串</returns>
		public static string ToMD5(string str)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			string result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str)));
			return result.Replace("-", "");
		}

		/// <summary>
		/// 使用 SHA1 算法加密数据流。
		/// </summary>
		/// <param name="bytes">输入加密数据流</param>
		/// <returns>加密后的字符串</returns>
		public static byte[] ToSHA1(byte[] bytes)
		{
			SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
			return sha1.ComputeHash(bytes);
		}

		/// <summary>
		/// 使用 SHA1 算法加密字符串。
		/// </summary>
		/// <param name="str">输入字符串</param>
		/// <returns>加密后的字符串</returns>
		public static string ToSHA1(string str)
		{
			SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
			string result = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(str)));
			return result.Replace("-", "");
		}

		/// <summary>
		/// 使用 HMAC SHA1 算法加密数据流。
		/// </summary>
		/// <param name="key">密匙</param>
		/// <param name="bytes">数据流</param>
		/// <returns></returns>
		public static byte[] ToHMACSHA1(byte[] key, byte[] bytes)
		{
			HMACSHA1 hmac = new HMACSHA1(key);
			hmac.Initialize();
			return hmac.ComputeHash(bytes);
		}

		/// <summary>
		/// 使用 HMAC SHA1 算法加密数据流。
		/// </summary>
		/// <param name="bytes">数据流</param>
		/// <returns></returns>
		public static byte[] ToHMACSHA1(byte[] bytes)
		{
			HMACSHA1 hmac = new HMACSHA1();
			hmac.Initialize();
			return hmac.ComputeHash(bytes);
		}

		/// <summary>
		/// 使用 HMAC SHA1 算法加密字符串。
		/// </summary>
		/// <param name="key">密匙</param>
		/// <param name="str">字符串</param>
		/// <returns></returns>
		public static string ToHMACSHA1(string key, string str)
		{
			return BitConverter.ToString(ToHMACSHA1(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(str))).Replace("-", "");
		}

		/// <summary>
		/// 使用 HMAC SHA1 算法加密字符串。
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns></returns>
		public static string ToHMACSHA1(string str)
		{
			return BitConverter.ToString(ToHMACSHA1(Encoding.UTF8.GetBytes(str))).Replace("-", "");
		}

		/// <summary>
		/// 编码为 Base64 字符串。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string EncodeBase64(string str)
		{
			string encode = "";
			if (!string.IsNullOrEmpty(str)) {
				byte[] bytes = Encoding.UTF8.GetBytes(str);
				try {
					encode = Convert.ToBase64String(bytes);
				} catch {
					encode = str;
				}
			}
			return encode;
		}

		/// <summary>
		/// 将 Base64 字符串解码。
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string DecodeBase64(string code)
		{
			string decode = "";
			if (!string.IsNullOrEmpty(code)) {
				byte[] bytes = Convert.FromBase64String(code);
				try {
					decode = Encoding.UTF8.GetString(bytes);
				} catch {
					decode = code;
				}
			}
			return decode;
		}

		//默认密钥向量
		private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

		/// <summary>
		/// DES加密字符串
		/// </summary>
		/// <param name="rgbKey">加密密钥，长度8位</param>
		/// <param name="rgbIV"></param>
		/// <param name="buffer">待加密的数据流</param>
		/// <returns>加密成功返回加密后的数据流，失败返回空值</returns>
		public static byte[] EncryptDES(byte[] rgbKey, byte[] rgbIV, byte[] buffer)
		{
			try {
				using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider()) {
					using (MemoryStream mStream = new MemoryStream()) {
						CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
						cStream.Write(buffer, 0, buffer.Length);
						cStream.FlushFinalBlock();
						return mStream.ToArray();
					}
				}
			} catch {
				return new byte[0];
			}
		}

		/// <summary>
		/// DES加密字符串
		/// </summary>
		/// <param name="encryptKey">加密密钥，长度8位</param>
		/// <param name="encryptIV">长度8位</param>
		/// <param name="encryptString">待加密的数据流</param>
		/// <returns>加密成功返回加密后的数据流，失败返回空值</returns>
		public static string EncryptDES(string encryptKey, string encryptIV, string encryptString)
		{
			try {
				byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
				byte[] rgbIV = Encoding.UTF8.GetBytes(encryptIV);
				byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
				using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider()) {
					using (MemoryStream mStream = new MemoryStream()) {
						CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
						cStream.Write(inputByteArray, 0, inputByteArray.Length);
						cStream.FlushFinalBlock();
						return Convert.ToBase64String(mStream.ToArray());
					}
				}
			} catch {
				return "";
			}
		}

		/// <summary>
		/// DES加密字符串，密匙长度必须等于 8 位
		/// </summary>
		/// <param name="encryptString">待加密的字符串</param>
		/// <param name="encryptKey">加密密钥，长度8位</param>
		/// <returns>加密成功返回加密后的字符串，失败返回空值</returns>
		public static string EncryptDES(string encryptString, string encryptKey)
		{
			try {
				byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.PadLeft(8).Substring(0, 8));
				byte[] rgbIV = Keys;
				byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
				using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider()) {
					using (MemoryStream mStream = new MemoryStream()) {
						CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
						cStream.Write(inputByteArray, 0, inputByteArray.Length);
						cStream.FlushFinalBlock();
						return Convert.ToBase64String(mStream.ToArray());
					}
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				return string.Empty;
			}
		}

		///<summary>
		/// DES解密字符串，密匙长度必须等于 8 位
		/// </summary>
		/// <param name="decryptString">待解密的字符串</param>
		/// <param name="decryptKey">解密密钥，长度8位，和加密密钥相同</param>
		/// <returns>解密成功返回解密后的字符串，失败返空值</returns>
		public static string DecryptDES(string decryptString, string decryptKey)
		{
			try {
				byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.PadLeft(8).Substring(0, 8));
				byte[] rgbIV = Keys;
				byte[] inputByteArray = Convert.FromBase64String(decryptString);
				DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
				MemoryStream mStream = new MemoryStream();
				CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				return Encoding.UTF8.GetString(mStream.ToArray());
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				return string.Empty;
			}
		}
	}
}
