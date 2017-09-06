using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Authorization;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;

public partial class web_uc_ImageUpload : System.Web.UI.UserControl
{
	public string ModuleCode
	{
		get { return Convert.ToString(ViewState["_ModuleCode"]); }
		set { ViewState["_ModuleCode"] = value; }
	}


	public string ModuleId
	{
		get { return Convert.ToString(ViewState["_ModuleId"]); }
		set { ViewState["_ModuleId"] = value; }
	}

	public string SourceCode
	{
		get { return Convert.ToString(ViewState["_SourceCode"]); }
		set { ViewState["_SourceCode"] = value; }
	}

	public string SourceId
	{
		get { return Convert.ToString(ViewState["_SourceId"]); }
		set { ViewState["_SourceId"] = value; }
	}

	public string ImageUrl
	{
		get { return Convert.ToString(ViewState["_ImageUrl"]); }
		set { ViewState["_ImageUrl"] = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			if (string.IsNullOrEmpty(this.img.ImageUrl)) {
				this.img.ImageUrl = this.ImageUrl;
			}
			this.img.Attributes.Add("onclick", "document.getElementById('" + this.fileUpload.ClientID + "').click();");
			this.fileUpload.Attributes.Add("onchange", "document.getElementById('" + this.btnFileUpload.ClientID + "').click();");
		}
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="moduleCode"></param>
	/// <param name="moduleId"></param>
	/// <param name="sourceCode"></param>
	/// <param name="sourceId"></param>
	public void InitParams(string moduleCode, string moduleId, string sourceCode, string sourceId)
	{
		//初始化图片上传控件参数
		this.ModuleCode = moduleCode;
		this.ModuleId = moduleId;
		this.SourceCode = sourceCode;
		this.SourceId = sourceId;
		using (var db = new NPiculetEntities()) {
			var att = db.bas_attachment.FirstOrDefault(a => a.ModuleCode == moduleCode && a.ModuleId == moduleId && a.SourceCode == sourceCode && a.SourceId == sourceId);
			if (att != null) {
				this.img.ImageUrl = Path.Combine(att.FilePath, att.FileName);
			}
		}
	}

	protected void btnFileUpload_OnClick(object sender, EventArgs e)
	{
		string filepath;

		//获取文件信息
		var hpf = this.fileUpload.PostedFile;

		//获取当前登录用户
		var user = LoginKit.GetUserInfo(Session.SessionID);

		//上传文件
		var abus = new AttachmentBus();
		var att = abus.UploadFile(hpf, this.ModuleCode, this.ModuleId, this.SourceCode, this.SourceId, 0, 0, user == null ? 0 : user.Id, out filepath);
		if (att == null) {
			this.Alert("文件上传失败！");
		} else {
			this.img.ImageUrl = filepath;
		}
	}
}