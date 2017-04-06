using System;
using System.Net;
using NPiculet.Log;
using NPiculet.Toolkit;

namespace NPiculet.Service.Weixin
{
	/// <summary>
	/// 获取访问令牌，每天限制 2000 次
	/// </summary>
	public class OAccessTokenAPI
	{
		private string _api = "https://api.weixin.qq.com/cgi-bin/token";
		private string _appId;
		private string _appSecret;

		private static DateTime _timeTag = DateTime.MinValue;
		private static OAccessToken _accessToken;

		//{"access_token":"ACCESS_TOKEN","expires_in":7200}
		//{"errcode":40001,"errmsg":"invalid credential"}
		private class access_token_obj
		{
			public int errcode;
			public string errmsg;

			public string access_token;
			public int expires_in;
		}

		public OAccessTokenAPI(string appId, string appSecret)
		{
			_appId = appId;
			_appSecret = appSecret;
		}

		/// <summary>
		/// 获取令牌
		/// </summary>
		/// <returns></returns>
		public OAccessToken GetAccessToken()
		{
			//检查缓存及过期时间
			TimeSpan ts = _timeTag - DateTime.Now;
			if (ts.TotalSeconds > 0) {

				Logger.Debug("OAccessTokenAPI Cache：(" + ts.TotalSeconds + "s)" + JsonKit.Serialize(_accessToken));

				return _accessToken;
			}

			//获取访问令牌
			try {
				string url = _api + "?grant_type=client_credential";
				url += "&appid=" + _appId;
				url += "&secret=" + _appSecret;

				//if (_accessToken.ErrorCode == 0 && !string.IsNullOrEmpty(_accessToken.AccessToken)) {
				//    //刷新令牌
				//}

				Logger.Debug("OAccessTokenAPI URL：" + url);

				//重新获取令牌
				using (WebClient wc = new WebClient()) {
					string result = wc.DownloadString(url);

					Logger.Debug("OAccessTokenAPI.GetAccessToken：" + result);

					var token = JsonKit.Deserialize<access_token_obj>(result);
					if (token != null) {
						if (!string.IsNullOrEmpty(token.access_token)) {
							//转换
							OAccessToken at = new OAccessToken();
							at.AccessToken = token.access_token;
							at.ExpiresInterval = token.expires_in;
							_accessToken = at;

							//时间戳
							_timeTag = DateTime.Now.AddSeconds(token.expires_in - 120);

							return _accessToken;
						} else {
							_accessToken = new OAccessToken() {ErrorCode = token.errcode, ErrorMessage = token.errmsg};
							return _accessToken;
						}
					}
				}
			} catch (Exception ex) {
				_accessToken = new OAccessToken() {ErrorCode = -1, ErrorMessage = ex.Message};
				return _accessToken;
			}

			return new OAccessToken() {ErrorCode = -1, ErrorMessage = "接口没有获取到正确结果！"};
		}
	}
}