using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace NPiculet.Toolkit {
	/// <summary>
	/// 数据工具
	/// </summary>
	public class DataKit {

		/// <summary>
		/// 列表转换为数据表
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static DataTable ToDataTable<T>(IEnumerable<T> list)
		{
			DataTable dt = new DataTable();
			// column names 
			PropertyInfo[] oProps = null;
			if (list == null)
				return dt;
			foreach (T rec in list) {
				if (oProps == null) {
					oProps = ((Type)rec.GetType()).GetProperties();
					foreach (PropertyInfo pi in oProps) {
						Type colType = pi.PropertyType;
						if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
						                                == typeof(Nullable<>))) {
							colType = colType.GetGenericArguments()[0];
						}
						dt.Columns.Add(new DataColumn(pi.Name, colType));
					}
				}
				DataRow dr = dt.NewRow();
				foreach (PropertyInfo pi in oProps) {
					dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
						(rec, null);
				}
				dt.Rows.Add(dr);
			}
			return dt;
		}
	}
}