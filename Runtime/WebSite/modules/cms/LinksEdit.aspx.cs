using System;
using System.Data;
using System.IO;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

namespace modules.info
{
	public partial class LinksEdit : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				this.Id.Value = WebParmKit.GetQuery("key", "");
				BindType();
				BindData();
			}
		}

		private void BindType() {
			var dbus = new DictBus();
			var data = dbus.GetDictItemList("ExtLinkType");
			BindKit.BindToListControl(this.Type, data, "Name", "Code");
		}

		private void BindData() {
			var id = ConvertKit.ConvertValue(this.Id.Value, 0);
			if (id > 0) {
				using (var db = new NPiculetEntities()) {
					var model = db.cms_friendlinks_info.FirstOrDefault(a => a.Id == id);
					if (model != null) {
						BindKit.BindModelToContainer(this.editor, model);
						ShowThumb(model.Image);
					}
				}
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid) return;

			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			cms_friendlinks_info model;

			using (var db = new NPiculetEntities()) {
				if (id == 0) {
					model = new cms_friendlinks_info();
					model.Click = 0;
					model.IsEnabled = 1;
					model.CreateDate = DateTime.Now;
					model.Creator = this.CurrentUserName;
				} else {
					model = db.cms_friendlinks_info.FirstOrDefault(a => a.Id == id);
				}
				BindKit.FillModelFromContainer(this.editor, model);

				if (!string.IsNullOrEmpty(this.AdvImage.FileName)) {
					//清理老图像
					if (!string.IsNullOrEmpty(this.PreviewImage.ImageUrl)) {
						var f = new FileInfo(Server.MapPath(this.PreviewImage.ImageUrl));
						if (f.Exists) f.Delete();
					}
					//更新新图
					int defaultWidth = new ConfigManager().GetConfig<int>("ImageWidth");
					if (defaultWidth < 1) defaultWidth = 1000;
					model.Image = FileWebKit.SaveZoomImage(this.AdvImage.PostedFile, defaultWidth);
				}

				db.SaveChanges();

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