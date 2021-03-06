﻿using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Log;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class FindPassStep1 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e) {

	}

	protected void btnFindPass_Click(object sender, EventArgs e) {
		if (!Page.IsValid)
			return;

		using (var db = new NPiculetEntities()) {
			var exist = db.sys_member_data.FirstOrDefault(x => x.MemberAccount == Account.Text && x.Mobile == this.Mobile.Text && x.Email == this.Email.Text);
			if (exist != null) {
				var count = db.sys_member_info.FirstOrDefault(x => x.Name == this.Name.Text);
				if (count != null) {
					this.Alert("您的密码为：" + count.Password + ",请尽快联系管理员修改密码。");
					return;
				} else {
					this.Alert("找不到该用户名信息，请联系管理员处理！");
					return;
				}
			} else {
				this.Alert("找不到该用户名信息，请核实具相关内容填写是否正确！");
				return;
			}
		}
	}
}