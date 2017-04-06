namespace NPiculet.Service.Weixin
{
	public struct OAccessToken
	{
		public int ErrorCode;
		public string ErrorMessage;

		public string AccessToken;
		public int ExpiresInterval;
	}
}