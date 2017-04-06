using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;

namespace NPiculet.Log
{
	public static class Logger
	{
		#region ��ʼ��

		private static readonly object SyncRoot = new object();
		private static LogProvider _provider;
		//private static LogProviderCollection _providers;

		private static LogProvider Provider
		{
			get
			{
				LoadProviders();
				return _provider;
			}
		}

		/// <summary>
		/// �� web.config �л�ȡ�ṩ�����ϡ�
		/// </summary>
		private static void LoadProviders()
		{
			if (_provider == null) {
				lock (SyncRoot) {
					//���¼������Ƿ������߳�ʵ������
					if (_provider == null) {
						//��ȡ���ý����á�
						var section = (LogProviderSection)ConfigurationManager.GetSection("NPiculet/logProvider");

						//����Ĭ���ṩ����
						//_providers = new LogProviderCollection();

						foreach (ProviderSettings settings in section.Providers) {
							//ֻ����Ĭ���ṩ����ʵ��
							if (settings.Name == section.DefaultProvider) {
								var instance = Activator.CreateInstance(Type.GetType(settings.Type)) as LogProvider;
								if (instance == null) {
									throw new Exception("�� Web.config �ļ�û����ȷ���� Provider ���ԣ�");
								}
								//_providers.Add(instance);
								//��ʼ������
								instance.Address = settings.Parameters["address"] ?? "";

								_provider = instance;
							}
						}

						//_provider = _providers[section.DefaultProvider];

						if (_provider == null) {
							throw new ProviderException("Ĭ�ϵ� Provider û���ҵ������� Web.config �����ã�");
						}
					}
				}
			}
		}

		#endregion

		#region ��¼��־

		/// <summary>
		/// ��¼�쳣��־���ӳ�ִ����Ϣ��������������ѹرյ���־������Ҳ�������
		/// </summary>
		/// <param name="fn"></param>
		/// <param name="ex"></param>
		public static void Error(Func<string> fn, Exception ex)
		{
			if (Provider.CheckEnabled(LogType.Info)) {
				Provider.Error(fn(), ex);
			}
		}

		/// <summary>
		/// ��¼��Ϣ��־���ӳ�ִ����Ϣ��������������ѹرյ���־������Ҳ�������
		/// </summary>
		/// <param name="fn"></param>
		public static void Info(Func<string> fn)
		{
			if (Provider.CheckEnabled(LogType.Info)) {
				Provider.Info(fn());
			}
		}

		/// <summary>
		/// ��¼������־���ӳ�ִ����Ϣ��������������ѹرյ���־������Ҳ�������
		/// </summary>
		/// <param name="fn"></param>
		public static void Debug(Func<string> fn)
		{
			if (Provider.CheckEnabled(LogType.Info)) {
				Provider.Debug(fn());
			}
		}

		/// <summary>
		/// ��¼�쳣��־
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="ex"></param>
		public static void Error(string msg, Exception ex)
		{
			Provider.Error(msg, ex);
		}

		/// <summary>
		/// ��¼��Ϣ��־
		/// </summary>
		/// <param name="msg"></param>
		public static void Info(string msg)
		{
			Provider.Info(msg);
		}

		/// <summary>
		/// ��¼������־
		/// </summary>
		/// <param name="msg"></param>
		public static void Debug(string msg)
		{
			Provider.Debug(msg);
		}

		#endregion

	}
}