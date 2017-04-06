using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class _default : System.Web.UI.Page
{
	public List<SysUserInfo> list = new List<SysUserInfo>();

	public void print(object msg)
	{
		Response.Write(msg + "<br />");
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		list.Add(new SysUserInfo() { Name = "ABC" });

		//print(JsonKit.Serialize(list));
		//print(list.ToJson());

		string json = "[{ Name: 'xxxxxx', Password: '1231231' }, { Name: 'xyz' }]";
		var l = JsonKit.Deserialize<List<SysUserInfo>>(json);

		print(l.ToJson());

		print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
	}
}