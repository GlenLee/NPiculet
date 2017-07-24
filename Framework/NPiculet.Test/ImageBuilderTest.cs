using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPiculet.Draw2D;
using System.Drawing;
using System.Drawing.Imaging;

namespace NPiculet.Test
{
	[TestClass]
	public class ImageBuilderTest
	{
		[TestMethod]
		public void TestImageBuilder()
		{
			//要记得及时销毁图片，否则会一直占用内存
			using (Image img = ImageBuilder.CreateEmptyImage(1000, 1000, Color.GreenYellow)) {

				//要记得及时销毁Builder对象，否则其中的图片会一直占用内存
				using (ImageBuilder builder = new ImageBuilder(img)) {

					img.Save(@"D:\temp\testbg.jpg");

					builder.MakeWatermarkText("测试", 9, 10, 10);
					builder.MakeWatermarkText("测试透明度", 9, 20, 100, 128);

					Random rnd = new Random();
					for (int i = 0; i < 100; i++) {
						Image watemark = ImageBuilder.CreateEmptyImage(20, 20, Color.Red);
						builder.MakeWatermarkImage(watemark, rnd.Next(0, img.Width), rnd.Next(0, img.Height), 0.5f);
					}
					builder.SaveImage(@"D:\temp\test2.jpg");

					builder.MakeZoomImage(640, 640, true, false, true, false);
					builder.SaveImage(@"D:\temp\test3.jpg");

					builder.MakeThumbnailImage(320, 240, true);
					builder.SaveImage(@"D:\temp\test1.jpg");
				}

			}

			for (int i = 1; i <= 7; i++) {
				MakeZoom(i);
				MakeZoomPng(i);
			}
		}

		private static void MakeZoom(int index)
		{
			try {
				using (ImageBuilder mBuilder = new ImageBuilder(Image.FromFile($@"D:\temp\test-source{index}.jpg"))) {
					mBuilder.MakeZoomImage(800, 600);
					mBuilder.SaveImage($@"D:\temp\test-t{index}.jpg");
				}
			} catch {
				// ignored
			}
		}

		private static void MakeZoomPng(int index)
		{
			try {
				using (ImageBuilder mBuilder = new ImageBuilder(Image.FromFile($@"D:\temp\test-source{index}.jpg"))) {
					mBuilder.MakeZoomImage(800, 600);
					mBuilder.SaveImage($@"D:\temp\test-v{index}.png", ImageFormat.Png);
				}
			} catch {
				// ignored
			}
		}
	}
}
