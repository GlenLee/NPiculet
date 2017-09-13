using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Sys;

public partial class web_uc_PageFooter : System.Web.UI.UserControl
{
	private ConfigManager _config = new ConfigManager();

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// 版权信息
	/// </summary>
	/// <returns></returns>
	protected string GetCopyright() {
		return string.Format("<a href=\"{1}\">{0}</a>", _config.GetConfig("CompanyName"), _config.GetConfig("DomainName"));
	}

	/// <summary>
	/// 备案号
	/// </summary>
	/// <returns></returns>
	protected string GetICP() {
		return _config.GetConfig("ICP");
	}
}