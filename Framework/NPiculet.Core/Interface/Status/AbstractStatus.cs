namespace NPiculet.Core
{
	public abstract partial class AbstractStatus : IStatus
	{
		public abstract string Get(string key);
		public abstract void Set(string key, string val);
		public virtual bool IsExist(string key) {
			return (Get(key) != null);
		}
	}
}