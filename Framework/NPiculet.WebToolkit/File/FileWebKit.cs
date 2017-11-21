using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using NPiculet.Draw2D;

namespace NPiculet.Toolkit
{
	public static class FileWebKit
	{
		#region 私有工具类

		/// <summary>
		/// 获取新文件路径
		/// </summary>
		/// <param name="dirName"></param>
		/// <param name="fileName"></param>
		/// <returns></returns>
		private static string GetNewFilePath(string dirName, string fileName)
		{
			var server = HttpContext.Current.Server;
			string filePath = "~/uploads/" + dirName + "/" + DateTime.Now.ToString("yyyyMM") + "/";

			DirectoryInfo dir = new DirectoryInfo(server.MapPath(filePath));
			if (!dir.Exists) dir.Create();

			return filePath + fileName;
		}

		#endregion

		/// <summary>
		/// 保存文件
		/// </summary>
		/// <param name="hpf"></param>
		/// <returns></returns>
		public static string SaveFile(HttpPostedFile hpf)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				string fileName = StringKit.GetStringByShortDate() + Path.GetExtension(hpf.FileName).ToLower();
				string filePath = GetNewFilePath("files", fileName);

				//上传缩略图
				string path = HttpContext.Current.Server.MapPath(filePath);
				hpf.SaveAs(path);

				return filePath;
			}
			return "";
		}

		/// <summary>
		/// 保存缩略图
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		public static string SaveThumbnailImage(HttpPostedFile hpf, int w, int h)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				if (FileKit.IsImage(hpf.FileName)) {
					string fileExt = Path.GetExtension(hpf.FileName).ToLower();
					string fileName, thumbPath;

					//上传缩略图
					using (Image bmp = Image.FromStream(hpf.InputStream)) {
						switch (fileExt) {
							case ".jpg":
							case ".jpeg":
							case ".bmp":
							case ".tiff":
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveThumbnailImage(bmp, w, h, HttpContext.Current.Server.MapPath(thumbPath));
								break;
							case ".png":
								fileName = StringKit.GetStringByShortDate() + ".png";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveThumbnailImage(bmp, w, h, HttpContext.Current.Server.MapPath(thumbPath), ImageFormat.Png);
								break;
							case ".gif":
								fileName = StringKit.GetStringByShortDate() + fileExt;
								thumbPath = GetNewFilePath("thumb", fileName);
								hpf.SaveAs(HttpContext.Current.Server.MapPath(thumbPath));
								break;
							default:
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveThumbnailImage(bmp, w, h, HttpContext.Current.Server.MapPath(thumbPath));
								break;
						}
					}

					return thumbPath;
				}
			}
			return "";
		}

		/// <summary>
		/// 保存缩略图，并只根据宽度等比缩放。
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		public static string SaveThumbnailImage(HttpPostedFile hpf, int w)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				if (FileKit.IsImage(hpf.FileName)) {
					string fileExt = Path.GetExtension(hpf.FileName).ToLower();
					string fileName, thumbPath;

					//上传缩略图
					using (Image bmp = Image.FromStream(hpf.InputStream)) {
						switch (fileExt) {
							case ".jpg":
							case ".jpeg":
							case ".bmp":
							case ".tiff":
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveThumbnailImage(bmp, w, HttpContext.Current.Server.MapPath(thumbPath));
								break;
							case ".png":
								fileName = StringKit.GetStringByShortDate() + ".png";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveThumbnailImage(bmp, w, HttpContext.Current.Server.MapPath(thumbPath), ImageFormat.Png);
								break;
							case ".gif":
								fileName = StringKit.GetStringByShortDate() + fileExt;
								thumbPath = GetNewFilePath("thumb", fileName);
								hpf.SaveAs(HttpContext.Current.Server.MapPath(thumbPath));
								break;
							default:
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveThumbnailImage(bmp, w, HttpContext.Current.Server.MapPath(thumbPath));
								break;
						}
					}

					return thumbPath;
				}
			}
			return "";
		}

		/// <summary>
		/// 保存高质量缩放图，并只根据宽度等比缩放。
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		public static string SaveZoomImage(HttpPostedFile hpf, int w, int h)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				if (FileKit.IsImage(hpf.FileName)) {
					string fileExt = Path.GetExtension(hpf.FileName).ToLower();
					string fileName, thumbPath;

					//上传缩略图
					using (Image bmp = Image.FromStream(hpf.InputStream)) {
						switch (fileExt) {
							case ".jpg":
							case ".jpeg":
							case ".bmp":
							case ".tiff":
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveZoomImage(bmp, w, h, HttpContext.Current.Server.MapPath(thumbPath));
								break;
							case ".png":
								fileName = StringKit.GetStringByShortDate() + ".png";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveZoomImage(bmp, w, h, HttpContext.Current.Server.MapPath(thumbPath), ImageFormat.Png);
								break;
							case ".gif":
								fileName = StringKit.GetStringByShortDate() + fileExt;
								thumbPath = GetNewFilePath("thumb", fileName);
								hpf.SaveAs(HttpContext.Current.Server.MapPath(thumbPath));
								break;
							default:
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveZoomImage(bmp, w, h, HttpContext.Current.Server.MapPath(thumbPath));
								break;
						}
					}

					return thumbPath;
				}
			}
			return "";
		}


		/// <summary>
		/// 保存高质量缩放图，并只根据宽度等比缩放。
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		public static string SaveZoomImage(HttpPostedFile hpf, int w)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				if (FileKit.IsImage(hpf.FileName)) {
					string fileExt = Path.GetExtension(hpf.FileName).ToLower();
					string fileName, thumbPath;

					//上传缩略图
					using (Image bmp = Image.FromStream(hpf.InputStream)) {
						switch (fileExt) {
							case ".jpg":
							case ".jpeg":
							case ".bmp":
							case ".tiff":
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveZoomImage(bmp, w, HttpContext.Current.Server.MapPath(thumbPath));
								break;
							case ".png":
								fileName = StringKit.GetStringByShortDate() + ".png";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveZoomImage(bmp, w, HttpContext.Current.Server.MapPath(thumbPath), ImageFormat.Png);
								break;
							case ".gif":
								fileName = StringKit.GetStringByShortDate() + fileExt;
								thumbPath = GetNewFilePath("thumb", fileName);
								hpf.SaveAs(HttpContext.Current.Server.MapPath(thumbPath));
								break;
							default:
								fileName = StringKit.GetStringByShortDate() + ".jpg";
								thumbPath = GetNewFilePath("thumb", fileName);
								FileKit.SaveZoomImage(bmp, w, HttpContext.Current.Server.MapPath(thumbPath));
								break;
						}
					}

					return thumbPath;
				}
			}
			return "";
		}

	}
}