using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace NPiculet.Toolkit
{
	public static class JsonExtension
	{
		public static string ProcessJsonValue(string value)
		{
			//return "\"" + value.Replace("\r", "\\r").Replace("\n", "\\n") + "\"";
			return JsonConvert.SerializeObject(value);
		}

		public static string ToJson<T>(this T value, params string[] filter)
		{
			if (value == null) {
				return "null";
			}
			Type type = value.GetType();
			switch (Type.GetTypeCode(type)) {
				case TypeCode.Object:
					return ConvertToJson(value, filter);

				case TypeCode.Boolean:
					return Convert.ToBoolean(value) ? "true" : "false";

				case TypeCode.DateTime:
					//return "\"" + Convert.ToDateTime(value).ToString("yyyy-MM-ddTH:mm:ss.fffffff") + "\"";
					var epoc = new DateTime(1970, 1, 1, 8, 0, 0); //+8 时区
					var delta = Convert.ToDateTime(value) - epoc;
					return delta.TotalMilliseconds.ToString("0");

				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					return value.ToString();
			}
			return ProcessJsonValue(value.ToString().FormatJson());
		}

		private static string ConvertToJson<T>(T value, params string[] filter)
		{
			Type type = value.GetType();
			//处理 Guid 类型
			if (type.Equals(typeof(Guid))) {
				return ProcessJsonValue(value.ToString());
			}
			//处理数组
			if (type.IsArray) {
				return ToJson(value as Array, filter);
			}
			//处理数据集
			if (typeof(NameValueCollection).IsAssignableFrom(type)) {
				return ToJson(value as NameValueCollection, filter);
			}
			if (typeof (IDictionary).IsAssignableFrom(type)) {
				return ToJson((IDictionary)value, filter);
			}
			if (typeof(IEnumerable).IsAssignableFrom(type)) {
				return ToJson((IEnumerable)value, filter);
			}
			//处理自定义对象
			return CustomObjectToJson(value, filter);
		}

		/// <summary>
		/// 处理自定义对象类
		/// </summary>
		/// <returns></returns>
		private static string CustomObjectToJson<T>(T value, params string[] filter)
		{
			Type type = value.GetType();
			var source = from s in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
						 where s.CanRead
						 select s;
			//var members = from s in type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
			//              select s;
			if (filter != null && filter.Length > 0) {
				Func<PropertyInfo, bool> predicate = s => filter.Contains<string>(s.Name);
				source = source.Where<PropertyInfo>(predicate);
			}
			StringBuilder builder = new StringBuilder();
			builder.Append("{");
			foreach (PropertyInfo info in source) {
				object val = info.GetValue(value, null);
				if (builder.Length > 1) {
					builder.Append(",");
				}
				builder.Append(ProcessJsonValue(info.Name) + ":" + ToJson(val, filter));
			}
			builder.Append("}");

			return builder.ToString();
		}

		public static string ToJson(this string value, params string[] filter)
		{
			if (value == null) return "";
			return ProcessJsonValue(value.FormatJson());
		}

		#region 处理数组

		public static string ToJson(this Array value, params string[] filter)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("[");
			for (int i = 0; i < value.Length; i++) {
				var item = value.GetValue(i);
				if (builder.Length > 1) builder.Append(",");
				builder.Append(ToJson(item, filter));
			}
			builder.Append("]");

			return builder.ToString();
		}

		public static string ToJson(this IEnumerable value, params string[] filter)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("[");
			IEnumerator enumerator = value.GetEnumerator();
			while (enumerator.MoveNext()) {
				if (builder.Length > 1) builder.Append(",");
				builder.Append(ToJson(enumerator.Current, filter));
			}
			builder.Append("]");

			return builder.ToString();
		}

		public static string ToJson(this NameValueCollection value, params string[] filter)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("{");
			foreach (string key in value.AllKeys) {
				if (((filter == null) || (filter.Length <= 0)) || filter.Contains<string>(key)) {
					if (builder.Length > 1) builder.Append(",");
					builder.Append(ProcessJsonValue(key) + ":" + ToJson(value[key], filter));
				}
			}
			builder.Append("}");

			return builder.ToString();
		}

		public static string ToJson(this IDictionary value, params string[] filter)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("{");
			foreach (string key in value.Keys) {
				if (((filter == null) || (filter.Length <= 0)) || filter.Contains<string>(key)) {
					if (builder.Length > 1) builder.Append(",");
					builder.Append(ProcessJsonValue(key) + ":" + ToJson(value[key], filter));
				}
			}
			builder.Append("}");

			return builder.ToString();
		}

		#endregion

		#region 处理数据集

		public static string ToJson(this DataSet value, params string[] filter)
		{
			string json = "[";
			foreach (DataTable dt in value.Tables) {
				if (json != "[") json += ",";
				json += ToJson(dt, filter);
			}
			json += "]";
			return json;
		}

		public static string ToJson(this DataTable value, params string[] filter)
		{
			string[] columns = new string[value.Columns.Count];
			for (int i = 0; i < columns.Length; i++) {
				columns[i] = value.Columns[i].ColumnName;
			}

			StringBuilder json = new StringBuilder();
			json.Append("[");
			//行循环
			for (int i = 0; i < value.Rows.Count; i++) {
				DataRow dr = value.Rows[i];
				if (i != 0) json.Append(",");
				//列循环
				json.Append("{");
				var firstIndex = -1;
				for (int j = 0; j < columns.Length; j++) {
					string columnName = columns[j];
					object columnValue = dr[j];
					if (((filter == null) || (filter.Length <= 0)) || filter.Contains<string>(columnName)) {
						//解决第 0 个参数被过滤掉会多出逗号的情况
						if (firstIndex == -1) firstIndex = j;
						if (j != firstIndex) json.Append(",");
						//组合 Json 值
						json.Append(ProcessJsonValue(columnName) + ":" + ToJson(columnValue, filter));
					}
				}
				json.Append("}");
			}
			json.Append("]");
			return json.ToString();
		}

		public static string ToJson(this DataRow value, params string[] filter)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("{");
			foreach (DataColumn column in value.Table.Columns) {
				if (((filter == null) || (filter.Length <= 0)) || filter.Contains<string>(column.ColumnName)) {
					if (builder.Length > 1) builder.Append(",");
					builder.Append(ProcessJsonValue(column.ColumnName) + ":" + ToJson(value[column], filter));
				}
			}
			builder.Append("}");

			return builder.ToString();
		}

		public static string ToJson(this DataView value, params string[] filter)
		{
			return ToJson(value.ToTable(), filter);
		}

		#endregion
	}
}