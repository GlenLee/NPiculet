using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NPiculet.Authorization;
using NPiculet.Base.EF;
using NPiculet.Logic.Data;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

namespace NPiculet.Logic.Base
{
	public class NormalUserControl : System.Web.UI.UserControl {
		#region 初始化参数

		/// <summary>
		/// 会员登录地址
		/// </summary>
		public string MemberLoginUrl { get { return WebConfigurationManager.AppSettings["MemberLoginUrl"]; } }

		/// <summary>
		/// 管理员登录地址
		/// </summary>
		public string AdminLoginUrl { get { return WebConfigurationManager.AppSettings["AdminLoginUrl"]; } }

		#endregion

		#region 通用方法

		public void Alert(string msg) {
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('" + msg + "');", true);
		}

		public void AlertAjax(Control control, string msg) {
			ScriptManager.RegisterClientScriptBlock(control, this.GetType(), "msg", "alert('" + msg + "');", true);
		}

		public void JavaSrcipt(string js) {
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", js, true);
		}

		public void JavaSrciptAjax(Control control, string js) {
			ScriptManager.RegisterClientScriptBlock(control, this.GetType(), "msg", js, true);
		}

		#endregion
	}

	/// <summary>
	/// 会员页基类
	/// </summary>
	public class MemberUserControl : NormalUserControl
	{
		protected override void OnInit(EventArgs e)
		{
			var member = LoginKit.GetCurrentMember();
			if (member == null) {
				string url = Request.ServerVariables["URL"];
				string query = Request.ServerVariables["QUERY_STRING"];
				Response.Redirect("~/Login.aspx?url=" + Server.UrlPathEncode(url + (string.IsNullOrEmpty(query) ? "" : "?" + query)));
				//LoginKit.MemberLogin(new SysUserInfoBus().GetUserInfo("gongfeiyu"));
			}
			base.OnInit(e);
		}

		protected Member<int> CurrentUserInfo
		{
			get { return LoginKit.GetCurrentMember(); }
		}

		protected int CurrentUserId { get { return CurrentUserInfo.Id; } }
		protected string CurrentUserName { get { return CurrentUserInfo.Name; } }
		protected string CurrentUserAccount { get { return CurrentUserInfo.Account; } }

		/// <summary>
		/// 获取格式化的时间
		/// </summary>
		/// <param name="date"></param>
		/// <param name="formatString"></param>
		/// <returns></returns>
		protected string GetDateTimeString(DateTime date, string formatString = "yyyy-MM-dd HH:mm:ss")
		{
			if (date <= new DateTime(1800, 1, 1)) return "";
			return date.ToString(formatString);
		}
	}

	/// <summary>
	/// 后台管理页基类
	/// </summary>
	public class AdminUserControl : NormalUserControl
	{
		protected override void OnInit(EventArgs e)
		{
			var admin = LoginKit.GetCurrentAdmin();
			if (admin == null) {
				Response.Redirect("~/modules/Default.aspx");
				//LoginKit.AdminLogin(new SysUserInfoBus().GetUserInfo("gongfeiyu"));
			}
			base.OnInit(e);
		}

		protected Administrator<int> CurrentUserInfo
		{
			get { return LoginKit.GetCurrentAdmin(); }
		}

		protected int CurrentUserId { get { return CurrentUserInfo.Id; } }
		protected string CurrentUserName { get { return CurrentUserInfo.Name; } }
		protected string CurrentUserAccount { get { return CurrentUserInfo.Account; } }
	}
}