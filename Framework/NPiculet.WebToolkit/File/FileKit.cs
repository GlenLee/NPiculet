using System;
using System.Drawing;
using System.IO;
using System.Web;
using NPiculet.Draw2D;

namespace NPiculet.Toolkit
{
	public static class FileKit
	{
		/// <summary>
		/// �����ļ�
		/// </summary>
		/// <param name="hpf"></param>
		/// <returns></returns>
		public static string SaveFile(HttpPostedFile hpf)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				string fileName = StringKit.GetStringByShortDate() + Path.GetExtension(hpf.FileName).ToLower();
				string filePath = GetNewFilePath("files", fileName);

				//�ϴ�����ͼ
				string path = HttpContext.Current.Server.MapPath(filePath);
				hpf.SaveAs(path);

				return filePath;
			}
			return "";
		}

		/// <summary>
		/// �Ƿ���ͼƬ
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static bool IsImage(string fileName)
		{
			string ext = Path.GetExtension(fileName);
			if (ext != null) {
				ext = ext.ToLower();
				return (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif");
			}
			return false;
		}

		/// <summary>
		/// ��������ͼ
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		public static string SaveThumbnailImage(HttpPostedFile hpf, int w, int h)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				if (IsImage(hpf.FileName)) {
					string fileName = StringKit.GetStringByShortDate() + ".jpg";
					string thumbPath = GetNewFilePath("thumb", fileName);

					//�ϴ�����ͼ
					using (Image bmp = Image.FromStream(hpf.InputStream)) {
						ImageBuilder builder = new ImageBuilder(bmp);
						builder.MakeThumbnailImage(w, h, false);
						builder.SaveImage(HttpContext.Current.Server.MapPath(thumbPath));
					}

					return thumbPath;
				}
			}
			return "";
		}

		/// <summary>
		/// ��������ͼ
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		public static string SaveZoomImage(HttpPostedFile hpf, int w, int h)
		{
			if (hpf != null && !string.IsNullOrEmpty(hpf.FileName)) {
				if (IsImage(hpf.FileName)) {
					string fileName = StringKit.GetStringByShortDate() + ".jpg";
					string thumbPath = GetNewFilePath("thumb", fileName);

					//�ϴ�����ͼ
					using (Image bmp = Image.FromStream(hpf.InputStream)) {
						ImageBuilder builder = new ImageBuilder(bmp);
						builder.MakeZoomImage(w, h, false, false, false, false);
						builder.SaveImage(HttpContext.Current.Server.MapPath(thumbPath));
					}

					return thumbPath;
				}
			}
			return "";
		}

		/// <summary>
		/// ��ȡ���ļ�·��
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
	}
}