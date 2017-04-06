using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace NPiculet.Toolkit
{
	public class WebKit
	{
		/// <summary> 
		/// ȡ�ÿ͑��˼�������ַ 
		/// </summary> 
		public static string GetSimpleIP()
		{
			if (null != HttpContext.Current.Request.ServerVariables["HTTP_VIA"]) {
				return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			} else {
				return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
		}

		/// <summary> 
		/// ȡ�ÿ͑������� IPv4 ��ַ 
		/// </summary> 
		/// <returns></returns> 
		public static string GetClientIPv4()
		{
			string ipv4 = String.Empty;
			foreach (IPAddress ip in Dns.GetHostAddresses(GetClientIP())) {
				if (ip.AddressFamily.ToString() == "InterNetwork") {
					ipv4 = ip.ToString();
					break;
				}
			}
			if (ipv4 != String.Empty) {
				return ipv4;
			}
			// ԭ����ʹ�� Dns.GetHostName ����ȡ�ص��� Server �����ϣ��� Client �ˡ� 
			// ��Ϊ���� Dns.GetHostEntry �������ɻ�ȡ�� IPv6 λַ���� DNS ��¼�� 
			// ����һ�ж��Ƿ����� IPv4 Э�鶨�������ת��Ϊ IPv4 ��ַ�� 
			foreach (IPAddress ip in Dns.GetHostEntry(GetClientIP()).AddressList)
			//foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName())) 
            {
				if (ip.AddressFamily.ToString() == "InterNetwork") {
					ipv4 = ip.ToString();
					break;
				}
			}
			return ipv4;
		}

		/// <summary>
		/// ȡ�ÿɴ�͸����Ŀ͑���������ַ
		/// </summary>
		public static string GetClientIP()
		{
			string result = String.Empty;

			result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (result != null && result != String.Empty) {
				//�����д��� 
				if (result.IndexOf(".") == -1)    //û�С�.���϶��Ƿ�IPv4��ʽ 
					result = null;
				else {
					if (result.IndexOf(",") != -1) {
						//�С�,�������ƶ������ȡ��һ������������IP�� 
						result = result.Replace(" ", "").Replace("'", "");
						string[] temparyip = result.Split(",;".ToCharArray());
						for (int i = 0; i < temparyip.Length; i++) {
							if (IsIPv4(temparyip[i])
								&& temparyip[i].Substring(0, 3) != "10."
								&& temparyip[i].Substring(0, 7) != "192.168"
								&& temparyip[i].Substring(0, 7) != "172.16.") {


								return temparyip[i];    //�ҵ����������ĵ�ַ 
							}
						}
					} else if (IsIPv4(result)) //������IP��ʽ 
						return result;
					else
						result = null;    //�����е����� ��IP��ȡIP 
				}

			}

			string ipAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

			if (null == result || result == String.Empty)
				result = ipAddress;

			if (result == null || result == String.Empty)
				result = HttpContext.Current.Request.UserHostAddress;

			return result;
		}

		/// <summary>
		/// �ж��Ƿ���IPv4��ַ
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		public static bool IsIPv4(string ip)
		{
			if (ip == null || ip == string.Empty || ip.Length < 7 || ip.Length > 15) return false;
			string pattern = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			return regex.IsMatch(ip);
		}
	}
}