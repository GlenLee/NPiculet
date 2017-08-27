using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPiculet.Authorization
{
	public class Organization
	{
		public int Id;
		public string Code;
		public string Name;
		public string FullName;

		public int RootId;
		public int ParentId;
		public int Layer;
		public string Path;
	}
}
