using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 操作日志表
	/// </summary>
	public partial class SysActionLog : ModelBase
	{
		public override string TableName { get { return "sys_action_log"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _actionType;
		private string _actionAccount;
		private string _targetCode;
		private string _targetId;
		private string _iP;
		private string _tag;
		private string _comment;
		private string _status;
		private DateTime _date;

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
		/// 动作类型
		/// </summary>
		[Column(Field = "ActionType", Type = "varchar", Length = 32, Scale = 0)]
		public string ActionType
		{
			get { return _actionType; }
			set
			{
				OnPropertyChanging("ActionType");
				_actionType = value;
				OnPropertyChanged("ActionType");
			}
		}

		/// <summary>
		/// 动作账号
		/// </summary>
		[Column(Field = "ActionAccount", Type = "varchar", Length = 32, Scale = 0)]
		public string ActionAccount
		{
			get { return _actionAccount; }
			set
			{
				OnPropertyChanging("ActionAccount");
				_actionAccount = value;
				OnPropertyChanged("ActionAccount");
			}
		}

		/// <summary>
		/// 目标编码
		/// </summary>
		[Column(Field = "TargetCode", Type = "varchar", Length = 128, Scale = 0)]
		public string TargetCode
		{
			get { return _targetCode; }
			set
			{
				OnPropertyChanging("TargetCode");
				_targetCode = value;
				OnPropertyChanged("TargetCode");
			}
		}

		/// <summary>
		/// 目标ID
		/// </summary>
		[Column(Field = "TargetId", Type = "varchar", Length = 64, Scale = 0)]
		public string TargetId
		{
			get { return _targetId; }
			set
			{
				OnPropertyChanging("TargetId");
				_targetId = value;
				OnPropertyChanged("TargetId");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "IP", Type = "varchar", Length = 64, Scale = 0)]
		public string IP
		{
			get { return _iP; }
			set
			{
				OnPropertyChanging("IP");
				_iP = value;
				OnPropertyChanged("IP");
			}
		}

		/// <summary>
		/// 标签：说明状态的短语
		/// </summary>
		[Column(Field = "Tag", Type = "varchar", Length = 128, Scale = 0)]
		public string Tag
		{
			get { return _tag; }
			set
			{
				OnPropertyChanging("Tag");
				_tag = value;
				OnPropertyChanged("Tag");
			}
		}

		/// <summary>
		/// 注释
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
		/// 记录状态
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
		/// 操作时间
		/// </summary>
		[Column(Field = "Date", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime Date
		{
			get { return _date; }
			set
			{
				OnPropertyChanging("Date");
				_date = value;
				OnPropertyChanged("Date");
			}
		}

		#endregion
	}
}
