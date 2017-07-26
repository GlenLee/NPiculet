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
		private Image _sourceImage = null; //原图对象
		private Image _targetImage = null; //新图对象

		/// <summary>
		/// 获取或设置一个 Image 对象。
		/// </summary>
		public Image SourceImage
		{
			get { return _sourceImage; }
			set { this._sourceImage = value; }
		}

		/// <summary>
		/// 获取或设置一个 Image 对象。
		/// </summary>
		public Image TargetImage {
			get {
				if (this._targetImage == null) {
					return this._sourceImage;
				}
				return this._targetImage;
			}
		}

		public ImageBuilder(Image img)
		{ this._sourceImage = img; }

		public ImageBuilder(Stream stream)
		{
			Bitmap img = new Bitmap(stream);
			this._sourceImage = (Image)img;
		}

		/// <summary>
		/// 创建一个空图片
		/// </summary>
		/// <param name="w">图宽</param>
		/// <param name="h">图高</param>
		/// <param name="color">底色</param>
		/// <returns></returns>
		public static Image CreateEmptyImage(int w, int h, Color color)
		{
			//建立画板
			Graphics g;
			Image bmp = new Bitmap(w, h);
			g = Graphics.FromImage(bmp);
			g.Clear(color);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			return bmp;
		}

		/// <summary>
		/// 生成缩略图。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <returns>缩略图</returns>
		public void MakeThumbnailImage(int w, int h, bool autuStretching = false)
		{
			//初始化 Image 对象
			Image img = this.TargetImage;
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

			this._targetImage = img.GetThumbnailImage(w, h, null, IntPtr.Zero);
		}

		/// <summary>
		/// 生成缩略图，并根据宽度等比缩放。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <returns>缩略图</returns>
		public void MakeThumbnailImage(int w, bool autuStretching = true)
		{
			//初始化 Image 对象
			Image img = this.TargetImage;
			//取得图片的高和宽
			int img_w = img.Width;
			int img_h = img.Height;
			//等比缩放高度
			int h = Convert.ToInt32((float)w * ((float)img_h / (float)img_w));

			if (!autuStretching) {
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

			this._targetImage = img.GetThumbnailImage(w, h, null, IntPtr.Zero);
		}

		/// <summary>
		/// 获取缩放的图片。
		/// </summary>
		/// <param name="img_w">原图宽</param>
		/// <param name="img_h">原图高</param>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		/// <param name="autoEnlarge">是否自动放大，图片小于定义高宽时执行</param>
		/// <param name="autoPadding">是否自动填充空白区域</param>
		/// <param name="autuStretching">是否自动拉伸，会导致图片变形</param>
		/// <param name="cutPicture">当长宽不符合比例时，是否剪裁图片多余部分</param>
		/// <returns>缩放后的图片</returns>
		private Image CreateZoomImage(int img_w, int img_h, int w, int h, bool autoEnlarge, bool autoPadding, bool autuStretching, bool cutPicture)
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
			//初始化Image对象
			Image img = this.TargetImage;
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
		/// 生成缩放的图片。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		/// <param name="autoEnlarge">是否自动放大，图片小于定义高宽时执行</param>
		/// <param name="autoPadding">是否自动填充空白区域，不填充时图片不会维持比例</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <param name="cutPicture">当长宽不符合比例时，是否剪裁掉超出部分，以维持比例</param>
		public void MakeZoomImage(int w, int h, bool autoEnlarge, bool autoPadding, bool autuStretching, bool cutPicture)
		{
			//初始化Image对象
			Image img = this.TargetImage;
			//取得图片的高和宽
			int img_w = img.Width;
			int img_h = img.Height;

			if (!autoEnlarge && img_w < w && img_h < h) {
				if (autoPadding) {
					this._targetImage = CreateZoomImage(img_w, img_h, w, h, autoEnlarge, autoPadding, autuStretching, cutPicture);
				} else {
					this._targetImage = img;
				}
			} else {
				this._targetImage = CreateZoomImage(img_w, img_h, w, h, autoEnlarge, autoPadding, autuStretching, cutPicture);
			}
		}

		/// <summary>
		/// 生成缩放的图片，并根据宽度等比缩放。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="autoEnlarge">是否自动放大，图片小于定义高宽时执行</param>
		/// <param name="autoPadding">是否自动填充空白区域，不填充时图片不会维持比例</param>
		/// <param name="autuStretching">是否自动拉伸</param>
		/// <param name="cutPicture">当长宽不符合比例时，是否剪裁掉超出部分，以维持比例</param>
		public void MakeZoomImage(int w, bool autoEnlarge, bool autoPadding, bool autuStretching, bool cutPicture)
		{
			//初始化Image对象
			Image img = this.TargetImage;
			//取得图片的高和宽
			int img_w = img.Width;
			int img_h = img.Height;
			//等比缩放高度
			int h = Convert.ToInt32((float)w * ((float)img_h / (float)img_w));

			if (!autoEnlarge && img_w < w && img_h < h) {
				if (autoPadding) {
					this._targetImage = CreateZoomImage(img_w, img_h, w, h, autoEnlarge, autoPadding, autuStretching, cutPicture);
				} else {
					this._targetImage = img;
				}
			} else {
				this._targetImage = CreateZoomImage(img_w, img_h, w, h, autoEnlarge, autoPadding, autuStretching, cutPicture);
			}
		}

		/// <summary>
		/// 生成缩放的图片。
		/// </summary>
		/// <param name="w">新宽</param>
		/// <param name="h">新高</param>
		public void MakeZoomImage(int w, int h)
		{
			//自动放大，不填充，自动拉伸，不剪裁
			MakeZoomImage(w, h, true, false, true, false);
		}

		/// <summary>
		/// 生成缩放的图片，并根据宽度等比缩放。
		/// </summary>
		/// <param name="w">新宽</param>
		public void MakeZoomImage(int w)
		{
			//自动放大，不填充，不拉伸，不剪裁
			MakeZoomImage(w, true, false, false, false);
		}

		/// <summary>
		/// 添加文字水印。
		/// </summary>
		/// <param name="text">水印文字</param>
		/// <param name="pound">文字磅值</param>
		/// <param name="alpha">透明度（0-255 越小越透明）</param>
		/// <param name="x">文字X坐标</param>
		/// <param name="y">文字Y坐标</param>
		public void MakeWatermarkText(string text, float pound, float x, float y, int alpha = 255)
		{
			//初始化Image对象
			Image img = this.TargetImage;
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

			this._targetImage = bmp;
		}

		/// <summary>
		/// 添加图片水印。
		/// </summary>
		/// <param name="watemark">水印图片</param>
		/// <param name="x">文字X坐标</param>
		/// <param name="y">文字Y坐标</param>
		/// <param name="alpha">透明度（0-1 越小越透明）</param>
		public void MakeWatermarkImage(Image watemark, float x, float y, float alpha = 1f)
		{
			//初始化Image对象
			Image img = this.TargetImage;
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
			//添加水印
			if (alpha < 255) {
				float[][] nArray = {
					new float[] {1, 0, 0, 0, 0},
					new float[] {0, 1, 0, 0, 0},
					new float[] {0, 0, 1, 0, 0},
					new float[] {0, 0, 0, alpha, 0},
					new float[] {0, 0, 0, 0, 1}
				};
				ColorMatrix matrix = new ColorMatrix(nArray);
				ImageAttributes attributes = new ImageAttributes();
				attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				g.DrawImage(watemark, new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), watemark.Width, watemark.Height), 0, 0, watemark.Width, watemark.Height, GraphicsUnit.Pixel, attributes);
			} else {
				g.DrawImage(watemark, x, y);
			}
			g.Dispose();

			this._targetImage = bmp;
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

			if (this._targetImage != null) {
				//this._bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);//保存图片
				this._targetImage.Save(savePath, jgpEncoder, myEncoderParameters);
				return true;
			} else {
				if (this._sourceImage != null) {
					//this._img.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);//保存图片
					this._sourceImage.Save(savePath, jgpEncoder, myEncoderParameters);
					return true;
				} else {
					return false;
				}
			}
		}

		/// <summary>
		/// 保存为指定格式的图片。
		/// </summary>
		/// <param name="savePath">保存路径</param>
		/// <param name="format">图片格式</param>
		/// <returns></returns>
		public bool SaveImage(string savePath, ImageFormat format)
		{
			//设置图片质量参数
			ImageCodecInfo imageEncoder = GetEncoder(format);
			Encoder myEncoder = Encoder.Quality;
			EncoderParameters myEncoderParameters = new EncoderParameters(1);
			EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
			myEncoderParameters.Param[0] = myEncoderParameter;

			if (this._targetImage != null) {
				this._targetImage.Save(savePath, imageEncoder, myEncoderParameters);
				return true;
			} else {
				if (this._sourceImage != null) {
					this._sourceImage.Save(savePath, imageEncoder, myEncoderParameters);
					return true;
				} else {
					return false;
				}
			}
		}

		/// <summary>
		/// 清除生成的对象的内容，但保留源 SourceImage 对象。
		/// </summary>
		public void Clear()
		{
			if (this._targetImage != null) { this._targetImage = null; }
		}

		/// <summary>
		/// 销毁所有 Image 对象，释放资源。
		/// </summary>
		public void Dispose()
		{
			if (this._sourceImage != null) { this._sourceImage.Dispose(); }
			if (this._targetImage != null) { this._targetImage.Dispose(); }
			this._sourceImage = null;
			this._targetImage = null;
		}

		#region IDisposable 成员

		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		#endregion
	}
}