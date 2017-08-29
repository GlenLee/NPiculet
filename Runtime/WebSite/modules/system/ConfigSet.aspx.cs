using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
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

	private ConfigBus _cbus = new ConfigBus();

	private void BindData()
	{
		var configs = _cbus.GetConfigList(null);

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

	private string GetControlValue(List<sys_config> configs, string controlId)
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
					var config = new sys_config();
					config.ConfigCode = tb.ID;
					config.ConfigValue = tb.Text;
					config.IsEnabled = 1;
					config.Creator = this.CurrentUserName;
					config.CreateDate = DateTime.Now;

					_cbus.Save(config, a => a.ConfigCode == tb.ID);
				}

				CheckBox cb = control as CheckBox;
				if (cb != null) {
					var config = new sys_config();
					config.ConfigCode = cb.ID;
					config.ConfigValue = cb.Checked ? "1" : "0";
					config.IsEnabled = 1;
					config.Creator = this.CurrentUserName;
					config.CreateDate = DateTime.Now;

					_cbus.Save(config, a => a.ConfigCode == tb.ID);
				}

				DropDownList ddl = control as DropDownList;
				if (ddl != null) {
					var config = new sys_config();
					config.ConfigCode = ddl.ID;
					config.ConfigValue = ddl.SelectedValue;
					config.IsEnabled = 1;
					config.Creator = this.CurrentUserName;
					config.CreateDate = DateTime.Now;

					_cbus.Save(config, a => a.ConfigCode == tb.ID);
				}
			}

			new ConfigManager().ClearConfigCache();

			this.promptControl.ShowSuccess("保存成功！");
		}
	}
}