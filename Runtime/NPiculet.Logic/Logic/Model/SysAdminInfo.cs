using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 管理员表
	/// </summary>
	public partial class SysAdminInfo : ModelBase
	{
		public override string TableName { get { return "sys_admin_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _userAccount;
		private int _isEnabled;

		#endregion

		#region 数据项（访问器）

		/// <summary>
		/// 
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
		/// 用户账号
		/// </summary>
		[Column(Field = "UserAccount", Type = "varchar", Length = 32, Scale = 0)]
		public string UserAccount
		{
			get { return _userAccount; }
			set
			{
				OnPropertyChanging("UserAccount");
				_userAccount = value;
				OnPropertyChanged("UserAccount");
			}
		}

		/// <summary>
		/// 是否启用
		/// </summary>
		[Column(Field = "IsEnabled", Type = "int", Length = 10, Scale = 0)]
		public int IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				OnPropertyChanging("IsEnabled");
				_isEnabled = value;
				OnPropertyChanged("IsEnabled");
			}
		}

		#endregion
	}
}
