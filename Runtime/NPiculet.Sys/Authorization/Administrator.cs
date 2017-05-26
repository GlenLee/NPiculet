using System.Collections.Generic;

namespace NPiculet.Authorization
{
	public class Administrator<TKey> : User<TKey>
	{
		/// <summary>
		/// 用户默认组织机构
		/// </summary>
		public Organization Organization;

		/// <summary>
		/// 用户所属角色列表
		/// </summary>
		public List<Role> Roles = new List<Role>();

		/// <summary>
		/// 用户所属组织机构列表
		/// </summary>
		public List<Organization> Orgs = new List<Organization>();
	}
}