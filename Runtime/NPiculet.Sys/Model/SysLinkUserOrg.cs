using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 用户角色连接表
	/// </summary>
	public partial class SysLinkUserOrg : ModelBase
	{
		public override string TableName { get { return "sys_link_user_org"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _userId;
		private int _orgId;

		#endregion

		#region 数据项（访问器）

		/// <summary>
		/// ID
		/// </summary>
		[Column(Field = "Id", Type = "int", Length = 10, Scale = 0)]
		public int Id
		{
			get { return _id; }
			set
			{
				OnPropertyChanging("Id");
				_id = value;
				OnPropertyChanged("Id");
			}
		}

		/// <summary>
		/// 用户ID
		/// </summary>
		[Column(Field = "UserId", Type = "int", Length = 10, Scale = 0)]
		public int UserId
		{
			get { return _userId; }
			set
			{
				OnPropertyChanging("UserId");
				_userId = value;
				OnPropertyChanged("UserId");
			}
		}

		/// <summary>
		/// 组织机构ID
		/// </summary>
		[Column(Field = "OrgId", Type = "int", Length = 10, Scale = 0)]
		public int OrgId
		{
			get { return _orgId; }
			set
			{
				OnPropertyChanging("OrgId");
				_orgId = value;
				OnPropertyChanged("OrgId");
			}
		}

		#endregion
	}
}
