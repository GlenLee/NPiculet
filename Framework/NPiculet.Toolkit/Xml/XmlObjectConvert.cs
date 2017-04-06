using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using NPiculet.Toolkit;

namespace System.Xml
{
	public static class XmlObjectConvert
	{
		#region 通用方法

		/// <summary>
		/// 根据特性信息转换当前模型中子项的值。
		/// </summary>
		/// <param name="info">模型子项的结构信息</param>
		/// <param name="val">需要转换类型的值</param>
		private static object GetValue(PropertyInfo info, object val)
		{
			Type type = info.PropertyType;
			return ConvertKit.ConvertValue(val, type);
		}

		#endregion

		#region 将 XML 转换为实例

		/// <summary>
		/// 转换XML文档为数据模型。
		/// </summary>
		/// <param name="xml">XML文档</param>
		/// <param name="rootPath">根节点路径</param>
		/// <param name="filter">过滤属性名称</param>
		public static T ConvertToModel<T>(XmlDocument xml, string rootPath, params string[] filter) where T : new()
		{
			T model = new T();
			XmlNode root = xml.SelectSingleNode(rootPath);
			if (root != null) {
				foreach (XmlNode node in root.ChildNodes) {
					FillObjectProperties(model, node, filter);
					FillObjectFields(model, node, filter);
				}
			}
			return model;
		}

		private static void FillObjectProperties(object model, XmlNode node, params string[] filter)
		{
			if (model != null) {
				Type type = model.GetType();
				//检查类型
				PropertyInfo info = type.GetProperty(node.Name);
				if (info != null) {
					bool skip = false;
					foreach (string f in filter) {
						if (info.Name == f)
							skip = true;
					}
					//属性可写
					if (!skip && info.CanWrite) {
						info.SetValue(model, GetValue(info, node.InnerText), null);
					}
				}
			}
		}

		private static void FillObjectFields(object model, XmlNode node, params string[] filter)
		{
			if (model != null) {
				Type type = model.GetType();
				FieldInfo field = type.GetField(node.Name);
				if (field != null) {
					bool skip = false;
					foreach (string f in filter) {
						if (field.Name == f)
							skip = true;
					}
					//属性可写
					if (!skip && field.FieldType.IsGenericType) {
						var items = field.GetValue(model) as IList;
						if (items != null) {
							//获取数据类型
							Type[] types = field.FieldType.GetGenericArguments();
							if (types.Length > 0) {
								Type t = types[0];

								//遍历“字段”子项
								XmlNodeList parents = node.ChildNodes;
								foreach (XmlNode parent in parents) {
									var val = parent.InnerText;

									if (SystemKit.IsNullableType(t)) {
										//处理 Nullable 类型
										try {
											var nullableConverter = new NullableConverter(t);
											items.Add(nullableConverter.ConvertFrom(val));
										} catch {
											items.Add(null);
										}
									} else if (t.Equals(typeof(Guid))) {
										//处理 Guid 类型
										var guidConverter = new GuidConverter();
										items.Add(guidConverter.ConvertFrom(val));
									} else {
										//检查类型
										if ((t.BaseType != null && t.BaseType.Equals(typeof(ValueType))) || t.Equals(typeof(String))) {
											items.Add(Convert.ChangeType(parent.InnerText, t));
										} else {
											//实例化类
											var instance = Activator.CreateInstance(t);
											//遍历属性子项
											XmlNodeList nodes = parent.ChildNodes;
											foreach (XmlNode item in nodes) {
												FillObjectProperties(instance, item);
												FillObjectFields(instance, item);
											}
											items.Add(instance);
										}
									}
								}
							}
						}
						//XmlNodeList parents = node.ChildNodes;
						//foreach (XmlNode parent in parents) {
						//    XmlNodeList nodes = parent.ChildNodes;
						//    foreach (XmlNode node in nodes) {

						//    }
						//}
						//info.SetValue(model, GetValue(info, node.InnerText), null);
					}
				}
			}
		}

		/// <summary>
		/// 转换XML文档为数据模型。
		/// </summary>
		/// <param name="xml">XML文档</param>
		/// <param name="rootPath">根节点路径</param>
		/// <param name="filter">过滤属性名称</param>
		public static List<T> ConvertToModelList<T>(XmlDocument xml, string rootPath, params string[] filter) where T : new()
		{
			List<T> list = new List<T>();
			XmlNode root = xml.SelectSingleNode(rootPath);
			if (root != null) {
				//获取所有子节点
				foreach (XmlNode node in root.ChildNodes) {
					T model = new T();
					//获取字段值
					foreach (XmlNode field in node.ChildNodes) {
						FillObjectProperties(model, field, filter);
						Type type = model.GetType();
						PropertyInfo info = type.GetProperty(field.Name);
						if (info != null) {
							bool skip = false;
							foreach (string f in filter) {
								if (info.Name == f)
									skip = true;
							}
							//属性可写
							if (!skip && info.CanWrite) {
								info.SetValue(model, GetValue(info, field.InnerText), null);
							}
						}
					}
					list.Add(model);
				}
			}
			return list;
		}

		#endregion

		#region 将实例转换为 XML 文档

		/// <summary>
		/// 转换数据模型为XML文档。
		/// </summary>
		/// <param name="model">数据模型</param>
		public static XmlDocument ConvertToXml(object model)
		{
			if (model != null) {
				//创建XML文档
				string rootPath = model.GetType().Name;
				XmlDocument xml = new XmlDocument();
				xml.SetText(rootPath, "");

				XmlNode root = xml.SelectSingleNode(rootPath);
				if (root != null) {
					//获取属性
					FillXmlProperties(model, xml, root);
					//获取字段
					FillXmlFields(model, xml, root);

					return xml;
				}
			}
			return null;
		}

		/// <summary>
		/// 获取属性
		/// </summary>
		/// <param name="model"></param>
		/// <param name="xml"></param>
		/// <param name="root"></param>
		private static void FillXmlProperties(object model, XmlDocument xml, XmlNode root)
		{
			if (model != null) {
				//检查类型
				if (model is ValueType || model is String) {
					root.InnerText = Convert.ToString(model);
				} else {
					//获取类型
					Type type = model.GetType();
					//获取属性
					PropertyInfo[] infos = type.GetProperties();
					foreach (PropertyInfo info in infos) {
						//属性可读
						if (info.CanRead) {
							XmlElement node = xml.CreateElement(info.Name);
							object value = info.GetValue(model, null);
							//处理日期
							if (value is DateTime) {
								node.InnerText = Convert.ToDateTime(value).ToString("yyyy-MM-ddTH:mm:ss.fffffff");
							} else {
								node.InnerText = Convert.ToString(value);
							}
							root.AppendChild(node);
						}
					}
				}
			}
		}

		/// <summary>
		/// 获取字段
		/// </summary>
		/// <param name="model"></param>
		/// <param name="xml"></param>
		/// <param name="root"></param>
		private static void FillXmlFields(object model, XmlDocument xml, XmlNode root)
		{
			if (model != null) {
				//获取类型
				Type type = model.GetType();
				//获取字段
				FieldInfo[] fields = type.GetFields();
				foreach (FieldInfo field in fields) {
					var items = field.GetValue(model) as IList;
					if (items != null) {
						XmlElement parent = xml.CreateElement(field.Name);
						foreach (var item in items) {
							XmlElement itemNode = xml.CreateElement("Item");

							FillXmlProperties(item, xml, itemNode);
							FillXmlFields(item, xml, itemNode);

							parent.AppendChild(itemNode);
						}
						root.AppendChild(parent);
					}
				}
			}
		}

		#endregion

		#region 转换 XML 文档

		/// <summary>
		/// 将 XML 文档转换为字符串
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static string ConvertToString(XmlDocument xml, Encoding encoding)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.OmitXmlDeclaration = false;
			settings.NewLineOnAttributes = true;
			settings.Encoding = encoding;

			using (MemoryStream ms = new MemoryStream()) {
				using (XmlWriter writer = XmlWriter.Create(ms, settings)) {
					xml.WriteTo(writer);
					writer.Flush();

					return encoding.GetString(ms.ToArray());
				}
			}
		}
		
		/// <summary>
		/// 将 XML 文档转换为字符串
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static string ConvertToString(XmlDocument xml)
		{
			return ConvertToString(xml, Encoding.UTF8);
		}

		/// <summary>
		/// 将对象转换为 XML 字符串
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ConvertToString(object obj)
		{
			return ConvertToString(ConvertToXml(obj));
		}

		#endregion
	}
}