using System;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// ö��˵������
	/// </summary>
	public class EnumText : Attribute
	{
		public string Text { get; set; }

		public EnumText(string text)
		{
			Text = text;
		}
	}

	/// <summary>
	/// ö�ٹ���
	/// </summary>
	public static class EnumKit
	{
		/// <summary>
		/// ת��Ϊö�����б�
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static EnumItem[] ToList(Type type)
		{
			var arr = Enum.GetValues(type);
			var items = new EnumItem[arr.Length];
			for (int i = 0; i < arr.Length; i++) {
				var e = arr.GetValue(i) as Enum;
				if (e != null) {
					items[i] = new EnumItem();
					items[i].Text = e.ToText();
					items[i].Code = e.ToString();
					items[i].Value = Convert.ToInt32(e);
				}
			}
			return items;
		}

		/// <summary>
		/// ת��Ϊö��˵��
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToText(this Enum value)
		{
			var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(EnumText), false);
			if (attributes.Length > 0) {
				return ((EnumText)attributes[0]).Text;
			}
			return string.Empty;
		}

		/// <summary>
		/// ת��Ϊö����
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static EnumItem ToEnumItem(this Enum value)
		{
			var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(EnumText), false);
			if (attributes.Length > 0) {
				EnumItem item = new EnumItem();
				item.Text = ((EnumText)attributes[0]).Text;
				item.Code = value.ToString();
				item.Value = Convert.ToInt32(value);
				return item;
			}
			return null;
		}

	}

}