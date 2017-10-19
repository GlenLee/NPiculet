using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class modules_cms_ContentTmplEdit : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			BindData();
			BindFields();
		}
	}

	private void BindData()
	{
		var id = WebParmKit.GetQuery("id", 0);
		if (id > 0) {
			using (var db = new NPiculetEntities()) {
				var model = db.cms_content_tmpl.FirstOrDefault(x => x.Id == id);
				if (model != null) {
					BindKit.BindModelToContainer(this.editor, model);
					this.IsEnabled.Checked = model.IsEnabled == 1;
				}
			}
		}
	}

	private void BindFields()
	{
		var tid = ConvertKit.ConvertValue(this.Id.Value, 0);
		if (tid > 0) {
			this.phFields.Visible = true;

			using (var db = new NPiculetEntities()) {
				var data = db.cms_content_tmpl_field.Where(a => a.TemplateId == tid).ToList();
				if (data.Count == 0) {
					data.Add(new cms_content_tmpl_field() { Name = "" });
					this.fields.DataBound += (sender, e) => {
						this.fields.Rows[0].Visible = false;
					};
				}

				this.fields.DataSource = data;
				this.fields.DataBind();
			}
		} else {
			this.phFields.Visible = false;
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			int id = WebParmKit.GetQuery("id", 0);
			cms_content_tmpl tmpl;

			using (var db = new NPiculetEntities()) {
				if (id > 0) {
					tmpl = db.cms_content_tmpl.FirstOrDefault(a => a.Id == id);
				} else {
					tmpl = new cms_content_tmpl();
					tmpl.CreateDate = DateTime.Now;
					tmpl.Creator = this.CurrentUserName;
				}
				BindKit.FillModelFromContainer(this.editor, tmpl);
				db.cms_content_tmpl.AddOrUpdate(tmpl);
				db.SaveChanges();
			}
			this.Id.Value = tmpl.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");

			BindFields();
		}
	}

	protected void btnSaveField_Click(object sender, EventArgs e) {
		foreach (GridViewRow row in this.fields.Rows) {
			if (row.RowType == DataControlRowType.DataRow) {
				SaveField(row);
			}
		}
	}

	private void CreateField(GridViewRow row) {
		var data = new cms_content_tmpl_field();
		BindKit.FillModelFromContainer(row, data);
		
		data.TemplateId = ConvertKit.ConvertValue(this.Id.Value, 0);
		data.CreateDate = DateTime.Now;
		data.Creator = this.CurrentUserName;

		using (var db = new NPiculetEntities()) {
			db.cms_content_tmpl_field.Add(data);
			db.SaveChanges();
		}
		BindFields();
	}

	private void SaveField(GridViewRow row)
	{
		using (var db = new NPiculetEntities()) {
			int id = ConvertKit.ConvertValue((row.FindControl("Id") as HiddenField).Value, 0);
			var data = db.cms_content_tmpl_field.FirstOrDefault(a => a.Id == id);
			if (data != null) {
				BindKit.FillModelFromContainer(row, data);

				db.cms_content_tmpl_field.AddOrUpdate(data);
				db.SaveChanges();
			}
		}
		BindFields();
	}

	protected void fields_OnRowDeleting(object sender, GridViewDeleteEventArgs e) {
		int id = ConvertKit.ConvertValue(this.fields.DataKeys[e.RowIndex]["Id"], 0);
		using (var db = new NPiculetEntities()) {
			var field = new cms_content_tmpl_field() { Id = id };
			db.cms_content_tmpl_field.Attach(field);
			db.cms_content_tmpl_field.Remove(field);
			db.SaveChanges();
		}
		BindFields();
	}

	protected void fields_OnRowCommand(object sender, GridViewCommandEventArgs e) {
		switch (e.CommandName) {
			case "Add":
				CreateField(this.fields.FooterRow);
				break;
		}
	}
}