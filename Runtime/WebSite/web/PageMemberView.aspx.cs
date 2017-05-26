using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class web_PageMemberView : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
		}
	}

	private readonly SysMemberInfoBus _userBus = new SysMemberInfoBus();
	private readonly SysMemberDataBus _dataBus = new SysMemberDataBus();
	private NPiculetEntities _db = new NPiculetEntities();

	private void BindData()
	{
		var userId = WebParmKit.GetRequestString("key", 0);
		if (userId <= 0)
			return;
		var model = _userBus.QueryModel("Id=" + userId);
		if (model == null)
			return;

		BindKit.BindModelToContainer(this.editor, model);
		//this.Account.ReadOnly = true;
		//CorpColor.Value = EntMemeberStatusHelper.GetStatusColor(model.Status);

		var data = _dataBus.QueryModel("UserAccount='" + model.Account + "'");
		if (data != null) {

			this.Title = model.Name;

			BindKit.BindModelToContainer(this.editor, data);
			//this.Id.Value = model.Id.ToString();
		}

		var corpInfo = _db.sys_member_corporation.SingleOrDefault(x => x.UserAccount == model.Account);
		if (corpInfo != null) {
			BindKit.BindModelToContainer(this.editor, corpInfo);
			CorporationNature.Text = corpInfo.CorporationNature;
		}
	}

	private void BindImg(string userId)
	{
		this.BusinessLicences.ImageUrl = GetImageUrl("EntReg", userId, "营业执照", "");

		this.InternetCulture.ImageUrl = GetImageUrl("EntReg", userId, "文化经营许可证", "");

		this.ApprovalDocument.ImageUrl = GetImageUrl("EntReg", userId, "公安审核批准文件", "");

		this.FireSafety.ImageUrl = GetImageUrl("EntReg", userId, "消防安全审查合格证", "");

		this.BodyCorporateIdView.ImageUrl = GetImageUrl("EntReg", userId, "法人身份证", "");

		this.BillboardView.ImageUrl = GetImageUrl("EntReg", userId, "招牌图片", "");

		this.EnterView.ImageUrl = GetImageUrl("EntReg", userId, "入口招牌", "");

		this.AllStaffForegroundView.ImageUrl = GetImageUrl("EntReg", userId, "全体员工合影照", "");

		this.ChargForegroundView.ImageUrl = GetImageUrl("EntReg", userId, "负责人吧台照", "");

		this.ForegroundView.ImageUrl = GetImageUrl("EntReg", userId, "前台照片", "");

		this.HallPanoramicView.ImageUrl = GetImageUrl("EntReg", userId, "大厅全景照", "");

		this.HallView.ImageUrl = GetImageUrl("EntReg", userId, "大厅照片", "");
	}

	protected string GetImageUrl(string moduleCode, string moduleId, string sourceCode, string sourceId)
	{
		using (var db = new NPiculetEntities()) {
			var att = db.bas_attachment.FirstOrDefault(a => a.ModuleCode == moduleCode && a.ModuleId == moduleId && a.SourceCode == sourceCode && a.SourceId == sourceId);
			if (att != null) {
				return Path.Combine(att.FilePath, att.FileName);
			}
		}
		return "~/styles/images/noimage.jpg";
	}

	protected void btnShowQualification_Click(object sender, EventArgs e)
	{
		var userId = WebParmKit.GetRequestString("key", 0);
		if (userId <= 0)
			return;
		var model = _userBus.QueryModel("Id=" + userId);
		if (model == null)
			return;
		if (!CorpQualification.Visible) {
			CorpQualification.Visible = true;
			BindImg(model.Id.ToString());
		}
	}
}