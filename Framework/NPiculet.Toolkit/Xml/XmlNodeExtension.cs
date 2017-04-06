using System.ComponentModel;
using NPiculet.Toolkit;

namespace System.Xml
{
	public static class XmlNodeExtension
	{
		/// <summary>
		/// 获取节点的文本。
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static string GetText(this XmlNode node)
		{
			return node == null ? String.Empty : node.InnerText;
		}

		/// <summary>
		/// 获取节点的文本并转换为指定值。
		/// </summary>
		/// <param name="node">节点</param>
		/// <returns></returns>
		public static T GetText<T>(this XmlNode node)
		{
			Type type = typeof(T);
			if (type.IsEnum) {
				return (T)Enum.Parse(type, node.InnerText);
			} else {
				return node == null ? default(T) : (T)Convert.ChangeType(node.InnerText, typeof(T));
			}
		}

		/// <summary>
		/// 设置节点的文本。
		/// </summary>
		/// <param name="node"></param>
		/// <param name="val"></param>
		public static void SetText(this XmlNode node, string val)
		{
			if (node.HasChildNodes) {
				node.FirstChild.InnerText = val;
			} else {
				node.InnerText = val;
			}
		}

		/// <summary>
		/// 获取属性。
		/// </summary>
		/// <param name="node">节点</param>
		/// <param name="attr">属性</param>
		/// <returns></returns>
		public static string GetAttr(this XmlNode node, string attr)
		{
			if (node.Attributes == null)
				return null;
			XmlAttribute att = node.Attributes[attr];
			return att == null ? String.Empty : node.Attributes[attr].Value;
		}

		/// <summary>
		/// 获取属性并转换为指定值。
		/// </summary>
		/// <param name="node">节点</param>
		/// <param name="attr">属性</param>
		/// <returns></returns>
		public static T GetAttr<T>(this XmlNode node, string attr)
		{
			if (node.Attributes == null)
				return default(T);
			XmlAttribute att = node.Attributes[attr];
			Type type = typeof(T);

			//object val = att == null ? default(T) : type.IsEnum ? (T)Enum.Parse(type, att.Value) : att.Value;
			//var val = att.Value;

			//if (SystemKit.IsNullableType(type)) {
			//    //处理 Nullable 类型
			//    var nullableConverter = new NullableConverter(type);
			//    return (T)nullableConverter.ConvertFrom(val);
			//} else if (type.Equals(typeof(Guid))) {
			//    //处理 Guid 类型
			//    var guidConverter = new GuidConverter();
			//    return (T)guidConverter.ConvertFrom(val);
			//} else {
			//    //检查类型
			//    if ((type.BaseType != null && type.BaseType.Equals(typeof(ValueType))) || type.Equals(typeof(String))) {
			//        return (T)Convert.ChangeType(att.Value, typeof(T));
			//    } else {
			//        //实例化类
			//        var instance = Activator.CreateInstance(type);
			//        return (T)instance;
			//    }
			//}

			return att == null ? default(T) : type.IsEnum ? (T)Enum.Parse(type, att.Value) : (T)Convert.ChangeType(att.Value, typeof(T));
		}

		/// <summary>
		/// 设置属性。
		/// </summary>
		/// <param name="node">节点</param>
		/// <param name="attr">属性</param>
		/// <param name="val">值</param>
		public static void SetAttr(this XmlNode node, string attr, string val)
		{
			if (node == null) return;
			if (node.Attributes != null) {
				XmlAttribute att = node.Attributes[attr];
				if (att != null) {
					att.Value = val;
				} else {
					if (node.OwnerDocument != null) {
						att = node.OwnerDocument.CreateAttribute(attr);
						att.Value = val;
						node.Attributes.Append(att);
					}
				}
			}
		}
	}
}