﻿using NPiculet.Base.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Cms.Business;
using NPiculet.Logic.Business;
using NPiculet.Logic.Sys;
using NPiculet.Toolkit;

public partial class _Default : System.Web.UI.Page
{
	private ConfigManager _config = new ConfigManager();

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// 获取网站名称
	/// </summary>
	/// <returns></returns>
	protected string GetWebSiteName()
	{
		return _config.GetConfig("WebSiteName");
	}
}