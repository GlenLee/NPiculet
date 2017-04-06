using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CmsNoticeRecord : ModelBase
	{
		public override string TableName { get { return "cms_notice_record"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _noticeSn;
		private int? _userId;
		private int? _isRead;
		private DateTime _readDate;

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
		[Column(Field = "NoticeSn", Type = "varchar", Length = 64, Scale = 0)]
		public string NoticeSn
		{
			get { return _noticeSn; }
			set
			{
				OnPropertyChanging("NoticeSn");
				_noticeSn = value;
				OnPropertyChanged("NoticeSn");
			}
		}

		/// <summary>
		/// 目标ID
		/// </summary>
		[Column(Field = "UserId", Type = "int", Length = 10, Scale = 0)]
		public int? UserId
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
		/// 是否已读
		/// </summary>
		[Column(Field = "IsRead", Type = "int", Length = 10, Scale = 0)]
		public int? IsRead
		{
			get { return _isRead; }
			set
			{
				OnPropertyChanging("IsRead");
				_isRead = value;
				OnPropertyChanged("IsRead");
			}
		}

		/// <summary>
		/// 已读时间
		/// </summary>
		[Column(Field = "ReadDate", Type = "datetime2", Length = 27, Scale = 7)]
		public DateTime ReadDate
		{
			get { return _readDate; }
			set
			{
				OnPropertyChanging("ReadDate");
				_readDate = value;
				OnPropertyChanged("ReadDate");
			}
		}

		#endregion
	}
}
