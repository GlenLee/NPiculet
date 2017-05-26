using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NPiculet.Toolkit
{
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
	}
}
