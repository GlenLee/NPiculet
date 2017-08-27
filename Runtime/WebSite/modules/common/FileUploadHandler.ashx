<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using NPiculet.Authorization;
using NPiculet.Logic.Business;

public class FileUploadHandler : IHttpHandler, IRequiresSessionState
{
	public void ProcessRequest(HttpContext context)
	{
		HttpPostedFile file = context.Request.Files["Filedata"];

		string moduleCode = context.Request.Params["moduleCode"];
		string moduleId = context.Request.Params["moduleId"];
		string sourceCode = context.Request.Params["sourceCode"];
		string sourceId = context.Request.Params["sourceId"];
		int parentId = Int32.Parse(context.Request.Params["parentId"]);//默认为0，不允许为空
		if (sourceCode == null) {
			sourceCode = "";
		}
		if (sourceId == null) {
			sourceId = "";
		}
		Upload(moduleCode, moduleId, sourceCode, sourceId, parentId, file, context);
	}

	/// <summary>
	/// 上传文件
	/// </summary>
	/// <param name="moduleCode"></param>
	/// <param name="moduleId"></param>
	/// <param name="sourceCode"></param>
	/// <param name="sourceId"></param>
	/// <param name="parentId"></param>
	/// <param name="hpf"></param>
	/// <param name="context"></param>
	/// <returns></returns>
	public string Upload(string moduleCode, string moduleId, string sourceCode, string sourceId, int parentId,
		HttpPostedFile hpf, HttpContext context)
	{
		string filepath;
		//获取当前登录用户
		var user = LoginKit.GetUserInfo(context.Session.SessionID);

		//上传文件
		var abus = new AttachmentBus();
		var parent = abus.GetDir(parentId);
		int layer = parent == null ? 0 : parent.Layer ?? 0; 
		var att = abus.UploadFile(hpf, moduleCode, moduleId, sourceCode, sourceId, parentId, layer, user == null ? 0 : user.Id, out filepath);
		if (att == null) {
		}

		return filepath;
	}

	public bool IsReusable
	{
		get
		{
			return false;
		}
	}

}