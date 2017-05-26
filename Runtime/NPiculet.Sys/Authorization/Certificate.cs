using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NPiculet.Logic.Sys
{
	/// <summary>
	/// ComponentGroup
	/// </summary>
	public class Certificate
	{
		public int Id;
		public string Sn;
		public string Name;
		public string Account;
		public int DeptId;
		public string DeptName;
		public int RootDeptId;
		public string RootDeptName;

		//public ReadOnlyCollection<Role> Roles { get; private set; }
		//public ReadOnlyCollection<Organization> Organizations { get; private set; }

		//public Certificate(int id, string sn, string name, string account, int deptId, string deptName, int rootDeptId, string rootDeptName, ReadOnlyCollection<Role> roles, ReadOnlyCollection<Organization> organizations)
		//{
		//	Id = id;
		//	Sn = sn;
		//	Name = name;
		//	Account = account;
		//	DeptId = deptId;
		//	DeptName = deptName;
		//	RootDeptId = rootDeptId;
		//	RootDeptName = rootDeptName;
		//	Roles = roles;
		//	Organizations = organizations;
		//}

	}
}