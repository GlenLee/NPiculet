using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using NPiculet.Authorization;
using NPiculet.Logic.Sys;

namespace NPiculet.Logic.Base {
	public class NormalPage : System.Web.UI.Page
	{
        #region 通用方法

        public void Alert(string msg) {
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('" + msg + "');", true);
		}

		public void AlertAjax(Control control, string msg)
		{
			ScriptManager.RegisterClientScriptBlock(control, this.GetType(), "msg", "alert('" + msg + "');", true);
		}

		/// <summary>
		/// 专用自定义Js弹出对话框
		/// </summary>
		/// <param name="msg"></param>
		protected virtual void AlertLayer(string msg)
		{
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "layer.alert('" + msg + "');", true);
		}

		public void JavaSrcipt(string js) {
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", js, true);
		}

		public void JavaSrciptAjax(Control control, string js)
		{
			ScriptManager.RegisterClientScriptBlock(control, this.GetType(), "msg", js, true);
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
				//member = LoginKit.MemberExist("test");
				//LoginKit.MemberLogin(member);
				string url = Request.ServerVariables["URL"];
				string query = Request.ServerVariables["QUERY_STRING"];
				string loginUrl = LoginKit.MemberLoginUrl;
				Response.Redirect(loginUrl + "?url=" + Server.UrlEncode(url + (string.IsNullOrEmpty(query) ? "" : "?" + query)));
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
	public class AdminPage : NormalPage
	{
		protected override void OnInit(EventArgs e)
		{
			//检查登陆状态
			var admin = LoginKit.GetCurrentAdmin();
			if (admin == null) {
				//admin = LoginKit.AdminExist("admin");
				//LoginKit.AdminLogin(admin);
				Response.Redirect(LoginKit.AdminLoginUrl);
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