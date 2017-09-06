using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using NPiculet.WebControls;

public partial class modules_member_MemberEdit : AdminPage {
	private readonly MemberBus _mbus = new MemberBus();

	protected void Page_Load(object sender, EventArgs e) {
		if (!Page.IsPostBack) {
			BindData();
			BindLog();
		}
	}

	private void BindData() {
		var memberId = WebParmKit.GetRequestString("key", 0);
		if (memberId > 0) {
			var model = _mbus.GetMemberInfo(memberId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);

				this.Account.ReadOnly = true;

				var data = _mbus.GetMemberData(memberId);
				if (data != null) {
					BindKit.BindModelToContainer(this.editor, data);

					this.Id.Value = model.Id.ToString();
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e) {
		if (Page.IsValid) {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			sys_member_info model;


			//保存用户信息
			if (id == 0) {
				if (_mbus.MemberExist(this.Account.Text)) {
					this.promptControl.ShowError("用户账号已存在，请重新输入！");
					return;
				}

				//获取最大排序
				model = new sys_member_info();
				model.MemberSn = StringKit.GetRandomString(16);
				model.IsEnabled = 1;
				model.IsDel = 0;
				model.Creator = this.CurrentUserName;
				model.CreateDate = DateTime.Now;
			} else {
				model = _mbus.GetMemberInfo(id);
			}
			BindKit.FillModelFromContainer(this.editor, model);
			_mbus.SaveMember(model);

			var data = _mbus.GetMemberData(model.Id);
			if (data == null) {
				data = new sys_member_data();
				BindKit.FillModelFromContainer(this.editor, data);
				data.MemberId = model.Id;
				data.MemberAccount = model.Account;
				data.IsDel = 0;
				_mbus.SaveMemberData(data);
			} else {
				int did = data.Id;
				BindKit.FillModelFromContainer(this.editor, data);
				data.Id = did;
				_mbus.SaveMemberData(data);
			}
			this.Id.Value = model.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");
		}
	}

	private void BindLog() {
		ActionLogBus abus = new ActionLogBus();

		var where = LinQKit.CreateWhere<sys_action_log>(a => a.ActionAccount == this.Account.Text);

		int count;

		var dt = abus.GetRecordList(out count, this.nPager.CurrentPage, this.nPager.PageSize, where);

		this.details.DataSource = dt;
		this.details.DataBind();

		this.nPager.RecordCount = count;
	}


	protected void nPager_OnPageClick(object sender, PageJumpEventArgs e) {
		BindLog();
	}
}