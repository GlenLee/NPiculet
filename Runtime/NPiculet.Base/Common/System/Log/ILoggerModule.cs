using System;
using NPiculet.Logic.Data;
using NPiculet.Plugin;

namespace NPiculet.Logic.Sys
{
	public interface ILoggerModule : IPlugin
	{
		SysActionLog NewLog();
		SysActionDetail NewDetail();

		void Log(string actionType, string userAccount, string targetCode, string targetId, string msg, params SysActionDetail[] details);
		void Log(string userAccount, string module, string id, string msg, params SysActionDetail[] details);

		void Error(string msg, Exception ex);

		void Info(string msg);

		void Debug(string msg);
	}
}