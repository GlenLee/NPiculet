using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 功能授权表
	/// </summary>
	[Serializable]
	public partial class SysAuthorization : ModelBase
	{
		public override string TableName { get { return "sys_authorization"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _targetId;
		private string _targetType;
		private int _functionId;
		private string _functionType;
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
		/// 授权对象ID：用户、角色
		/// </summary>
		[Column(Field = "TargetId", Type = "int", Length = 10, Scale = 0)]
		public int TargetId
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
		/// 授权对象类型：用户、角色
		/// </summary>
		[Column(Field = "TargetType", Type = "varchar", Length = 16, Scale = 0)]
		public string TargetType
		{
			get { return _targetType; }
			set
			{
				OnPropertyChanging("TargetType");
				_targetType = value;
				OnPropertyChanged("TargetType");
			}
		}

		/// <summary>
		/// 功能ID：菜单、功能
		/// </summary>
		[Column(Field = "FunctionId", Type = "int", Length = 10, Scale = 0)]
		public int FunctionId
		{
			get { return _functionId; }
			set
			{
				OnPropertyChanging("FunctionId");
				_functionId = value;
				OnPropertyChanged("FunctionId");
			}
		}

		/// <summary>
		/// 功能类型：菜单、功能
		/// </summary>
		[Column(Field = "FunctionType", Type = "varchar", Length = 16, Scale = 0)]
		public string FunctionType
		{
			get { return _functionType; }
			set
			{
				OnPropertyChanging("FunctionType");
				_functionType = value;
				OnPropertyChanged("FunctionType");
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

		#endregion
	}
}
