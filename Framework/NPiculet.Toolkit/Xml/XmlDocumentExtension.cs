using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using NPiculet.Toolkit;

namespace System.Xml
{
	public static class XmlDocumentExtension
	{
		/// <summary>
		/// 从文件读取 XML 文件。
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="filePath"></param>
		public static void LoadFromFile(this XmlDocument xml, string filePath)
		{
			string path = SystemKit.ConvertToFullPath(filePath);
			xml.Load(path);
		}

		/// <summary>
		/// 从文件读取 XML 文件。
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="filePath"></param>
		public static void SaveToFile(this XmlDocument xml, string filePath)
		{
			string path = SystemKit.ConvertToFullPath(filePath);
			xml.Save(path);
		}

		/// <summary>
		/// 获取节点的文本。
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="xpath"></param>
		/// <returns></returns>
		public static string GetText(this XmlDocument xml, string xpath)
		{
			var node = xml.SelectSingleNode(xpath);
			return node.GetText();
		}

		/// <summary>
		/// 设置节点的文本。
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="xpath"></param>
		/// <param name="val"></param>
		public static void SetText(this XmlDocument xml, string xpath, string val)
		{
			//尝试读取路径
			var nodes = xml.SelectNodes(xpath);
			if (nodes == null || nodes.Count == 0) {
				//初始化参数
				Regex nodeRegex = new Regex(@"[^/]+");
				var matchs = nodeRegex.Matches(xpath);
				int count = matchs.Count;
				//循环创建路径
				string parentPath = string.Empty;
				for (int i = 0; i < count; i++) {
					string name = matchs[i].Value;
					var ns = xml.SelectNodes(parentPath + name);
					if (ns != null && ns.Count > 0) {
						if (i == count - 1) {
							foreach (XmlNode node in ns) {
								if (node.HasChildNodes) {
									node.FirstChild.InnerText = val;
								} else {
									node.InnerText = val;
								}
							}
						}
					} else {
						CreateNode(xml, parentPath, name, val);
					}
					parentPath += "/" + matchs[i].Value;
				}
			} else {
				//赋值
				foreach (XmlNode node in nodes) {
					if (node.HasChildNodes) {
						node.FirstChild.InnerText = val;
					} else {
						node.InnerText = val;
					}
				}
			}
		}

		/// <summary>
		/// 创建节点。
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="parentPath"></param>
		/// <param name="name"></param>
		/// <param name="val"></param>
		private static void CreateNode(XmlDocument xml, string parentPath, string name, string val)
		{
			if (string.IsNullOrEmpty(parentPath)) {
				XmlNode n = xml.CreateElement(name);
				n.InnerText = val;
				xml.AppendChild(n);
			} else {
				var nodes = xml.SelectNodes(parentPath);
				if (nodes != null && nodes.Count > 0) {
					foreach (XmlNode node in nodes) {
						XmlNode n = xml.CreateElement(name);
						n.InnerText = val;
						node.AppendChild(n);
					}
				}
			}
		}
	}
}