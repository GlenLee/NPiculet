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
		private static readonly Random _rnd = new Random();
		private static byte[] _IVKeys = { 0x10, 0x30, 0x55, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

		/// <summary>
		/// 创建一个随机密钥，默认长度8。
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static byte[] CreateKey(int length = 8) {
			byte[] key = new byte[8];
			for (int i = 0; i < length; i++) {
				key[i] = Convert.ToByte(_rnd.Next(0, 256));
			}
			return key;
		}

		/// <summary>
		/// DES加密字符串
		/// </summary>
		/// <param name="rgbKey">加密密钥，长度8位</param>
		/// <param name="rgbIV">对称算法的初始化向量，长度8位</param>
		/// <param name="buffer">待加密的数据流</param>
		/// <returns>加密成功返回加密后的数据流，失败返回空值</returns>
		public static byte[] EncryptDES(byte[] rgbKey, byte[] rgbIV, byte[] buffer)
		{
			using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider()) {
				using (MemoryStream mStream = new MemoryStream()) {
					CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
					cStream.Write(buffer, 0, buffer.Length);
					cStream.FlushFinalBlock();
					return mStream.ToArray();
				}
			}
		}

		/// <summary>
		/// DES加密字符串
		/// </summary>
		/// <param name="encryptKey">加密密钥，长度8位</param>
		/// <param name="encryptIV">对称算法的初始化向量，长度8位</param>
		/// <param name="encryptString">待加密的数据流</param>
		/// <returns>加密成功返回加密后的数据流，失败返回空值</returns>
		public static string EncryptDES(string encryptKey, string encryptIV, string encryptString)
		{
			byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.PadLeft(8).Substring(0, 8));
			byte[] rgbIV = Encoding.UTF8.GetBytes(encryptIV.PadLeft(8).Substring(0, 8));
			byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
			using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider()) {
				using (MemoryStream mStream = new MemoryStream()) {
					CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
					cStream.Write(inputByteArray, 0, inputByteArray.Length);
					cStream.FlushFinalBlock();
					return Convert.ToBase64String(mStream.ToArray());
				}
			}
		}

		/// <summary>
		/// DES加密字符串，密匙长度必须等于 8 位
		/// </summary>
		/// <param name="encryptKey">加密密钥，长度8位</param>
		/// <param name="encryptString">待加密的字符串</param>
		/// <returns>加密成功返回加密后的字符串，失败返回空值</returns>
		public static string EncryptDES(string encryptKey, string encryptString)
		{
			byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.PadLeft(8).Substring(0, 8));
			byte[] rgbIV = _IVKeys;
			byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
			using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider()) {
				using (MemoryStream mStream = new MemoryStream()) {
					CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
					cStream.Write(inputByteArray, 0, inputByteArray.Length);
					cStream.FlushFinalBlock();
					return Convert.ToBase64String(mStream.ToArray());
				}
			}
		}

		///<summary>
		/// DES解密字符串，密匙长度必须等于 8 位
		/// </summary>
		/// <param name="decryptKey">解密密钥，长度8位，和加密密钥相同</param>
		/// <param name="decryptString">待解密的字符串</param>
		/// <returns>解密成功返回解密后的字符串，失败返空值</returns>
		public static string DecryptDES(string decryptKey, string decryptString)
		{
			try {
				byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.PadLeft(8).Substring(0, 8));
				byte[] rgbIV = _IVKeys;
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
