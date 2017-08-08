using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 系统配置表
	/// </summary>
	[Serializable]
	public partial class SysConfig : ModelBase
	{
		public override string TableName { get { return "sys_config"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _configType;
		private string _configName;
		private string _configCode;
		private string _configValue;
		private string _creator;
		private DateTime _createDate;
		private int _isEnabled;

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
		/// 
		/// </summary>
		[Column(Field = "ConfigType", Type = "varchar", Length = 32, Scale = 0)]
		public string ConfigType
		{
			get { return _configType; }
			set
			{
				OnPropertyChanging("ConfigType");
				_configType = value;
				OnPropertyChanged("ConfigType");
			}
		}

		/// <summary>
		/// 配置项名称
		/// </summary>
		[Column(Field = "ConfigName", Type = "varchar", Length = 64, Scale = 0)]
		public string ConfigName
		{
			get { return _configName; }
			set
			{
				OnPropertyChanging("ConfigName");
				_configName = value;
				OnPropertyChanged("ConfigName");
			}
		}

		/// <summary>
		/// 配置项代码
		/// </summary>
		[Column(Field = "ConfigCode", Type = "varchar", Length = 32, Scale = 0)]
		public string ConfigCode
		{
			get { return _configCode; }
			set
			{
				OnPropertyChanging("ConfigCode");
				_configCode = value;
				OnPropertyChanged("ConfigCode");
			}
		}

		/// <summary>
		/// 配置值
		/// </summary>
		[Column(Field = "ConfigValue", Type = "varchar", Length = 255, Scale = 0)]
		public string ConfigValue
		{
			get { return _configValue; }
			set
			{
				OnPropertyChanging("ConfigValue");
				_configValue = value;
				OnPropertyChanged("ConfigValue");
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

		#endregion
	}
}
