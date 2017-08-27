using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_common_FileTmplUpload : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnSave_OnClick(object sender, EventArgs e)
	{
		int fileId = WebParmKit.GetQuery("fid", 0);
		if (fileId > 0) {
			var abus = new AttachmentBus();
			abus.UploadTmpl(this.fileUpload.PostedFile, fileId);
		}

		this.JavaSrcipt("closeWin();");
	}
}