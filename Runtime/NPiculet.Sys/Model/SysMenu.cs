using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 系统菜单表
	/// </summary>
	public partial class SysMenu : ModelBase
	{
		public override string TableName { get { return "sys_menu"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _parentId;
		private int _rootId;
		private string _path;
		private string _name;
		private string _code;
		private string _icon;
		private int? _type;
		private int? _depth;
		private int? _isExternal;
		private string _url;
		private string _target;
		private string _comment;
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
		/// 父序号
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
		/// 根序号
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
		/// 编码
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
		/// 图标
		/// </summary>
		[Column(Field = "Icon", Type = "varchar", Length = -1, Scale = 0)]
		public string Icon
		{
			get { return _icon; }
			set
			{
				OnPropertyChanging("Icon");
				_icon = value;
				OnPropertyChanged("Icon");
			}
		}

		/// <summary>
		/// 类型
		/// </summary>
		[Column(Field = "Type", Type = "int", Length = 10, Scale = 0)]
		public int? Type
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
		/// 深度
		/// </summary>
		[Column(Field = "Depth", Type = "int", Length = 10, Scale = 0)]
		public int? Depth
		{
			get { return _depth; }
			set
			{
				OnPropertyChanging("Depth");
				_depth = value;
				OnPropertyChanged("Depth");
			}
		}

		/// <summary>
		/// 使用外部链接
		/// </summary>
		[Column(Field = "IsExternal", Type = "int", Length = 10, Scale = 0)]
		public int? IsExternal
		{
			get { return _isExternal; }
			set
			{
				OnPropertyChanging("IsExternal");
				_isExternal = value;
				OnPropertyChanged("IsExternal");
			}
		}

		/// <summary>
		/// 页面地址
		/// </summary>
		[Column(Field = "Url", Type = "varchar", Length = -1, Scale = 0)]
		public string Url
		{
			get { return _url; }
			set
			{
				OnPropertyChanging("Url");
				_url = value;
				OnPropertyChanged("Url");
			}
		}

		/// <summary>
		/// 目标
		/// </summary>
		[Column(Field = "Target", Type = "varchar", Length = 32, Scale = 0)]
		public string Target
		{
			get { return _target; }
			set
			{
				OnPropertyChanging("Target");
				_target = value;
				OnPropertyChanged("Target");
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		[Column(Field = "Comment", Type = "varchar", Length = -1, Scale = 0)]
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
