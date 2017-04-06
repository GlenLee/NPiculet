using System;
using System.Configuration.Provider;

namespace NPiculet.Log
{
	public class LogProviderCollection : ProviderCollection
	{
		/// <summary>
		/// �����ṩ�����ƻ�ȡʵ����
		/// </summary>
		/// <param name="name">�ṩ������</param>
		public new LogProvider this[string name]
		{
			get {
				return (LogProvider)base[name];
			}
		}

		/// <summary>
		/// ����һ���ṩ�������ϡ�
		/// </summary>
		/// <param name="provider"></param>
		public override void Add(ProviderBase provider)
		{
			if (provider == null) {
				throw new ArgumentNullException("provider");
			}
			if (!(provider is LogProvider)) {
				throw new ArgumentException("����� Provider ���ͣ�", "provider");
			}
			base.Add(provider);
		}
	}
}