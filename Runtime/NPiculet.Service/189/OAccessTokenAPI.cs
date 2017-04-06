using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using NPiculet.Log;
using NPiculet.Toolkit;

namespace NPiculet.Service.E189
{
	public class OAccessTokenAPI
	{
		private string _api = "https://oauth.api.189.cn/emp/oauth2/v3/access_token";
		private string _appId;
		private string _appSecret;

		private static DateTime _timeTag = DateTime.MinValue;
		private static OAccessToken _accessToken;

		public OAccessTokenAPI(string appId, string appSecret)
		{
			_appId = appId;
			_appSecret = appSecret;
		}

		private class access_token_obj
		{
			public int res_code;
			public string res_message;
			public string state;

			public string access_token;
			public int expires_in;
			public string open_id;
			public string scope;
		}

		/// <summary>
		/// 获取令牌
		/// </summary>
		/// <returns></returns>
		public OAccessToken GetAccessToken()
		{
			//获取访问令牌
			try {
				using (WebClient wc = new WebClient()) {
					wc.Credentials = CredentialCache.DefaultCredentials;

					NameValueCollection args = new NameValueCollection();
					args.Add("grant_type", "client_credentials");
					args.Add("app_id", _appId);
					args.Add("app_secret", _appSecret);

					byte[] results = wc.UploadValues(_api, args);
					string result = Encoding.UTF8.GetString(results);

					Logger.Debug("189 OAccessTokenAPI.GetAccessToken：" + result);

					var token = JsonKit.Deserialize<access_token_obj>(result);
					if (token != null) {
						if (!string.IsNullOrEmpty(token.access_token)) {
							//转换
							OAccessToken at = new OAccessToken();
							at.ResultCode = token.res_code;
							at.ResultMessage = token.res_message;
							at.State = token.state;

							at.AccessToken = token.access_token;
							at.ExpiresInterval = token.expires_in;

							at.OpenId = token.open_id;
							at.Scope = token.scope;

							_accessToken = at;

							//时间戳
							_timeTag = DateTime.Now.AddSeconds(token.expires_in - 120);

							return _accessToken;
						} else {
							_accessToken = new OAccessToken() { ResultCode = token.res_code, ResultMessage = token.res_message };
							return _accessToken;
						}
					}
				}
			} catch (Exception ex) {
				_accessToken = new OAccessToken() { ResultCode = -1, ResultMessage = ex.Message };
				return _accessToken;
			}

			return new OAccessToken() { ResultCode = -1, ResultMessage = "接口没有获取到正确结果！" };
		}

		public void Refresh()
		{
			//刷新令牌
		}
	}
}