using System;
using System.Web.UI;
using NPiculet.Logic.Sys;

namespace NPiculet.Logic.Base {
	public class NormalPage : System.Web.UI.Page
	{
        #region 通用方法

        public void Alert(string msg) {
			Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + msg + "');", true);
		}

		public void AlertAjax(Control control, string msg)
		{
			ScriptManager.RegisterStartupScript(control, this.GetType(), "msg", "alert('" + msg + "');", true);
		}

		public void JavaSrcipt(string js) {
			Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", js, true);
		}

		public void JavaSrciptAjax(Control control, string js)
		{
			ScriptManager.RegisterStartupScript(control, this.GetType(), "msg", js, true);
		}

		#endregion
	}

	/// <summary>
	/// 会员页基类
	/// </summary>
	public class MemberPage : NormalPage
	{
		protected override void OnInit(EventArgs e)
		{
			var member = LoginKit.GetCurrentMember();
			if (member == null) {
				string url = Request.ServerVariables["URL"];
				string query = Request.ServerVariables["QUERY_STRING"];
				string loginUrl = LoginKit.MemberLoginUrl;
				Response.Redirect(loginUrl + "?url=" + Server.UrlEncode(url + (string.IsNullOrEmpty(query) ? "" : "?" + query)));
			}
			base.OnInit(e);
		}

		protected Member CurrentUserInfo
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
	public class AdminPage : NormalPage
	{
		protected override void OnInit(EventArgs e)
		{
			var admin = LoginKit.GetCurrentAdmin();
			if (admin == null) {
				Response.Redirect(LoginKit.AdminLoginUrl);
			}
			base.OnInit(e);
		}

		protected Administrator CurrentUserInfo
		{
			get { return LoginKit.GetCurrentAdmin(); }
		}

		protected int CurrentUserId { get { return CurrentUserInfo.Id; } }
		protected string CurrentUserName { get { return CurrentUserInfo.Name; } }
		protected string CurrentUserAccount { get { return CurrentUserInfo.Account; } }
	}
}