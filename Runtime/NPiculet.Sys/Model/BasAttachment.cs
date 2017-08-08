using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class BasAttachment : ModelBase
	{
		public override string TableName { get { return "bas_attachment"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private string _moduleCode;
		private string _moduleId;
		private int? _userId;
		private string _mode;
		private string _fileName;
		private string _fileType;
		private string _filePath;
		private string _fileExt;
		private int? _length;
		private string _sourceCode;
		private string _sourceId;
		private string _description;
		private int? _isDir;
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
		[Column(Field = "ModuleCode", Type = "varchar", Length = 128, Scale = 0)]
		public string ModuleCode
		{
			get { return _moduleCode; }
			set
			{
				OnPropertyChanging("ModuleCode");
				_moduleCode = value;
				OnPropertyChanged("ModuleCode");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "ModuleId", Type = "varchar", Length = 64, Scale = 0)]
		public string ModuleId
		{
			get { return _moduleId; }
			set
			{
				OnPropertyChanging("ModuleId");
				_moduleId = value;
				OnPropertyChanged("ModuleId");
			}
		}

		/// <summary>
		/// 
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
		/// 
		/// </summary>
		[Column(Field = "Mode", Type = "varchar", Length = 16, Scale = 0)]
		public string Mode
		{
			get { return _mode; }
			set
			{
				OnPropertyChanging("Mode");
				_mode = value;
				OnPropertyChanged("Mode");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "FileName", Type = "varchar", Length = 255, Scale = 0)]
		public string FileName
		{
			get { return _fileName; }
			set
			{
				OnPropertyChanging("FileName");
				_fileName = value;
				OnPropertyChanged("FileName");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "FileType", Type = "varchar", Length = 32, Scale = 0)]
		public string FileType
		{
			get { return _fileType; }
			set
			{
				OnPropertyChanging("FileType");
				_fileType = value;
				OnPropertyChanged("FileType");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "FilePath", Type = "varchar", Length = 255, Scale = 0)]
		public string FilePath
		{
			get { return _filePath; }
			set
			{
				OnPropertyChanging("FilePath");
				_filePath = value;
				OnPropertyChanged("FilePath");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "FileExt", Type = "varchar", Length = 16, Scale = 0)]
		public string FileExt
		{
			get { return _fileExt; }
			set
			{
				OnPropertyChanging("FileExt");
				_fileExt = value;
				OnPropertyChanged("FileExt");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "Length", Type = "int", Length = 10, Scale = 0)]
		public int? Length
		{
			get { return _length; }
			set
			{
				OnPropertyChanging("Length");
				_length = value;
				OnPropertyChanged("Length");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "SourceCode", Type = "varchar", Length = 128, Scale = 0)]
		public string SourceCode
		{
			get { return _sourceCode; }
			set
			{
				OnPropertyChanging("SourceCode");
				_sourceCode = value;
				OnPropertyChanged("SourceCode");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Column(Field = "SourceId", Type = "varchar", Length = 128, Scale = 0)]
		public string SourceId
		{
			get { return _sourceId; }
			set
			{
				OnPropertyChanging("SourceId");
				_sourceId = value;
				OnPropertyChanged("SourceId");
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
		[Column(Field = "IsDir", Type = "int", Length = 10, Scale = 0)]
		public int? IsDir
		{
			get { return _isDir; }
			set
			{
				OnPropertyChanging("IsDir");
				_isDir = value;
				OnPropertyChanged("IsDir");
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
