using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegStep2 : System.Web.UI.Page {

	private NPiculetEntities _db = new NPiculetEntities();

    protected void Page_Load(object sender, EventArgs e)
	{
        BindData();
	}

    private void BindData()
    {
        string account = WebParmKit.GetRequestString("account", "").FormatSqlParm();
        if (!string.IsNullOrEmpty(account))
        {
            var data = _db.sys_member_info.Where(x => x.Account == account).FirstOrDefault();
            if(data!=null)
            {
               // this.CcfbCode.Text = data.UserSn;
                this.txtName.Text = data.Name;
                this.txtAccount.Text = data.Account;
            } 
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (!string.IsNullOrEmpty(this.Email.Text.Trim()))
            {
                var m1 = _db.sys_member_data.Where(x => x.Email == this.Email.Text.Trim().FormatSqlParm()).ToList();
                    
                if (m1 != null)
                {
                    this.Alert("邮箱已经存在,不能重复注册!");
                    return;
                }
            }
            try
            {
                var info = _db.sys_member_data.Where(x => x.UserAccount == this.txtAccount.Text.FormatSqlParm()).FirstOrDefault();

                BindKit.FillModelFromContainer(this.frm, info);

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("(o゜▽゜)o☆[BINGO!]", ex);
                this.Alert("注册失败，请重新填写!");
                return; 
            }
            
        }
    }
}