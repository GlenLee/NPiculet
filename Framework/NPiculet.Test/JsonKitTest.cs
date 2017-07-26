using NPiculet.Toolkit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using Newtonsoft.Json.Linq;

namespace NPiculet.Test
{


	/// <summary>
	///这是 JsonKitTest 的测试类，旨在
	///包含所有 JsonKitTest 单元测试
	///</summary>
	[TestClass()]
	public class JsonKitTest
	{
		private TestContext testContextInstance;

		/// <summary>
		///获取或设置测试上下文，上下文提供
		///有关当前测试运行及其功能的信息。
		///</summary>
		public TestContext TestContext
		{
			get {
				return testContextInstance;
			}
			set {
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
		///SerializeDynamic 的测试
		///</summary>
		[TestMethod()]
		public void SerializeDynamicTest()
		{
			string expected = "{\"id\":1,\"name\":\"abc\",\"birthday\":\"2015-01-01 00:00:00\"}";
			string actual = JsonKit.SerializeDynamic(new { id = 1, name = "abc", birthday = new DateTime(2015, 1, 1) });
			Assert.AreEqual(expected, actual);
		}

		class MyClass
		{
			public int id;
			public string name;
			public DateTime birthday { get; set; }
		}

		/// <summary>
		///Serialize 的测试
		///</summary>
		[TestMethod()]
		public void SerializeTest()
		{
			MyClass cls = new MyClass() { id = 1, name = "abc", birthday = new DateTime(2015, 1, 1) };
			string expected = "{\"id\":1,\"name\":\"abc\",\"birthday\":\"2015-01-01 00:00:00\"}";
			string actual = JsonKit.SerializeDynamic(cls);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///DeserializeDynamic 的测试
		///</summary>
		[TestMethod()]
		public void DeserializeDynamicTest()
		{
			string json = "{\"id\":1,\"name\":\"abc\",\"birthday\":\"2015-01-01 00:00:00\"}";
			dynamic actual = JsonKit.DeserializeDynamic(json);

			Assert.AreEqual(1, (int)actual.id);
			Assert.AreEqual("abc", (string)actual.name);
			Assert.AreEqual("2015-01-01 00:00:00", (string)actual.birthday);
		}

		#region 反序列化测试

		private class DateDemo
		{
			public DateTime Date { get; set; }
		}

		/// <summary>
		/// 反序列化时间测试
		/// </summary>
		[TestMethod()]
		public void DeserializeDateTimeTest()
		{
			string json = "{ \"Date\": \"2015-02-01\" }";
			var expected = new DateTime(2015, 2, 1);
			var actual = JsonKit.Deserialize<DateDemo>(json);

			Assert.AreEqual(expected, actual.Date);
		}

		[TestMethod()]
		public void DeserializeJsDateTest()
		{
			string json = "{ \"Date\": 1422720000000 }";
			var expected = new DateTime(2015, 2, 1);

			var actual = JsonKit.Deserialize<DateDemo>(json);
			Assert.AreEqual(expected, actual.Date);

			json = "{ \"Date\": \"1422720000000\" }";

			actual = JsonKit.Deserialize<DateDemo>(json);
			Assert.AreEqual(expected, actual.Date);
		}

		#endregion

		#region 转换测试

		[TestMethod]
		public void ConvertTest() {
			string json = @"{	""routes"": [
		{
			""name"": """",
			""route"": ""View/{id}.html"",
			""url"": ""~/web/ContentView.aspx""
		},
		{
			""name"": """",
			""route"": ""List/{groupCode}.html"",
			""url"": ""~/web/ContentList.aspx""
		}
	]}";
			JObject o = JObject.Parse(json);
			Console.WriteLine(o.Count);
			Console.WriteLine(o["routes"]);
			Console.WriteLine(o["routes"][0]["name"]);
			//Console.WriteLine(o["CreateDate"]);
			//Console.WriteLine(o["Drives"]);
			//Console.WriteLine(o["Drives"][0]);
		}

		#endregion
	}
}
