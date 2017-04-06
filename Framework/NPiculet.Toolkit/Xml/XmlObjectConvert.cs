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
		#region ͨ�÷���

		/// <summary>
		/// ����������Ϣת����ǰģ���������ֵ��
		/// </summary>
		/// <param name="info">ģ������Ľṹ��Ϣ</param>
		/// <param name="val">��Ҫת�����͵�ֵ</param>
		private static object GetValue(PropertyInfo info, object val)
		{
			Type type = info.PropertyType;
			return ConvertKit.ConvertValue(val, type);
		}

		#endregion

		#region �� XML ת��Ϊʵ��

		/// <summary>
		/// ת��XML�ĵ�Ϊ����ģ�͡�
		/// </summary>
		/// <param name="xml">XML�ĵ�</param>
		/// <param name="rootPath">���ڵ�·��</param>
		/// <param name="filter">������������</param>
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
				//�������
				PropertyInfo info = type.GetProperty(node.Name);
				if (info != null) {
					bool skip = false;
					foreach (string f in filter) {
						if (info.Name == f)
							skip = true;
					}
					//���Կ�д
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
					//���Կ�д
					if (!skip && field.FieldType.IsGenericType) {
						var items = field.GetValue(model) as IList;
						if (items != null) {
							//��ȡ��������
							Type[] types = field.FieldType.GetGenericArguments();
							if (types.Length > 0) {
								Type t = types[0];

								//�������ֶΡ�����
								XmlNodeList parents = node.ChildNodes;
								foreach (XmlNode parent in parents) {
									var val = parent.InnerText;

									if (SystemKit.IsNullableType(t)) {
										//���� Nullable ����
										try {
											var nullableConverter = new NullableConverter(t);
											items.Add(nullableConverter.ConvertFrom(val));
										} catch {
											items.Add(null);
										}
									} else if (t.Equals(typeof(Guid))) {
										//���� Guid ����
										var guidConverter = new GuidConverter();
										items.Add(guidConverter.ConvertFrom(val));
									} else {
										//�������
										if ((t.BaseType != null && t.BaseType.Equals(typeof(ValueType))) || t.Equals(typeof(String))) {
											items.Add(Convert.ChangeType(parent.InnerText, t));
										} else {
											//ʵ������
											var instance = Activator.CreateInstance(t);
											//������������
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
		/// ת��XML�ĵ�Ϊ����ģ�͡�
		/// </summary>
		/// <param name="xml">XML�ĵ�</param>
		/// <param name="rootPath">���ڵ�·��</param>
		/// <param name="filter">������������</param>
		public static List<T> ConvertToModelList<T>(XmlDocument xml, string rootPath, params string[] filter) where T : new()
		{
			List<T> list = new List<T>();
			XmlNode root = xml.SelectSingleNode(rootPath);
			if (root != null) {
				//��ȡ�����ӽڵ�
				foreach (XmlNode node in root.ChildNodes) {
					T model = new T();
					//��ȡ�ֶ�ֵ
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
							//���Կ�д
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

		#region ��ʵ��ת��Ϊ XML �ĵ�

		/// <summary>
		/// ת������ģ��ΪXML�ĵ���
		/// </summary>
		/// <param name="model">����ģ��</param>
		public static XmlDocument ConvertToXml(object model)
		{
			if (model != null) {
				//����XML�ĵ�
				string rootPath = model.GetType().Name;
				XmlDocument xml = new XmlDocument();
				xml.SetText(rootPath, "");

				XmlNode root = xml.SelectSingleNode(rootPath);
				if (root != null) {
					//��ȡ����
					FillXmlProperties(model, xml, root);
					//��ȡ�ֶ�
					FillXmlFields(model, xml, root);

					return xml;
				}
			}
			return null;
		}

		/// <summary>
		/// ��ȡ����
		/// </summary>
		/// <param name="model"></param>
		/// <param name="xml"></param>
		/// <param name="root"></param>
		private static void FillXmlProperties(object model, XmlDocument xml, XmlNode root)
		{
			if (model != null) {
				//�������
				if (model is ValueType || model is String) {
					root.InnerText = Convert.ToString(model);
				} else {
					//��ȡ����
					Type type = model.GetType();
					//��ȡ����
					PropertyInfo[] infos = type.GetProperties();
					foreach (PropertyInfo info in infos) {
						//���Կɶ�
						if (info.CanRead) {
							XmlElement node = xml.CreateElement(info.Name);
							object value = info.GetValue(model, null);
							//��������
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
		/// ��ȡ�ֶ�
		/// </summary>
		/// <param name="model"></param>
		/// <param name="xml"></param>
		/// <param name="root"></param>
		private static void FillXmlFields(object model, XmlDocument xml, XmlNode root)
		{
			if (model != null) {
				//��ȡ����
				Type type = model.GetType();
				//��ȡ�ֶ�
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

		#region ת�� XML �ĵ�

		/// <summary>
		/// �� XML �ĵ�ת��Ϊ�ַ���
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
		/// �� XML �ĵ�ת��Ϊ�ַ���
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static string ConvertToString(XmlDocument xml)
		{
			return ConvertToString(xml, Encoding.UTF8);
		}

		/// <summary>
		/// ������ת��Ϊ XML �ַ���
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