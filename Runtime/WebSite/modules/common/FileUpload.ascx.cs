using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class modules_common_FileUpload : NormalUserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// 上传文件，用法可参考 /web/Demo.aspx 或 本页注释
	/// </summary>
	/// <param name="moduleCode">所属模块编码</param>
	/// <param name="moduleId">所属模块ID</param>
	/// <param name="sourceCode">来源编码</param>
	/// <param name="sourceId">来源ID</param>
	/// <returns>返回路径是空表示上传失败</returns>
	public bas_attachment Upload(string moduleCode, string moduleId, string sourceCode, string sourceId)
	{
		string filepath;

		//获取文件信息
		var hpf = this.file.PostedFile;

		//获取当前登录用户
		var user = LoginKit.GetUserInfo(Session.SessionID);

		//上传文件
		var abus = new BasAttachmentBus();
		return abus.UploadFile(hpf, moduleCode, moduleId, sourceCode, sourceId, 0, 0, user == null ? 0 : user.Id, out filepath);
	}

	//说明：
	//为了便于最后归档项目中的所有文件，设计了四个关键查询字段

	//参数说明一
	//string moduleCode = "pro_project_info"; //模块编码，例如：项目表名
	//string moduleId = "WH001"; //模块ID，例如：项目ID。根据此ID即可查询并归档项目中所有附件。
	//string sourceCode = "开标环节"; //数据环节编码，可以是环节，也可以是表
	//string sourceId = ""; //数据环节ID，这里没有，就空着

	//参数说明二
	//string moduleCode = "pro_project_info"; //模块编码，为了便于最后归档项目中的所有文件
	//string moduleId = "WH001"; //模块ID，可以理解为主表ID
	//string sourceCode = "pro_bidding_info"; //表示这是针对招标信息表的附件
	//string sourceId = "1"; //招标信息ID，可以理解为子表ID

	//保存并返回文件所在的服务器相对路径，同时数据会存到 bas_attachment 数据表
	//string filepath = this.FileUpload.Upload(moduleCode, moduleId, sourceCode, sourceId);
}