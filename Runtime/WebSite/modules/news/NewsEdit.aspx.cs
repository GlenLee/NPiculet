using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_news_NewsEdit : AdminPage
{
	public string GroupCode
	{
		get { return WebParmKit.GetQuery("code", ""); }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			var bus = new CmsContentGroupBus();
			var group = bus.QueryModel("GroupCode='" + this.GroupCode + "'");
			if (group != null) {
				this.GroupName.Text = group.GroupName;
			}

			BindData();
		}
	}

	private readonly CmsContentPageBus _bus = new CmsContentPageBus();

	private void BindData()
	{
		var contentId = WebParmKit.GetRequestString("id", 0);

		if (contentId > 0) {
			var model = _bus.QueryModel("Id=" + contentId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.ContentTitle.Text = model.Title;

				ShowThumb(model.Thumb);
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = new CmsContentPage();
			BindKit.FillModelFromContainer(this.editor, model);
			model.Title = this.ContentTitle.Text;

			if (!string.IsNullOrEmpty(this.Thumb.FileName)) {
				//清理老图像
				if (!string.IsNullOrEmpty(this.PreviewThumb.ImageUrl)) {
					var f = new FileInfo(Server.MapPath(this.PreviewThumb.ImageUrl));
					if (f.Exists) f.Delete();
				}
				//更新新图
				model.Thumb = FileWebKit.SaveZoomImage(this.Thumb.PostedFile, 1024, 1024);
			}

			if (this.Id.Value == "") {
				model.GroupCode = this.GroupCode;
				model.CategoryId = 0;
				model.Click = 0;
				model.CreateDate = DateTime.Now;
				model.IsEnabled = 1;
				model.Author = this.CurrentUserName;

				_bus.Insert(model);
			} else {
				_bus.Update(model, null);
			}

			ShowThumb(model.Thumb);

			this.promptControl.ShowSuccess("保存成功！");
		}
	}

	private void ShowThumb(string thumbPath)
	{
		if (!string.IsNullOrEmpty(thumbPath)) {
			this.ThumbHyperLink.NavigateUrl = thumbPath;
			this.PreviewThumb.ImageUrl = thumbPath;
			this.PreviewThumb.Visible = true;
		} else {
			this.PreviewThumb.Visible = false;
		}
	}
}