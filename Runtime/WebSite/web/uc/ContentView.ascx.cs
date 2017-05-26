using NPiculet.Base.EF;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_uc_ContentView : System.Web.UI.UserControl
{
	NPiculetEntities se = new NPiculetEntities();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// 绑定数据，并更新点击数
    /// </summary>
    private void BindData()
    {
        int id = WebParmKit.GetRequestString("id", 0);
        var data = se.cms_content_page.FirstOrDefault(x => x.Id == id);
        if (data != null)
        {
            data.Click++;

            this.title.Text = data.Title;
            this.clicks.Text = data.Click.ToString();
            this.content.Text = data.Content;
            this.author.Text = data.Author;
            this.date.Text = data.CreateDate.ToString("yyyy-MM-dd HH:mm");
            se.SaveChanges();
        }
    }
}