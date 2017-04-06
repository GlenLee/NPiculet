using System;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// ö����
	/// </summary>
	public class EnumItem
	{
		public string Text { get; set; }
		public string Code { get; set; }
		public int Value { get; set; }

		public override string ToString()
		{
			return string.Format("Code:{0},Value:{1},Text:{2}", this.Code, this.Value, this.Text);
		}
	}
}