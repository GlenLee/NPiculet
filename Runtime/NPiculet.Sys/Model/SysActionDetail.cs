using System;

namespace NPiculet.Logic.Data
{
	/// <summary>
	/// 操作明细表
	/// </summary>
	[Serializable]
	public partial class SysActionDetail : ModelBase
	{
		public override string TableName { get { return "sys_action_detail"; } }
		public override string PrimeKey { get { return "Id"; } }

		#region 数据项（私有属性）

		private int _id;
		private int _actionId;
		private string _fieldCode;
		private string _oldValue;
		private string _newValue;
		private string _tag;

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
		/// 动作ID
		/// </summary>
		[Column(Field = "ActionId", Type = "int", Length = 10, Scale = 0)]
		public int ActionId
		{
			get { return _actionId; }
			set
			{
				OnPropertyChanging("ActionId");
				_actionId = value;
				OnPropertyChanged("ActionId");
			}
		}

		/// <summary>
		/// 字段编码
		/// </summary>
		[Column(Field = "FieldCode", Type = "varchar", Length = 128, Scale = 0)]
		public string FieldCode
		{
			get { return _fieldCode; }
			set
			{
				OnPropertyChanging("FieldCode");
				_fieldCode = value;
				OnPropertyChanged("FieldCode");
			}
		}

		/// <summary>
		/// 旧值
		/// </summary>
		[Column(Field = "OldValue", Type = "varchar", Length = -1, Scale = 0)]
		public string OldValue
		{
			get { return _oldValue; }
			set
			{
				OnPropertyChanging("OldValue");
				_oldValue = value;
				OnPropertyChanged("OldValue");
			}
		}

		/// <summary>
		/// 新值
		/// </summary>
		[Column(Field = "NewValue", Type = "varchar", Length = -1, Scale = 0)]
		public string NewValue
		{
			get { return _newValue; }
			set
			{
				OnPropertyChanging("NewValue");
				_newValue = value;
				OnPropertyChanged("NewValue");
			}
		}

		/// <summary>
		/// 标签
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

		#endregion
	}
}
