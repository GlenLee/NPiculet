using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class CmsContentGroup : ModelBase
	{
		public override string TableName { get { return "cms_content_group"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _groupCode;
		private string _groupName;
		private string _groupType;
		private int? _parentId;
		private int? _layer;
		private string _path;
		private string _icon;
		private string _url;
		private int? _isExternal;
		private int? _isShow;
		private string _comment;
		private int? _orderBy;
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
		/// 
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
		/// 
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
		/// 
		/// </summary>
		[Column(Field = "GroupType", Type = "varchar", Length = 16, Scale = 0)]
		public string GroupType
		{
			get { return _groupType; }
			set
			{
				OnPropertyChanging("GroupType");
				_groupType = value;
				OnPropertyChanged("GroupType");
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
		/// 
		/// </summary>
		[Column(Field = "Layer", Type = "int", Length = 10, Scale = 0)]
		public int? Layer
		{
			get { return _layer; }
			set
			{
				OnPropertyChanging("Layer");
				_layer = value;
				OnPropertyChanged("Layer");
			}
		}

		/// <summary>
		/// 
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
		/// 
		/// </summary>
		[Column(Field = "Icon", Type = "varchar", Length = 128, Scale = 0)]
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
		/// 
		/// </summary>
		[Column(Field = "Url", Type = "varchar", Length = 255, Scale = 0)]
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
		/// 
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
		/// 
		/// </summary>
		[Column(Field = "IsShow", Type = "int", Length = 10, Scale = 0)]
		public int? IsShow
		{
			get { return _isShow; }
			set
			{
				OnPropertyChanging("IsShow");
				_isShow = value;
				OnPropertyChanged("IsShow");
			}
		}

		/// <summary>
		/// 
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
		/// 
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
		/// 
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
