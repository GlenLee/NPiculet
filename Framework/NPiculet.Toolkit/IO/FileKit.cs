using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using NPiculet.Draw2D;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// �����ļ���д���������ж�
	/// </summary>
	public static class FileKit {

		#region �ļ���������

		/// <summary>
		/// ��ȡ�ı��ļ�
		/// </summary>
		/// <param name="filepath"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static string ReadTextFile(string filepath, Encoding encoding) {
			if (!string.IsNullOrEmpty(filepath)) {
				FileInfo f = new FileInfo(filepath);
				if (f.Exists) {
					using (var fs = f.OpenRead()) {
						byte[] bytes = new byte[fs.Length];
						fs.Read(bytes, 0, (int) fs.Length);
						return encoding.GetString(bytes);
					}
				}
			}
			return "";
		}

		/// <summary>
		/// ��ȡ�ı��ļ���Ĭ�ϱ���UTF-8
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns></returns>
		public static string ReadTextFile(string filepath) {
			return ReadTextFile(filepath, Encoding.UTF8);
		}

		/// <summary>
		/// �����ı��ļ�
		/// </summary>
		/// <param name="filepath"></param>
		/// <param name="content"></param>
		/// <param name="encoding"></param>
		public static void SaveTextFile(string filepath, string content, Encoding encoding)
		{
			FileInfo f = new FileInfo(filepath);
			using (var fs = f.OpenWrite()) {
				byte[] bytes = encoding.GetBytes(content);
				fs.Write(bytes, 0, bytes.Length);
				fs.Flush();
			}
		}

		/// <summary>
		/// �����ı��ļ���Ĭ�ϱ���UTF-8
		/// </summary>
		/// <param name="filepath"></param>
		/// <param name="content"></param>
		public static void SaveTextFile(string filepath, string content)
		{
			SaveTextFile(filepath, content, Encoding.UTF8);
		}

		#endregion

		#region �ļ����ͼ��

		/// <summary>
		/// �Ƿ���ͼƬ
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static bool IsImage(string fileName) {
			string ext = Path.GetExtension(fileName);
			if (ext != null) {
				ext = ext.ToLower();
				return (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif" || ext== ".tiff" || ext == ".ico");
			}
			return false;
		}

		#endregion

		#region ͼ���ļ�����

		/// <summary>
		/// ���������������ͼ��
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="savePath"></param>
		public static void SaveZoomImage(Image bmp, int w, int h, string savePath)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeZoomImage(w, h, false, false, false, false);
				builder.SaveImage(savePath);
			}
		}

		/// <summary>
		/// ���������������ͼ��
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="savePath"></param>
		/// <param name="format"></param>
		public static void SaveZoomImage(Image bmp, int w, int h, string savePath, ImageFormat format)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeZoomImage(w, h, false, false, false, false);
				builder.SaveImage(savePath, format);
			}
		}

		/// <summary>
		/// ���������������ͼ�������ݿ�ȵȱ����š�
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="savePath"></param>
		public static void SaveZoomImage(Image bmp, int w, string savePath)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeZoomImage(w, false, false, false, false);
				builder.SaveImage(savePath);
			}
		}

		/// <summary>
		/// ���������������ͼ�������ݿ�ȵȱ����š�
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="savePath"></param>
		/// <param name="format"></param>
		public static void SaveZoomImage(Image bmp, int w, string savePath, ImageFormat format)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeZoomImage(w, false, false, false, false);
				builder.SaveImage(savePath, format);
			}
		}

		/// <summary>
		/// ��������ͼ������������ʧ�϶࣬������Ҫ������ʡ�ռ�������
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="savePath"></param>
		public static void SaveThumbnailImage(Image bmp, int w, int h, string savePath)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeThumbnailImage(w, h, false);
				builder.SaveImage(savePath);
			}
		}

		/// <summary>
		/// ��������ͼ������������ʧ�϶࣬������Ҫ������ʡ�ռ�������
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="savePath"></param>
		/// <param name="format"></param>
		public static void SaveThumbnailImage(Image bmp, int w, int h, string savePath, ImageFormat format)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeThumbnailImage(w, h, false);
				builder.SaveImage(savePath, format);
			}
		}

		/// <summary>
		/// ��������ͼ������������ʧ�϶࣬������Ҫ������ʡ�ռ������������ݿ�ȵȱ����š�
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="savePath"></param>
		public static void SaveThumbnailImage(Image bmp, int w, string savePath)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeThumbnailImage(w, false);
				builder.SaveImage(savePath);
			}
		}

		/// <summary>
		/// ��������ͼ������������ʧ�϶࣬������Ҫ������ʡ�ռ������������ݿ�ȵȱ����š�
		/// </summary>
		/// <param name="bmp"></param>
		/// <param name="w"></param>
		/// <param name="savePath"></param>
		/// <param name="format"></param>
		public static void SaveThumbnailImage(Image bmp, int w, string savePath, ImageFormat format)
		{
			using (ImageBuilder builder = new ImageBuilder(bmp)) {
				builder.MakeThumbnailImage(w, false);
				builder.SaveImage(savePath, format);
			}
		}

		#endregion
	}
}