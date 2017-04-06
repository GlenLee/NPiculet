using System;
using System.Net;
using NPiculet.Log;
using NPiculet.Toolkit;

namespace NPiculet.Service.Weixin
{
	/// <summary>
	/// 根据授权 Code 获取用户的 OpenID 以及网页访问令牌
	/// </summary>
	public class OWebAccessTokenAPI
	{
		private string _api = "https://api.weixin.qq.com/sns/oauth2/access_token";
		private string _appId;
		private string _appSecret;
		private string _code;

		//{"access_token":"OezXcEiiBSKSxW0eoylIeOsrMX2XKepqKbkbT3eF0VGmZ-D3I-CzDDGdCc0YHqaH497mZOrk_fRHJJk1DCgShbps0TauB09OCxgoVTAyLuFq2r4f7SlHRcjn79lXe_fRMZJ7-7zvTY4XqaQmRgZ6Jw","expires_in":7200,"refresh_token":"OezXcEiiBSKSxW0eoylIeOsrMX2XKepqKbkbT3eF0VGmZ-D3I-CzDDGdCc0YHqaHDTx59dNtg_jluZDMXp9CwfWkZSbLN-NQbcnPkJdiaBU_ROZ2_Hr4QZ6x0Q0Q0uMbXGgzeygl2zBWYK13b01c_Q","openid":"oyjztjodZQRLT0QASFRe14eU-6Ck","scope":"snsapi_base"}
		//{"errcode":40029,"errmsg":"invalid code"}
		private class access_token_obj
		{
			public int errcode;
			public string errmsg;

			public string access_token;
			public int expires_in;
			public string refresh_token;
			public string openid;
			public string scope;
		}

		public OWebAccessTokenAPI(string appId, string appSecret, string code)
		{
			_appId = appId;
			_appSecret = appSecret;
			_code = code;
		}

		public OWebAccessToken GetWebAccessToken()
		{
			//获取网页访问令牌及OpenID
			string url = _api + "?appid=" + _appId;
			url += "&secret=" + _appSecret;
			url += "&code=" + _code;
			url += "&grant_type=authorization_code";

			//if (_accessToken.ErrorCode == 0 && !string.IsNullOrEmpty(_accessToken.AccessToken)) {
			//    //刷新令牌
			//}

			Logger.Debug("OWebAccessTokenAPI URL：" + url);

			//重新获取令牌
			try {
				using (WebClient wc = new WebClient()) {
					string result = wc.DownloadString(url);

					Logger.Debug("OWebAccessTokenAPI.GetWebAccessToken：" + result);

					var token = JsonKit.Deserialize<access_token_obj>(result);
					if (token != null) {
						if (!string.IsNullOrEmpty(token.access_token)) {
							OWebAccessToken at = new OWebAccessToken();
							at.ErrorCode = token.errcode;
							at.ErrorMessage = token.errmsg;
							at.AccessToken = token.access_token;
							at.ExpiresInterval = token.expires_in;
							at.RefreshToken = token.refresh_token;
							at.OpenId = token.openid;
							at.Scope = token.scope;

							return at;
						} else {
							return new OWebAccessToken() { ErrorCode = token.errcode, ErrorMessage = token.errmsg };
						}
					}
				}
			} catch (Exception ex) {

				Logger.Error("OWebAccessTokenAPI Error", ex);

				return new OWebAccessToken() { ErrorCode = -1, ErrorMessage = ex.Message };
			}
			return new OWebAccessToken() { ErrorCode = -1, ErrorMessage = "接口没有获取到正确结果！" };
		}
	}
}