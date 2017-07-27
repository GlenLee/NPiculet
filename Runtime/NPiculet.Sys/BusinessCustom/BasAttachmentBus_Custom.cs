using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using NPiculet.Base.EF;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class BasAttachmentBus
	{
		/// <summary>
		/// 获取文件列表
		/// </summary>
		/// <param name="moduleCode"></param>
		/// <param name="moduleId"></param>
		/// <param name="sourceCode"></param>
		/// <param name="sourceId"></param>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public List<bas_attachment> GetFileList(string moduleCode, string moduleId, string sourceCode, string sourceId, int parentId)
		{
			NPiculetEntities db = new NPiculetEntities();
			var query = (from a in db.bas_attachment
						 where a.ModuleCode == moduleCode && a.ModuleId == moduleId && a.SourceCode == sourceCode && a.SourceId == sourceId
							&& a.ParentId == parentId
						 orderby a.IsDir descending, a.CreateDate
						 select a);
			return query.ToList();
		}

		/// <summary>
		/// 获取文件列表
		/// </summary>
		/// <param name="moduleCode"></param>
		/// <param name="moduleId"></param>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public List<bas_attachment> GetFileList(string moduleCode, string moduleId, int parentId)
		{
			NPiculetEntities db = new NPiculetEntities();
			var query = (from a in db.bas_attachment
						 where a.ModuleCode == moduleCode && a.ModuleId == moduleId && a.ParentId == parentId
						 orderby a.IsDir descending, a.CreateDate
						 select a);
			return query.ToList();
		}

		/// <summary>
		/// 上传文件
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="moduleCode"></param>
		/// <param name="moduleId"></param>
		/// <param name="sourceCode"></param>
		/// <param name="sourceId"></param>
		/// <param name="parentId"></param>
		/// <param name="layer"></param>
		/// <param name="userId"></param>
		/// <param name="filepath"></param>
		/// <returns></returns>
		public bas_attachment UploadFile(HttpPostedFile hpf, string moduleCode, string moduleId, string sourceCode, string sourceId, int parentId, int layer, int userId, out string filepath)
		{
			try {
				filepath = string.Empty;

				//检查文件是否有效
				if (string.IsNullOrEmpty(hpf.FileName) || hpf.ContentLength == 0) {
					return null;
				}

				using (var db = new NPiculetEntities()) {
					//查询已有附件
					var exist = db.bas_attachment.FirstOrDefault(a => a.ModuleCode == moduleCode && a.ModuleId == moduleId && a.SourceCode == sourceCode && a.SourceId == sourceId);
					if (exist != null) {
						try {
							FileInfo file = new FileInfo(Path.Combine(exist.FilePath, exist.FileName));
							if (file.Exists) file.Delete();
						} catch { }
					}

					//上传并返回相对路径
					filepath = FileWebKit.SaveFile(hpf);

					//保存到数据表
					var att = exist ?? new bas_attachment();
					att.ParentId = parentId;
					att.UserId = userId;
					att.Mode = "File";
					att.ModuleCode = moduleCode;
					att.ModuleId = moduleId;
					att.SourceCode = sourceCode;
					att.SourceId = sourceId;
					att.Name = hpf.FileName;
					att.FilePath = Path.GetDirectoryName(filepath);
					att.FileExt = Path.GetExtension(filepath);
					att.FileName = Path.GetFileName(filepath);
					//att.FileType = hpf.ContentType;
					att.Length = hpf.ContentLength;
					att.Layer = layer;
					att.IsDir = 0;
					att.IsTmpl = 0;
					att.CreateDate = DateTime.Now;

					if (exist == null) db.bas_attachment.Add(att);
					db.SaveChanges();

					return att;
				}
			} catch (DbEntityValidationException ex) {
				throw new Exception(LinQKit.GetErrorMessage(ex), ex);
			}
		}

		/// <summary>
		/// 创建目录
		/// </summary>
		/// <param name="dirName"></param>
		/// <param name="moduleCode"></param>
		/// <param name="moduleId"></param>
		/// <param name="sourceCode"></param>
		/// <param name="sourceId"></param>
		/// <param name="parentId"></param>
		/// <param name="layer"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bas_attachment CreateDir(string dirName, string moduleCode, string moduleId, string sourceCode, string sourceId, int parentId, int layer, int userId)
		{
			try {
				//保存到数据表
				var att = new bas_attachment();
				att.ParentId = parentId;
				att.UserId = userId;
				att.Mode = "Dir";
				att.ModuleCode = moduleCode;
				att.ModuleId = moduleId;
				att.SourceCode = sourceCode;
				att.SourceId = sourceId;
				att.Name = dirName;
				att.FileName = dirName;
				att.Layer = layer;
				att.IsDir = 1;
				att.IsTmpl = 0;
				att.CreateDate = DateTime.Now;

				using (var db = new NPiculetEntities()) {
					db.bas_attachment.Add(att);
					db.SaveChanges();
				}

				return att;
			} catch (DbEntityValidationException ex) {
				throw new Exception(LinQKit.GetErrorMessage(ex), ex);
			}
		}

		/// <summary>
		/// 创建模板文件
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="moduleCode"></param>
		/// <param name="moduleId"></param>
		/// <param name="sourceCode"></param>
		/// <param name="sourceId"></param>
		/// <param name="parentId"></param>
		/// <param name="layer"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public bas_attachment CreateTmpl(string fileName, string moduleCode, string moduleId, string sourceCode, string sourceId, int parentId, int layer, int userId)
		{
			try {
				//保存到数据表
				var att = new bas_attachment();
				att.ParentId = parentId;
				att.UserId = userId;
				att.Mode = "File";
				att.ModuleCode = moduleCode;
				att.ModuleId = moduleId;
				att.SourceCode = sourceCode;
				att.SourceId = sourceId;
				att.Name = fileName;
				att.Layer = layer;
				att.IsDir = 0;
				att.IsTmpl = 1;
				att.CreateDate = DateTime.Now;

				using (var db = new NPiculetEntities()) {
					db.bas_attachment.Add(att);
					db.SaveChanges();
				}

				return att;
			} catch (DbEntityValidationException ex) {
				throw new Exception(LinQKit.GetErrorMessage(ex), ex);
			}
		}

		/// <summary>
		/// 根据ID删除附件
		/// </summary>
		/// <param name="attId"></param>
		public void DeleteAttachment(string attId)
		{
			if (!string.IsNullOrEmpty(attId)) {
				using (var db = new NPiculetEntities()) {
					int aid = ConvertKit.ConvertValue(attId, 0);
					var att = db.bas_attachment.FirstOrDefault(a => a.Id == aid);
					if (att != null) {
						db.bas_attachment.Remove(att);
						db.SaveChanges();
					}
				}
			}
		}
        /// <summary>
        /// 获取专家专业类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDir(string moduleId, int aid)
        {
            string sql = " SELECT '0' as Id, '根目录'as Name";
            sql += " UNION ALL";
            sql += " SELECT Id, Name FROM bas_attachment WHERE IsDir=1 and ModuleId='" + moduleId + "' and Id<>" + aid;
            
            return base.QuerySql(sql);
        }

		/// <summary>
		/// 获取目录信息
		/// </summary>
		/// <param name="did"></param>
		/// <returns></returns>
		public bas_attachment GetDir(int did)
		{
			using (var db = new NPiculetEntities()) {
				return db.bas_attachment.FirstOrDefault(a => a.Id == did);
			}
		}

		/// <summary>
		/// 上传模块文件
		/// </summary>
		/// <param name="hpf"></param>
		/// <param name="fileId"></param>
		public void UploadTmpl(HttpPostedFile hpf, int fileId)
		{
			using (var db = new NPiculetEntities()) {
				var att = db.bas_attachment.FirstOrDefault(a => a.Id == fileId);
				if (att != null) {
					try {
						//检查文件是否有效
						if (string.IsNullOrEmpty(hpf.FileName) || hpf.ContentLength == 0) {
							return;
						}

						//上传并返回相对路径
						string filepath = FileWebKit.SaveFile(hpf);

						//保存到数据表
						att.Name = hpf.FileName;
						att.FilePath = Path.GetDirectoryName(filepath);
						att.FileExt = Path.GetExtension(filepath);
						att.FileName = Path.GetFileName(filepath);
						//att.FileType = hpf.ContentType;
						att.Length = hpf.ContentLength;

						db.SaveChanges();
					} catch (DbEntityValidationException ex) {
						throw new Exception(LinQKit.GetErrorMessage(ex), ex);
					}
				}
			}
		}

		/// <summary>
		/// 获取所有模板文件
		/// </summary>
		/// <param name="moduleCode"></param>
		/// <param name="moduleId"></param>
		/// <returns></returns>
		public List<bas_attachment> GetTmplList(string moduleCode, string moduleId)
		{
			using (var db = new NPiculetEntities()) {
				return (from a in db.bas_attachment
						where a.ModuleCode == moduleCode && a.ModuleId == moduleId && a.IsTmpl == 1
						select a).ToList();
			}
		}
	}
}
