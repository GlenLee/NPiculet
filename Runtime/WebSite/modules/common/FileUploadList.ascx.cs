using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class modules_common_FileUploadList : System.Web.UI.UserControl
{
	private bool _showToolbar = true;
	/// <summary>
	/// 是否显示工具栏
	/// </summary>
	public bool ShowToolbar { get { return _showToolbar; } set { _showToolbar = value; } }

	/// <summary>
	/// 提交链接
	/// </summary>
	public string SendUrl { get; set; }
    public string isModfy { get; set; }
    public string _ModuleCode
    {
		get { return Convert.ToString(ViewState["_ModuleCode"]); }
		set { ViewState["_ModuleCode"] = value; }
	}

    public string _ModuleId
	{
		get { return Convert.ToString(ViewState["_ModuleId"]); }
		set { ViewState["_ModuleId"] = value; }
	}

    public int _ParentId
	{
		get { return ConvertKit.ConvertValue(ViewState["_ParentId"], 0); }
		set { ViewState["_ParentId"] = value; }
	}

    public int _RootId
	{
		get { return ConvertKit.ConvertValue(ViewState["_RootId"], 0); }
		set { ViewState["_RootId"] = value; }
	}

	public int _Layer
	{
		get { return ConvertKit.ConvertValue(ViewState["_Layer"], 0); }
		set { ViewState["_Layer"] = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			this.phToolbar.Visible = ShowToolbar;
			//this.fileUpload.Attributes.Add("onchange", "return $('#" + this.btnFileUpload.ClientID + "').click();");
			//this.fileUpload.Attributes.Add("style", "display:none;");
			//this.btnFileUpload.Attributes.Add("style", "display:none;");

			//处理提交按钮
			if (!string.IsNullOrEmpty(SendUrl)) this.phSendButton.Visible = true;
		}
	}

	/// <summary>
	/// 绑定数据
	/// </summary>
	/// <param name="moduleCode">模块名称</param>
	/// <param name="moduleId">模块ID</param>
	/// <param name="parentId">目录树的父ID</param>
	public void BindData(string moduleCode, string moduleId, int parentId)
	{
		this._ModuleCode = moduleCode;
		this._ModuleId = moduleId;
		this._ParentId = parentId;

		var abus = new BasAttachmentBus();
		var parent = abus.GetDir(parentId);
		if (parent != null) {
			this._RootId = parent.ParentId ?? 0;
			this._Layer = parent.Layer ?? 0;
		}

		var files = abus.GetFileList(moduleCode, moduleId, parentId);

		//空目录占位符，作用是返回上一层的按钮
		if (parent != null) {
			var att = new bas_attachment();
			att.Id = parent.ParentId ?? 0;
			att.Layer = parent.Layer ?? 0;
			att.Name = "...";
			att.IsDir = 1;
			files.Insert(0, att);
		}

		//绑定文件列表
		this.filelist.DataSource = files;
		this.filelist.DataBind();
	}

	protected string GetFilePath()
	{
		string filepath = Path.Combine(Eval("FilePath").ToString(), Eval("FileName").ToString());
		return ResolveClientUrl(filepath);
	}

	protected string GetFileType()
	{
		var type = Convert.ToInt32(Eval("IsDir"));
		return type == 1 ? "文件夹" : "文档";
	}

	protected string GetFileLength()
	{
		var length = Convert.ToInt32(Eval("Length"));
		if (length > 1024 * 1024 * 1024) return (length / 1024f / 1024f / 1024f).ToString("#.0") + " GB";
		if (length > 1024 * 1024) return (length / 1024f / 1024f).ToString("#.0") + " MB";
		if (length > 1024) return (length / 1024f).ToString("#.0") + " KB";
		return length + " B";
	}

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

	/// <summary>
	/// 获取文件的链接
	/// </summary>
	/// <returns></returns>
	protected string GetFileLink()
	{
		//处理文件
		string url;
		string name = Convert.ToString(Eval("Name"));
		int dir = Convert.ToInt32(Eval("IsDir"));
		if (dir == 1) {
			url = "#";
		} else {
			string path = Convert.ToString(Eval("FilePath"));
			string file = Convert.ToString(Eval("FileName"));
			url = ResolveClientUrl(Path.Combine(path, file));
		}
		return string.Format("<a href=\"{0}\">{1}</a>", url, name);
		//处理目录
	}

	//图标模板
	private string _iconHtml = "<img src=\"{0}\" alt=\"{1}\"/>";

	protected void filelist_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		var item = e.Item.DataItem as bas_attachment;
		var link = e.Item.FindControl("filelink") as LinkButton;
		if (link != null && item != null) {
			string fix = (item.IsTmpl == 1 && string.IsNullOrEmpty(item.FilePath) ? "(必传文件) " : "");
			link.Text = string.Format(_iconHtml, GetFileIcon(item.IsDir ?? 0, item.FileExt), item.Name) + fix + item.Name;
			link.CommandArgument = item.Id.ToString();
			if (item.IsDir == 1 && item.Name == "...") {
				var cb = e.Item.FindControl("cb");
				cb.Visible = false;
			}
		}
	}

	protected void filelink_OnClick(object sender, EventArgs e)
	{
		var link = sender as LinkButton;
		var attId = Convert.ToInt32(link.CommandArgument);
		using (var db = new NPiculetEntities()) {
			var att = db.bas_attachment.FirstOrDefault(a => a.Id == attId);
			//处理根目录
			if (att == null || attId == 0) {
				BindData(this._ModuleCode, this._ModuleId, 0);
				return;
			}
			//处理目录以及文件下载
			if (att.IsDir == 1) {
				//进入下级目录
				BindData(att.ModuleCode, att.ModuleId, att.Id);
			} else {
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

	//protected void btnFileUpload_OnClick(object sender, EventArgs e)
	//{
	//	string filepath;

	//	//获取文件信息
	//	var hpf = this.fileUpload.PostedFile;

	//	//获取当前登录用户
	//	var user = LoginKit.GetUserInfo(Session.SessionID);

	//	//上传文件
	//	var abus = new BasAttachmentBus();
	//	var att = abus.UploadFile(hpf, this._ModuleCode, this._ModuleId, "", "", this._ParentId, user == null ? 0 : user.Id, out filepath);
	//	if (att == null) {
	//		this.Alert("文件上传失败！");
	//	} else {
	//		BindData(this._ModuleCode, this._ModuleId, this._ParentId, this._RootId);
	//	}
	//}

	/// <summary>
	/// 创建目录
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnCreateDir_OnClick(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtDirName.Text) || this.txtDirName.Text == "...") {
			this.Alert("创建目录名称不能空！");
			return;
		}

		//获取当前登录用户
		var user = LoginKit.GetUserInfo(Session.SessionID);

		//上传文件
		var abus = new BasAttachmentBus();
		var att = abus.CreateDir(this.txtDirName.Text, this._ModuleCode, this._ModuleId, "", "", this._ParentId, this._Layer + 1, user == null ? 0 : user.Id);
		if (att == null) {
			this.Alert("目录创建失败！");
		} else {
			this.txtDirName.Text = string.Empty;
			BindData(this._ModuleCode, this._ModuleId, this._ParentId);
		}
	}

	protected void btnDel_OnClick(object sender, EventArgs e)
	{
		string msg = null;
		using (var db = new NPiculetEntities()) {
			foreach (RepeaterItem item in this.filelist.Items) {
				var cb = item.FindControl("cb") as HtmlInputCheckBox;
				if (cb != null) {
					if (cb.Checked) {
						var attId = Convert.ToInt32(cb.Value);
						var att = db.bas_attachment.FirstOrDefault(a => a.Id == attId);
						if (att != null) {
							//检查文件是否是模板
							bool need = att.IsTmpl == 1 && string.IsNullOrEmpty(att.FilePath);
							if (!need) {
								if (att.IsDir == 0) {
									var file = new FileInfo(Path.Combine(att.FilePath, att.FileName));
									if (file.Exists) file.Delete();
								}
								db.bas_attachment.Remove(att);
							} else {
								msg = "必传文件不允许删除！";
							}
						}
					}
					db.SaveChanges();
				}
			}
		}
		if (!string.IsNullOrEmpty(msg)) {
			this.Alert(msg);
		}
		BindData(this._ModuleCode, this._ModuleId, this._ParentId);
	}

	protected void btnRefresh_OnClick(object sender, EventArgs e)
	{
		BindData(this._ModuleCode, this._ModuleId, this._ParentId);
	}

    //文件归档
	protected void btnArchiving_Click(object sender, EventArgs e)
	{
		/*
         1.根据项目编号查询附件列表
         2.调用接口创建项目编号文件夹
         3.调用接口循环创建文件
         */
		//检查必传文件
		var abus = new BasAttachmentBus();
		var needfiles = abus.GetTmplList(this._ModuleCode, this._ModuleId);
		foreach (bas_attachment att in needfiles) {
			if (string.IsNullOrEmpty(att.FilePath)) {
				this.Alert("请完成所有“必传文件”的上传，之后才可以归档！");
				return;
			}
		}
	}
}