using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Toolkit;

public partial class EntRegStep2 : NormalPage
{
	private readonly NPiculetEntities _db = new NPiculetEntities();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			string account = WebParmKit.GetRequestString("account", "");

			if (string.IsNullOrEmpty(account)) {
				Response.Redirect("EntRegStep1.aspx");
				return;
			}
			
			var userInfo = _db.sys_member_info.FirstOrDefault(x => x.Account == account);
			if (userInfo == null) {
				JavaSrcipt("$.alert('无法获取用户信息，请重新注册或者登陆后再填写！');");
				return;
			}
			if (userInfo.Status == "1") {
				Response.Redirect("EntRegStep3.aspx");
				return;
			}

			var corporation = _db.sys_member_corporation.FirstOrDefault(x => x.UserId == userInfo.Id);
			if (corporation != null) {
				BindKit.BindModelToContainer(this.CorpInfo, corporation);
			}

			UserAccount.Text = account;
			CorporationNature.DataSource = CommonLib.EnterpriseNatures;
			CorporationNature.DataBind();
		}
	}

	protected void btnNext_Click(object sender, EventArgs e)
	{
		if(!corpRegLng.Value.Any() || string.IsNullOrEmpty(corpRegLng.Value.Trim()))
		{
			JavaSrcipt("$.alert('请在地图上设置您的企业地址！');");
			return;
		}
		
		string account = UserAccount.Text.Trim();
		if (string.IsNullOrEmpty(account))
		{
			JavaSrcipt("$.alert('无法获取上一步注册的用户信息，请重新注册或者登陆后再填写！');");
			return;
		}

		var userInfo = _db.sys_member_info.FirstOrDefault(x => x.Account == account);
		if (userInfo == null)
		{
			JavaSrcipt("$.alert('无法获取用户信息，请重新注册或者登陆后再填写！');");
			return;
		}

		var corporation = _db.sys_member_corporation.FirstOrDefault(x => x.UserId == userInfo.Id);
		if (corporation == null)
		{
			string lng = corpRegLng.Value.Trim();
			string lat = corpRegLat.Value.Trim();
			var model = _db.sys_member_corporation.Create();
			BindKit.FillModelFromContainer(CorpInfo, model);
			model.UserAccount = userInfo.Account;
			model.UserId = userInfo.Id;
			model.longitude = lng;
			model.Altitudes = lat;
			_db.sys_member_corporation.Add(model);
			_db.SaveChanges();
		} else {
			BindKit.FillModelFromContainer(CorpInfo, corporation);
			_db.SaveChanges();
		}

		Response.Redirect("EntRegStep3.aspx");
	}
}