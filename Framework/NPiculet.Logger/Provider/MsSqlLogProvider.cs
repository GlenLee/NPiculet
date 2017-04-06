using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NPiculet.Log
{
	/// <summary>
	/// ���� MS SQL Server ����־�洢�࣬��Ҫ�������ݱ�
	/// create table SysLogs (
	///   Id                   int                  identity,
	///   Type                 varchar(16)          null,
	///   Message              nvarchar(512)        null,
	///   Exception            ntext                null,
	///   Date                 datetime             not null,
	///   constraint PK_SYSLOGS primary key (Id)
	///)
	/// </summary>
	public class MsSqlLogProvider : LogProvider
	{
		#region ��ʼ��

		public override string Name
		{
			get { return "MsSqlLogProvider"; }
		}

		public override string Address { get; set; }

		#endregion

		private void Log(string msg, LogType type, Exception ex = null)
		{
			if (!string.IsNullOrEmpty(Address)){
				string exString = string.Empty;
				if (type == LogType.Error) {
					StringBuilder sb = new StringBuilder();
					ProcessError(sb, ex);
				}
				SqlParameter[] parms = new SqlParameter[] {
					new SqlParameter("@Type", type.ToString()),
					new SqlParameter("@Message", msg),
					new SqlParameter("@Exception", exString),
					new SqlParameter("@Date", DateTime.Now),
				};
				DbHelper.Execute(Address, CommandType.Text, "INSERT INTO SysLogs ([Type], [Message], [Exception], [Date]) VALUES (@Type, @Message, @Exception, @Date);", parms);
			} else {
				throw new ArgumentNullException("����ΪMsSqlLogProvider�����ý�ȱ�١�address�����ԣ��޷�ȡ�����ݿ����ӵ�ַ��");
			}
		}

		private void ProcessError(StringBuilder sb, Exception ex, int layer = 0)
		{
			if (ex != null) {
				//����ǰ׺
				string pefix = string.Empty;
				if (layer > 0) {
					for (int i = 0; i < layer; i++) {
						pefix += "  ";
					}
				}
				sb.AppendLine(pefix + "Message: " + ex.Message);
				sb.AppendLine(pefix + "StackTrace: " + ex.StackTrace);

				ProcessError(sb, ex.InnerException, layer + 1);
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