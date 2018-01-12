using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class modules_cms_PageEdit : AdminPage
{
	public int GroupId { get { return WebParmKit.GetQuery("gid", 0); } }
	public string GroupCode { get { return WebParmKit.GetQuery("group", ""); } }

	private readonly CmsContentBus _cbus = new CmsContentBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			this.Author.Text = this.CurrentUserName;
			BindGroups();
			BindTmplList();
			BindData();
			BindTmplFields();
			InitControl();
		}
	}

	private void BindGroups()
	{
		var data = _cbus.GetGroupList(a => a.IsEnabled == 1 && (a.GroupType == "List" || a.GroupType == "Image"));
		this.groups.DataSource = data;
		this.groups.DataTextField = "GroupName";
		this.groups.DataValueField = "GroupCode";
		this.groups.DataBind();
	}

	/// <summary>
	/// 初始化控件
	/// </summary>
	private void InitControl()
	{
		if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
			this.btnPublish.Visible = false;
		} else {
			this.btnPublish.Visible = true;
			this.btnView.NavigateUrl = "~/view/" + this.Id.Value;
		}
	}

	private void BindData()
	{
		int gid = this.GroupId;
		string code = this.GroupCode;

		//获取组数据
		var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == gid);
		//if (group == null) {
		//	this.AlertBeauty("没有找到数据，请检查数据完整性！");
		//	this.btnSave.Visible = false;
		//	this.btnPublish.Visible = false;
		//	this.btnView.Visible = false;
		//	return;
		//}
		if (group != null) {
			this.Title = group.GroupName;
			this.GroupName.Text = group.GroupName;
			this.mGroupCode.Value = group.GroupCode;
		}

		//获取页数据
		int dataId = WebParmKit.GetQuery("id", 0);
		if (dataId > 0) {
			var model = _cbus.GetPage(a => a.Id == dataId);
			if (model != null) {
				BindKit.BindModelToContainer(this.editor, model);
				this.InfoTitle.Text = model.Title;

				ShowThumb(model.Thumb);

				//处理置顶
				this.Sort.Checked = model.Sort == 0;
			}

			this.btnView.Visible = true;
		} else {
			this.btnView.Visible = false;
		}

		//处理所属组
		using (var db = new NPiculetEntities()) {
			var gdata = (from a in db.cms_content_link where a.PageId == dataId select a).ToList();
			foreach (ListItem item in this.groups.Items) {
				foreach (cms_content_link link in gdata) {
					if (item.Value == link.GroupCode) {
						item.Selected = true;
					}
				}
				if (item.Value == this.mGroupCode.Value) {
					item.Selected = true;
				}
			}
		}
	}

	/// <summary>
	/// 绑定模板下拉框
	/// </summary>
	private void BindTmplList()
	{
		using (var db = new NPiculetEntities()) {
			var query = (from a in db.cms_content_tmpl orderby a.Sort select a).ToList();
			BindKit.BindToListControl(this.TemplateId, query, "Name", "Id");
			this.TemplateId.Items.Insert(0, new ListItem("", ""));
		}
	}

	/// <summary>
	/// 绑定模板字段
	/// </summary>
	private void BindTmplFields()
	{
		int dataId = WebParmKit.GetQuery("id", 0);
		int tid = ConvertKit.ConvertValue(this.TemplateId.SelectedValue, 0);

		using (var db = new NPiculetEntities()) {
			var query = (from f in db.cms_content_tmpl_field
				join v in db.cms_content_tmpl_value on f.Id equals v.FieldId into tmp
				from t in (from p in tmp where p.DataId == dataId select p).DefaultIfEmpty()
				where f.TemplateId == tid && f.Type != "fixed"
				select new {
					f.Id,
					f.Name,
					f.Code,
					f.Type,
					t.Value
				});
			this.fields.DataSource = query.ToList();
			this.fields.DataBind();

			if (tid > 0) {
				var fixedValue = db.cms_content_tmpl_value.FirstOrDefault(a => a.TemplateId == tid && a.DataId == dataId && a.Type == "fixed");
				if (fixedValue != null) this.TemplateContent.Value = fixedValue.Value;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			cms_content_page data;

			if (id == 0) {
				data = new cms_content_page();
			} else {
				data = _cbus.GetPage(a => a.Id == id);
			}

			BindKit.FillModelFromContainer(this.editor, data);

			if (!string.IsNullOrEmpty(this.Thumb.FileName)) {
				//清理老图像
				if (!string.IsNullOrEmpty(this.PreviewThumb.ImageUrl)) {
					var f = new FileInfo(Server.MapPath(this.PreviewThumb.ImageUrl));
					if (f.Exists) f.Delete();
				}
				//更新新图
				if (this.Thumb.PostedFile.ContentLength > 0) {
					if (FileKit.IsImage(this.Thumb.PostedFile.FileName)) {
						int defaultWidth = new ConfigManager().GetConfig<int>("ImageWidth");
						if (defaultWidth < 1) defaultWidth = 1000;
						data.Thumb = FileWebKit.SaveZoomImage(this.Thumb.PostedFile, defaultWidth);
					} else {
						this.Alert("您上传的不是图片！");
					}
				}
				ShowThumb(data.Thumb);
			}

			//处理置顶
			data.Sort = this.Sort.Checked ? 0 : 1;

			//处理组信息
			int gid = this.GroupId;
			string code = this.GroupCode;
			var group = _cbus.GetGroup(a => a.GroupCode == code || a.Id == gid);

			if (string.IsNullOrEmpty(this.Id.Value) || this.Id.Value == "0") {
				InsertNewData(data, group);
			} else {
				data.Title = this.InfoTitle.Text;
				_cbus.SavePage(data);
			}

			this.Id.Value = data.Id.ToString();

			SaveGroups();
			SaveTmplFields(data);

			this.promptControl.ShowSuccess("保存成功！");
		}

		InitControl();
	}

	/// <summary>
	/// 保存所属组
	/// </summary>
	private void SaveGroups() {
		int pageId = ConvertKit.ConvertValue(this.Id.Value, 0);
		var links = new List<cms_content_link>();
		foreach (ListItem item in this.groups.Items) {
			if (item.Selected) {
				links.Add(new cms_content_link() { PageId = pageId, GroupCode = item.Value });
			}
		}
		using (var db = new NPiculetEntities()) {
			var hasdata = db.cms_content_link.Where(a => a.PageId == pageId).ToList();
			//计算差集新增
			var except = links.Except(hasdata, new GroupCompare()).ToList();
			db.cms_content_link.AddRange(except);
			//删除多余数据
			var delete = hasdata.Except(links, new GroupCompare());
			db.cms_content_link.RemoveRange(delete);
			db.SaveChanges();
		}
	}

	private class GroupCompare : IEqualityComparer<cms_content_link>
	{
		public bool Equals(cms_content_link x, cms_content_link y)
		{
			if (ReferenceEquals(x, y)) return true;
			return x != null && y != null
				&& x.PageId == y.PageId
				&& x.GroupCode == y.GroupCode;
		}

		public int GetHashCode(cms_content_link obj)
		{
			int hCode = obj.PageId.GetHashCode() ^ obj.GroupCode.GetHashCode();
			return hCode.GetHashCode();
		}
	}

	/// <summary>
	/// 保存模板字段配置
	/// </summary>
	/// <param name="data"></param>
	private void SaveTmplFields(cms_content_page data) {

		//处理模板内容
		int tid = ConvertKit.ConvertValue(this.TemplateId.SelectedValue, 0);
		if (tid > 0) {
			using (var db = new NPiculetEntities()) {
				var tmpl = db.cms_content_tmpl.FirstOrDefault(a => a.Id == tid);

				for (int i = 0; i < this.fields.Items.Count; i++) {
					var item = this.fields.Items[i];
					var fid = ConvertKit.ConvertValue((item.FindControl("Id") as HiddenField).Value, 0);
					var fval = (item.FindControl("Value") as TextBox).Text;

					//更新模板数据
					var fvalue = db.cms_content_tmpl_value.FirstOrDefault(a => a.TemplateId == tid && a.FieldId == fid && a.DataId == data.Id);
					if (fvalue == null) {
						fvalue = new cms_content_tmpl_value();
						fvalue.TemplateId = tid;
						fvalue.FieldId = fid;
						fvalue.DataId = data.Id;
						fvalue.Value = fval;
						db.cms_content_tmpl_value.Add(fvalue);
					} else {
						fvalue.Value = fval;
					}
				}
				var fixedField = db.cms_content_tmpl_field.FirstOrDefault(a => a.TemplateId == tid && a.Type == "fixed");
				if (fixedField == null) {
					fixedField = new cms_content_tmpl_field();
					fixedField.Code = "TemplateContent";
					fixedField.TemplateId = tid;
					fixedField.Type = "fixed";
					fixedField.CreateDate = DateTime.Now;
					fixedField.Name = "模板内容";
					fixedField.Creator = this.CurrentUserName;
					db.cms_content_tmpl_field.Add(fixedField);
				}
				db.SaveChanges();

				var fixedValue = db.cms_content_tmpl_value.FirstOrDefault(a => a.TemplateId == tid && a.FieldId == fixedField.Id && a.DataId == data.Id && a.Type == "fixed");
				if (fixedValue == null) {
					fixedValue = new cms_content_tmpl_value();
					fixedValue.TemplateId = tid;
					fixedValue.FieldId = fixedField.Id;
					fixedValue.DataId = data.Id;
					fixedValue.Type = "fixed";
					db.cms_content_tmpl_value.Add(fixedValue);
				}
				fixedValue.Value = this.TemplateContent.Value;
				db.SaveChanges();

				string tmplHtml = tmpl.Template;
				//替换模板字段
				for (int i = 0; i < this.fields.Items.Count; i++) {
					var item = this.fields.Items[i];
					//var fid = ConvertKit.ConvertValue((item.FindControl("Id") as HiddenField).Value, 0);
					var fcode = (item.FindControl("Code") as HiddenField).Value;
					var ftype = (item.FindControl("Type") as HiddenField).Value;
					var fval = (item.FindControl("Value") as TextBox).Text;
					if (ftype == "textarea") fval = fval.Replace("\r\n", "<br/>　　　");
					tmplHtml = tmplHtml.Replace("{{" + fcode + "}}", fval);
				}
				//替换固定字段
				tmplHtml = tmplHtml.Replace("{{标题}}", data.Title);
				tmplHtml = tmplHtml.Replace("{{内容}}", this.TemplateContent.Value);
				data.Content = tmplHtml;
				this.Content.Value = tmplHtml;
				_cbus.SavePage(data);
			}
		}
	}

	/// <summary>
	/// 新增数据
	/// </summary>
	/// <param name="model"></param>
	/// <param name="group"></param>
	private void InsertNewData(cms_content_page model, cms_content_group group)
	{
		var user = this.CurrentUserInfo;

		model.Id = 0;
		model.Title = this.InfoTitle.Text;
		model.GroupCode = group == null ? null : group.GroupCode;
		model.Click = 0;
		model.CreateDate = DateTime.Now;
		model.IsEnabled = 0;
		if (user.Organization != null)
			model.OrgId = user.Organization.Id;
		model.UserId = user.Id;
		model.Author = user.Name;

		_cbus.SavePage(model);

		BindKit.BindModelToContainer(this.editor, model);

		this.Sort.Checked = model.Sort == 0;

		//保存日志和加积分
		int point = ConvertKit.ConvertValue(new ConfigManager().GetConfig("NewsPoint"), 0);
		var pbus = new CmsPointBus();
		pbus.SavePointLog(this.CurrentUserInfo, "cms_content_page", model.Id.ToString(), point, "发布文章，增加积分", model.Title);
	}

	/// <summary>
	/// 显示缩略图
	/// </summary>
	/// <param name="thumbPath"></param>
	private void ShowThumb(string thumbPath)
	{
		if (!string.IsNullOrEmpty(thumbPath)) {
			this.ThumbHyperLink.NavigateUrl = thumbPath;
			this.PreviewThumb.ImageUrl = thumbPath;
			this.PreviewThumb.Visible = true;
		} else {
			this.PreviewThumb.Visible = false;
		}
	}

	/// <summary>
	/// 组合返回链接
	/// </summary>
	/// <returns></returns>
	protected string GetBackUrl() {
		int gid = this.GroupId;
		string code = this.GroupCode;
		string url = "<a href=\"PageList.aspx?";
		if (gid > 0) url += "gid=" + gid;
		if (!string.IsNullOrEmpty(code)) url += "group=" + code;
		url += "\"><i class=\"fa fa-arrow-left\"></i>返回</a>";
		return url;
	}

	/// <summary>
	/// 发布文章
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnPublish_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Id.Value) && this.Id.Value != "0") {
			int id = ConvertKit.ConvertValue(this.Id.Value, 0);
			_cbus.PublishPage(id);
			this.IsEnabled.Checked = true;
		}
	}

	/// <summary>
	/// 选择模板判断
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void TemplateId_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		var val = this.TemplateId.SelectedValue;
		var useTmpl = !string.IsNullOrEmpty(val);
		this.phContent.Visible = !useTmpl;
		this.phTmpl.Visible = useTmpl;
		if (useTmpl) BindTmplFields();
	}

	/// <summary>
	/// 模板字段绑定事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void fields_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		dynamic data = e.Item.DataItem;
		if (data.Type == "textarea") {
			var box = e.Item.FindControl("Value") as TextBox;
			if (box != null) {
				box.TextMode = TextBoxMode.MultiLine;
				box.Rows = 3;
			}
		}
	}
}