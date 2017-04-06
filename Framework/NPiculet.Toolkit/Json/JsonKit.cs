//using Jil;

using System;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// JSON 工具集
	/// </summary>
	public static class JsonKit
	{
		/// <summary>
		/// 序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string Serialize<T>(T obj)
		{
			//return JSON.Serialize(obj, Options.MillisecondsSinceUnixEpoch);
			return JsonConvert.SerializeObject(obj, Formatting.None, new ChinaDateTimeConverter());
		}

		public static string Serialize(DataSet obj) { return obj.ToJson(); }
		public static string Serialize(DataTable obj) { return obj.ToJson(); }
		public static string Serialize(DataRow obj) { return obj.ToJson(); }

		/// <summary>
		/// 序列化动态对象
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string SerializeDynamic(object obj)
		{
			//return JSON.SerializeDynamic(obj, Options.MillisecondsSinceUnixEpoch);
			return Serialize(obj);
		}

		/// <summary>
		/// 反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="json"></param>
		/// <returns></returns>
		public static T Deserialize<T>(string json)
		{
			//return JSON.Deserialize<T>(json, Options.MillisecondsSinceUnixEpoch);
			return JsonConvert.DeserializeObject<T>(json, new ChinaDateTimeConverter());
		}

		/// <summary>
		/// 反序列化动态对象
		/// </summary>
		/// <param name="json"></param>
		/// <returns></returns>
		public static dynamic DeserializeDynamic(string json)
		{
			//return JSON.DeserializeDynamic(json, Options.MillisecondsSinceUnixEpoch);
			return JsonConvert.DeserializeObject<dynamic>(json, new ChinaDateTimeConverter());
		}

		/// <summary>
		/// 获取 JS 格式的时间长整型数字
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static long ToJsDate(DateTime date)
		{
			var jsdate = date - new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
			long ticks = Convert.ToInt64(jsdate.TotalMilliseconds);
			return ticks;
		}

		/// <summary>
		/// 将 JS 格式的时间长整型数字转换为时间
		/// </summary>
		/// <param name="ticks"></param>
		/// <returns></returns>
		public static DateTime FromJsDate(long ticks)
		{
			var timezone = new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
			var date = timezone.AddMilliseconds(ticks);
			return date;
		}
	}

	//2005-11-5 21:21:25
	public class ChinaDateTimeConverter : DateTimeConverterBase
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			//如果是字符串，尝试转换日期
			if (reader.TokenType == JsonToken.String) {
				string val = reader.Value.ToString();
				DateTime date;
				DateTime.TryParse(val, out date);
				if (date == DateTime.MinValue) {
					long ticks;
					if (long.TryParse(val, out ticks)) {
						date = new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
						date = date.AddMilliseconds(ticks);
						return date;
					}
				}
				return date;
			}
			//如果是数字，尝试转换日期
			if (reader.TokenType == JsonToken.Integer) {
				long ticks = Convert.ToInt64(reader.Value);
				var date = new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
				date = date.AddMilliseconds(ticks);
				return date;
			}
			//如果是日期则直接转换
			if (reader.TokenType == JsonToken.Date) {
				return Convert.ToDateTime(reader.Value);
			}
			//throw new Exception(String.Format("日期格式错误，标记：{0}", reader.TokenType));
			return DateTime.MinValue;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			string date;
			if (value is DateTime) {
				date = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
			} else {
				throw new Exception("值不是时间对象！");
			}
			writer.WriteValue(date);
		}
	}

	/// <summary>
	/// 用于 Json.Net 的日期转换器
	/// </summary>
	public class UnixDateTimeConverter : DateTimeConverterBase
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Integer) {
				throw new Exception(String.Format("日期格式错误，标记：{0}", reader.TokenType));
			}
			var ticks = (long)reader.Value;
			var date = new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
			date = date.AddMilliseconds(ticks);
			return date;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			long ticks;
			if (value is DateTime) {
				var epoc = new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
				var delta = ((DateTime)value) - epoc;
				ticks = (long)delta.TotalMilliseconds;
			} else {
				throw new Exception("值不是时间对象！");
			}
			writer.WriteValue(ticks);
		}
	}
}