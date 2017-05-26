using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;

public partial class modules_common_FileTmplSet : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnSave_OnClick(object sender, EventArgs e)
	{
		string moduleCode = Request.QueryString["moduleCode"];
		string moduleId = Request.QueryString["moduleId"];
		string sourceCode = Request.QueryString["sourceCode"];
		string sourceId = Request.QueryString["sourceId"];

		var abus = new BasAttachmentBus();
		abus.CreateTmpl(this.FileName.Text, "pro_project_info", moduleId, sourceCode, sourceId, 0, 0, this.CurrentUserId);

		this.JavaSrcipt("closeWin();");
	}
}