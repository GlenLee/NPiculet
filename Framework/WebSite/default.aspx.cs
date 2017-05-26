using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Draw2D;
using NPiculet.Toolkit;
using NPiculet.Log;

public partial class test : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string sid = Session.SessionID;
		Response.Write(sid);
		Logger.Info(sid);

		if (Session["_demo_"] == null)
			Session["_demo_"] = StringKit.GetRandomString(10);
		Response.Write("\r\n<br/>\r\n" + Session["_demo_"]);

		string json = JsonKit.Serialize(new { test = "123" });
		Response.Write(json);
	}
}