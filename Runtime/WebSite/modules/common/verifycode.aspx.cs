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
		Bitmap img = VerifyCode.Create(4, 50, out outValue);

		//输出到浏览器
		MemoryStream ms = new MemoryStream();
		img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
		HttpContext.Current.Response.ClearContent();
		HttpContext.Current.Response.ContentType = "image/Jpeg";
		HttpContext.Current.Response.BinaryWrite(ms.ToArray());

		Session["_VerifyCode_"] = outValue;
    }

}