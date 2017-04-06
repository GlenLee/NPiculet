using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NPiculet.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NPiculet.Test
{
    
    
    /// <summary>
    ///这是 CacheManagerTest 的测试类，旨在
    ///包含所有 CacheManagerTest 单元测试
    ///</summary>
	[TestClass()]
	public class CacheManagerTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///获取或设置测试上下文，上下文提供
		///有关当前测试运行及其功能的信息。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region 附加测试特性
		// 
		//编写测试时，还可使用以下特性:
		//
		//使用 ClassInitialize 在运行类中的第一个测试前先运行代码
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//使用 ClassCleanup 在运行完类中的所有测试后再运行代码
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//使用 TestInitialize 在运行每个测试前先运行代码
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//使用 TestCleanup 在运行完每个测试后运行代码
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		[TestMethod()]
		public void CacheManagerConstructorTest()
		{
			CacheManager<int> intCache = new CacheManager<int>();
			intCache.Set("A", 1);
			CacheManager<string> strCache = new CacheManager<string>();
			strCache.Set("AA", "A");
			strCache.Set("BB", "B");

			CacheManager<int> temp1 = new CacheManager<int>();
			CacheManager<string> temp2 = new CacheManager<string>();

			Assert.AreEqual(1, temp1.Count);
			Assert.AreEqual(2, temp2.Count);
		}

		/// <summary>
		///Clear 的测试
		///</summary>
		public void ClearTestHelper<T>(T val)
		{
			CacheManager<T> target = new CacheManager<T>(); // TODO: 初始化为适当的值
			target.Set("A", val);
			target.Clear();
			Assert.AreEqual(0, target.Count, "Clear失败！");
		}

		[TestMethod()]
		public void ClearTest()
		{
			ClearTestHelper<int>(1);
			ClearTestHelper<string>("A");
		}

		/// <summary>
		///Get 的测试
		///</summary>
		public void GetTestHelper<T>(string key, T expected)
		{
			CacheManager<T> target = new CacheManager<T>();
			target.Set(key, expected);
			T actual = target.Get(key);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void GetTest()
		{
			GetTestHelper<int>("A", 1);
			GetTestHelper<string>("A", "XXX");
			GetTestHelper<double>("A", 1);
			GetTestHelper<Regex>("", new Regex("(.*)"));
		}

		/// <summary>
		///Remove 的测试
		///</summary>
		public void RemoveTestHelper<T>(string key, T value)
		{
			CacheManager<T> target = new CacheManager<T>();
			target.Set(key, value);

			Assert.AreEqual(value, target.Get(key));
			Assert.IsTrue(target.Keys.Contains(key));

			target.Remove(key);

			Assert.AreNotEqual(target.Get(key), value);
			Assert.IsFalse(target.Keys.Contains(key));
		}

		[TestMethod()]
		public void RemoveTest()
		{
			RemoveTestHelper("xxx", "xxxxxx");
			RemoveTestHelper("xxx1", 1);
			RemoveTestHelper("xxx", new object());
		}

		/// <summary>
		///RemoveAll 的测试
		///</summary>
		public void RemoveAllTestHelper()
		{
			CacheManager<string> target = new CacheManager<string>();
			target.Clear();
			target.Set("aaa", "xxc");
			target.Set("bbb", "xxc");
			target.Set("ccc", "xxc");
			List<string> keys = new List<string>() { "xxx", "ccc", "bbb" };
			target.RemoveAll(keys);
			Assert.AreEqual(1, target.Count);
		}

		[TestMethod()]
		public void RemoveAllTest()
		{
			RemoveAllTestHelper();
		}

		/// <summary>
		///Set 的测试
		///</summary>
		public void SetTestHelper<T>(string key, T value)
		{
			CacheManager<T> target = new CacheManager<T>(); // TODO: 初始化为适当的值
			target.Set(key, value);
			Assert.AreEqual(value, target.Get(key));
		}

		[TestMethod()]
		public void SetTest()
		{
			SetTestHelper("a", 1);
			SetTestHelper("a", 2);
			SetTestHelper("b", "x");
			SetTestHelper("a", true);
			SetTestHelper("a", false);
		}

		/// <summary>
		///Set 的测试
		///</summary>
		public void SetTest1Helper()
		{
			CacheManager<int> target = new CacheManager<int>();
			target.Clear();
			target.Set("xxx", 1, new TimeSpan(0, 0, 0, 0, 500), CacheBehavior.Delay);
			Assert.AreEqual(1, target.Get("xxx"));
			Assert.AreEqual(1, target.Get("xxx"));
			Assert.AreEqual(1, target.Get("xxx"));
			Thread.Sleep(500);
			Assert.AreEqual(0, target.Get("xxx"));

			target.Set("yyy", 1, new TimeSpan(0, 0, 0, 0, 500), CacheBehavior.NeverExpire);
			Assert.AreEqual(1, target.Get("yyy"));
			Thread.Sleep(500);
			Assert.AreEqual(1, target.Get("yyy"));
			Thread.Sleep(100);
			Assert.AreEqual(1, target.Get("yyy"));

			target.Set("zzz", 1, new TimeSpan(0, 0, 0, 0, 500), CacheBehavior.Once);
			Assert.AreEqual(1, target.Get("zzz"));
			Assert.AreEqual(0, target.Get("zzz"));

			target.Set("fixed", 1, new TimeSpan(0, 0, 0, 0, 500), CacheBehavior.FixedTime);
			Assert.AreEqual(1, target.Get("fixed"));
			Thread.Sleep(300);
			Assert.AreEqual(1, target.Get("fixed"));
			Thread.Sleep(300);
			Assert.AreEqual(0, target.Get("fixed"));
		}

		[TestMethod()]
		public void SetTest1()
		{
			SetTest1Helper();
		}

		/// <summary>
		///Count 的测试
		///</summary>
		public void CountTestHelper()
		{
			CacheManager<int> target = new CacheManager<int>();
			target.Clear();
			target.Set("a", 1);
			target.Set("a", 2);
			target.Set("b", 1);
			Assert.AreEqual(2, target.Count);

			CacheManager<int> temp = new CacheManager<int>();
			temp.Set("c", 12);
			Assert.AreEqual(3, target.Count);

			CacheManager<string> strCache = new CacheManager<string>(); // TODO: 初始化为适当的值
			strCache.Clear();
			strCache.Set("a", "xyz");
			strCache.Set("b", "xyz");
			Assert.AreEqual(2, strCache.Count);

			target.Clear();
			Assert.AreEqual(0, target.Count);

			strCache.Clear();
			Assert.AreEqual(0, strCache.Count);
		}

		[TestMethod()]
		public void CountTest()
		{
			CountTestHelper();
		}

		/// <summary>
		///Keys 的测试
		///</summary>
		public void KeysTestHelper()
		{
			CacheManager<int> target = new CacheManager<int>(); // TODO: 初始化为适当的值
			target.Clear();
			target.Set("a", 1);
			target.Set("b", 1);

			Assert.AreEqual(2, target.Keys.Count);

			string[] keys = target.Keys.ToArray();
			List<string> ks = new List<string>() { "a", "b" };

			for (int i = 0; i < keys.Length; i++) {
				Assert.IsTrue(ks.Contains(keys[i]));
			}
		}

		[TestMethod()]
		public void KeysTest()
		{
			KeysTestHelper();
		}
	}
}
