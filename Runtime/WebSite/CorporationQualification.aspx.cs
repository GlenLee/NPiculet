using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Toolkit;
using NPiculet.Logic.Base;

public partial class CorporationQualification : MemberPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //初始化图片上传控件参数           
            BindImageUpload();
        }
    }

    private void BindImageUpload()
    {
        this.BusinessLicences.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "营业执照", "");
        this.BusinessLicences.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.InternetCulture.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "文化经营许可证", "");
        this.InternetCulture.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.ApprovalDocument.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "公安审核批准文件", "");
        this.ApprovalDocument.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.FireSafety.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "消防安全审查合格证", "");
        this.FireSafety.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.BodyCorporateIdView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "法人身份证", "");
        this.BodyCorporateIdView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.BillboardView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "招牌图片", "");
        this.BillboardView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.EnterView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "入口招牌", "");
        this.EnterView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.AllStaffForegroundView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "全体员工合影照", "");
        this.AllStaffForegroundView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.ChargForegroundView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "负责人吧台照", "");
        this.ChargForegroundView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.ForegroundView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "前台照片", "");
        this.ForegroundView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.HallPanoramicView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "大厅全景照", "");
        this.HallPanoramicView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.HallView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "大厅照片", "");
        this.HallView.ImageUrl = "~/styles/images/clickUpdate.jpg";


        this.ManagerView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "经营信息", "");
        this.ManagerView.ImageUrl = "~/styles/images/clickUpdate.jpg";

        this.ChargeView.InitParams("EntReg", Convert.ToString(this.CurrentUserId), "收费文件", "");
        this.ChargeView.ImageUrl = "~/styles/images/clickUpdate.jpg";

    }

	protected void btnSaveData_Click(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
}