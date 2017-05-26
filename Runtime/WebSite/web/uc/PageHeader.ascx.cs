using System;
using System.Linq;
using System.Web.UI;
using NPiculet.Base.EF;
using NPiculet.Logic.Sys;

namespace web.uc
{
	public partial class WebUcPageHeader : System.Web.UI.UserControl
	{
		private sys_member_info _currentUser;
		readonly NPiculetEntities _sysEntities = new NPiculetEntities();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected string GetLoginStatus()
		{
			var user = LoginKit.GetCurrentMember();
			if (user == null)
			{
				return "<a href=\"" + ResolveClientUrl("~/Login.aspx") + "\">登录</a> | <a href=\"" +
						ResolveClientUrl("~/EntRegStep1.aspx") + "\">注册</a>";
			}
		
			_currentUser = _sysEntities.sys_member_info.SingleOrDefault(x => x.Id == user.Id);
			if (_currentUser == null)
			{ 
				return "<a href=\"" + ResolveClientUrl("~/Login.aspx") + "\">登录</a> | <a href=\"" +
						ResolveClientUrl("~/EntRegStep1.aspx") + "\">注册</a>";
			}

			var level = _currentUser.MemberLevel;
			switch (level)
			{
				case "个人用户":
				{
					string html = user.Name + "，你好！";
					html += " <a href=\"" + ResolveClientUrl("~/MemberCenter.aspx") + "\">用户中心</a> | <a href=\"" + ResolveClientUrl("~/Logout.aspx") + "\">退出</a>";
					return html;
				}
				case "企业用户":
				{
					string html = user.Name + "，你好！";
					html += " <a href=\"" + ResolveClientUrl("~/CorporationCenter.aspx") + "\">用户中心</a> | <a href=\"" +
							ResolveClientUrl("~/Logout.aspx") + "\">退出</a>";
					return html;
				}
				default:
				{
					string html = user.Name + "，你好！";
					html += "<a href=\"" + ResolveClientUrl("~/Logout.aspx") + "\">退出</a>";
					return html;
				}
			}
		}
	}
}