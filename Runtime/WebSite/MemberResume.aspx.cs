using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Authorization;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class MemberResume : MemberPage
{
	private const string JOBSEEKER_CODE = "PageJobSeeker";

	private readonly CmsContentBus _cbus = new CmsContentBus();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack)
			return;
		BindData();
	}

	private void BindData()
	{
		//this.IsEnabled.DataSource = HireStatusHelper.AllHireStatus;
		//this.IsEnabled.DataBind();

		var model = GetResumeModelFromDb();
		if (model != null)
		{
			BindKit.BindModelToContainer(this.MemberResumeEditor, model);
			this.InfoTitle.Text = model.Title;
			this.IsEnabled.SelectedIndex = model.IsEnabled;
		}
	}


	private cms_content_page GetResumeModelFromDb()
	{
		if (CurrentUserInfo == null)
			return null;

		var user = LoginKit.GetCurrentMember();
		if (user == null)
			return null;

		string account = CurrentUserInfo.Account;
		if (string.IsNullOrEmpty(account))
			return null;

		return _cbus.GetPage(a => a.GroupCode == JOBSEEKER_CODE && a.Author == account);
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid)
			return;

		var model = GetResumeModelFromDb();
		if (model != null)
		{
			BindKit.FillModelFromContainer(this.MemberResumeEditor, model);
			model.IsEnabled = this.IsEnabled.SelectedIndex;
			model.Title = this.InfoTitle.Text;

			_cbus.SavePage(model);
		}
		else
		{
			model = new cms_content_page()
			{
				Title = this.InfoTitle.Text,
				GroupCode = JOBSEEKER_CODE,
				Click = 0,
				CreateDate = DateTime.Now,
				Author = CurrentUserName,
				IsEnabled = IsEnabled.SelectedIndex
			};

			_cbus.SavePage(model);
		}

		this.promptControl.ShowSuccess("保存成功！");
	}
}