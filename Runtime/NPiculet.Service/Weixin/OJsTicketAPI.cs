using System;
using System.Net;
using NPiculet.Toolkit;

namespace NPiculet.Service.Weixin
{
	/// <summary>
	/// 获取JS票据
	/// </summary>
	public class OJsTicketAPI
	{
		private string _api = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
		private string _accessToken;

		private static DateTime _timeTag = DateTime.MinValue;
		private static OJsTicket _jsticket;

		//{"ticket":"ticket","expires_in":7200}
		//{"errcode":40001,"errmsg":"invalid credential"}
		private class access_token_obj
		{
			public int errcode;
			public string errmsg;

			public string ticket;
			public int expires_in;
		}

		public OJsTicketAPI(string accessToken)
		{
			_accessToken = accessToken;
		}

		/// <summary>
		/// 获取令牌
		/// </summary>
		/// <returns></returns>
		public OJsTicket GetJsTicket()
		{
			//检查缓存及过期时间
			TimeSpan ts = _timeTag - DateTime.Now;
			if (ts.TotalSeconds > 0) {
				return _jsticket;
			}

			//获取访问令牌
			try {
				string url = _api + "?access_token=" + _accessToken + "&type=jsapi";

				//if (_accessToken.ErrorCode == 0 && !string.IsNullOrEmpty(_accessToken.AccessToken)) {
				//    //刷新令牌
				//}

				//重新获取令牌
				using (WebClient wc = new WebClient()) {
					string result = wc.DownloadString(url);
					var token = JsonKit.Deserialize<access_token_obj>(result);
					if (token != null) {
						if (!string.IsNullOrEmpty(token.ticket)) {
							//转换
							OJsTicket at = new OJsTicket();
							at.Ticket = token.ticket;
							at.ExpiresInterval = token.expires_in;
							_jsticket = at;

							//时间戳
							_timeTag = DateTime.Now.AddSeconds(token.expires_in - 120);

							return _jsticket;
						} else {
							_jsticket = new OJsTicket() {ErrorCode = token.errcode, ErrorMessage = token.errmsg};
							return _jsticket;
						}
					}
				}
			} catch (Exception ex) {
				_jsticket = new OJsTicket() {ErrorCode = -1, ErrorMessage = ex.Message};
				return _jsticket;
			}

			return new OJsTicket() {ErrorCode = -1, ErrorMessage = "接口没有获取到正确结果！"};
		}
	}
}