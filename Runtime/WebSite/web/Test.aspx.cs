using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Toolkit;

public partial class web_Test : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			//初始化图片上传控件参数
			this.ImageUpload.InitParams("EntReg", "企业ID", "工商执照", "");
			this.ImageUpload.ImageUrl = "~/styles/images/user.png";

			this.ImageUpload1.InitParams("EntReg", "aaaa", "营业执照", "");
			this.ImageUpload1.ImageUrl = "~/styles/images/user.png";
		}
	}
}