using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CorporationCenter : MemberPage
{
	NPiculetEntities _db = new NPiculetEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCoporationData();
        }
    }

    private void BindCoporationData()
    {
        var member = this.CurrentUserInfo;
        if (member!=null)
        {            
            var memberData = _db.sys_member_corporation.Where(x => x.UserId == member.Id).FirstOrDefault();
            if (memberData != null)
            {
                this.CorporationBreifName.Text = memberData.CorporationBreifName;
                this.CorporationAddress.Text = memberData.CorporationAddress;
                this.CorporationName.Text = memberData.CorporationName;
                this.chargeMan.Text = memberData.ChargeMan;
                this.chargeManTel.Text = memberData.ChargeManTel;
                this.CorporationNature.Text = memberData.CorporationNature;
                this.laywer.Text = memberData.BodyCorporate;
                this.Mobile.Text = memberData.BodyCorporateTel;

            }
        }
    }
}