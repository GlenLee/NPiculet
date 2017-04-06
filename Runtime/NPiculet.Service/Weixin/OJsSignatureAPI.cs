using System;
using NPiculet.Toolkit;

namespace NPiculet.Service.Weixin
{
	/// <summary>
	/// 获取签名
	/// </summary>
	public class OJsSignatureAPI
	{
		private string _url; //生成签名的URL
		private string _ticket; //JS票据

		public OJsSignatureAPI(string url, string ticket)
		{
			_url = url;
			_ticket = ticket;
		}

		/// <summary>
		/// 获取签名
		/// </summary>
		/// <returns></returns>
		public OJsSignature GetSignature()
		{
			OJsSignature ost = new OJsSignature();
			ost.NonceStr = GetRandomString(16);
			ost.Timestamp = GetTime();
			ost.Need = @"jsapi_ticket=" + _ticket + "&noncestr=" + ost.NonceStr + "&timestamp=" + ost.Timestamp + "&url=" + _url;
			//ost.Signature = FormsAuthentication.HashPasswordForStoringInConfigFile(ost.Need, "SHA1").ToLower();
			ost.Signature = EncryptKit.ToSHA1(ost.Need);
			return ost;
		}

		private static Random _rnd = new Random();

		/// <summary>
		/// 产生一个由英文字母和数字组成的随机字符串。
		/// </summary>
		/// <param name="n">产生的字符个数</param>
		/// <returns></returns>
		public static string GetRandomString(int n)
		{
			short chr = 0;
			string str = "";
			for (int i = 0; i < n; i++) {
				switch (_rnd.Next(3)) {
					case 0:
						chr = (short) _rnd.Next(48, 58);
						break;
					case 1:
						chr = (short) _rnd.Next(65, 91);
						break;
					case 2:
						chr = (short) _rnd.Next(97, 123);
						break;
				}
				str += Convert.ToChar(chr).ToString();
			}
			return str;
		}

		/// <summary>
		/// 获取时间戳
		/// </summary>
		/// <param name="n">产生的字符个数</param>
		/// <returns></returns>
		public long GetTime()
		{
			DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));

			DateTime nowTime = DateTime.Now;

			long unixTime = (long) Math.Round((nowTime - startTime).TotalSeconds, MidpointRounding.AwayFromZero);

			return unixTime;
		}
	}
}