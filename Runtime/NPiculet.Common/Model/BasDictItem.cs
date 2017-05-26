using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 字典项
	/// </summary>
	public partial class BasDictItem : ModelBase
	{
		public override string TableName { get { return "bas_dict_item"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _groupCode;
		private string _code;
		private string _name;
		private string _value;
		private string _memo;
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
		/// 字典组编码
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
		/// 属性值
		/// </summary>
		[Column(Field = "Value", Type = "varchar", Length = 255, Scale = 0)]
		public string Value
		{
			get { return _value; }
			set
			{
				OnPropertyChanging("Value");
				_value = value;
				OnPropertyChanged("Value");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Memo", Type = "varchar", Length = 255, Scale = 0)]
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
