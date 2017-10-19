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

public partial class modules_cms_ContentEdit : AdminPage
{
	public int GroupId { get { return WebParmKit.GetQuery("gid", 0); } }
	public string GroupCode { get { return WebParmKit.GetQuery("group", ""); } }

	private readonly CmsContentBus _cbus = new CmsContentBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			InitControl();
		}
	}

	/// <summary>
	/// 初始化控件
	/// </summary>
	private void InitControl() {
		this.btnView.NavigateUrl = "~/view/" + this.Id.Value;
	}

	private void BindData()
	{
		//绑定组信息
		int gid = this.GroupId;
		string code = this.GroupCode;
		var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == gid);
		if (group == null) {
			this.AlertBeauty("没有找到数据，请检查数据完整性！");
			this.btnSave.Visible = false;
			this.btnView.Visible = false;
			return;
		}

		this.Title = group.GroupName;
		this.GroupName.Text = group.GroupName;
		//this.pThumb.Visible = false;

		//绑定数据
		var model = _cbus.GetPage(a => a.GroupCode == group.GroupCode);
		if (model != null) {
			BindKit.BindModelToContainer(this.editor, model);
			this.btnView.Visible = true;
		} else {
			this.btnView.Visible = false;
		}
	}

	/// <summary>
	/// 保存数据
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
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

			int gid = this.GroupId;
			string code = this.GroupCode;
			var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == gid);
			model.GroupCode = group.GroupCode;

			_cbus.SavePage(model);

			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");
		}

		InitControl();
	}
}