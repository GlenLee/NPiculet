using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 用户表
	/// </summary>
	public partial class SysMemberInfo : ModelBase
	{
		public override string TableName { get { return "sys_member_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _userSn;
		private string _account;
		private string _password;
		private string _name;
		private string _memberLevel;
		private string _bindSource;
		private DateTime _bindDate;
		private int? _loginTimes;
		private DateTime _lastLoginDate;
		private DateTime _lastLogoutDate;
		private string _passQuestion;
		private string _passAnswer;
		private int? _failedCount;
		private DateTime _failedDate;
		private int? _orderBy;
		private int _isEnabled;
		private int _isDel;
		private string _status;
		private string _updater;
		private DateTime _updateDate;
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
		/// 序号
		/// </summary>
		[Column(Field = "UserSn", Type = "varchar", Length = 64, Scale = 0)]
		public string UserSn
		{
			get { return _userSn; }
			set
			{
				OnPropertyChanging("UserSn");
				_userSn = value;
				OnPropertyChanged("UserSn");
			}
		}

		/// <summary>
		/// 帐号
		/// </summary>
		[Column(Field = "Account", Type = "varchar", Length = 32, Scale = 0)]
		public string Account
		{
			get { return _account; }
			set
			{
				OnPropertyChanging("Account");
				_account = value;
				OnPropertyChanged("Account");
			}
		}

		/// <summary>
		/// 密码
		/// </summary>
		[Column(Field = "Password", Type = "varchar", Length = 32, Scale = 0)]
		public string Password
		{
			get { return _password; }
			set
			{
				OnPropertyChanging("Password");
				_password = value;
				OnPropertyChanged("Password");
			}
		}

		/// <summary>
		/// 名称
		/// </summary>
		[Column(Field = "Name", Type = "varchar", Length = 32, Scale = 0)]
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
		[Column(Field = "MemberLevel", Type = "varchar", Length = 16, Scale = 0)]
		public string MemberLevel
		{
			get { return _memberLevel; }
			set
			{
				OnPropertyChanging("MemberLevel");
				_memberLevel = value;
				OnPropertyChanged("MemberLevel");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "BindSource", Type = "varchar", Length = 32, Scale = 0)]
		public string BindSource
		{
			get { return _bindSource; }
			set
			{
				OnPropertyChanging("BindSource");
				_bindSource = value;
				OnPropertyChanged("BindSource");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "BindDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime BindDate
		{
			get { return _bindDate; }
			set
			{
				OnPropertyChanging("BindDate");
				_bindDate = value;
				OnPropertyChanged("BindDate");
			}
		}

		/// <summary>
		/// 登录次数
		/// </summary>
		[Column(Field = "LoginTimes", Type = "int", Length = 10, Scale = 0)]
		public int? LoginTimes
		{
			get { return _loginTimes; }
			set
			{
				OnPropertyChanging("LoginTimes");
				_loginTimes = value;
				OnPropertyChanged("LoginTimes");
			}
		}

		/// <summary>
		/// 最后登入时间
		/// </summary>
		[Column(Field = "LastLoginDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime LastLoginDate
		{
			get { return _lastLoginDate; }
			set
			{
				OnPropertyChanging("LastLoginDate");
				_lastLoginDate = value;
				OnPropertyChanged("LastLoginDate");
			}
		}

		/// <summary>
		/// 最后登出时间
		/// </summary>
		[Column(Field = "LastLogoutDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime LastLogoutDate
		{
			get { return _lastLogoutDate; }
			set
			{
				OnPropertyChanging("LastLogoutDate");
				_lastLogoutDate = value;
				OnPropertyChanged("LastLogoutDate");
			}
		}

		/// <summary>
		/// 密码问题
		/// </summary>
		[Column(Field = "PassQuestion", Type = "varchar", Length = 255, Scale = 0)]
		public string PassQuestion
		{
			get { return _passQuestion; }
			set
			{
				OnPropertyChanging("PassQuestion");
				_passQuestion = value;
				OnPropertyChanged("PassQuestion");
			}
		}

		/// <summary>
		/// 密码回答
		/// </summary>
		[Column(Field = "PassAnswer", Type = "varchar", Length = 255, Scale = 0)]
		public string PassAnswer
		{
			get { return _passAnswer; }
			set
			{
				OnPropertyChanging("PassAnswer");
				_passAnswer = value;
				OnPropertyChanged("PassAnswer");
			}
		}

		/// <summary>
		/// 登陆错误次数
		/// </summary>
		[Column(Field = "FailedCount", Type = "int", Length = 10, Scale = 0)]
		public int? FailedCount
		{
			get { return _failedCount; }
			set
			{
				OnPropertyChanging("FailedCount");
				_failedCount = value;
				OnPropertyChanged("FailedCount");
			}
		}

		/// <summary>
		/// 登陆错误时间
		/// </summary>
		[Column(Field = "FailedDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime FailedDate
		{
			get { return _failedDate; }
			set
			{
				OnPropertyChanging("FailedDate");
				_failedDate = value;
				OnPropertyChanged("FailedDate");
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
		/// 
		/// </summary>
		[Column(Field = "Status", Type = "varchar", Length = 16, Scale = 0)]
		public string Status
		{
			get { return _status; }
			set
			{
				OnPropertyChanging("Status");
				_status = value;
				OnPropertyChanged("Status");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Updater", Type = "varchar", Length = 32, Scale = 0)]
		public string Updater
		{
			get { return _updater; }
			set
			{
				OnPropertyChanging("Updater");
				_updater = value;
				OnPropertyChanged("Updater");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "UpdateDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime UpdateDate
		{
			get { return _updateDate; }
			set
			{
				OnPropertyChanging("UpdateDate");
				_updateDate = value;
				OnPropertyChanged("UpdateDate");
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
