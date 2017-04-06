using System.Web;

namespace NPiculet.Service.Weixin
{
	/// <summary>
	/// 生成获取授权 Code 的链接地址，要事先再微信中为域名授权，才能正常访问
	/// </summary>
	public class OAuthCodeAPI
	{
		private string _api = "https://open.weixin.qq.com/connect/oauth2/authorize";
		private string _appId;

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="appId"></param>
		public OAuthCodeAPI(string appId)
		{
			_appId = appId;
		}

		/// <summary>
		/// 获取授权 Code 的链接地址，需事先在微信中为 URI 的域名授权，否则会报错
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		public string GetURL(string uri)
		{
			string url = _api + "?appid=" + _appId;
			url += "&redirect_uri=" + HttpUtility.UrlPathEncode(uri);
			url += "&response_type=code";
			url += "&scope=snsapi_base";
			url += "&state=1";
			url += "#wechat_redirect";
			return url;
		}
	}
}