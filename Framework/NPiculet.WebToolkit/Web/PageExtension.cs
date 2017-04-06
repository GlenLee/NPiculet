using System.Web.UI.WebControls;

namespace System.Web.UI
{
	public static class PageExtension
	{
		public static void Redirect(this Page page, string navigateUrl, params ListItem[] parameters)
		{
			string url = navigateUrl;
			if (parameters != null) {
				bool flag = true;
				foreach (ListItem parameter in parameters) {
					if (flag) {
						url += "?";
						flag = false;
					} else {
						url += "&";
					}
					url += string.Format("{0}={1}", parameter.Text, page.Server.UrlEncode(parameter.Value));
				}
			}
			page.Response.Redirect(page.ResolveUrl(url), false);
		}

		public static void Redirect(this UserControl userControl, string navigateUrl, params ListItem[] parameters)
		{
			string url = navigateUrl;
			if (parameters != null) {
				bool flag = true;
				foreach (ListItem parameter in parameters) {
					if (flag) {
						url += "?";
						flag = false;
					} else {
						url += "&";
					}
					url += string.Format("{0}={1}", parameter.Text, userControl.Server.UrlEncode(parameter.Value));
				}
			}
			userControl.Response.Redirect(userControl.ResolveUrl(url), false);
		}

		/// <summary>
		/// 弹出提示框。
		/// </summary>
		/// <param name="page"></param>
		/// <param name="msg"></param>
		public static void Alert(this Page page, string msg)
		{
			page.ClientScript.RegisterStartupScript(page.GetType(), "msg", "alert('" + msg + "');", true);
		}

		/// <summary>
		/// 弹出提示框。
		/// </summary>
		/// <param name="userControl"></param>
		/// <param name="msg"></param>
		public static void Alert(this UserControl userControl, string msg)
		{
			userControl.Page.ClientScript.RegisterStartupScript(userControl.GetType(), "msg", "alert('" + msg + "');", true);
		}

		/// <summary>
		/// 执行 Javascript 脚本。
		/// </summary>
		/// <param name="page"></param>
		/// <param name="js"></param>
		public static void JavaSrcipt(this Page page, string js)
		{
			page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), js, true);
		}

		/// <summary>
		/// 执行 Javascript 脚本。
		/// </summary>
		/// <param name="userControl"></param>
		/// <param name="js"></param>
		public static void JavaSrcipt(this UserControl userControl, string js)
		{
			userControl.Page.ClientScript.RegisterStartupScript(userControl.GetType(), Guid.NewGuid().ToString(), js, true);
		}

		/// <summary>
		/// 添加属性
		/// </summary>
		/// <param name="control"></param>
		/// <param name="sKey"></param>
		/// <param name="strValue"></param>
		public static void SetAttribute(this WebControl control, string sKey, string strValue)
		{
			if (control != null) {
				if (control.Attributes[sKey] != null) {
					string str = control.Attributes[sKey].Trim();
					if (str.IndexOf(strValue) == -1) {
						if ((str.Length != 0) && !str.EndsWith(";")) {
							str = str + ";";
						}
						control.Attributes[sKey] = str + strValue;
					}
				} else {
					control.Attributes.Add(sKey, strValue);
				}
			}
		}
	}
}
