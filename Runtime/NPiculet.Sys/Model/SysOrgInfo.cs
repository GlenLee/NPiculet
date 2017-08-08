using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 组织机构表
	/// </summary>
	[Serializable]
	public partial class SysOrgInfo : ModelBase
	{
		public override string TableName { get { return "sys_org_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _groupCode;
		private int _parentId;
		private int _rootId;
		private string _path;
		private string _orgName;
		private string _orgCode;
		private int? _orgType;
		private string _fullName;
		private string _alias;
		private int? _level;
		private string _address;
		private string _tel;
		private string _memo;
		private int? _point;
		private int? _orderBy;
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
		/// 组ID
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
		/// 父ID
		/// </summary>
		[Column(Field = "ParentId", Type = "int", Length = 10, Scale = 0)]
		public int ParentId
		{
			get { return _parentId; }
			set
			{
				OnPropertyChanging("ParentId");
				_parentId = value;
				OnPropertyChanged("ParentId");
			}
		}

		/// <summary>
		/// 根ID
		/// </summary>
		[Column(Field = "RootId", Type = "int", Length = 10, Scale = 0)]
		public int RootId
		{
			get { return _rootId; }
			set
			{
				OnPropertyChanging("RootId");
				_rootId = value;
				OnPropertyChanged("RootId");
			}
		}

		/// <summary>
		/// 路径
		/// </summary>
		[Column(Field = "Path", Type = "varchar", Length = -1, Scale = 0)]
		public string Path
		{
			get { return _path; }
			set
			{
				OnPropertyChanging("Path");
				_path = value;
				OnPropertyChanged("Path");
			}
		}

		/// <summary>
		/// 名称
		/// </summary>
		[Column(Field = "OrgName", Type = "varchar", Length = 64, Scale = 0)]
		public string OrgName
		{
			get { return _orgName; }
			set
			{
				OnPropertyChanging("OrgName");
				_orgName = value;
				OnPropertyChanged("OrgName");
			}
		}

		/// <summary>
		/// 编码
		/// </summary>
		[Column(Field = "OrgCode", Type = "varchar", Length = 32, Scale = 0)]
		public string OrgCode
		{
			get { return _orgCode; }
			set
			{
				OnPropertyChanging("OrgCode");
				_orgCode = value;
				OnPropertyChanged("OrgCode");
			}
		}

		/// <summary>
		/// 类型：主机构、子机构
		/// </summary>
		[Column(Field = "OrgType", Type = "int", Length = 10, Scale = 0)]
		public int? OrgType
		{
			get { return _orgType; }
			set
			{
				OnPropertyChanging("OrgType");
				_orgType = value;
				OnPropertyChanged("OrgType");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "FullName", Type = "varchar", Length = -1, Scale = 0)]
		public string FullName
		{
			get { return _fullName; }
			set
			{
				OnPropertyChanging("FullName");
				_fullName = value;
				OnPropertyChanged("FullName");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Alias", Type = "varchar", Length = 64, Scale = 0)]
		public string Alias
		{
			get { return _alias; }
			set
			{
				OnPropertyChanging("Alias");
				_alias = value;
				OnPropertyChanged("Alias");
			}
		}

		/// <summary>
		/// 子组织等级
		/// </summary>
		[Column(Field = "Level", Type = "int", Length = 10, Scale = 0)]
		public int? Level
		{
			get { return _level; }
			set
			{
				OnPropertyChanging("Level");
				_level = value;
				OnPropertyChanged("Level");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Address", Type = "varchar", Length = 256, Scale = 0)]
		public string Address
		{
			get { return _address; }
			set
			{
				OnPropertyChanging("Address");
				_address = value;
				OnPropertyChanged("Address");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Tel", Type = "varchar", Length = 128, Scale = 0)]
		public string Tel
		{
			get { return _tel; }
			set
			{
				OnPropertyChanging("Tel");
				_tel = value;
				OnPropertyChanged("Tel");
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
		/// 积分
		/// </summary>
		[Column(Field = "Point", Type = "int", Length = 10, Scale = 0)]
		public int? Point {
			get { return _point; }
			set {
				OnPropertyChanging("Point");
				_point = value;
				OnPropertyChanged("Point");
			}
		}

		/// <summary>
		/// 排序
		/// </summary>
		[Column(Field = "OrderBy", Type = "int", Length = 10, Scale = 0)]
		public int? OrderBy
		{
			get { return _orderBy; }
			set
			{
				OnPropertyChanging("OrderBy");
				_orderBy = value;
				OnPropertyChanged("OrderBy");
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
