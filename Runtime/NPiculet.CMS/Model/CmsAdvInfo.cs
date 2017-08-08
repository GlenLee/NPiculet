using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class CmsAdvInfo : ModelBase
	{
		public override string TableName { get { return "cms_adv_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _position;
		private string _title;
		private string _image;
		private string _cover;
		private string _url;
		private string _description;
		private string _css;
		private string _script;
		private int _click;
		private int _isEnabled;
		private int? _orderBy;
		private DateTime _startDate;
		private DateTime _endDate;
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
		[Column(Field = "Position", Type = "varchar", Length = 16, Scale = 0)]
		public string Position
		{
			get { return _position; }
			set
			{
				OnPropertyChanging("Position");
				_position = value;
				OnPropertyChanged("Position");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Title", Type = "varchar", Length = 255, Scale = 0)]
		public string Title {
			get { return _title; }
			set {
				OnPropertyChanging("Title");
				_title = value;
				OnPropertyChanged("Title");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Image", Type = "varchar", Length = 255, Scale = 0)]
		public string Image
		{
			get { return _image; }
			set
			{
				OnPropertyChanging("Image");
				_image = value;
				OnPropertyChanged("Image");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Cover", Type = "varchar", Length = 255, Scale = 0)]
		public string Cover {
			get { return _cover; }
			set {
				OnPropertyChanging("Cover");
				_cover = value;
				OnPropertyChanged("Cover");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Url", Type = "varchar", Length = 1000, Scale = 0)]
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
		[Column(Field = "Description", Type = "text", Length = 16, Scale = 0)]
		public string Description {
			get { return _description; }
			set {
				OnPropertyChanging("Description");
				_description = value;
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Css", Type = "text", Length = 16, Scale = 0)]
		public string Css {
			get { return _css; }
			set {
				OnPropertyChanging("Css");
				_css = value;
				OnPropertyChanged("Css");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Script", Type = "text", Length = 16, Scale = 0)]
		public string Script {
			get { return _script; }
			set {
				OnPropertyChanging("Script");
				_script = value;
				OnPropertyChanged("Script");
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
		[Column(Field = "StartDate", Type = "datetime", Length = 23, Scale = 3)]
		public DateTime StartDate {
			get { return _startDate; }
			set {
				OnPropertyChanging("StartDate");
				_startDate = value;
				OnPropertyChanged("StartDate");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "EndDate", Type = "datetime", Length = 23, Scale = 3)]
		public DateTime EndDate {
			get { return _endDate; }
			set {
				OnPropertyChanging("EndDate");
				_endDate = value;
				OnPropertyChanged("EndDate");
			}
		}

		/// <summary>
		/// 
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
		/// 
		/// </summary>
		[Column(Field = "CreateDate", Type = "datetime", Length = 23, Scale = 3)]
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
