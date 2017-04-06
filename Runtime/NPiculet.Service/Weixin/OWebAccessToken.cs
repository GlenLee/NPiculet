namespace NPiculet.Service.Weixin
{
	public struct OWebAccessToken
	{
		public int ErrorCode;
		public string ErrorMessage;

		public string AccessToken;
		public int ExpiresInterval;
		public string RefreshToken;
		public string OpenId;
		public string Scope;
	}
}