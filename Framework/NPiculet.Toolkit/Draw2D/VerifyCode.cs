using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Collections;

namespace NPiculet.Draw2D
{
	/// <summary>
	/// 生成验证码图片。
	/// </summary>
    public static class VerifyCode
    {
		/// <summary>
		/// 获取验证码图片对象。
		/// </summary>
		/// <param name="charNumber">验证字符数</param>
		/// <param name="mixNumber">背景杂点数</param>
		/// <param name="charWidth">字符宽</param>
		/// <param name="imgHeight">图片高度</param>
		/// <param name="outValue">返回值</param>
		/// <param name="bgColor">背景颜色</param>
		/// <returns></returns>
		public static Bitmap Create(int charNumber, int mixNumber, int charWidth, int imgHeight, out string outValue, Color bgColor)
        {
			outValue = String.Empty;

			Bitmap img = new Bitmap(charWidth * charNumber + charNumber, imgHeight);//建立图片
            Graphics g = Graphics.FromImage(img);//建立画板
            g.Clear(bgColor);//清理画板

			//字符随机颜色
			//Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.DarkGreen, Color.DarkOrchid, Color.Brown, Color.DarkCyan, Color.Purple };
			Color[] c = { Color.Black, Color.DarkBlue, Color.DarkGreen, Color.DarkOrchid, Color.Brown, Color.DarkCyan, Color.Purple, Color.Navy };
			//杂点随机颜色
			Color[] cs = { Color.FromArgb(128, 128, 128, 255), Color.FromArgb(128, 128, 255, 255), Color.FromArgb(128, 128, 255, 128), Color.FromArgb(128, 255, 128, 128) };
            //随机式样
            FontStyle[] fs = { FontStyle.Bold, FontStyle.Italic, FontStyle.Regular };
            //定义随机数
            Random rnd = new Random();
            //生成糙点
            for (int i = 0; i < mixNumber; i++) {
                Brush b = new SolidBrush(cs[rnd.Next(cs.Length)]);
                Pen p = new Pen(b);
				Point p1 = new Point(rnd.Next(img.Width), rnd.Next(img.Height));
				Point p2 = new Point(rnd.Next(img.Width), rnd.Next(img.Height));
                g.DrawLine(p, p1, p2);
            }
            //生成文字
			for (int i = 0; i < charNumber; i++) {
				//设置字体
				Font f = new Font(FontFamily.GenericSerif, charWidth, fs[rnd.Next(3)]);
                Brush b = new SolidBrush(c[rnd.Next(c.Length)]);

				//生成随机字符
				string chars = "123456789abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
				int index = rnd.Next(chars.Length);
				string chr = chars.Substring(index, 1);

				outValue += chr;
				g.DrawString(chr, f, b, i * charWidth, rnd.Next(imgHeight - imgHeight / 2) - 6);
            }

            g.Dispose();
			return img;
        }

		/// <summary>
		/// 获取验证码图片对象。
		/// </summary>
		/// <param name="charNumber">验证字符数</param>
		/// <param name="mixNumber">背景杂点数</param>
		/// <param name="charWidth">字符宽</param>
		/// <param name="imgHeight">图片高度</param>
		/// <param name="outValue">返回值</param>
		/// <returns></returns>
		public static Bitmap Create(int charNumber, int mixNumber, int charWidth, int imgHeight, out string outValue)
		{
			return Create(charNumber, mixNumber, charWidth, imgHeight, out outValue, Color.White);
		}

		/// <summary>
		/// 获取验证码图片对象。
		/// </summary>
		/// <param name="charNumber">验证字符数</param>
		/// <param name="mixNumber">背景杂点数</param>
		/// <param name="outValue">返回值</param>
		/// <param name="bgColor">背景颜色</param>
		/// <returns></returns>
		public static Bitmap Create(int charNumber, int mixNumber, out string outValue, Color bgColor) {
			return Create(charNumber, mixNumber, 10, 17, out outValue, bgColor);
		}

		/// <summary>
		/// 获取验证码图片对象。
		/// </summary>
		/// <param name="charNumber">验证字符数</param>
		/// <param name="mixNumber">背景杂点数</param>
		/// <param name="outValue">返回值</param>
		/// <returns></returns>
		public static Bitmap Create(int charNumber, int mixNumber, out string outValue)
		{
			return Create(charNumber, mixNumber, 10, 17, out outValue, Color.White);
		}
	}
}
