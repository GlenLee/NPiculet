using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberCenter : MemberPage
{
	NPiculetEntities _db = new NPiculetEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUserInfoData();
        }
    }

    private void BindUserInfoData()
	{
		var member = this.CurrentUserInfo;
		this.Name.Text = member.Name;
		BindKit.BindModelToContainer(this.infoEditor, member);
		this.btnSave.Visible = false;
	}

    protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			this.Alert("修改基本信息成功！");
		}
	}
}