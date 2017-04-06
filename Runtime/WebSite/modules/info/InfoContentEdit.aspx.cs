using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_info_InfoContentEdit : AdminPage
{
	[Category("业务参数"), Browsable(true), Description("栏目编码")]
	public string GroupCode { get { return WebParmKit.GetRequestString("code", ""); } }

	[Category("业务参数"), Browsable(true), Description("栏目类型")]
	public string GroupType { get { return WebParmKit.GetRequestString("type", ""); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			var group = _groupBus.QueryModel("GroupCode='" + this.GroupCode + "'");
			this.GroupName.Text = group.GroupName;

			if (Request.QueryString["m"] == "content") {
				this.InfoTitle.Text = group.GroupName;
				this.pThumb.Visible = false;
			}

			BindData();

			InitControl();
		}
	}

	/// <summary>
	/// 初始化控件
	/// </summary>
	private void InitControl()
	{
		//if (WebParmKit.GetQuery("thumb", "") == "1") {
			//this.pThumb.Visible = true;
		//}
	}

	private readonly CmsContentGroupBus _groupBus = new CmsContentGroupBus();
	private readonly CmsContentPageBus _pageBus = new CmsContentPageBus();

	private void BindData()
	{
		int dataId = WebParmKit.GetRequestString("key", 0);
		if (dataId > 0) {
			string whereString = "GroupCode='" + this.GroupCode + "' and Id=" + dataId;

			var model = _pageBus.QueryModel(whereString);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.InfoTitle.Text = model.Title;

				ShowThumb(model.Thumb);
			}
		}
		if (Request.QueryString["m"] == "content") {
			string whereString = "GroupCode='" + this.GroupCode + "'";

			var model = _pageBus.QueryModel(whereString);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.InfoTitle.Text = model.Title;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = new CmsContentPage();
			BindKit.FillModelFromContainer(this.editor, model);

			if (!string.IsNullOrEmpty(this.Thumb.FileName)) {
				//清理老图像
				if (!string.IsNullOrEmpty(this.PreviewThumb.ImageUrl)) {
					var f = new FileInfo(Server.MapPath(this.PreviewThumb.ImageUrl));
					if (f.Exists) f.Delete();
				}
				//更新新图
				if (this.Thumb.PostedFile.ContentLength > 0) {
					if (FileKit.IsImage(this.Thumb.PostedFile.FileName)) {
						model.Thumb = FileKit.SaveZoomImage(this.Thumb.PostedFile, 1024, 1024);
					} else {
						this.Alert("您上传的不是图片！");
					}
				}
				ShowThumb(model.Thumb);
			}

			if (Request.QueryString["m"] == "content") {
				model.Title = this.InfoTitle.Text;
				if (!_pageBus.Update(model, "GroupCode='" + this.GroupCode + "'")) {
					model.GroupCode = this.GroupCode;
					model.CategoryId = 0;
					model.Click = 0;
					model.CreateDate = DateTime.Now;
					model.IsEnabled = 1;
					model.Author = this.CurrentUserName;
					model.Id = _pageBus.InsertIdentity(model);
					BindKit.BindModelToContainer(this.editor, model);
				}
			} else {
				if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
					model.Title = this.InfoTitle.Text;
					model.GroupCode = this.GroupCode;
					model.CategoryId = 0;
					model.Click = 0;
					model.CreateDate = DateTime.Now;
					model.IsEnabled = 1;
					model.Author = this.CurrentUserName;

					//_infoBus.Insert(model);
					model.Id = _pageBus.InsertIdentity(model);
					this.Id.Value = model.Id.ToString();
				} else {
					model.Title = this.InfoTitle.Text;
					_pageBus.Update(model, null);
				}
			}
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

	protected string GetBackUrl()
	{
		if (this.GroupType == "List") {
			return "<a href=\"InfoPageList.aspx?code=" + this.GroupCode + "\">返回</a>";
		}
		return "";
	}

	protected string GetStyle()
	{
		if (Request.QueryString["m"] == "content") {
			return " style=\"display:none;\"";
		}
		return "";
	}
}