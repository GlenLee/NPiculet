using System;
using System.Linq;
using NPiculet.Base.EF;
using System.Web.UI;
using NPiculet.Authorization;

namespace web.uc
{
	public partial class WebUcMemberSimpleInfo : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) {
				var user = LoginKit.GetCurrentMember();
				if (user == null) return;

				using (NPiculetEntities db = new NPiculetEntities()) {
					var currentUser = db.sys_member_info.FirstOrDefault(d => d.Id == user.Id);
					if (currentUser != null) {
						lblAccount.Text = currentUser.Account;
						lblMemberLevel.Text = currentUser.MemberLevel;
						lblName.Text = currentUser.Name;
					}

					var data = db.sys_member_data.FirstOrDefault(d => d.UserId == user.Id);
					lblExp.Text = data == null ? "0" : Convert.ToDecimal(data.Exp).ToString("0.##");
				}
			}
		}

		protected void btn_center_Click(object sender, EventArgs e)
		{
			var user = LoginKit.GetCurrentMember();
			if (user == null) return;

			using (NPiculetEntities db = new NPiculetEntities()) {
				var currentUser = db.sys_member_info.FirstOrDefault(d => d.Id == user.Id);
				if (currentUser != null) {
					var level = currentUser.MemberLevel;
					if (!string.IsNullOrEmpty(level)) {
						if (level == "个人用户") {
							this.Response.Redirect("~/MemberCenter.aspx");
						} else {
							this.Response.Redirect("~/CorporationCenter.aspx");
						}
					} else {
						this.JavaSrcipt("$.alert('无法获取用户类型，请重新登陆！');");
						return;
					}
				}
			}
		}
	}
}