using NPiculet.Logic.Business;
using System;
using System.Configuration;

namespace NPiculet.Service.Weixin
{
	public class OConfig
	{
		/// <summary>
		/// 获取 APP ID
		/// </summary>
		public static string AppId
		{
			//get { return ConfigurationManager.AppSettings["WeixinAppId"]; }
			get {
				var config = new SysConfigBus().QueryModel("ConfigCode='WeixinAppID'");
				return config == null ? "" : config.ConfigValue;
			}
		}

		/// <summary>
		/// 获取 APP Secret
		/// </summary>
		public static string AppSecret
		{
			//get { return ConfigurationManager.AppSettings["WeixinAppSecret"]; }
			get {
				var config = new SysConfigBus().QueryModel("ConfigCode='WeixinAppSecret'");
				return config == null ? "" : config.ConfigValue;
			}
		}

		/// <summary>
		/// 获取 APP ID
		/// </summary>
		public static string AppWebSite
		{
			get { return ConfigurationManager.AppSettings["WeixinAppWebSite"]; }
		}

		/// <summary>
		/// 获取时间戳
		/// </summary>
		/// <returns></returns>
		public static string GetTimeStamp()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}