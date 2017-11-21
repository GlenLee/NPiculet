using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPiculet.Base.EF;
using NPiculet.Cms.Business;
using NPiculet.CMS.Business;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_cms_MsgBoardGroupEdit : AdminPage
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
				var model = db.cms_msgboard_group.FirstOrDefault(x => x.Id == id);
				if (model != null) {
					BindKit.BindModelToContainer(this.editor, model);
				}
			}
		}
	}

	private List<MsgBoardConfig> GetConfigJson() {
		if (string.IsNullOrEmpty(this.Config.Value) || this.Config.Value == "null")
			return new List<MsgBoardConfig>();
		return JsonKit.Deserialize<List<MsgBoardConfig>>(this.Config.Value);
	}

	private void BindFields()
	{
		var tid = ConvertKit.ConvertValue(this.Id.Value, 0);
		if (tid > 0) {
			this.phFields.Visible = true;

			var fs = GetConfigJson();

			//加入空数据行，用于显示GirdView脚部
			if (fs.Count == 0) {
				fs.Add(new MsgBoardConfig());
				this.fields.ShowFooter = true;

				this.fields.DataBound += (sender, e) => {
					//if (this.fields.Rows.Count > 0)
					//	this.fields.Rows[0].Visible = false;

					var row = this.fields.Rows[0];
					int count = row.Cells.Count;
					row.Cells.Clear();
					row.Cells.Add(new TableCell() { ColumnSpan = count, Text = "没有数据", ForeColor = Color.DarkGray, HorizontalAlign = HorizontalAlign.Center });

				};
			}

			this.fields.DataSource = fs;
			this.fields.DataBind();
		} else {
			this.phFields.Visible = false;
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			int id = WebParmKit.GetQuery("id", 0);
			cms_msgboard_group group;

			using (var db = new NPiculetEntities()) {
				if (id > 0) {
					group = db.cms_msgboard_group.FirstOrDefault(a => a.Id == id);
				} else {
					group = new cms_msgboard_group();
					group.CreateDate = DateTime.Now;
					group.Creator = this.CurrentUserName;
				}
				BindKit.FillModelFromContainer(this.editor, group);
				db.cms_msgboard_group.AddOrUpdate(group);
				db.SaveChanges();
			}
			this.Id.Value = group.Id.ToString();

			this.promptControl.ShowSuccess("保存成功！");

			BindFields();
		}
	}

	/// <summary>
	/// 保存所有字段配置
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSaveField_Click(object sender, EventArgs e) {
		RefreshConfigJson();
		UpdateConfig();
	}

	/// <summary>
	/// 更新配置
	/// </summary>
	private void UpdateConfig() {
		int id = ConvertKit.ConvertValue(this.Id.Value, 0);
		var mbus = new CmsMsgBoardBus();
		mbus.UpdateGroupConfig(a => a.Id == id, this.Config.Value);
	}

	/// <summary>
	/// 刷新配置 Json
	/// </summary>
	private void RefreshConfigJson() {
		var fs = new List<MsgBoardConfig>();
		foreach (GridViewRow row in this.fields.Rows) {
			if (row.RowType == DataControlRowType.DataRow) {
				var field = new MsgBoardConfig();
				BindKit.FillModelFromContainer(row, field);
				fs.Add(field);
			}
		}
		this.Config.Value = fs.ToJson();
	}

	private List<bas_dict_item> _types = null;

	private void BindType(DropDownList ddl)
	{
		if (_types == null) {
			var dbus = new DictBus();
			_types = dbus.GetDictItemList("FieldType");
		}
		BindKit.BindToListControl(ddl, _types, "Name", "Value");
	}

	/// <summary>
	/// 绑定字段时处理下拉框
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void fields_OnRowDataBound(object sender, GridViewRowEventArgs e) {

		var ddl = (DropDownList)e.Row.FindControl("Type");
		if (ddl != null) BindType(ddl);

		if (e.Row.RowType == DataControlRowType.DataRow) {
			var data = (MsgBoardConfig)e.Row.DataItem;
			var val = Convert.ToString(data.Type);
			BindKit.SelectItemInSingleListControl(ddl, val, true);
		}
	}

	/// <summary>
	/// 删除字段
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void fields_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		var fs = GetConfigJson();
		if (fs.Count >= e.RowIndex) {
			fs.RemoveAt(e.RowIndex);
		}
		this.Config.Value = fs.ToString();

		UpdateConfig();
		BindFields();
	}

	protected void fields_OnRowCommand(object sender, GridViewCommandEventArgs e)
	{
		switch (e.CommandName) {
			case "Add":
				this.Config.Value = CreateField(this.fields.FooterRow);
				UpdateConfig();
				break;
		}
		BindFields();
	}

	private string CreateField(GridViewRow row) {
		var fs = GetConfigJson();

		var config = new MsgBoardConfig();
		BindKit.FillModelFromContainer(row, config);

		fs.Add(config);

		return fs.ToJson();
	}

}