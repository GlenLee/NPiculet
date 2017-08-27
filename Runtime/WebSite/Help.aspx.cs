using NPiculet.Base.EF;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_Help : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
			byte[] _IVKeys = { 0xFF, 0x30, 0x55, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
	        byte[] s = EncryptKit.EncryptDES(Encoding.UTF8.GetBytes("da123fgr"), _IVKeys, Encoding.UTF8.GetBytes("password123123123123132"));
			Response.Write(StringKit.GetHex(s));
	        Response.Write("<br/>");

	        byte b = Convert.ToByte(0);
	        Response.Write(b);
	        Response.Write("<br/>");

			Response.Write(Guid.NewGuid());
	        Response.Write("<br/>");
			Response.Write(EncryptKit.ToMD5("123"));
	        Response.Write("<br/>");
	        Response.Write(EncryptKit.ToSHA1("123"));
	        Response.Write("<br/>");
	        Response.Write(EncryptKit.ToHMACSHA1("", "123"));
	        Response.Write("<br/>");
	        Response.Write(EncryptKit.EncryptDES("123", ""));
	        Response.Write("<br/>");
	        Response.Write(EncryptKit.ToSHA1("123"));
	        Response.Write("<br/>");
			Response.Write(EncryptKit.ToSHA1("12387123hasdj87123kjha7868123!@@131"));
		}
    }
}