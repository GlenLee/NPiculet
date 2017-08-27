using System;
using System.ComponentModel;

namespace NPiculet.Toolkit
{
	public class ConvertKit
	{
		/// <summary>
		/// ��ֵתΪָ�����������͡�
		/// </summary>
		/// <param name="val">��Ҫת�����͵�ֵ</param>
		/// <param name="defaultValue">��������</param>
		public static T ConvertValue<T>(object val, T defaultValue)
		{
			Type type = typeof(T);
			try {
				if (SystemKit.IsNullableType(type)) {
					var nullableConverter = new NullableConverter(type);
					return (T)nullableConverter.ConvertFrom(val);
				} else if (type.Equals(typeof(Guid))) {
					var guidConverter = new GuidConverter();
					return (T)guidConverter.ConvertFrom(val);
				} else if (type.IsEnum) {
					return (T)Enum.Parse(type, val.ToString());
				} else if (type.IsValueType || type.Equals(typeof(String))) {
					return (T)(val == null ? Activator.CreateInstance(type) : Convert.ChangeType(val, type));
				} else {
					return (T)Convert.ChangeType(val, type);
				}
			} catch {
				//return (T)(type.IsValueType ? Activator.CreateInstance(type) : null);
				return defaultValue;
			}
		}

		/// <summary>
		/// ת����ǰģ���������ֵ��
		/// </summary>
		/// <param name="val">��Ҫת�����͵�ֵ</param>
		/// <param name="type">��������</param>
		public static object ConvertValue(object val, Type type)
		{
			try {
				if (SystemKit.IsNullableType(type)) {
					var nullableConverter = new NullableConverter(type);
					//��������ת��Ϊ����
					if (type == typeof(int?) && val is bool) {
						return (bool)val ? 1 : 0;
					}
					if (type == typeof(bool?) && val is int) {
						return (int)val == 1;
					}
					//����ֵ
					return nullableConverter.ConvertFrom(val);
				} else if (type.Equals(typeof(Guid))) {
					var guidConverter = new GuidConverter();
					return guidConverter.ConvertFrom(val);
				} else if (type.IsEnum) {
					return Enum.Parse(type, val.ToString());
				} else if (type.IsValueType || type.Equals(typeof(String))) {
					return val == null ? Activator.CreateInstance(type) : Convert.ChangeType(val, type);
				} else {
					return Convert.ChangeType(val, type);
				}
			} catch {
				return type.IsValueType ? Activator.CreateInstance(type) : null;
			}
		}

		/// <summary>
		/// ת����ǰģ���������ֵ��
		/// </summary>
		/// <typeparam name="T">��������</typeparam>
		/// <param name="val">��Ҫת�����͵�ֵ</param>
		/// <returns></returns>
		public static T ConvertValue<T>(object val)
		{
			Type type = typeof(T);
			try {
				if (SystemKit.IsNullableType(type)) {
					var nullableConverter = new NullableConverter(type);
					return (T)nullableConverter.ConvertFrom(val);
				} else if (type.Equals(typeof(Guid))) {
					var guidConverter = new GuidConverter();
					return (T)guidConverter.ConvertFrom(val);
				} else if (type.IsEnum) {
					return (T)Enum.Parse(type, val.ToString());
				} else if (type.IsValueType || type.Equals(typeof(String))) {
					return (T)(val == null ? Activator.CreateInstance(type) : Convert.ChangeType(val, type));
				} else {
					return (T)Convert.ChangeType(val, type);
				}
			} catch {
				return (T)(type.IsValueType ? Activator.CreateInstance(type) : default(T));
			}
		}

		/// <summary>
		/// ��ȡĳ�����͵�Ĭ��ֵ
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetDefault<T>()
		{
			return (T)GetDefault(typeof(T));
		}

		/// <summary>
		/// ��ȡĳ�����͵�Ĭ��ֵ
		/// </summary>
		/// <returns></returns>
		public static object GetDefault(Type type)
		{
			return (type.IsValueType ? Activator.CreateInstance(type) : null);
		}
	}
}