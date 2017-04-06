using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPiculet.Logic
{
	public class Organization
	{
		public int Id;
		public string Name;
		public string FullName;

		public int RootId;
		public int ParentId;
		public int Layer;
		public string Path;
	}
}
