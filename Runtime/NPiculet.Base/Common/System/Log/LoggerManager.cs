using System;
using System.Web;
using NPiculet.Data;
using NPiculet.Log;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Plugin;

namespace NPiculet.Logic.Sys
{
	public class LoggerManager : PluginBase, ILoggerModule
	{
		public LoggerManager(IPluginDescriptor descr) : base(descr)
		{
		}

		/// <summary>
		/// 创建新的日志对象，已包含日志 Type 信息。
		/// </summary>
		/// <returns></returns>
		public SysActionLog NewLog()
		{
			return new SysActionLogBus().NewLog();
		}

		/// <summary>
		/// 创建新的日志明细对象
		/// </summary>
		/// <returns></returns>
		public SysActionDetail NewDetail()
		{
			return new SysActionLogBus().NewDetail();
		}

		/// <summary>
		/// 记录日志
		/// </summary>
		/// <param name="actionType">日志类型</param>
		/// <param name="userAccount"></param>
		/// <param name="targetCode">来自模块（或数据表）</param>
		/// <param name="targetId">数据ID</param>
		/// <param name="msg"></param>
		/// <param name="details"></param>
		public void Log(string actionType, string userAccount, string targetCode, string targetId, string msg, params SysActionDetail[] details)
		{
			SysActionLogBus bus = new SysActionLogBus();

			SysActionLog log = bus.NewLog();
			log.ActionType = actionType;
			log.ActionAccount = userAccount;
			log.TargetCode = targetCode;
			log.TargetId = targetId;
			log.Comment = msg;
			log.Date = DateTime.Now;

			int logId = bus.InsertIdentity(log);

			if (details != null && details.Length > 0) {
				for (int i = 0; i < details.Length; i++) {
					SysActionDetail detail = details[i];
					detail.ActionId = logId;

					SysActionDetailBus dbus = new SysActionDetailBus();
					dbus.Insert(detail);
				}
			}
		}

		/// <summary>
		/// 记录日志
		/// </summary>
		/// <param name="userAccount"></param>
		/// <param name="module">来自模块（或数据表）</param>
		/// <param name="id">数据ID</param>
		/// <param name="msg"></param>
		/// <param name="details"></param>
		public void Log(string userAccount, string module, string id, string msg, params SysActionDetail[] details)
		{
			SysActionLogBus bus = new SysActionLogBus();

			SysActionLog log = bus.NewLog();
			log.ActionAccount = userAccount;
			log.TargetCode = module;
			log.TargetId = id;
			log.Comment = msg;
			log.Date = DateTime.Now;

			int logId = bus.InsertIdentity(log);

			if (details != null && details.Length > 0) {
				for (int i = 0; i < details.Length; i++) {
					SysActionDetail detail = details[i];
					detail.ActionId = logId;

					SysActionDetailBus dbus = new SysActionDetailBus();
					dbus.Insert(detail);
				}
			}
		}

		public void Error(string msg, Exception ex)
		{
			Logger.Error(msg, ex);
		}

		public void Info(string msg)
		{
			Logger.Info(msg);
		}

		public void Debug(string msg)
		{
			Logger.Debug(msg);
		}

	}
}