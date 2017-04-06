using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace NPiculet.Core
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

	public class CacheItem<T>
	{
		/// <summary>
		/// 过期时间
		/// </summary>
		private DateTime _expireDate;
		public DateTime ExpireDate
		{
			get { return _expireDate; }
			set { _expireDate = value; }
		}

		/// <summary>
		/// 过期时长
		/// </summary>
		private TimeSpan _expireDelay;
		public TimeSpan ExpireDelay
		{
			get { return _expireDelay; }
			set { _expireDelay = value; }
		}

		/// <summary>
		/// 缓存行为
		/// </summary>
		public CacheBehavior Behavior { get; private set; }

		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid { get; private set; }

		/// <summary>
		/// 缓存提示
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// 访问次数
		/// </summary>
		public long Times { get; private set; }

		/// <summary>
		/// 构造函数，指定值、过期时间、行为
		/// </summary>
		/// <param name="value"></param>
		/// <param name="delay"></param>
		/// <param name="behavior"></param>
		public CacheItem(T value, TimeSpan delay, CacheBehavior behavior)
		{
			if ((behavior == CacheBehavior.Delay || behavior == CacheBehavior.FixedTime) && Math.Abs(delay.TotalSeconds) <= 0) {
				throw new Exception("过期时间不允许为 0，这将导致缓存无法发挥作用！从重新设置过期时间！");
			}
			this.ExpireDelay = delay;
			this.ExpireDate = DateTime.Now.Add(ExpireDelay);

			this.Value = value;
			this.Behavior = behavior;

			this.IsValid = true;
			this.Message = string.Empty;
		}

		/// <summary>
		/// 构造函数，指定值
		/// </summary>
		/// <param name="value"></param>
		public CacheItem(T value)
		{
			this.ExpireDelay = new TimeSpan(0, 30, 0);
			this.ExpireDate = DateTime.Now.Add(ExpireDelay);

			this.Value = value;
			this.Behavior = CacheBehavior.Delay;

			this.IsValid = true;
			this.Message = string.Empty;
		}

		private T _value;
		/// <summary>
		/// 获取缓存值
		/// </summary>
		public T Value {
			get {
				if (!this.IsValid) throw new Exception("缓存已失效！");
				this.Times++;
				return _value;
			}
			private set { _value = value; }
		}

		/// <summary>
		/// 是否已过期
		/// </summary>
		/// <returns></returns>
		public bool IsExpired()
		{
			//永不过期
			if (this.Behavior == CacheBehavior.NeverExpire) {
				return false;
			}
			//一次过期
			if (this.Behavior == CacheBehavior.Once) {
				return this.Times == 0;
			}
			this.IsValid = ExpireDate >= DateTime.Now;
			return !this.IsValid;
		}

		/// <summary>
		/// 销毁缓存
		/// </summary>
		public void Destroy(string msg = null)
		{
			this.IsValid = false;
			this.Message = msg ?? "缓存已销毁！";
		}
    }
}