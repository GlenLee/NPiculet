using NPiculet.Base.EF;
using NPiculet.Toolkit;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_Help : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {

			var config = new sys_config();
			config.ConfigCode = "FF";
			config.ConfigValue = StringKit.GetStringByDateTime();

			Expression<Func<sys_config, bool>> predicate = null;
			using (var db = new NPiculetEntities()) {
				var c = db.sys_config.FirstOrDefault(predicate);
				Response.Write(JsonKit.Serialize(c));

				//config.Id = c.Id;
				//db.sys_config.AddOrUpdate(config);

				this.gvSingleTable.DataSource = db.sys_config.ToList();
				this.gvSingleTable.DataBind();

			}
		}
	}
}