using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Info;

public partial class modules_Url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        string userId = "1";
        //string sourcecode; //对应的数据表
        //string sourceId; //对应的数据ID
        string type = Request.QueryString["type"]; //处理类型
        string noticeId = Request.QueryString["id"];
        string url = Request.QueryString["url"];
        //NoticeManager nm = new NoticeManager();
        switch (type)
        {
            case "View":
                //nm.DeleteNotice(noticeId, userId);
                //更改 NoticePushRecord 数据
                //where record.NoticeSn == sn and record.UserId == userId; //接收通知的用户
                //delete NoticePushRecord 中的数据
                break;
            case "Process":
                //nm.FinishNotice(noticeId, userId);
                break;
                //where record.NoticeSn == sn and record.UserId == userId; //接收通知的用户
                //uodate NoticePushRecord.IsRead = 1 中的数据
        }
        Response.Redirect(url + "?id=" + noticeId);
        //Response.Redirect(url ? key = sourceId);
    }
}