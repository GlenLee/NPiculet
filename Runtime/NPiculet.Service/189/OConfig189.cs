using System;

namespace NPiculet.Service.E189
{
	public class OConfig189
	{
		public static string AppId = "336151150000039245";
		public static string AppSecret = "5119e52d164d4f304720414d9ed4cba4";

		public static string GetTimeStamp()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}