using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;

public partial class modules_WaitingList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string GetNoticeList()
    {
        System.Data.DataTable dt = NPiculet.Data.DbHelper.Create().GetDataTable("SELECT * FROM notice_info INNER JOIN notice_push_record on \"Sn\" = \"NoticeSn\" AND \"UserId\" = 1 AND \"IsRead\" = 0");
        string infoString = "", formatString = "<li><a href=\"Url.aspx?id={0}&type={1}&url={2}\" target=\"mainFrame\"\">{3}</a></li>";
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            infoString += string.Format(formatString, dr["Id"], dr["NoticeType"], dr["Url"], dr["Title"]);//, notice.SourceId
        }

        //NoticeInfoBus _noticeBus = new NoticeInfoBus();
        //List<NoticeInfo> infos = null;
        //if (parameter == "1") infos = _noticeBus.GetInfo("INNER JOIN notice_push_record on \"Sn\" = \"NoticeSn\" AND \"UserId\" = 1212");
        //else if (parameter == "2") infos = _noticeBus.GetInfo("NoticeType='" + "" + "'");
        //"INNER join notice_info on \"Sn\" =\"NoticeSn\""

        //string infoString = "", formatString = "<li><a href=\"Url.aspx?id={0}&type={1}&url={2}\" target=\"mainFrame\"\">{3}</a></li>";
        //foreach (NoticeInfo notice in infos)
        //{
        //    infoString += string.Format(formatString, notice.Id, notice.NoticeType, notice.Url, notice.Title);//, notice.SourceId
        //}
        return infoString;
    }
}