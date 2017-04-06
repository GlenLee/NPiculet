using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NPiculet.Log;
using NPiculet.Toolkit;

namespace NPiculet.Service.E189
{
	public class OTokenAPI
	{
		private string _api = "http://api.189.cn/v2/dm/randcode/token";
		private string _appId;
		private string _accessToken;

		public OTokenAPI(string appId, string accessToken)
		{
			_appId = appId;
			_accessToken = accessToken;
		}

		private class token_obj
		{
			public int res_code;
			public string res_message;
			public string token;
		}

		public OToken GetToken()
		{
			try {
				using (WebClient wc = new WebClient()) {
					wc.Credentials = CredentialCache.DefaultCredentials;

					SortedDictionary<string, string> args = new SortedDictionary<string, string>();
					args.Add("app_id", _appId);
					args.Add("access_token", _accessToken);
					args.Add("timestamp", OConfig189.GetTimeStamp());

					string sign = Utility189.DoSignature(args, OConfig189.AppSecret);

					args.Add("sign", sign);

					string result = wc.DownloadString(_api + "?" + Utility189.GetUrlParameters(args));

					Logger.Debug("189 OTokenAPI.GetToken：" + result);

					var token = JsonKit.Deserialize<token_obj>(result);
					if (token != null) {
						if (!string.IsNullOrEmpty(token.token)) {
							//转换
							OToken at = new OToken();
							at.ResultCode = token.res_code;
							at.Token = token.token;

							return at;
						} else {
							return new OToken() { ResultCode = token.res_code, ResultMessage = token.res_message };
						}
					}
				}
			} catch (Exception ex) {
				return new OToken() { ResultCode = -1, ResultMessage = ex.Message };
			}

			return new OToken() { ResultCode = -1, ResultMessage = "接口没有获取到正确结果！" };
		}
	}
}