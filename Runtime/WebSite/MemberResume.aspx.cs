using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Authorization;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class MemberResume : MemberPage
{
	private const string JOBSEEKER_CODE = "PageJobSeeker";

	private readonly CmsContentPageBus _pageBus = new CmsContentPageBus();
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


	private CmsContentPage GetResumeModelFromDb()
	{
		if (CurrentUserInfo == null)
			return null;

		var user = LoginKit.GetCurrentMember();
		if (user == null)
			return null;

		string account = CurrentUserInfo.Account;
		if (string.IsNullOrEmpty(account))
			return null;

		string whereString = "GroupCode='" + JOBSEEKER_CODE + "' and Author = '" + account + "'";
		return _pageBus.QueryModel(whereString);
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

			_pageBus.Update(model, null);
		}
		else
		{
			model = new CmsContentPage
			{
				Title = this.InfoTitle.Text,
				GroupCode = JOBSEEKER_CODE,
				CategoryId = 0,
				Click = 0,
				CreateDate = DateTime.Now,
				Author = CurrentUserName,
				IsEnabled = IsEnabled.SelectedIndex
			};

			model.Id = _pageBus.InsertIdentity(model);
		}

		this.promptControl.ShowSuccess("保存成功！");
	}
}