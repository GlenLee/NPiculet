using System;
using System.IO;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

namespace modules.info
{
	public partial class AdvEdit : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				this.Id.Value = WebParmKit.GetQuery("key", "");
				BindType();
				BindData();
			}
		}

		private void BindType()
		{
			DictBus dbus = new DictBus();
			var list = dbus.GetActiveItemList("AdPosition");
			BindKit.BindToListControl(this.Position, list, "Name", "Code");
		}

		private readonly CmsAdvBus _bus = new CmsAdvBus();

		private void BindData()
		{
			var advId = ConvertKit.ConvertValue(this.Id.Value, 0);
			if (advId > 0) {
				var model = _bus.GetAdv(advId);
				if (model != null) {
					BindKit.BindModelToContainer(this.editor, model);
					this.txtTitle.Text = model.Title;
					if (model.StartDate > DateTime.MinValue) this.StartDate.Text = model.StartDate.Value.ToString("yyyy-MM-dd");
					if (model.EndDate > DateTime.MinValue) this.EndDate.Text = model.EndDate.Value.ToString("yyyy-MM-dd");

					ShowThumb(model);
					SetControlStatus();
				}
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Page.IsValid) {
				int id = ConvertKit.ConvertValue(this.Id.Value, 0);
				cms_adv_info model;

				if (id == 0) {
					model = new cms_adv_info();
					model.Click = 0;
					model.IsEnabled = 1;
					model.CreateDate = DateTime.Now;
					model.Creator = this.CurrentUserName;
				} else {
					model = _bus.GetAdv(id);
				}

				BindKit.FillModelFromContainer(this.editor, model);

				model.Title = this.txtTitle.Text;

				int defaultWidth = new ConfigManager().GetConfig<int>("ImageWidth");

				if (!string.IsNullOrEmpty(this.BannerImage.FileName)) {
					//清理老图像
					if (!string.IsNullOrEmpty(this.PreviewImage.ImageUrl)) {
						var f = new FileInfo(Server.MapPath(this.PreviewImage.ImageUrl));
						if (f.Exists) f.Delete();
					}
					//更新新图
					//model.Image = FileWebKit.SaveFile(this.AdvImage.PostedFile);
				}

				if (!string.IsNullOrEmpty(this.BannerCover.FileName)) {
					//清理老图像
					if (!string.IsNullOrEmpty(this.PreviewCover.ImageUrl)) {
						var f = new FileInfo(Server.MapPath(this.PreviewCover.ImageUrl));
						if (f.Exists) f.Delete();
					}
					//更新新图
					//model.Image = FileWebKit.SaveFile(this.AdvImage.PostedFile);
				}

				//保存
				_bus.Save(model);

				this.Id.Value = model.Id.ToString();

				//展示缩略图
				ShowThumb(model);

				this.promptControl.ShowSuccess("保存成功！");
			}
		}

		private void ShowThumb(cms_adv_info adv)
		{
			if (!string.IsNullOrEmpty(adv.Image)) {
				this.ImageHyperLink.NavigateUrl = adv.Image;
				this.PreviewImage.ImageUrl = adv.Image;
				this.PreviewImage.Visible = true;
			} else {
				//this.PreviewImage.Visible = false;
			}

			if (!string.IsNullOrEmpty(adv.Cover)) {
				this.CoverHyperLink.NavigateUrl = adv.Cover;
				this.PreviewCover.ImageUrl = adv.Cover;
				this.PreviewCover.Visible = true;
			} else {
				//this.PreviewCover.Visible = false;
			}
		}

		protected void Position_OnSelectedIndexChanged(object sender, EventArgs e) {
			SetControlStatus();
		}

		private void SetControlStatus() {
			this.phCover.Visible = this.Position.SelectedValue == "ad.top";
		}
	}
}