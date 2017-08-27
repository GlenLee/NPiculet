namespace NPiculet.Cache
{
	/// <summary>
	/// 缓存的存取行为。
	/// </summary>
	public enum CacheBehavior
	{
		/// <summary>
		/// 永不过期
		/// </summary>
		NeverExpire,
		/// <summary>
		/// 固定时间失效
		/// </summary>
		FixedTime,
		/// <summary>
		/// 每次读取缓存数据时，皆对缓存项进行延时
		/// </summary>
		Delay,
		/// <summary>
		/// 只读一次
		/// </summary>
		Once
	}
}