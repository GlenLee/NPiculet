using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Sys;
using System.Net;
using System.IO;
using NPiculet.Toolkit;

public partial class ContentPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
        BindWeather();
	}

    private void BindWeather()
	{
		try {
            //System.Net.HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create("http://api.map.baidu.com/telematics/v3/weather?location=%E6%98%86%E6%98%8E&output=json&ak=B8cb5720f21c85d3174998ae7a400f7c&qq-pf-to=pcqq.c2c");
            //myReq.Timeout = 50000;
            //HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            //StreamReader myStream = new StreamReader(HttpWResp.GetResponseStream());
            //string doc = Convert.ToString(myStream.ReadToEnd());
            //myStream.Close();
            //var jsonstring = JsonKit.Deserialize(doc);

        }
        catch (Exception) {
			throw;
		}
	}

    protected string GetPlatformName()
	{
		string pname = new ConfigManager().GetWebConfig("WebSiteName");
		return string.IsNullOrEmpty(pname) ? ConfigurationManager.AppSettings["WebTitle"] : pname;
	}

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath;
        if (!string.IsNullOrEmpty(url))
        {
            if (!string.IsNullOrEmpty(this.keyword.Text.FormatSqlParm()))
            {
                url += "?Key=" + this.keyword.Text.FormatSqlParm();
            }
            Response.Redirect(url);
        }
    }
}
