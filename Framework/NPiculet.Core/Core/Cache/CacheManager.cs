using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;

namespace NPiculet.Sys
{
	public class CacheManager<T> : ICache<T>
	{
		#region 初始化

		/// <summary>
		/// 初始化容器，并防止被覆盖。
		/// </summary>
		private readonly static ConcurrentDictionary<string, CacheItem<T>> _container = new ConcurrentDictionary<string, CacheItem<T>>();

		private static object _syncObject = new object();
		private static Timer _timer = null;

		public CacheManager()
		{
			//定时清理过期缓存
			if (_timer == null) {
				lock (_syncObject) {
					if (_timer == null) {
						_timer = new Timer(300000); //每5分钟
						_timer.Elapsed += (sender, args) => { ClearExpiredCache(); };
						_timer.Start();
					}
				}
			}
		}

		/// <summary>
		/// 清理过期缓存
		/// </summary>
		private void ClearExpiredCache()
		{
			foreach (string key in _container.Keys) {
				if (_container.ContainsKey(key)) {
					CacheItem<T> item = _container[key];
					if (item.IsExpired()) {
						_container.TryRemove(key, out item);
					}
				}
			}
		}

		#endregion

		#region 实现接口

		/// <summary>
		/// 统计缓存数量
		/// </summary>
		public int Count
		{
			get { return _container.Count; }
		}

		/// <summary>
		/// 获取所有键集合。
		/// </summary>
		public ICollection<string> Keys
		{
			get { return _container.Keys; }
		}

		/// <summary>
		/// 是否包含键
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ContainsKey(string key)
		{
			return _container.ContainsKey(key);
		}

		/// <summary>
		/// 获取 key 键所指向的对象。
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public CacheItem<T> Get(string key)
		{
			if (_container.ContainsKey(key)) {
				CacheItem<T> item = _container[key];
				if (item.IsExpired()) {
					_container.TryRemove(key, out item);
					item.Destroy("你访问的缓存已过期！");
					return item;
				}
				switch (item.Behavior) {
					case CacheBehavior.Delay:
						item.ExpireDate = DateTime.Now.Add(item.ExpireDelay);
						break;
					case CacheBehavior.Once:
						item.Destroy();
						_container.TryRemove(key, out item);
						break;
				}
				return item;
			}
			var fail = new CacheItem<T>(default(T));
			fail.Destroy("没有找到缓存项！");
            return fail;
		}

		/// <summary>
		/// 移除一条项目。
		/// </summary>
		/// <param name="key"></param>
		public void Remove(string key)
		{
			CacheItem<T> item;
			_container.TryRemove(key, out item);
		}

		/// <summary>
		/// 移除所有指定的缓存集合。
		/// </summary>
		/// <param name="keys">Key 的集合</param>
		public void RemoveAll(ICollection<string> keys)
		{
			CacheItem<T> item;
			foreach (string key in keys) {
				_container.TryRemove(key, out item);
			}
		}

		/// <summary>
		/// 移除所有缓存。
		/// </summary>
		public void Clear()
		{
			_container.Clear();
		}

		/// <summary>
		/// 设置缓存
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="delay"></param>
		/// <param name="behavior"></param>
		public void Set(string key, T value, TimeSpan delay, CacheBehavior behavior)
		{
			_container[key] = new CacheItem<T>(value, delay, behavior);
		}

		/// <summary>
		/// 设置缓存，默认 30 分钟过期
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Set(string key, T value)
		{
			Set(key, value, new TimeSpan(0, 30, 0), CacheBehavior.Delay);
		}

		#endregion
	}
}