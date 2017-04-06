using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NPiculet.Draw2D
{
	/// <summary>
	/// 几何工具
	/// </summary>
	public class GeometryKit
	{
		/// <summary>
		/// 获取两点之间的距离
		/// </summary>
		/// <returns></returns>
		public double GetTwoPointDistance(Point p1, Point p2)
		{
			return Math.Sqrt(Math.Abs(p1.X - p2.X) * Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y) * Math.Abs(p1.Y - p2.Y));
		}
	}
}
