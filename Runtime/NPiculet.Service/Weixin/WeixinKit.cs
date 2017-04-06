using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NPiculet.Toolkit;

namespace NPiculet.Service.Weixin
{
	public class WeixinKit
	{
		#region 微信基础功能

		/// <summary>
		/// 获取基础访问令牌，每天限制 2000 次
		/// </summary>
		/// <param name="appId"></param>
		/// <param name="appSecret"></param>
		/// <returns></returns>
		public OAccessToken GetAccessToken(string appId, string appSecret)
		{
			OAccessTokenAPI api = new OAccessTokenAPI(appId, appSecret);
			return api.GetAccessToken();
		}

		#endregion

		#region Web功能

		/// <summary>
		/// 获取 Web 访问令牌
		/// </summary>
		/// <param name="appId"></param>
		/// <param name="appSecret"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		public OWebAccessToken GetWebAccessToken(string appId, string appSecret, string code)
		{
			OWebAccessTokenAPI api = new OWebAccessTokenAPI(appId, appSecret, code);
			return api.GetWebAccessToken();
		}

		/// <summary>
		/// 生成获取微信 code 的链接地址，仅服务号有用
		/// </summary>
		/// <param name="appId">微信AppID</param>
		/// <param name="url">完整的链接地址，以 http:// 作为开头</param>
		/// <returns></returns>
		public string GetCodeUrl(string appId, string url)
		{
			OAuthCodeAPI api = new OAuthCodeAPI(appId);
			return api.GetURL(url);
		}

		/// <summary>
		/// 根据微信 Code 获取微信 OpenID
		/// </summary>
		/// <returns></returns>
		public string GetOpenId(string appId, string appSecret, string code)
		{
//#if !DEBUG
			//获取缓存
			string openId = CookiesKit.GetCookie("OpenId");

			if (!string.IsNullOrEmpty(openId)) {
				return openId;
			}

			if (!string.IsNullOrEmpty(code)) {
				OWebAccessTokenAPI atapi = new OWebAccessTokenAPI(appId, appSecret, code);
				OWebAccessToken at = atapi.GetWebAccessToken();
				CookiesKit.SetCookie("OpenId", at.OpenId);

				return at.OpenId;
			}
			return string.Empty;
//#else
//            return "ornCZt1qWRaya7C3Xd1-pN1ktFrI";
//#endif
		}

		#endregion

		#region 微信JS-SDK相关

		/// <summary>
		/// 获取 JS 请求的票据
		/// </summary>
		/// <param name="appId"></param>
		/// <param name="appSecret"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		public OJsTicket GetOJsTicket(string appId, string appSecret, string code)
		{
			var token = GetWebAccessToken(appId, appSecret, code);
			var api = new OJsTicketAPI(token.AccessToken);
			return api.GetJsTicket();
		}

		/// <summary>
		/// 获取 JS 签名
		/// </summary>
		/// <param name="appId"></param>
		/// <param name="appSecret"></param>
		/// <param name="code"></param>
		/// <param name="url"></param>
		/// <returns></returns>
		public OJsSignature GetSignature(string appId, string appSecret, string code, string url)
		{
			var ticket = GetOJsTicket(appId, appSecret, code);
			var api = new OJsSignatureAPI(url, ticket.Ticket);
			return api.GetSignature();
		}

		#endregion
	}
}
