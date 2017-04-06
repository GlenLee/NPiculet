using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 用户资料表
	/// </summary>
	public partial class SysMemberData : ModelBase
	{
		public override string TableName { get { return "sys_member_data"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _userId;
		private string _userAccount;
		private string _nickname;
		private string _birthday;
		private string _sex;
		private string _email;
		private string _mobile;
		private string _address;
		private string _memberCard;
		private string _idCard;
		private string _education;
		private string _qQ;
		private string _weixin;
		private string _weibo;
		private string _interest;
		private decimal? _pointCurrent;
		private decimal? _pointTotal;
		private decimal? _exp;
		private decimal? _cash;
		private decimal? _cost;
		private string _headIcon;
		private string _memo;
		private string _rechargeStatus;
		private int? _isDel;

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
		[Column(Field = "UserId", Type = "int", Length = 10, Scale = 0)]
		public int UserId
		{
			get { return _userId; }
			set
			{
				OnPropertyChanging("UserId");
				_userId = value;
				OnPropertyChanged("UserId");
			}
		}

		/// <summary>
		/// 用户账号
		/// </summary>
		[Column(Field = "UserAccount", Type = "varchar", Length = 32, Scale = 0)]
		public string UserAccount
		{
			get { return _userAccount; }
			set
			{
				OnPropertyChanging("UserAccount");
				_userAccount = value;
				OnPropertyChanged("UserAccount");
			}
		}

		/// <summary>
		/// 昵称
		/// </summary>
		[Column(Field = "Nickname", Type = "varchar", Length = 32, Scale = 0)]
		public string Nickname
		{
			get { return _nickname; }
			set
			{
				OnPropertyChanging("Nickname");
				_nickname = value;
				OnPropertyChanged("Nickname");
			}
		}

		/// <summary>
		/// 生日
		/// </summary>
		[Column(Field = "Birthday", Type = "varchar", Length = 16, Scale = 0)]
		public string Birthday
		{
			get { return _birthday; }
			set
			{
				OnPropertyChanging("Birthday");
				_birthday = value;
				OnPropertyChanged("Birthday");
			}
		}

		/// <summary>
		/// 性别
		/// </summary>
		[Column(Field = "Sex", Type = "varchar", Length = 8, Scale = 0)]
		public string Sex
		{
			get { return _sex; }
			set
			{
				OnPropertyChanging("Sex");
				_sex = value;
				OnPropertyChanged("Sex");
			}
		}

		/// <summary>
		/// 电子邮件
		/// </summary>
		[Column(Field = "Email", Type = "varchar", Length = 64, Scale = 0)]
		public string Email
		{
			get { return _email; }
			set
			{
				OnPropertyChanging("Email");
				_email = value;
				OnPropertyChanged("Email");
			}
		}

		/// <summary>
		/// 手机号码
		/// </summary>
		[Column(Field = "Mobile", Type = "varchar", Length = 32, Scale = 0)]
		public string Mobile
		{
			get { return _mobile; }
			set
			{
				OnPropertyChanging("Mobile");
				_mobile = value;
				OnPropertyChanged("Mobile");
			}
		}

		/// <summary>
		/// 住址
		/// </summary>
		[Column(Field = "Address", Type = "varchar", Length = 255, Scale = 0)]
		public string Address
		{
			get { return _address; }
			set
			{
				OnPropertyChanging("Address");
				_address = value;
				OnPropertyChanged("Address");
			}
		}

		/// <summary>
		/// 会员卡号
		/// </summary>
		[Column(Field = "MemberCard", Type = "varchar", Length = 32, Scale = 0)]
		public string MemberCard
		{
			get { return _memberCard; }
			set
			{
				OnPropertyChanging("MemberCard");
				_memberCard = value;
				OnPropertyChanged("MemberCard");
			}
		}

		/// <summary>
		/// 身份证
		/// </summary>
		[Column(Field = "IdCard", Type = "varchar", Length = 32, Scale = 0)]
		public string IdCard
		{
			get { return _idCard; }
			set
			{
				OnPropertyChanging("IdCard");
				_idCard = value;
				OnPropertyChanged("IdCard");
			}
		}

		/// <summary>
		/// 学历
		/// </summary>
		[Column(Field = "Education", Type = "varchar", Length = 62, Scale = 0)]
		public string Education
		{
			get { return _education; }
			set
			{
				OnPropertyChanging("Education");
				_education = value;
				OnPropertyChanged("Education");
			}
		}

		/// <summary>
		/// QQ
		/// </summary>
		[Column(Field = "QQ", Type = "varchar", Length = 16, Scale = 0)]
		public string QQ
		{
			get { return _qQ; }
			set
			{
				OnPropertyChanging("QQ");
				_qQ = value;
				OnPropertyChanged("QQ");
			}
		}

		/// <summary>
		/// MSN
		/// </summary>
		[Column(Field = "Weixin", Type = "varchar", Length = 64, Scale = 0)]
		public string Weixin
		{
			get { return _weixin; }
			set
			{
				OnPropertyChanging("Weixin");
				_weixin = value;
				OnPropertyChanged("Weixin");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Weibo", Type = "varchar", Length = 64, Scale = 0)]
		public string Weibo
		{
			get { return _weibo; }
			set
			{
				OnPropertyChanging("Weibo");
				_weibo = value;
				OnPropertyChanged("Weibo");
			}
		}

		/// <summary>
		/// 兴趣
		/// </summary>
		[Column(Field = "Interest", Type = "varchar", Length = 128, Scale = 0)]
		public string Interest
		{
			get { return _interest; }
			set
			{
				OnPropertyChanging("Interest");
				_interest = value;
				OnPropertyChanged("Interest");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "PointCurrent", Type = "decimal", Length = 16, Scale = 2)]
		public decimal? PointCurrent
		{
			get { return _pointCurrent; }
			set
			{
				OnPropertyChanging("PointCurrent");
				_pointCurrent = value;
				OnPropertyChanged("PointCurrent");
			}
		}

		/// <summary>
		/// 积分
		/// </summary>
		[Column(Field = "PointTotal", Type = "decimal", Length = 16, Scale = 2)]
		public decimal? PointTotal
		{
			get { return _pointTotal; }
			set
			{
				OnPropertyChanging("PointTotal");
				_pointTotal = value;
				OnPropertyChanged("PointTotal");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Exp", Type = "decimal", Length = 16, Scale = 2)]
		public decimal? Exp
		{
			get { return _exp; }
			set
			{
				OnPropertyChanging("Exp");
				_exp = value;
				OnPropertyChanged("Exp");
			}
		}

		/// <summary>
		/// 现金
		/// </summary>
		[Column(Field = "Cash", Type = "decimal", Length = 16, Scale = 2)]
		public decimal? Cash
		{
			get { return _cash; }
			set
			{
				OnPropertyChanging("Cash");
				_cash = value;
				OnPropertyChanged("Cash");
			}
		}

		/// <summary>
		/// 花费
		/// </summary>
		[Column(Field = "Cost", Type = "decimal", Length = 16, Scale = 2)]
		public decimal? Cost
		{
			get { return _cost; }
			set
			{
				OnPropertyChanging("Cost");
				_cost = value;
				OnPropertyChanged("Cost");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "HeadIcon", Type = "varchar", Length = 128, Scale = 0)]
		public string HeadIcon
		{
			get { return _headIcon; }
			set
			{
				OnPropertyChanging("HeadIcon");
				_headIcon = value;
				OnPropertyChanged("HeadIcon");
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		[Column(Field = "Memo", Type = "varchar", Length = 128, Scale = 0)]
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
		/// 充值状态
		/// </summary>
		[Column(Field = "RechargeStatus", Type = "varchar", Length = 16, Scale = 0)]
		public string RechargeStatus
		{
			get { return _rechargeStatus; }
			set
			{
				OnPropertyChanging("RechargeStatus");
				_rechargeStatus = value;
				OnPropertyChanged("RechargeStatus");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "IsDel", Type = "int", Length = 10, Scale = 0)]
		public int? IsDel
		{
			get { return _isDel; }
			set
			{
				OnPropertyChanging("IsDel");
				_isDel = value;
				OnPropertyChanged("IsDel");
			}
		}

		#endregion
	}
}
