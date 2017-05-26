using System;
using System.Data;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

namespace modules.member
{
	public partial class ModulesMemberEntMemberEdit : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindData();
				BindLog();
			}
			this.NPager1.PageClick += (o, args) => { BindLog(); };
		}

		private readonly SysMemberInfoBus _userBus = new SysMemberInfoBus();
		private readonly SysMemberDataBus _dataBus = new SysMemberDataBus();

		private void BindData()
		{
			CorporationNature.DataSource = CommonLib.EnterpriseNatures;
			CorporationNature.DataBind();

			var userId = WebParmKit.GetRequestString("key", 0);
			if (userId <= 0)
				return;
			var model = _userBus.QueryModel("Id=" + userId);
			if (model == null)
				return;

			BindKit.BindModelToContainer(this.editor, model);
			//this.Account.ReadOnly = true;
			CorpColor.Value = EntMemeberStatusHelper.GetStatusColor(model.Status);

			var data = _dataBus.QueryModel("UserId=" + model.Id);
			if (data != null)
			{
				BindKit.BindModelToContainer(this.editor, data);
			}

			using (var db = new NPiculetEntities()) {
				var corpInfo = db.sys_member_corporation.SingleOrDefault(x => x.UserId == model.Id);
				if (corpInfo != null) {
					BindKit.BindModelToContainer(this.editor, corpInfo);
					CorporationNature.SelectedValue = corpInfo.CorporationNature;
				}
			}
		}
		protected void btnPass_Click(object sender, EventArgs e)
		{
			var userId = WebParmKit.GetRequestString("key", 0);
			if (userId > 0)
			{
				var model = _userBus.QueryModel("Id=" + userId);
				if (model != null)
				{
					model.Status = "1";
					_userBus.Update(model, null);
				}
			}
		}
		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			using (var db = new NPiculetEntities()) {

				sys_member_info member;
				var userId = WebParmKit.GetRequestString("key", 0);

				//保存用户信息
				if (userId == 0) {
					if (db.sys_member_info.Any(a => a.Account == this.Account.Text)) {
						this.promptControl.ShowError("用户账号已存在，请重新输入！");
						return;
					}

					member = new sys_member_info();
					BindKit.FillModelFromContainer(this.editor, member);
					//获取最大排序
					member.UserSn = Guid.NewGuid().ToString().ToLower();
					member.IsEnabled = 1;
					member.IsDel = 0;
					member.Creator = this.CurrentUserName;
					member.CreateDate = DateTime.Now;
					db.SaveChanges();

				} else {
					member = db.sys_member_info.FirstOrDefault(a => a.Id == userId);
					BindKit.FillModelFromContainer(this.editor, member);
					db.SaveChanges();
				}

				var data = db.sys_member_data.FirstOrDefault(d => d.UserId == member.Id);
				if (data == null) {
					data = new sys_member_data();
					BindKit.FillModelFromContainer(this.editor, data);
					data.UserId = member.Id;
					data.UserAccount = member.Account;
					data.IsDel = 0;
					db.sys_member_data.Add(data);
					db.SaveChanges();
				} else {
					BindKit.FillModelFromContainer(this.editor, data);
					data.UserAccount = member.Account;
					db.SaveChanges();
				}

				var corpInfo = db.sys_member_corporation.FirstOrDefault(x => x.UserId == member.Id);
				if (corpInfo != null) {
					BindKit.FillModelFromContainer(editor, corpInfo);
					corpInfo.UserAccount = member.Account;
					db.SaveChanges();
				}
			}

			this.promptControl.ShowSuccess("保存成功！");
		}

		private void BindLog()
		{
			SysActionLogBus bus = new SysActionLogBus();

			string whereString = "ActionAccount='" + this.Account.Text + "'";

			int count = bus.RecordCount(whereString);
			this.NPager1.PageSize = 10;
			this.NPager1.RecordCount = count;

			var dt = bus.Query(this.NPager1.CurrentPage, this.NPager1.PageSize, whereString, "Date DESC");

			this.details.DataSource = dt;
			this.details.DataBind();
		}

		private void BindImg(string userId)
		{
			this.BusinessLicences.InitParams("EntReg", userId, "营业执照", "");
			this.BusinessLicences.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.InternetCulture.InitParams("EntReg", userId, "文化经营许可证", "");
			this.InternetCulture.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.ApprovalDocument.InitParams("EntReg", userId, "公安审核批准文件", "");
			this.ApprovalDocument.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.FireSafety.InitParams("EntReg", userId, "消防安全审查合格证", "");
			this.FireSafety.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.BodyCorporateIdView.InitParams("EntReg", userId, "法人身份证", "");
			this.BodyCorporateIdView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.BillboardView.InitParams("EntReg", userId, "招牌图片", "");
			this.BillboardView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.EnterView.InitParams("EntReg", userId, "入口招牌", "");
			this.EnterView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.AllStaffForegroundView.InitParams("EntReg", userId, "全体员工合影照", "");
			this.AllStaffForegroundView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.ChargForegroundView.InitParams("EntReg", userId, "负责人吧台照", "");
			this.ChargForegroundView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.ForegroundView.InitParams("EntReg", userId, "前台照片", "");
			this.ForegroundView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.HallPanoramicView.InitParams("EntReg", userId, "大厅全景照", "");
			this.HallPanoramicView.ImageUrl = "~/styles/images/clickUpdate.jpg";

			this.HallView.InitParams("EntReg", userId, "大厅照片", "");
			this.HallView.ImageUrl = "~/styles/images/clickUpdate.jpg";
		}

		protected void btnShowQualification_Click(object sender, EventArgs e)
		{
			var userId = WebParmKit.GetRequestString("key", 0);
			if (userId <= 0)
				return;
			var model = _userBus.QueryModel("Id=" + userId);
			if (model == null)
				return;
			if (!CorpQualification.Visible)
			{
				CorpQualification.Visible = true;
				BindImg(model.Id.ToString());
			}
		}
	}
}