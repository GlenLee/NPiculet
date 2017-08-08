using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class CmsContentPage : ModelBase
	{
		public override string TableName { get { return "cms_content_page"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _orgId;
		private int _userId;
		private string _groupCode;
		private int _categoryId;
		private string _categoryName;
		private string _title;
		private string _subTitle;
		private string _content;
		private string _thumb;
		private string _source;
		private int _click;
		private int _isEnabled;
		private string _author;
		private int? _orderBy;
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
		[Column(Field = "OrgId", Type = "int", Length = 10, Scale = 0)]
		public int OrgId {
			get { return _orgId; }
			set {
				OnPropertyChanging("OrgId");
				_orgId = value;
				OnPropertyChanged("OrgId");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "UserId", Type = "int", Length = 10, Scale = 0)]
		public int UserId {
			get { return _userId; }
			set {
				OnPropertyChanging("UserId");
				_userId = value;
				OnPropertyChanged("UserId");
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
		[Column(Field = "CategoryId", Type = "int", Length = 10, Scale = 0)]
		public int CategoryId
		{
			get { return _categoryId; }
			set
			{
				OnPropertyChanging("CategoryId");
				_categoryId = value;
				OnPropertyChanged("CategoryId");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "CategoryName", Type = "varchar", Length = 64, Scale = 0)]
		public string CategoryName
		{
			get { return _categoryName; }
			set
			{
				OnPropertyChanging("CategoryName");
				_categoryName = value;
				OnPropertyChanged("CategoryName");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Title", Type = "varchar", Length = 256, Scale = 0)]
		public string Title
		{
			get { return _title; }
			set
			{
				OnPropertyChanging("Title");
				_title = value;
				OnPropertyChanged("Title");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "SubTitle", Type = "varchar", Length = 256, Scale = 0)]
		public string SubTitle
		{
			get { return _subTitle; }
			set
			{
				OnPropertyChanging("SubTitle");
				_subTitle = value;
				OnPropertyChanged("SubTitle");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Content", Type = "text", Length = 16, Scale = 0)]
		public string Content
		{
			get { return _content; }
			set
			{
				OnPropertyChanging("Content");
				_content = value;
				OnPropertyChanged("Content");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Thumb", Type = "varchar", Length = 128, Scale = 0)]
		public string Thumb
		{
			get { return _thumb; }
			set
			{
				OnPropertyChanging("Thumb");
				_thumb = value;
				OnPropertyChanged("Thumb");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Source", Type = "varchar", Length = 128, Scale = 0)]
		public string Source
		{
			get { return _source; }
			set
			{
				OnPropertyChanging("Source");
				_source = value;
				OnPropertyChanged("Source");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Click", Type = "int", Length = 10, Scale = 0)]
		public int Click
		{
			get { return _click; }
			set
			{
				OnPropertyChanging("Click");
				_click = value;
				OnPropertyChanged("Click");
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

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Author", Type = "varchar", Length = 32, Scale = 0)]
		public string Author
		{
			get { return _author; }
			set
			{
				OnPropertyChanging("Author");
				_author = value;
				OnPropertyChanged("Author");
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
