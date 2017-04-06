using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NPiculet.Toolkit.System {
	/// <summary>
	/// 类处理工具
	/// </summary>
	public class ClassKit {
		/// <summary>
		/// 获取属性类
		/// </summary>
		/// <typeparam name="T">属性类型</typeparam>
		/// <param name="info">属性对象</param>
		/// <returns>属性类</returns>
		public T GetAttribute<T>(PropertyInfo info) where T : Attribute {
			return Attribute.GetCustomAttribute(info, typeof(T)) as T;
		}

		/// <summary>
		/// 获取属性类
		/// </summary>
		/// <param name="type"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetAttribute<T>(Type type) where T : Attribute
		{
			PropertyInfo[] peroperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (PropertyInfo property in peroperties) {
				object[] objs = property.GetCustomAttributes(typeof(T), true);
				if (objs.Length > 0) {
					return (T)objs[0];
				}
			}
			return null;
		}

		/// <summary>
		/// 获取对象类型的属性数组
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static PropertyInfo[] GetPropertyInfos(Type type)
		{
			return type.GetProperties();
		}

		/// <summary>
		/// 获取对象的函数
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static MethodInfo[] GetMethodInfos(Type type)
		{
			return type.GetMethods();
		}
	}
}
