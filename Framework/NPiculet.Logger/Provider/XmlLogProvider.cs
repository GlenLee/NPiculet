using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

namespace NPiculet.Log
{
	public class XmlLogProvider : LogProvider
	{
		private static readonly object SyncRoot = new object();

		#region 初始化

		public override string Name
		{
			get { return "XmlLogProvider"; }
		}

		private string _address;

		public override string Address
		{
			get { return _address ?? ""; }
			set
			{
				_address = value;
				//检查日志目录是否存在
				string path = ConvertToFullPath(_address);
				if (!Directory.Exists(path)) {
					Directory.CreateDirectory(path);
				}
			}
		}

		#endregion

		private bool CheckFile(string path)
		{
			FileInfo file = new FileInfo(ConvertToFullPath(path));
			return file.Exists;
		}

		private void SaveXml(XmlDocument xml, string filePath, Formatting formatting)
		{
			using (var writer = new XmlTextWriter(filePath, Encoding.UTF8)) {
				writer.Formatting = formatting;
				if (formatting == Formatting.Indented) writer.Indentation = 2;

				xml.Save(writer);

				writer.Flush();
			}
		}

		/// <summary>
		/// 设置属性。
		/// </summary>
		/// <param name="node">节点</param>
		/// <param name="attr">属性</param>
		/// <param name="val">值</param>
		public static void SetAttr(XmlNode node, string attr, string val)
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

		/// <summary>
		/// 设置节点的文本。
		/// </summary>
		/// <param name="node"></param>
		/// <param name="val"></param>
		public static void SetText(XmlNode node, string val)
		{
			if (node.HasChildNodes) {
				node.FirstChild.InnerText = val;
			} else {
				node.InnerText = val;
			}
		}

		private void Log(string msg, LogType type, Exception ex = null)
		{
			string file = string.Format("{0}_{1:yyyy-MM-dd}.xml", type.ToString().ToLower(), DateTime.Now);
			string path = Path.Combine(ConvertToFullPath(Address), file);
			lock (SyncRoot) {
				XmlDocument xml = new XmlDocument();
				if (CheckFile(path)) {
					xml.Load(path);
				}

				var root = xml.SelectSingleNode("/Logs");
				if (root == null) {
					root = xml.CreateElement("Logs");
					xml.AppendChild(root);
				}
				//添加节点
				var log = xml.CreateElement("Log");
				DateTime now = DateTime.Now;
				SetAttr(log, "Date", now.ToString("yyyy-MM-dd"));
				SetAttr(log, "Time", now.ToString("HH:mm:ss"));
				SetAttr(log, "Type", type.ToString());
				root.AppendChild(log);
				//添加消息
				var message = xml.CreateElement("Message");
				SetText(message, msg);
				log.AppendChild(message);

				//处理错误
				if (type == LogType.Error) {
					ProcessError(log, ex);
				}

				SaveXml(xml, path, Formatting.Indented);
			}
		}

		private void ProcessError(XmlElement root, Exception ex, int layer = 0)
		{
			if (ex != null) {
				var xml = root.OwnerDocument;

				XmlElement exception;
				if (layer > 0) {
					exception = xml.CreateElement("InnerException");
				} else {
					exception = xml.CreateElement("Exception");
				}

				var message = xml.CreateElement("Message");
				SetText(message, ex.Message);
				exception.AppendChild(message);

				var stackTrace = xml.CreateElement("StackTrace");
				SetText(stackTrace, ex.StackTrace);
				exception.AppendChild(stackTrace);

				root.AppendChild(exception);

				ProcessError(exception, ex.InnerException, layer + 1);
			}
		}

		public override void Error(string msg, Exception ex)
		{
			Log(msg, LogType.Error, ex);
		}

		public override void Info(string msg)
		{
			Log(msg, LogType.Info);
		}

		public override void Debug(string msg)
		{
			Log(msg, LogType.Debug);
		}
	}
}