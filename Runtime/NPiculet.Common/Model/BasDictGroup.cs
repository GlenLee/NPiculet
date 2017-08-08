using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 字典分组
	/// </summary>
	[Serializable]
	public partial class BasDictGroup : ModelBase
	{
		public override string TableName { get { return "bas_dict_group"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _code;
		private string _name;
		private string _displayMode;
		private string _memo;
		private int _isEntity;
		private string _entityCode;
		private int _isDel;
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
		/// 字典组名称
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
		/// 展示方式
		/// </summary>
		[Column(Field = "DisplayMode", Type = "varchar", Length = 16, Scale = 0)]
		public string DisplayMode
		{
			get { return _displayMode; }
			set
			{
				OnPropertyChanging("DisplayMode");
				_displayMode = value;
				OnPropertyChanged("DisplayMode");
			}
		}

		/// <summary>
		/// 备注
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
		/// 是否是实体数据表
		/// </summary>
		[Column(Field = "IsEntity", Type = "int", Length = 10, Scale = 0)]
		public int IsEntity
		{
			get { return _isEntity; }
			set
			{
				OnPropertyChanging("IsEntity");
				_isEntity = value;
				OnPropertyChanged("IsEntity");
			}
		}

		/// <summary>
		/// 实体数据表编码
		/// </summary>
		[Column(Field = "EntityCode", Type = "varchar", Length = 128, Scale = 0)]
		public string EntityCode
		{
			get { return _entityCode; }
			set
			{
				OnPropertyChanging("EntityCode");
				_entityCode = value;
				OnPropertyChanged("EntityCode");
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
