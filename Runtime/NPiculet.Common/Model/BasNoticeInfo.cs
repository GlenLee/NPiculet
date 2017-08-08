using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class BasNoticeInfo : ModelBase
	{
		public override string TableName { get { return "bas_notice_info"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _sn;
		private string _title;
		private string _content;
		private string _noticeType;
		private string _noticeSource;
		private string _url;
		private string _senderId;
		private string _senderName;
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
		[Column(Field = "Sn", Type = "varchar", Length = 64, Scale = 0)]
		public string Sn
		{
			get { return _sn; }
			set
			{
				OnPropertyChanging("Sn");
				_sn = value;
				OnPropertyChanged("Sn");
			}
		}

		/// <summary>
		/// 标题
		/// </summary>
		[Column(Field = "Title", Type = "varchar", Length = 128, Scale = 0)]
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
		/// 内容
		/// </summary>
		[Column(Field = "Content", Type = "varchar", Length = -1, Scale = 0)]
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
		/// 类型(View查看后完成；Process处理后完成)
		/// </summary>
		[Column(Field = "NoticeType", Type = "varchar", Length = 64, Scale = 0)]
		public string NoticeType
		{
			get { return _noticeType; }
			set
			{
				OnPropertyChanging("NoticeType");
				_noticeType = value;
				OnPropertyChanged("NoticeType");
			}
		}

		/// <summary>
		/// 来源（模块名枚举）
		/// </summary>
		[Column(Field = "NoticeSource", Type = "varchar", Length = 128, Scale = 0)]
		public string NoticeSource
		{
			get { return _noticeSource; }
			set
			{
				OnPropertyChanging("NoticeSource");
				_noticeSource = value;
				OnPropertyChanged("NoticeSource");
			}
		}

		/// <summary>
		/// 跳转地址
		/// </summary>
		[Column(Field = "Url", Type = "varchar", Length = 255, Scale = 0)]
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
		/// 发送人ID
		/// </summary>
		[Column(Field = "SenderId", Type = "varchar", Length = 64, Scale = 0)]
		public string SenderId
		{
			get { return _senderId; }
			set
			{
				OnPropertyChanging("SenderId");
				_senderId = value;
				OnPropertyChanged("SenderId");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "SenderName", Type = "varchar", Length = 32, Scale = 0)]
		public string SenderName
		{
			get { return _senderName; }
			set
			{
				OnPropertyChanging("SenderName");
				_senderName = value;
				OnPropertyChanged("SenderName");
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
