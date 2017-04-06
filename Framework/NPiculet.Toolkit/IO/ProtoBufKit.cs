using System;
using System.IO;
using ProtoBuf;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// Google Protocol Buffer 工具集
	/// </summary>
	public static class ProtoBufKit
	{
		/// <summary>
		/// 序列化，并返回二进制流
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static byte[] Serialize<T>(T obj)
		{
			using (var ms = new MemoryStream()) {
				Serializer.Serialize(ms, obj);
				return ms.ToArray();
			}
		}

		/// <summary>
		/// 用指定的流容器序列化对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="stream"></param>
		/// <param name="obj"></param>
		public static void Serialize<T>(Stream stream, T obj)
		{
			Serializer.Serialize(stream, obj);
		}

		/// <summary>
		/// 序列化，并返回二进制流编码后的 Base64 字符串
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string SerializeBase64<T>(T obj)
		{
			using (var ms = new MemoryStream()) {
				Serializer.Serialize(ms, obj);
				return Convert.ToBase64String(ms.ToArray());
			}
		}

		/// <summary>
		/// 反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static T Deserialize<T>(byte[] bytes)
		{
			using (var ms = new MemoryStream(bytes)) {
				return Serializer.Deserialize<T>(ms);
			}
		}

		/// <summary>
		/// 读取指定的流容器反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static T Deserialize<T>(Stream stream)
		{
			return Serializer.Deserialize<T>(stream);
		}

		/// <summary>
		/// 根据二进制流编码后的 Base64 字符串，反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="base64str"></param>
		/// <returns></returns>
		public static T DeserializeBase64<T>(string base64str)
		{
			byte[] bytes = Convert.FromBase64String(base64str);
			using (var ms = new MemoryStream(bytes)) {
				return Serializer.Deserialize<T>(ms);
			}
		}
	}
}