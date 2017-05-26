using System;
using System.Data;
using System.IO;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

namespace modules.info
{
	public partial class LinksEdit : AdminPage
	{
		readonly NPiculetEntities _db = new NPiculetEntities();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.Id.Value = WebParmKit.GetRequestString("key", 0).ToString();
				BindData();
			}
		}

		private void BindData()
		{
			var id = Convert.ToInt32(this.Id.Value);
			if (id <= 0)
				return;
			var model = _db.cms_friendlinks_info.SingleOrDefault(x => x.Id == id);
			if (model == null)
				return;
			BindKit.BindModelToContainer(this.editor, model);
			ShowThumb(model.Image);
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;
			var model = new cms_friendlinks_info();
			BindKit.FillModelFromContainer(this.editor, model);

			if (!string.IsNullOrEmpty(this.AdvImage.FileName))
			{
				//清理老图像
				if (!string.IsNullOrEmpty(this.PreviewImage.ImageUrl))
				{
					var f = new FileInfo(Server.MapPath(this.PreviewImage.ImageUrl));
					if (f.Exists) f.Delete();
				}
				//更新新图
				model.Image = FileKit.SaveThumbnailImage(this.AdvImage.PostedFile, 1024, 1024);
			}

			if (this.Id.Value == "0")
			{
				//model.Type = "";
				model.Click = 0;
				model.IsEnabled = 1;
				model.CreateDate = DateTime.Now;
				model.Creator = this.CurrentUserName;
				model = _db.cms_friendlinks_info.Add(model);
				_db.SaveChanges();
				Id.Value = model.Id.ToString();
			}
			else
			{
				_db.Entry(model).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();
			}

			ShowThumb(model.Image);
			this.promptControl.ShowSuccess("保存成功！");
		}

		private void ShowThumb(string imagePath)
		{
			if (!string.IsNullOrEmpty(imagePath))
			{
				this.ImageHyperLink.NavigateUrl = imagePath;
				this.PreviewImage.ImageUrl = imagePath;
				this.PreviewImage.Visible = true;
			}
			else
			{
				this.PreviewImage.Visible = false;
			}
		}
	}
}