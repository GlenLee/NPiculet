using System.Collections.Generic;
using NPiculet.Toolkit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace NPiculet.Test
{
    
    
    /// <summary>
    ///这是 JsonExtensionTest 的测试类，旨在
    ///包含所有 JsonExtensionTest 单元测试
    ///</summary>
	[TestClass()]
	public class JsonExtensionTest
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

		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestDataTable()
		{
			string expected; //预期值
			string actual; //实际值

			DataTable dt = new DataTable();
			dt.Columns.Add("FieldA");
			dt.Columns.Add("fieldB");
			for (int i = 0; i < 3; i++) {
				var dr = dt.NewRow();
				dr[0] = "Row" + i;
				dr[1] = i;
				dt.Rows.Add(dr);
			}

			expected = "[{\"FieldA\":\"Row0\",\"fieldB\":\"0\"},{\"FieldA\":\"Row1\",\"fieldB\":\"1\"},{\"FieldA\":\"Row2\",\"fieldB\":\"2\"}]";
			actual = dt.ToJson();
			Assert.AreEqual(expected, actual);

			expected = "[{\"fieldB\":\"0\"},{\"fieldB\":\"1\"},{\"fieldB\":\"2\"}]";
			actual = dt.ToJson("fieldB");
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestDictionary()
		{
			IDictionary value = new Dictionary<string, int>(); // TODO: 初始化为适当的值
			value.Add("demo", 1);
			value.Add("abc", 3);
			value.Add("xyz", 2);

			string[] filter = new [] { "demo", "xyz" }; //仅显示在过滤列表中的参数

			string expected = "{\"demo\":1,\"xyz\":2}";
			string actual = value.ToJson(filter);
			Assert.AreEqual(expected, actual);

			actual = JsonExtension.ToJson(value, filter);
			Assert.AreEqual(expected, actual);

			expected = "{\"demo\":1,\"abc\":3,\"xyz\":2}";
			actual = value.ToJson();
			Assert.AreEqual(expected, actual);

			expected = "{\"demo\":1}";
			actual = value.ToJson("demo");
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestArray()
		{
			string[] value = new string[2] { "demo", "xyz" };

			string expected = "[\"demo\",\"xyz\"]";
			string actual = value.ToJson();
			Assert.AreEqual(expected, actual);

			int[] ints = new int[2] {1, 2};

			expected = "[1,2]";
			actual = ints.ToJson();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestValue()
		{
			string expected; //预期值
			string actual; //实际值

			expected = "123";
			actual = 123.ToJson();
			Assert.AreEqual(expected, actual);

			expected = "\"123\"";
			actual = "123".ToJson();
			Assert.AreEqual(expected, actual);

			expected = "1.5";
			actual = 1.5.ToJson();
			Assert.AreEqual(expected, actual);

			expected = "true";
			actual = true.ToJson();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestNameValueCollection()
		{
			string expected; //预期值
			string actual; //实际值

			NameValueCollection nameValues = new NameValueCollection();
			nameValues.Add("Demo", "aaa");
			nameValues.Add("test", "bbb");

			expected = "{\"Demo\":\"aaa\",\"test\":\"bbb\"}";
			actual = nameValues.ToJson();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestEnumerable()
		{
			string expected; //预期值
			string actual; //实际值

			List<string> list = new List<string>();
			list.Add("Demo");
			list.Add("test");

			expected = "[\"Demo\",\"test\"]";
			actual = list.ToJson();
			Assert.AreEqual(expected, actual);
		}
		
		/// <summary>
		///ToJson 的测试
		///</summary>
		[TestMethod()]
		public void ToJsonTestCustomObject()
		{
			string expected; //预期值
			string actual; //实际值

			var obj = new { Name = "Demo", Value = "ok", Index = 2 };

			expected = "{\"Name\":\"Demo\",\"Value\":\"ok\",\"Index\":2}";
			actual = obj.ToJson();
			Assert.AreEqual(expected, actual);

			var objEnter = new { Name = "Demo", Value = "ok\r\nThis have enter\r\n", Index = 2 };

			expected = "{\"Name\":\"Demo\",\"Value\":\"ok\\r\\nThis have enter\\r\\n\",\"Index\":2}";
			actual = objEnter.ToJson();
			Assert.AreEqual(expected, actual);
		}

	}
}
