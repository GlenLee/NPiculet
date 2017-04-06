using System;
using System.IO;

namespace NPiculet.Log
{
	public class FileLogProvider : LogProvider
	{
		private static readonly object SyncRoot = new object();

		#region 初始化

		public override string Name
		{
			get { return "FileLogProvider"; }
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

		private void Log(string msg, LogType type, Exception ex = null)
		{
			string file = string.Format("{0}_{1:yyyy-MM-dd}.txt", type.ToString().ToLower(), DateTime.Now);
			string path = Path.Combine(ConvertToFullPath(Address), file);
			lock (SyncRoot) {
				using (StreamWriter writer = new StreamWriter(path, true)) {
					writer.WriteLine("[ " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ] " + msg);
					if (type == LogType.Error) {
						ProcessError(writer, ex);
					}
					writer.WriteLine("------------------------------");
				}
			}
		}

		private void ProcessError(StreamWriter writer, Exception ex, int layer = 0)
		{
			if (ex != null) {
				//产生前缀
				string pefix = string.Empty;
				if (layer > 0) {
					for (int i = 0; i < layer; i++) {
						pefix += "  ";
					}
				}
				writer.WriteLine(pefix + "Message: " + ex.Message);
				writer.WriteLine(pefix + "StackTrace: " + ex.StackTrace);

				ProcessError(writer, ex.InnerException, layer + 1);
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