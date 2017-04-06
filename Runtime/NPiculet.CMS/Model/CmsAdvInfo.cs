using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CmsAdvInfo : ModelBase
	{
		public override string TableName { get { return "cms_adv_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _type;
		private string _description;
		private string _image;
		private string _url;
		private int _click;
		private int _isEnabled;
		private int? _orderBy;
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
		/// 
		/// </summary>
		[Column(Field = "Description", Type = "text", Length = 16, Scale = 0)]
		public string Description
		{
			get { return _description; }
			set
			{
				OnPropertyChanging("Description");
				_description = value;
				OnPropertyChanged("Description");
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
