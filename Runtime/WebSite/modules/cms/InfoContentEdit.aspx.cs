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

public partial class modules_info_InfoContentEdit : AdminPage
{
	[Category("业务参数"), Browsable(true), Description("栏目编码")]
	public string GroupCode { get { return WebParmKit.GetQuery("code", ""); } }

	[Category("业务参数"), Browsable(true), Description("栏目类型")]
	public string GroupType { get { return WebParmKit.GetQuery("type", ""); } }

	private readonly CmsContentBus _cbus = new CmsContentBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			string code = GroupCode;
			cms_content_group group;
			if (code.IsNumeric()) {
				int dataId = ConvertKit.ConvertValue(code, 0);
				group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == dataId);
			} else {
				group = _cbus.GetGroup(a => a.GroupCode == code);
			}
			if (group == null) {
				this.AlertBeauty("没有找到数据，请检查数据完整性！");
				this.btnSave.Visible = false;
				this.btnPublish.Visible = false;
				this.btnView.Visible = false;
				return;
			}

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

	private void BindData()
	{
		string gcode = null, code = GroupCode;

		if (code.IsNumeric()) {
			int id = ConvertKit.ConvertValue(code, 0);
			var g = _cbus.GetGroup(a => a.Id == id);
			if (g != null) gcode = g.GroupCode;
		}

		int dataId = WebParmKit.GetQuery("id", 0);
		if (dataId > 0) {
			var model = _cbus.GetPage(a => (a.GroupCode == code || a.GroupCode == gcode) && a.Id == dataId);
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
			var model = _cbus.GetPage(a => a.GroupCode == code || a.GroupCode == gcode);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.InfoTitle.Text = model.Title;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			var model = new cms_content_page();
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
			int dataId = ConvertKit.ConvertValue(code, 0);
			var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == dataId);

			if (this.GroupType.ToLower() == "content") {
				model.Title = this.InfoTitle.Text;

				_cbus.SavePageByGroup(group.GroupCode, model);
				//if (!_cbus.Update(model, "GroupCode='" + group.GroupCode + "'")) {
				//	InsertNewData(model, group);
				//}
			} else {
				if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
					InsertNewData(model, group);
				} else {
					model.Title = this.InfoTitle.Text;
					_cbus.SavePage(model);
				}
			}

			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");
		}

		InitControl();
	}

	private void InsertNewData(cms_content_page model, cms_content_group group) {
		var user = this.CurrentUserInfo;

		model.Title = this.InfoTitle.Text;
		model.GroupCode = group.GroupCode;
		model.Click = 0;
		model.CreateDate = DateTime.Now;
		model.IsEnabled = 0;
		model.OrgId = user.Organization.Id;
		model.UserId = user.Id;
		model.Author = user.Name;

		_cbus.SavePage(model);

		BindKit.BindModelToContainer(this.editor, model);

		//保存日志和加积分
		int point = ConvertKit.ConvertValue(new ConfigManager().GetConfig("NewsPoint"), 0);
		var pbus = new CmsPointBus();
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
			var p = _cbus.GetPage(a => a.Id == ConvertKit.ConvertValue(this.Id.Value, 0));
			p.IsEnabled = 1;
			_cbus.SavePage(p);
			this.IsEnabled.Checked = true;
		}
	}
}