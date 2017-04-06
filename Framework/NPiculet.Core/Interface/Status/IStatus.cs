namespace NPiculet.Core
{
	public partial interface IStatus
	{
		string Get(string key);
		void Set(string key, string val);
		bool IsExist(string key);
	}
}