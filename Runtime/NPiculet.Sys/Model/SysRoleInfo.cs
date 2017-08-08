using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 角色信息
	/// </summary>
	[Serializable]
	public partial class SysRoleInfo : ModelBase
	{
		public override string TableName { get { return "sys_role_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _roleName;
		private string _comment;
		private int _isEnabled;
		private int _isDel;
		private string _creator;
		private DateTime _createDate;

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
		/// 名称
		/// </summary>
		[Column(Field = "RoleName", Type = "varchar", Length = 32, Scale = 0)]
		public string RoleName
		{
			get { return _roleName; }
			set
			{
				OnPropertyChanging("RoleName");
				_roleName = value;
				OnPropertyChanged("RoleName");
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		[Column(Field = "Comment", Type = "varchar", Length = 255, Scale = 0)]
		public string Comment
		{
			get { return _comment; }
			set
			{
				OnPropertyChanging("Comment");
				_comment = value;
				OnPropertyChanged("Comment");
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

		/// <summary>
		/// 是否已删除
		/// </summary>
		[Column(Field = "IsDel", Type = "int", Length = 10, Scale = 0)]
		public int IsDel
		{
			get { return _isDel; }
			set
			{
				OnPropertyChanging("IsDel");
				_isDel = value;
				OnPropertyChanged("IsDel");
			}
		}

		/// <summary>
		/// 创建人
		/// </summary>
		[Column(Field = "Creator", Type = "varchar", Length = 32, Scale = 0)]
		public string Creator
		{
			get { return _creator; }
			set
			{
				OnPropertyChanging("Creator");
				_creator = value;
				OnPropertyChanged("Creator");
			}
		}

		/// <summary>
		/// 创建时间
		/// </summary>
		[Column(Field = "CreateDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set
			{
				OnPropertyChanging("CreateDate");
				_createDate = value;
				OnPropertyChanged("CreateDate");
			}
		}

		#endregion
	}
}
