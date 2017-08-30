using System;
using System.Data;
using System.IO;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class EntHireEdit : MemberPage
{
	private readonly CmsContentBus _cbus = new CmsContentBus();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack)
			return;
		this.Id.Value = WebParmKit.GetRequestString("key", 0).ToString();
		this.GroupCode.Value = WebParmKit.GetRequestString("code", "EntHire");
		BindData();
	}

	private void BindData()
	{
		//this.IsEnabled.DataSource = HireStatusHelper.AllHireStatus;
		//this.IsEnabled.DataBind();

		if (CurrentUserInfo == null)
			return;
		int dataId = WebParmKit.GetRequestString("key", 0);
		string groupCode = WebParmKit.GetRequestString("code", "");
		if (dataId > 0)
		{
			var model = _cbus.GetPage(a => a.GroupCode == groupCode && a.Id == dataId);
			if (model != null)
			{
				BindKit.BindModelToContainer(this.EntHireEditor, model);
				this.InfoTitle.Text = model.Title;
				this.IsEnabled.SelectedIndex = model.IsEnabled;
			}
		}
	}


	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid)
			return;

		var model = new cms_content_page();
		BindKit.FillModelFromContainer(this.EntHireEditor, model);
		model.IsEnabled = this.IsEnabled.SelectedIndex;

		if (model.Id == 0)
		{
			model.Title = this.InfoTitle.Text;
			model.GroupCode = this.GroupCode.Value;
			model.Click = 0;
			model.CreateDate = DateTime.Now;
			model.Author = this.CurrentUserName;

			_cbus.SavePage(model);
			this.Id.Value = model.Id.ToString();
		}
		else
		{
			model.Title = this.InfoTitle.Text;
			_cbus.SavePage(model);
		}

		this.promptControl.ShowSuccess("保存成功！");
	}

	protected void btnGoBack_Click(object sender, EventArgs e)
	{
		Response.Redirect("EntHireList.aspx");
	}
}