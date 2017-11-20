using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class modules_cms_PageEdit : AdminPage
{
	public int GroupId { get { return WebParmKit.GetQuery("gid", 0); } }
	public string GroupCode { get { return WebParmKit.GetQuery("group", ""); } }

	private readonly CmsContentBus _cbus = new CmsContentBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {

			this.Author.Text = this.CurrentUserName;

			BindData();
			InitControl();
		}
	}

	/// <summary>
	/// 初始化控件
	/// </summary>
	private void InitControl()
	{
		if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
			this.btnPublish.Visible = false;
		} else {
			this.btnPublish.Visible = true;
			this.btnView.NavigateUrl = "~/view/" + this.Id.Value;
		}
	}

	private void BindData()
	{
		int gid = this.GroupId;
		string code = this.GroupCode;
		var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == gid);
		if (group == null) {
			this.AlertBeauty("没有找到数据，请检查数据完整性！");
			this.btnSave.Visible = false;
			this.btnPublish.Visible = false;
			this.btnView.Visible = false;
			return;
		}

		this.Title = group.GroupName;
		this.GroupName.Text = group.GroupName;

		int dataId = WebParmKit.GetQuery("id", 0);
		if (dataId > 0) {
			var model = _cbus.GetPage(a => a.GroupCode == group.GroupCode && a.Id == dataId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.InfoTitle.Text = model.Title;

				ShowThumb(model.Thumb);

				//处理置顶
				this.Sort.Checked = model.Sort == 0;
			}

			this.btnView.Visible = true;
		} else {
			this.btnView.Visible = false;
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			cms_content_page model;

			if (id == 0) {
				model = new cms_content_page();
			} else {
				model = _cbus.GetPage(a => a.Id == id);
			}

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

			//处理置顶
			model.Sort = this.Sort.Checked ? 0 : 1;

			//处理组信息
			int gid = this.GroupId;
			string code = this.GroupCode;
			var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == gid);

			if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
				InsertNewData(model, group);
			} else {
				model.Title = this.InfoTitle.Text;
				_cbus.SavePage(model);
			}

			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");
		}

		InitControl();
	}

	/// <summary>
	/// 新增数据
	/// </summary>
	/// <param name="model"></param>
	/// <param name="group"></param>
	private void InsertNewData(cms_content_page model, cms_content_group group)
	{
		var user = this.CurrentUserInfo;

		model.Id = 0;
		model.Title = this.InfoTitle.Text;
		model.GroupCode = group.GroupCode;
		model.Click = 0;
		model.CreateDate = DateTime.Now;
		model.IsEnabled = 0;
		if (user.Organization != null)
			model.OrgId = user.Organization.Id;
		model.UserId = user.Id;
		model.Author = user.Name;

		_cbus.SavePage(model);

		BindKit.BindModelToContainer(this.editor, model);

		this.Sort.Checked = model.Sort == 0;

		//保存日志和加积分
		int point = ConvertKit.ConvertValue(new ConfigManager().GetConfig("NewsPoint"), 0);
		var pbus = new CmsPointBus();
		pbus.SavePointLog(this.CurrentUserInfo, "cms_content_page", model.Id.ToString(), point, "发布文章，增加积分", model.Title);
	}

	/// <summary>
	/// 显示缩略图
	/// </summary>
	/// <param name="thumbPath"></param>
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

	/// <summary>
	/// 组合返回链接
	/// </summary>
	/// <returns></returns>
	protected string GetBackUrl() {
		int gid = this.GroupId;
		string code = this.GroupCode;
		string url = "<a href=\"PageList.aspx?";
		if (gid > 0) url += "gid=" + gid;
		if (!string.IsNullOrEmpty(code)) url += "group=" + code;
		url += "\"><i class=\"fa fa-arrow-left\"></i>返回</a>";
		return url;
	}

	/// <summary>
	/// 发布文章
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnPublish_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value) && this.Id.Value != "0") {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			_cbus.PublishPage(id);
			this.IsEnabled.Checked = true;
		}
	}
}