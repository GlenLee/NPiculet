using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace NPiculet.Data
{
	public class OracleHelper : AbstractDbHelper
	{
		#region ��ʼ��

		public OracleHelper(ServerType type, string connString) : base(type, connString)
		{ }

		/// <summary>
		/// �������ݿ����Ӷ���
		/// </summary>
		/// <param name="connString">�����ַ���</param>
		/// <returns>���ݿ����Ӷ���</returns>
		protected override IDbConnection CreateConnection(string connString)
		{
			return new OracleConnection(connString);
		}

		/// <summary>
		/// ����������������
		/// </summary>
		/// <returns>����������</returns>
		protected override IDbDataAdapter CreateDataAdapter()
		{
			return new OracleDataAdapter();
		}

		#endregion

		#region ������������

		/// <summary>
		/// �����������ݡ�
		/// </summary>
		/// <param name="dataTable">���ݱ�</param>
		/// <param name="tableName">Ҫ��������ݱ�����</param>
		/// <param name="connKey">������������</param>
		public override void BatchInsert(DataTable dataTable, string tableName, string connKey = null)
		{
			var sql = string.Empty;
			try {
				this.Open(connKey);
				this.Command.CommandType = CommandType.Text;
				this.Command.CommandText = "SELECT * FROM " + tableName;

				var dt = dataTable.Copy();
				foreach (DataRow dr in dt.Rows) {
					if (dr.RowState == DataRowState.Unchanged) dr.SetAdded();
				}
				this.Command.Transaction = this.Connection.BeginTransaction();
				var da = new OracleDataAdapter((OracleCommand)this.Command);
				var cb = new OracleCommandBuilder(da);
				da.InsertCommand = cb.GetInsertCommand();
				da.Update(dt);
				this.Command.Transaction.Commit();
			} catch (Exception ex) {
				throw new Exception("������������ʱ���ִ���" + ex.Message + "\r\n" + sql, ex);
			}
		}

		#endregion
	}
}