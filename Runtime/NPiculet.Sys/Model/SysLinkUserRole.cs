using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 用户角色连接表
	/// </summary>
	[Serializable]
	public partial class SysLinkUserRole : ModelBase
	{
		public override string TableName { get { return "sys_link_user_role"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _userId;
		private int _roleId;

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
		/// 角色ID
		/// </summary>
		[Column(Field = "RoleId", Type = "int", Length = 10, Scale = 0)]
		public int RoleId
		{
			get { return _roleId; }
			set
			{
				OnPropertyChanging("RoleId");
				_roleId = value;
				OnPropertyChanged("RoleId");
			}
		}

		#endregion
	}
}
