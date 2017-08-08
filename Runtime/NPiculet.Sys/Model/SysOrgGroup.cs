using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 组织机构组
	/// </summary>
	[Serializable]
	public partial class SysOrgGroup : ModelBase
	{
		public override string TableName { get { return "sys_org_group"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _groupName;
		private string _groupCode;
		private string _memo;
		private int _isVirtual;
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
		[Column(Field = "GroupName", Type = "varchar", Length = 64, Scale = 0)]
		public string GroupName
		{
			get { return _groupName; }
			set
			{
				OnPropertyChanging("GroupName");
				_groupName = value;
				OnPropertyChanged("GroupName");
			}
		}

		/// <summary>
		/// 编码
		/// </summary>
		[Column(Field = "GroupCode", Type = "varchar", Length = 32, Scale = 0)]
		public string GroupCode
		{
			get { return _groupCode; }
			set
			{
				OnPropertyChanging("GroupCode");
				_groupCode = value;
				OnPropertyChanged("GroupCode");
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		[Column(Field = "Memo", Type = "varchar", Length = -1, Scale = 0)]
		public string Memo
		{
			get { return _memo; }
			set
			{
				OnPropertyChanging("Memo");
				_memo = value;
				OnPropertyChanged("Memo");
			}
		}

		/// <summary>
		/// 是否虚拟组织
		/// </summary>
		[Column(Field = "IsVirtual", Type = "int", Length = 10, Scale = 0)]
		public int IsVirtual
		{
			get { return _isVirtual; }
			set
			{
				OnPropertyChanging("IsVirtual");
				_isVirtual = value;
				OnPropertyChanged("IsVirtual");
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
