namespace NPiculet.Authorization
{
	/// <summary>
	/// 用户基类
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class User<TKey>
	{
		public TKey Id;
		public int Type;
		public string Sn;
		public string Name;
		public string Account;
		public string Password;
		public string Level;

		public string Sex;
		public string Mobile;
		public string Weixin;

		public string StateCode;
		public bool IsEnabled;
	}
}