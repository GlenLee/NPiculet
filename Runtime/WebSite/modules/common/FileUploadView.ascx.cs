using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_common_FileUploadView : System.Web.UI.UserControl
{
	private bool _showToolbar = false;
	/// <summary>
	/// 是否显示工具栏
	/// </summary>
	public bool ShowToolbar { get { return _showToolbar; } set { _showToolbar = value; } }

	private string _ModuleCode
	{
		get { return Convert.ToString(ViewState["_ModuleCode"]); }
		set { ViewState["_ModuleCode"] = value; }
	}

	private string _ModuleId
	{
		get { return Convert.ToString(ViewState["_ModuleId"]); }
		set { ViewState["_ModuleId"] = value; }
	}

	private string _SourceCode
	{
		get { return Convert.ToString(ViewState["_SourceCode"]); }
		set { ViewState["_SourceCode"] = value; }
	}

	private string _SourceId
	{
		get { return Convert.ToString(ViewState["_SourceId"]); }
		set { ViewState["_SourceId"] = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//if (!Page.IsPostBack) {
		//	BindData();
		//}
	}

	public void BindData(string moduleCode, string moduleId, string sourceCode, string sourceId)
	{
		this._ModuleCode = moduleCode;
		this._ModuleId = moduleId;
		this._SourceCode = sourceCode;
		this._SourceId = sourceId;

		var bus = new AttachmentBus();
		var data = bus.GetFileList(moduleCode, moduleId, sourceCode, sourceId, 0);
		this.list.DataSource = (from a in data where a.IsDir == 0 select a).ToList();
		this.list.DataBind();
	}

	protected string GetFilePath()
	{
		int attId = ConvertKit.ConvertValue(Eval("Id"), 0);
		int tmpl = ConvertKit.ConvertValue(Eval("IsTmpl"), 0);
		string path = Convert.ToString(Eval("FilePath"));
		string file = Convert.ToString(Eval("FileName"));
		//检查文件是否是模板
		if (tmpl == 1 && string.IsNullOrEmpty(path)) {
			return "javascript:uploadTmpl(" + attId + ");";
		}
		//下载文件
		if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(file)) {
			string filepath = Path.Combine(path, file);
			return ResolveClientUrl(filepath);
		}
		return "#";
	}

	protected string GetFileName()
	{
		int tmpl = ConvertKit.ConvertValue(Eval("IsTmpl"), 0);
		string name = Convert.ToString(Eval("Name"));
		return name + (tmpl == 1 ? " <small>(必传文档)</small>" : "");
	}

	protected void btnDelete_OnClick(object sender, EventArgs e)
	{
		var btn = sender as LinkButton;
		if (btn != null) {
			var val = btn.CommandArgument;
			var bus = new AttachmentBus();
			bus.DeleteAttachment(val);
			BindData(_ModuleCode, _ModuleId, _SourceCode, _SourceId);
		}
	}

	protected void list_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		var item = e.Item.DataItem as bas_attachment;
		var btn = e.Item.FindControl("btnDelete") as LinkButton;
		if (btn != null) {
			if (!ShowToolbar) {
				btn.Visible = false;
			} else {
				btn.CommandArgument = item == null ? "" : item.Id.ToString();
			}
		}
		var link = e.Item.FindControl("filelink") as LinkButton;
		if (link != null && item != null) {
			bool need = (item.IsTmpl == 1 && string.IsNullOrEmpty(item.FilePath));
			string fix = need ? "(必传文件) " : "";
			link.Text = string.Format(_iconHtml, GetFileIcon(item.IsDir ?? 0, item.FileExt), item.Name) + fix + item.Name;
			link.CommandArgument = item.Id.ToString();
			if (item.IsDir == 1 && item.Name == "...") {
				var cb = e.Item.FindControl("cb");
				cb.Visible = false;
			}
			if (need) {
				if (btn != null) {
					btn.Visible = false;
				}
			}
		}
	}

	//图标模板
	private string _iconHtml = "<img src=\"{0}\" alt=\"{1}\"/>";

	/// <summary>
	/// 获取文件的图标
	/// </summary>
	/// <returns></returns>
	protected string GetFileIcon(int dir, string ext)
	{
		if (dir == 1) return ResolveClientUrl("~/modules/images/f01.png");
		switch (ext) {
			case ".rar":
			case ".zip":
			case ".7z":
				return ResolveClientUrl("~/modules/images/f02.png");
			case ".xls":
			case ".xlsx":
				return ResolveClientUrl("~/modules/images/f05.png");
			case ".doc":
			case ".docx":
			case ".wps":
				return ResolveClientUrl("~/modules/images/f06.png");
			default:
				return ResolveClientUrl("~/modules/images/f03.png");
		}
	}

	protected void filelink_OnClick(object sender, EventArgs e)
	{
		var link = sender as LinkButton;
		var attId = Convert.ToInt32(link.CommandArgument);
		using (var db = new NPiculetEntities()) {
			var att = db.bas_attachment.FirstOrDefault(a => a.Id == attId);
			//处理根目录
			if (att != null) {
				//检查文件是否是模板
				if (att.IsTmpl == 1 && string.IsNullOrEmpty(att.FilePath)) {
					this.JavaSrcipt("uploadTmpl(" + att.Id + ");");
					return;
				}
				//下载文件
				string filepath = Server.MapPath(Path.Combine(att.FilePath, att.FileName));
				FileInfo file = new FileInfo(filepath);
				if (file.Exists) {
					Response.Clear();
					Response.ContentType = "application/octet-stream";
					Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(att.Name));
					Response.WriteFile(filepath);
					Response.End();
				} else {
					this.Alert("文件在服务器中不存在，请联系管理员检查！" + filepath);
				}
			}
		}
	}

}