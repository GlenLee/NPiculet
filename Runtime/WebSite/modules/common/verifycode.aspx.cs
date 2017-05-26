using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Draw2D;

public partial class modules_common_verifycode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
	{
		//取得验证码数据
		string outValue;
		Bitmap img = VerifyCode.Create(4, 20, 24, 46, out outValue, Color.White);
		//Bitmap img = VerifyCode.Create(4, 0, 24, 46, out outValue, Color.Transparent);

		//输出到浏览器
		using (MemoryStream ms = new MemoryStream()) {
		    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
		    HttpContext.Current.Response.ClearContent();
		    HttpContext.Current.Response.ContentType = "image/png";
		    HttpContext.Current.Response.BinaryWrite(ms.ToArray());
	    }

	    Session["_VerifyCode_"] = outValue.ToLower();
    }

}