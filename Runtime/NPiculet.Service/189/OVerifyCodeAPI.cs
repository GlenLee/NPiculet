using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using NPiculet.Log;
using NPiculet.Toolkit;

namespace NPiculet.Service.E189
{
	public class OVerifyCodeAPI
	{
		private string _api = "http://api.189.cn/v2/dm/randcode/send";
		private string _appId;
		private string _accessToken;

		public OVerifyCodeAPI(string appId, string accessToken)
		{
			_appId = appId;
			_accessToken = accessToken;
		}

		private class verify_code_obj
		{
			public int res_code;
			public string res_message;
			public string identifier;
			public string create_at;
		}

		/// <summary>
		/// 发送短信
		/// </summary>
		/// <param name="verifyCode"></param>
		/// <returns></returns>
		public OVerifyCode Send(string phone, string url)
		{
			try {
				using (WebClient wc = new WebClient()) {
					wc.Credentials = CredentialCache.DefaultCredentials;

					string tk = new OTokenAPI(_appId, _accessToken).GetToken().Token;

					SortedDictionary<string, string> args = new SortedDictionary<string, string>();
					args.Add("app_id", _appId);
					args.Add("access_token", _accessToken);
					args.Add("token", tk);
					args.Add("phone", phone);
					args.Add("url", url);
					args.Add("timestamp", OConfig189.GetTimeStamp());
					args.Add("exp_time", "3"); //可选

					string sign = Utility189.DoSignature(args, OConfig189.AppSecret);

					args.Add("sign", sign);

					Logger.Debug("189 OVerifyCodeAPI.Send：" + Utility189.GetUrlParameters(args));

					//byte[] data = Utility189.GetDataParm(args);
					//byte[] bytes = wc.UploadData(_api, data);
					//string result = Encoding.UTF8.GetString(bytes);
					string result = Utility189.PostWebRequest(_api, Utility189.GetUrlParameters(args), Encoding.UTF8);

					Logger.Debug("189 OVerifyCodeAPI.Result：" + result);

					var verifyCodeObj = JsonKit.Deserialize<verify_code_obj>(result);
					if (verifyCodeObj != null) {
						if (!string.IsNullOrEmpty(verifyCodeObj.identifier)) {
							//转换
							OVerifyCode verify = new OVerifyCode();
							verify.Identifier = verifyCodeObj.identifier;
							verify.CreateAt = verifyCodeObj.create_at;

							return verify;
						} else {
							return new OVerifyCode() { ResultCode = verifyCodeObj.res_code, ResultMessage = verifyCodeObj.res_message };
						}
					}
				}
			} catch (Exception ex) {
				return new OVerifyCode() { ResultCode = -1, ResultMessage = ex.Message };
			}

			return new OVerifyCode() { ResultCode = -1, ResultMessage = "接口没有获取到正确结果！" };
		}
	}
}