using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 字典项
	/// </summary>
	public partial class CmsRegionInfo : ModelBase
	{
		public override string TableName { get { return "cms_region_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int? _parentId;
		private string _type;
		private string _code;
		private string _name;
		private string _zipCode;
		private int? _level;
		private int _isEnabled;
		private string _creator;
		private DateTime _createDate;

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
		/// 
		/// </summary>
		[Column(Field = "ParentId", Type = "int", Length = 10, Scale = 0)]
		public int? ParentId
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
		/// 类型：Province,City,District
		/// </summary>
		[Column(Field = "Type", Type = "varchar", Length = 16, Scale = 0)]
		public string Type
		{
			get { return _type; }
			set
			{
				OnPropertyChanging("Type");
				_type = value;
				OnPropertyChanged("Type");
			}
		}

		/// <summary>
		/// 项编码
		/// </summary>
		[Column(Field = "Code", Type = "varchar", Length = 32, Scale = 0)]
		public string Code
		{
			get { return _code; }
			set
			{
				OnPropertyChanging("Code");
				_code = value;
				OnPropertyChanged("Code");
			}
		}

		/// <summary>
		/// 属性名称
		/// </summary>
		[Column(Field = "Name", Type = "varchar", Length = 64, Scale = 0)]
		public string Name
		{
			get { return _name; }
			set
			{
				OnPropertyChanging("Name");
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "ZipCode", Type = "varchar", Length = 16, Scale = 0)]
		public string ZipCode
		{
			get { return _zipCode; }
			set
			{
				OnPropertyChanging("ZipCode");
				_zipCode = value;
				OnPropertyChanged("ZipCode");
			}
		}

		/// <summary>
		/// 
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
		/// 是否已启用
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
