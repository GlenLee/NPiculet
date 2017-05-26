using System;
using System.Collections;
using System.Data;
using System.Web;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 缓存管理器。
	/// </summary>
	public static class CacheKit
	{
		/// <summary>
		/// 移除缓存。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		public static void Remove(string cacheKey)
		{
			try {
				HttpContext.Current.Cache.Remove(cacheKey);
			} catch { }
		}

		/// <summary>
		/// 检查缓存是否存在。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <returns>是否存在</returns>
		public static bool IsExist(string cacheKey)
		{
			if (HttpContext.Current.Cache[cacheKey] != null) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// 设置缓存。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <param name="obj">储存的对象</param>
		/// <param name="expirySpan">过期间隔</param>
		/// <param name="cacheItemPriority">缓存回收的优先级</param>
		private static void SaveCache(string cacheKey, object obj, TimeSpan expirySpan, System.Web.Caching.CacheItemPriority cacheItemPriority)
		{
			if (IsExist(cacheKey)) {
				HttpContext.Current.Cache.Insert(cacheKey, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, expirySpan, cacheItemPriority, null);
			} else {
				HttpContext.Current.Cache.Add(cacheKey, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, expirySpan, cacheItemPriority, null);
			}
		}

		#region 设置缓存

		/// <summary>
		/// 设置缓存。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <param name="obj">对象</param>
		public static void SetCahceObject(string cacheKey, object obj)
		{
			SaveCache(cacheKey, obj, TimeSpan.FromMinutes(30), System.Web.Caching.CacheItemPriority.Normal);
		}

		/// <summary>
		/// 设置缓存。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <param name="obj">对象</param>
		/// <param name="expirySpan">过期间隔</param>
		public static void SetCahceObject(string cacheKey, object obj, TimeSpan expirySpan)
		{
			SaveCache(cacheKey, obj, expirySpan, System.Web.Caching.CacheItemPriority.Normal);
		}

		/// <summary>
		/// 设置缓存。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <param name="obj">对象</param>
		/// <param name="expirySpan">过期间隔</param>
		/// <param name="cacheItemPriority">缓存回收的优先级</param>
		public static void SetCahceObject(string cacheKey, object obj, TimeSpan expirySpan, System.Web.Caching.CacheItemPriority cacheItemPriority)
		{
			SaveCache(cacheKey, obj, expirySpan, cacheItemPriority);
		}

		/// <summary>
		/// 设置缓存。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <param name="obj">对象</param>
		/// <param name="cacheItemPriority">缓存回收的优先级</param>
		public static void SetCahceObject(string cacheKey, object obj, System.Web.Caching.CacheItemPriority cacheItemPriority)
		{
			SaveCache(cacheKey, obj, TimeSpan.FromMinutes(30), cacheItemPriority);
		}

		#endregion

		#region 获取缓存
		
		/// <summary>
		/// 获取缓存的数据表。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <returns>数据表</returns>
		public static DataTable GetCahceDataTable(string cacheKey)
		{
			return HttpContext.Current.Cache[cacheKey] as DataTable;
		}

		/// <summary>
		/// 获取缓存的对象。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <returns>数据表</returns>
		public static object GetCahceObject(string cacheKey)
		{
			if (IsExist(cacheKey)) {
				return HttpContext.Current.Cache[cacheKey];
			} else {
				return null;
			}
		}

		/// <summary>
		/// 获取缓存希哈表。
		/// </summary>
		/// <param name="cacheKey">缓存的索引键</param>
		/// <returns>希哈表</returns>
		public static Hashtable GetCahceHashtable(string cacheKey)
		{
			if (IsExist(cacheKey)) {
				return (Hashtable)HttpContext.Current.Cache[cacheKey];
			} else {
				return null;
			}
		}

		#endregion
	}
}