using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class FindPassStep1 : System.Web.UI.Page
{
    private readonly NPiculetEntities _db = new NPiculetEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFindPass_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        var exist = _db.sys_member_data.Where(x => x.UserAccount == Account.Text && x.Mobile == this.Mobile.Text && x.Email == this.Email.Text).FirstOrDefault();
        if (exist != null)
        {
            var count = _db.sys_member_info.Where(x => x.Name == this.Name.Text).FirstOrDefault();
            if (count!=null)
            {
                this.Alert("您的密码为："+count.Password+",请尽快联系管理员修改密码。");
                return;
            }
            else
            {
                this.Alert("找不到该用户名信息，请联系管理员处理！");
                return;
            }
        }
        else
        {
            this.Alert("找不到该用户名信息，请核实具相关内容填写是否正确！");
            return;
        }
    }
}