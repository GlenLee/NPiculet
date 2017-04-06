using System.Collections.Generic;

namespace NPiculet.Logic
{
	public class Administrator : User
	{
		public int DeptId;
		public int DeptName;

		public List<Role> Roles = new List<Role>();
		public List<Organization> Orgs = new List<Organization>();
	}
}