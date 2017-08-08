using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class system_Admin_ConfigSet : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack) {
			BindData();
		}
    }

	private readonly SysConfigBus _bus = new SysConfigBus();

	private void BindData()
	{
		var configs = _bus.QueryList("");

		foreach (Control control in this.container.Controls) {
			TextBox tb = control as TextBox;
			if (tb != null) {
				var val = GetControlValue(configs, tb.ID);
				if (val != null) tb.Text = val;
			}

			CheckBox cb = control as CheckBox;
			if (cb != null) {
				var val = GetControlValue(configs, cb.ID);
				if (val != null) cb.Enabled = val == "1";
			}

			DropDownList ddl = control as DropDownList;
			if (ddl != null) {
				var val = GetControlValue(configs, ddl.ID);
				if (val != null) BindKit.SelectItemInSingleListControl(ddl, val, true);
			}
		}
	}

	private string GetControlValue(List<SysConfig> configs, string controlId)
	{
		var config = (from c in configs where c.ConfigCode == controlId select c).FirstOrDefault();
		return config == null ? null : config.ConfigValue;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (Page.IsValid) {
			foreach (Control control in this.container.Controls) {
				TextBox tb = control as TextBox;
				if (tb != null) {
					var config = _bus.CreateModel();
					config.ConfigCode = tb.ID;
					config.ConfigValue = tb.Text;
					config.IsEnabled = 1;
					config.Creator = this.CurrentUserName;
					config.CreateDate = DateTime.Now;

					if (!_bus.Update(config, "ConfigCode='" + tb.ID + "'")) {
						_bus.Insert(config);
					}
				}

				CheckBox cb = control as CheckBox;
				if (cb != null) {
					var config = _bus.CreateModel();
					config.ConfigCode = cb.ID;
					config.ConfigValue = cb.Checked ? "1" : "0";
					config.IsEnabled = 1;
					config.Creator = this.CurrentUserName;
					config.CreateDate = DateTime.Now;

					if (!_bus.Update(config, "ConfigCode='" + cb.ID + "'")) {
						_bus.Insert(config);
					}
				}

				DropDownList ddl = control as DropDownList;
				if (ddl != null) {
					var config = _bus.CreateModel();
					config.ConfigCode = ddl.ID;
					config.ConfigValue = ddl.SelectedValue;
					config.IsEnabled = 1;
					config.Creator = this.CurrentUserName;
					config.CreateDate = DateTime.Now;

					if (!_bus.Update(config, "ConfigCode='" + ddl.ID + "'")) {
						_bus.Insert(config);
					}
				}
			}

			new ConfigManager().ClearWebConfigCache();

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}