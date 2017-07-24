using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NPiculet.Draw2D
{
	/// <summary>
	/// 碰撞检测工具
	/// </summary>
	public class HitKit
	{
		/// <summary>
		/// 检测点是否在矩形内
		/// </summary>
		/// <returns></returns>
		public bool TestPointInRectangle(Point p, Rectangle rect)
		{
			return p.X >= rect.X && p.X <= (rect.X + rect.Width) && p.Y >= rect.Y && p.Y <= (rect.Y + rect.Height);
		}

		/// <summary>
		/// 检测点是否在圆形内
		/// </summary>
		/// <returns></returns>
		public bool TestPointInCircle(Point p, Point circleCenter, double radius)
		{
			return new GeometryKit().TwoPointDistance(p, circleCenter) <= radius;
		}
	}
}
