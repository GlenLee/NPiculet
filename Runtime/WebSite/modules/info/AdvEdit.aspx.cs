using System;
using System.IO;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

namespace modules.info
{
	public partial class AdvEdit : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.IsPostBack) 
				return;
			this.Id.Value = WebParmKit.GetQuery("key", 0).ToString();
			BindType();
			BindData();
		}

		private void BindType()
		{
			BasDictItemBus ibus = new BasDictItemBus();
			var list = ibus.GetDictItemList("Publicity");
			BindKit.BindToListControl(this.Type, list, "Name", "Value");
		}

		private readonly CmsAdvInfoBus _bus = new CmsAdvInfoBus();

		private void BindData()
		{
			var advId = Convert.ToInt32(this.Id.Value);
			if (advId > 0) {
				var model = _bus.QueryModel("Id=" + advId);
				if (model != null) {
					BindKit.BindModelToContainer(this.editor, model);

					ShowThumb(model.Image);
				}
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Page.IsValid) {
				var model = new CmsAdvInfo();
				BindKit.FillModelFromContainer(this.editor, model);

				if (!string.IsNullOrEmpty(this.AdvImage.FileName)) {
					//清理老图像
					if (!string.IsNullOrEmpty(this.PreviewImage.ImageUrl)) {
						var f = new FileInfo(Server.MapPath(this.PreviewImage.ImageUrl));
						if (f.Exists) f.Delete();
					}
					//更新新图
					model.Image = FileWebKit.SaveZoomImage(this.AdvImage.PostedFile, 1200);
					//model.Image = FileWebKit.SaveFile(this.AdvImage.PostedFile);
                }

				if (this.Id.Value == "0") {
					//model.Type = "";
					model.Click = 0;
					model.IsEnabled = 1;
					model.CreateDate = DateTime.Now;
					model.Creator = this.CurrentUserName;

					this.Id.Value = _bus.InsertIdentity(model).ToString();
				} else {
					_bus.Update(model, null);
				}

				ShowThumb(model.Image);

				this.promptControl.ShowSuccess("保存成功！");
			}
		}

		private void ShowThumb(string imagePath)
		{
			if (!string.IsNullOrEmpty(imagePath)) {
				this.ImageHyperLink.NavigateUrl = imagePath;
				this.PreviewImage.ImageUrl = imagePath;
				this.PreviewImage.Visible = true;
			} else {
				this.PreviewImage.Visible = false;
			}
		}
	}
}