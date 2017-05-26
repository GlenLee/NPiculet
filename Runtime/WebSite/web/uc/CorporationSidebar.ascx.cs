using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_uc_CorporationSidebar : System.Web.UI.UserControl
{
    public string Actived { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected string GetActived(string page)
    {
        if (this.Actived == page)
        {
            return " style=\"actived\"";
        }
        return "";
    }
}