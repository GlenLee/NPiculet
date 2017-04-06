﻿using System;
using System.Data;
using System.Data.SQLite;

namespace NPiculet.Data
{
	public class SqliteHelper : AbstractDbHelper
	{
		#region 初始化

		public SqliteHelper(ServerType type, string connString)
			: base(type, connString)
		{ }

		/// <summary>
		/// 创建数据库连接对象。
		/// </summary>
		/// <param name="connString">连接字符串</param>
		/// <returns>数据库连接对象</returns>
		protected override IDbConnection CreateConnection(string connString)
		{
			return new SQLiteConnection(connString);
		}

		/// <summary>
		/// 创建数据适配器。
		/// </summary>
		/// <returns>数据适配器</returns>
		protected override IDbDataAdapter CreateDataAdapter()
		{
			return new SQLiteDataAdapter();
		}

		#endregion

		#region 批量增加数据

		/// <summary>
		/// 批量插入数据。
		/// </summary>
		/// <param name="dataTable">数据表</param>
		/// <param name="tableName">要插入的数据表名称</param>
		/// <param name="connKey">连接配置名称</param>
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
				var da = new SQLiteDataAdapter((SQLiteCommand)this.Command);
				var cb = new SQLiteCommandBuilder(da);
				da.InsertCommand = cb.GetInsertCommand();
				da.Update(dt);
				this.Command.Transaction.Commit();
			} catch (Exception ex) {
				throw new Exception("批量插入数据时出现错误：" + ex.Message + "\r\n" + sql, ex);
			}
		}

		#endregion

		#region 特有数据处理方法

		protected override string ProcessSqlString(string sql)
		{
			return sql.Replace("`", "");
		}

		#endregion

	}
}
