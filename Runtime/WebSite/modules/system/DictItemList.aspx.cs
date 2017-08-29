using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_DictItemList : AdminPage
{
	private readonly DictBus _dbus = new DictBus();

	protected void Page_Load(object sender, EventArgs e)
	{
		//修改表头
		BindTableHeader();
		//绑定数据
		if (!Page.IsPostBack) {
			BindDictGroup();

			//获取字典分组
			string group = WebParmKit.GetQuery("group", "");
			string fix = WebParmKit.GetQuery("fix", "");
			if (!string.IsNullOrEmpty(group)) {
				this.ddlDictGroup.SelectedIndex = this.ddlDictGroup.Items.IndexOf(this.ddlDictGroup.Items.FindByValue(group));
				this.Title = this.ddlDictGroup.SelectedItem.Text;
			}
			if (fix == "true") {
				this.ddlDictGroup.Enabled = false;
				this.ddlDictGroup.Visible = false;
			}

			//绑定数据
			BindData();
		}
		//分页事件
		this.NPager1.PageClick += (o, args) => {
			BindData();
		};
	}

	private void BindTableHeader()
	{
		string colnumNames = WebParmKit.GetQuery("cols", "");
		if (!string.IsNullOrEmpty(colnumNames)) {
			string[] cols = colnumNames.Split(',');
			for (int i = 0; i < cols.Length; i++) {
				this.list.Columns[i].HeaderText = cols[i];
			}
		}
	}


	private void BindDictGroup()
	{
		this.ddlDictGroup.DataSource = _dbus.GetDictGroup(a => a.IsDel == 0);
		this.ddlDictGroup.DataTextField = "Name";
		this.ddlDictGroup.DataValueField = "Code";
		this.ddlDictGroup.DataBind();
		this.ddlDictGroup.Items.Insert(0, new ListItem("全部", ""));
	}

	private void BindData()
	{
		string whereString = "";
		string key = this.txtKeywords.Text.FormatSqlParm();

		if (!string.IsNullOrEmpty(this.ddlDictGroup.SelectedValue)) whereString = string.Format("`GroupCode`='{0}'", this.ddlDictGroup.SelectedValue);
		if (!string.IsNullOrEmpty(key)) {
			if (!string.IsNullOrEmpty(whereString)) whereString += " AND ";
			whereString += string.Format("(Name LIKE '%{0}%' OR Code LIKE '%{0}%')", key);
		}

		int count;
		this.list.DataSource = _dbus.GetDictItemData(out count, this.NPager1.CurrentPage, this.NPager1.PageSize, this.ddlDictGroup.SelectedValue, this.txtKeywords.Text);
		this.list.DataBind();

		this.NPager1.RecordCount = count;

		BindKit.BindOnClientClick(this.list, "Delete", "return confirm('确定要删除吗？');");
	}

	protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex > -1) {
			if (this.list.DataKeys.Count > e.RowIndex) {
				int id = ConvertKit.ConvertValue(this.list.DataKeys[e.RowIndex]["Id"], 0);
				_dbus.DeleteItem(id);
			}
			BindData();
		}
	}

	protected string GetStatusString(string enabled)
	{
		return enabled == "1" ? "启用" : "<span style=\"color:red\">停用</span>";
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		BindData();
	}
}