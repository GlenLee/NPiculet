using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.CMS.BusinessCustom;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class modules_info_InfoContentEdit : AdminPage
{
	[Category("业务参数"), Browsable(true), Description("栏目编码")]
	public string GroupCode { get { return WebParmKit.GetQuery("code", ""); } }

	[Category("业务参数"), Browsable(true), Description("栏目类型")]
	public string GroupType { get { return WebParmKit.GetQuery("type", ""); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			string whereString, code = GroupCode;
			if (code.IsNumeric()) {
				whereString = "(GroupCode='" + code + "' or Id=" + code + ")";
			} else {
				whereString = "GroupCode='" + code + "'";
			}

			var group = _groupBus.QueryModel(whereString);
			this.GroupName.Text = group.GroupName;

			if (this.GroupType.ToLower() == "content") {
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
	private void InitControl() {
		if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
			this.btnPublish.Visible = false;
		} else {
			this.btnPublish.Visible = true;
		}
	}

	private readonly CmsContentGroupBus _groupBus = new CmsContentGroupBus();
	private readonly CmsContentPageBus _pageBus = new CmsContentPageBus();

	private void BindData()
	{
		string whereString, code = GroupCode;
		if (code.IsNumeric()) {
			whereString = "(GroupCode='" + code + "' or GroupCode IN (SELECT GroupCode FROM cms_content_group WHERE Id=" + code + "))";
		} else {
			whereString = "GroupCode='" + code + "'";
		}

		int dataId = WebParmKit.GetQuery("id", 0);
		if (dataId > 0) {
			whereString += " and Id=" + dataId;

			var model = _pageBus.QueryModel(whereString);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.InfoTitle.Text = model.Title;

				ShowThumb(model.Thumb);
			}

			this.btnView.Visible = true;
		} else {
			this.btnView.Visible = false;
		}

		if (this.GroupType.ToLower() == "content") {
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
						model.Thumb = FileWebKit.SaveZoomImage(this.Thumb.PostedFile, 1200);
					} else {
						this.Alert("您上传的不是图片！");
					}
				}
				ShowThumb(model.Thumb);
			}

			string code = GroupCode;
			var group = _groupBus.QueryModel("(GroupCode='" + code + "' or Id=" + code + ")");

			if (this.GroupType.ToLower() == "content") {
				model.Title = this.InfoTitle.Text;
				if (!_pageBus.Update(model, "GroupCode='" + group.GroupCode + "'")) {
					InsertNewData(model, group);
				}
			} else {
				if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
					InsertNewData(model, group);
				} else {
					model.Title = this.InfoTitle.Text;
					_pageBus.Update(model);
				}
			}

			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");
		}

		InitControl();
	}

	private void InsertNewData(CmsContentPage model, CmsContentGroup group) {
		var user = this.CurrentUserInfo;

		model.Title = this.InfoTitle.Text;
		model.GroupCode = group.GroupCode;
		model.CategoryId = 0;
		model.Click = 0;
		model.CreateDate = DateTime.Now;
		model.IsEnabled = 0;
		model.OrgId = user.Organization.Id;
		model.UserId = user.Id;
		model.Author = user.Name;
		model.Id = _pageBus.InsertIdentity(model);
		BindKit.BindModelToContainer(this.editor, model);

		//保存日志和加积分
		int point = ConvertKit.ConvertValue(new ConfigManager().GetWebConfig("NewsPoint"), 0);
		var pbus = new CmsPointLogBus();
		pbus.SavePointLog(this.CurrentUserInfo, "cms_content_page", model.Id.ToString(), point, "发布文章，增加积分", model.Title);
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
			return "<a href=\"InfoPageList.aspx?code=" + this.GroupCode + "\"><i class=\"sui-icon icon-tb-back\"></i>返回</a>";
		}
		return "";
	}

	protected string GetStyle()
	{
		if (this.GroupType.ToLower() == "content") {
			return " style=\"display:none;\"";
		}
		return "";
	}

	/// <summary>
	/// 发布文章
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnPublish_Click(object sender, EventArgs e) {
		if (!string.IsNullOrEmpty(this.Id.Value) && this.Id.Value != "0") {
			_pageBus.Update(new CmsContentPage() { IsEnabled = 1 }, "Id=" + this.Id.Value);
			this.IsEnabled.Checked = true;
		}
	}
}