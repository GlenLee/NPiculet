using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPiculet.Core
{
	public partial interface ICache<T>
	{
		/// <summary>
		/// 统计缓存数量。
		/// </summary>
		int Count { get; }

		/// <summary>
		/// 获取缓存 Key 集合。
		/// </summary>
		ICollection<string> Keys { get; }

		/// <summary>
		/// 是否包含键
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		bool ContainsKey(string key);

		/// <summary>
		/// 获取缓存。
		/// </summary>
		/// <param name="key">Key</param>
		/// <returns>返回 <paramref name="key"/> 或 <c>null</c>。</returns>
		CacheItem<T> Get(string key);

		/// <summary>
		/// 移除一个缓存。
		/// </summary>
		/// <param name="key">Key</param>
		void Remove(string key);

		/// <summary>
		/// 移除所有指定的缓存集合。
		/// </summary>
		/// <param name="keys">Key 的集合</param>
		void RemoveAll(ICollection<string> keys);

		/// <summary>
		/// 移除所有缓存。
		/// </summary>
		void Clear();

		/// <summary>
		/// 增加一个缓存。
		/// </summary>
		/// <remarks>新增一个缓存，使用默认优先级且没有过期时间。</remarks>
		/// <param name="key">Key</param>
		/// <param name="value">缓存值</param>
		void Set(string key, T value);

		/// <summary>
		/// 增加一个缓存。
		/// </summary>
		/// <remarks>新增一个缓存，使用默认优先级。</remarks>
		/// <param name="key">Key</param>
		/// <param name="value">缓存值</param>
		/// <param name="delay">缓存生存间隔</param>
		/// <param name="behavior">缓存行为</param>
		void Set(string key, T value, TimeSpan delay, CacheBehavior behavior);
	}
}
