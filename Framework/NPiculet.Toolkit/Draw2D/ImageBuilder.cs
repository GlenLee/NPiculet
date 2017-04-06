using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.IO;

namespace NPiculet.Draw2D
{
	/// <summary>
	/// 图片处理类，主要用于缩放图片及生成水印。
	/// </summary>
	public class ImageBuilder : IDisposable
	{
		private Image _img = null;
		private Image _bmp = null;

		/// <summary>
		/// 获取或设置一个 Image 对象。
		/// </summary>
		public Image GetImage
		{
			get { return _img; }
			set { this._img = value; }
		}

		public ImageBuilder()
		{ }

		public ImageBuilder(Image img)
		{ this._img = img; }

		public ImageBuilder(Stream stream)
		{
			Bitmap img = new Bitmap(stream);
			this._img = (Image)img;
		}

		/// <summary>
		/// 生成缩略图。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <returns>缩略图</returns>
		public void MakeThumbnailImage(int w, int h, bool autuStretching)
		{
			//初始化 Image 对象
			Image img;
			if (this._bmp == null) {
				img = this._img;
			} else {
				img = this._bmp;
			}
			if (!autuStretching) {
				//取得图片的高和宽
				int img_w = img.Width;
				int img_h = img.Height;
				//计算缩略图的高和宽
				if (img_w > img_h) {
					h = (int)(img_h * w / img_w);
				} else {
					w = (int)(img_w * h / img_h);
				}
				//设置缩略图的高和宽
				if (w > img_w) { w = img_w; }
				if (h > img_h) { h = img_h; }
			}

			this._bmp = img.GetThumbnailImage(w, h, null, IntPtr.Zero);
		}

		/// <summary>
		/// 生成缩放的图片。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		/// <param name="autoEnlarge">是否自动放大</param>
		/// <param name="autoPadding">是否自动填充空白区域</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <param name="cutPicture">当长宽不符合比例时，是否剪切图片</param>
		public void MakeZoomImage(int w, int h, bool autoEnlarge, bool autoPadding, bool autuStretching, bool cutPicture)
		{
			//初始化Image对象
			Image img;
			if (this._bmp == null) {
				img = this._img;
			} else {
				img = this._bmp;
			}
			//取得图片的高和宽
			int img_w = img.Width;
			int img_h = img.Height;

			if (!autoEnlarge && img_w < w && img_h < h) {
				if (autoPadding) {
					this._bmp = GetZoomImage(img, img_w, img_h, w, h, autoEnlarge, autoPadding, autuStretching, cutPicture);
				} else {
					this._bmp = img;
				}
			} else {
				this._bmp = GetZoomImage(img, img_w, img_h, w, h, autoEnlarge, autoPadding, autuStretching, cutPicture);
			}
		}

		/// <summary>
		/// 获取缩放的图片。
		/// </summary>
		/// <param name="img">原图</param>
		/// <param name="img_w">原图宽</param>
		/// <param name="img_h">原图高</param>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		/// <param name="autoEnlarge">是否自动放大</param>
		/// <param name="autoPadding">是否自动填充空白区域</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <param name="cutPicture">当长宽不符合比例时，是否剪切图片</param>
		/// <returns>缩放后的图片</returns>
		private Image GetZoomImage(Image img, int img_w, int img_h, int w, int h, bool autoEnlarge, bool autoPadding, bool autuStretching, bool cutPicture)
		{
			int new_h, new_w;
			if (!autoEnlarge && img_w < w && img_h < h) {
				new_h = img_h;
				new_w = img_w;
			} else {
				if (!autuStretching && !cutPicture) {
					//计算缩略图的长宽！！！！
					if (img_w > img_h) {
						new_h = (int)(img_h * w / img_w);
						new_w = w;
					} else {
						new_h = h;
						new_w = (int)(img_w * h / img_h);
					}
				} else {
					new_h = h;
					new_w = w;
				}
			}
			//建立画板
			Graphics g;
			Image bmp;
			if (autoPadding) {
				bmp = new Bitmap(w, h);
			} else {
				bmp = new Bitmap(new_w, new_h);
			}
			g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			//设置质量
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			//填充图片
			if (!cutPicture) {
				if (autoPadding && !autuStretching) {
					//填充空白区域
					int pad_w = (int)((w - new_w) / 2);
					int pad_h = (int)((h - new_h) / 2);
					g.DrawImage(img, new Rectangle(pad_w, pad_h, new_w, new_h), new Rectangle(0, 0, img_w, img_h), GraphicsUnit.Pixel);
				} else {
					//生成图片
					g.DrawImage(img, new Rectangle(0, 0, new_w, new_h), new Rectangle(0, 0, img_w, img_h), GraphicsUnit.Pixel);
				}
			} else {
				//此逻辑有错误！！！
				Point point = new Point();
				if (img_w > img_h) {
					point.X = (int)((img_w * (h / img_h) - img_h) / 2);
					point.Y = 0;
				} else {
					point.X = 0;
					point.Y = (int)((img_h * (w / img_w) - img_w) / 2);
				}
				g.DrawImage(img, new Rectangle(0, 0, new_w, new_h), new Rectangle(point.X, point.Y, img_w, img_h), GraphicsUnit.Pixel);
			}

			return bmp;
		}

		/// <summary>
		/// 添加文字水印。
		/// </summary>
		/// <param name="text">水印文字</param>
		/// <param name="pound">文字磅值</param>
		/// <param name="alpha">透明度</param>
		/// <param name="x">文字X坐标</param>
		/// <param name="y">文字Y坐标</param>
		public void MakeWatermarkText(string text, float pound, int alpha, float x, float y)
		{
			//初始化Image对象
			Image img;
			if (this._bmp == null) {
				img = this._img;
			} else {
				img = this._bmp;
			}
			//取得图片的高和宽
			int img_w = img.Width;
			int img_h = img.Height;

			//建立画板
			Graphics g;
			Image bmp = new Bitmap(img_w, img_h);
			g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			//填充图片
			g.DrawImage(img, 0, 0, img_w, img_h);
			//定义水印文字
			Font f = new Font("Arial", pound);
			Brush b = new SolidBrush(Color.FromArgb(alpha, Color.Black));
			//添加水印
			g.DrawString(text, f, b, x, y);
			g.Dispose();

			this._bmp = bmp;
		}

		/// <summary>
		/// 获取图片编码器
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo codec in codecs) {
				if (codec.FormatID == format.Guid) {
					return codec;
				}
			}
			return null;
		}

		/// <summary>
		/// 保存为 Jpeg 图片。
		/// </summary>
		/// <param name="savePath">保存路径</param>
		/// <param name="quality">图片质量，最大100L</param>
		/// <returns></returns>
		public bool SaveImage(string savePath, long quality = 95L)
		{
			//设置图片质量参数
			ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
			Encoder myEncoder = Encoder.Quality;
			EncoderParameters myEncoderParameters = new EncoderParameters(1);
			EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
			myEncoderParameters.Param[0] = myEncoderParameter;

			if (this._bmp != null) {
				//this._bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);//保存图片
				this._bmp.Save(savePath, jgpEncoder, myEncoderParameters);
				return true;
			} else {
				if (this._img != null) {
					//this._img.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);//保存图片
					this._img.Save(savePath, jgpEncoder, myEncoderParameters);
					return true;
				} else {
					return false;
				}
			}
		}

		/// <summary>
		/// 清除生成的对象的内容，但保留源 Image 对象。
		/// </summary>
		public void Clear()
		{
			if (this._bmp != null) { this._bmp = null; }
		}

		/// <summary>
		/// 销毁所有 Image 对象，释放资源。
		/// </summary>
		public void Dispose()
		{
			if (this._img != null) { this._img.Dispose(); }
			if (this._bmp != null) { this._bmp.Dispose(); }
		}

		#region IDisposable 成员

		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		#endregion
	}
}