using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Toolkit;

public partial class modules_common_FileModifyDialog : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			int aid = WebParmKit.GetQuery("id", 0);
			BindData(aid);
		}
	}

	private void BindData(int aid)
	{
		using (var db = new NPiculetEntities()) {
			var att = db.bas_attachment.FirstOrDefault(a => a.Id == aid);
			if (att != null) {
				this.name.Text = att.Name;
				this.name.ReadOnly = (att.IsDir == 0);
				BindDir();
				this.curDir.SelectedValue = Convert.ToString(att.ParentId);
			}
		}
	}

	private void BindDir()
	{
		int aid = WebParmKit.GetQuery("id", 0);
		string moduleId = WebParmKit.GetQuery("key", "");
		AttachmentBus abus = new AttachmentBus();
		this.curDir.DataSource = abus.GetAllDir(moduleId, aid);
		this.curDir.DataTextField = "Name";
		this.curDir.DataValueField = "Id";
		this.curDir.DataBind();
	}

	protected void btnModify_Click(object sender, EventArgs e)
	{
		try {
			using (var db = new NPiculetEntities()) {
				int aid = WebParmKit.GetQuery("id", 0);
				var att = db.bas_attachment.FirstOrDefault(a => a.Id == aid);
				if (att != null) {
					att.ParentId = Int32.Parse(this.curDir.SelectedValue);
					att.Name = this.name.Text;
					db.SaveChanges();
				}
				this.JavaSrcipt("closeWin();");
			}
		} catch (DBConcurrencyException edb) {
			this.AlertBeauty("修改失败" + edb.Message);
		}
	}
}