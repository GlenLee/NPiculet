using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_uc_ContentPage : System.Web.UI.UserControl
{
	public string GroupCode { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.NPager1.PageSize = 13;

            BindData(1);
        }

        this.NPager1.PageClick += (o, args) => {
            BindData(args.PageIndex);
        };
    }

    private readonly CmsContentPageBus _bus = new CmsContentPageBus();

    private void BindData(int pageIndex)
    {
        string whereString = "GroupCode='" + GroupCode + "'";
        string search = WebParmKit.GetRequestString("key", "").FormatSqlParm();
        if (!string.IsNullOrEmpty(search))
        {
            whereString += " and Title like '%" + search + "%'";
        }
        int count = _bus.RecordCount(whereString);
        this.NPager1.RecordCount = count;

        DataTable dt = _bus.Query(pageIndex, this.NPager1.PageSize, whereString, "CreateDate DESC");

        this.list.DataSource = dt.DefaultView;
        this.list.DataBind();
    }
}