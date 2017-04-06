using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class modules_system_AuthSet : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack) {
			SetAuthMode(false);

		    BindTargetData();
			BindAuthData();
	    }
    }

	private readonly SysAuthorizationBus _bus = new SysAuthorizationBus();

	/// <summary>
	/// 绑定待授权目标数据
	/// </summary>
	private void BindTargetData()
	{
		string moduleName = WebParmKit.GetRequestString("m", "");
		int dataId = WebParmKit.GetRequestString("key", 0);
		string pageUrl = WebParmKit.GetRequestString("p", "");
		
		this.TargetType.Value = moduleName;
		this.TargetId.Value = dataId.ToString();

		if (dataId > 0 && !string.IsNullOrEmpty(moduleName)) {
			switch (moduleName) {
				case "Role":
					ShowRoleAuth();
					break;
				case "User":
					ShowUserAuth();
					break;
				case "Org":
					ShowOrgAuth();
					break;
			}
		}
	}

	/// <summary>
	/// 显示角色信息
	/// </summary>
	private void ShowRoleAuth()
	{
		this.TargetTypeName.Text = "角色";
		SysRoleInfoBus bus = new SysRoleInfoBus();
		var model = bus.QueryModel("Id=" + this.TargetId.Value);
		if (model != null) {
			this.TargetName.Text = model.RoleName;
			this.TargetMemo.Text = model.Comment;
		}
	}

	/// <summary>
	/// 显示用户信息
	/// </summary>
	private void ShowUserAuth()
	{
		this.TargetTypeName.Text = "用户";
		SysUserInfoBus bus = new SysUserInfoBus();
		var model = bus.QueryModel("Id=" + this.TargetId.Value);
		if (model != null) {
			this.TargetName.Text = model.Name;
			this.TargetMemo.Text = "用户帐号：" + model.Account;
		}
	}

	/// <summary>
	/// 显示组织机构信息
	/// </summary>
	private void ShowOrgAuth()
	{
		this.TargetTypeName.Text = "组织机构";
		SysOrgInfoBus bus = new SysOrgInfoBus();
		var model = bus.QueryModel("Id=" + this.TargetId.Value);
		if (model != null) {
			this.TargetName.Text = model.OrgName;
			this.TargetMemo.Text = model.Memo;
		}
	}

	private DataView _dv = null;

	/// <summary>
	/// 显示已授权数据
	/// </summary>
	private void BindAuthData()
	{
		_dv = _bus.GetAuthList(this.TargetType.Value, this.TargetId.Value).DefaultView;
		_dv.RowFilter = "ParentId=0";
		this.authMain.DataSource = _dv;
		this.authMain.DataBind();
	}

	/// <summary>
	/// 显示所有功能
	/// </summary>
	private void BindFunData()
	{
		_dv = _bus.GetFullAuthList(this.TargetType.Value, this.TargetId.Value).DefaultView;
		_dv.RowFilter = "ParentId=0";
		this.authMain.DataSource = _dv;
		this.authMain.DataBind();
	}

	protected void authMain_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		var authSub = e.Item.FindControl("authSub") as DataList;

		_dv.RowFilter = "ParentId=" + ((DataRowView)e.Item.DataItem)["Id"];
		authSub.DataSource = _dv;
		authSub.DataBind();
	}

	protected void authSub_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		var authItems = e.Item.FindControl("authItems") as CheckBoxList;
		_dv.RowFilter = "ParentId=" + ((DataRowView)e.Item.DataItem)["Id"];
		if (authItems != null) {
			foreach (DataRowView dr in _dv) {
				var dataId = Convert.ToString(dr["Id"]);
				var path = Convert.ToString(dr["Path"]);

				var item = new ListItem(Convert.ToString(dr["Name"]), dataId + "," + path);
				if (this.btnAuth.Visible) {
					item.Selected = true;
				} else {
					if (Convert.ToInt32(dr["IsAuth"]) >= 1) {
						item.Selected = true;
					}
				}
				authItems.Items.Add(item);
			}
		}
	}

	private void SetAuthMode(bool visible)
	{
		this.btnSave.Visible = visible;
		this.btnAuth.Visible = !visible;
	}

	private List<SysAuthorization> _currentAuthList = new List<SysAuthorization>();

	private bool AppendAuthItem(int functionId)
	{
		var auth = new SysAuthorization();
		auth.TargetType = this.TargetType.Value;
		auth.TargetId = Convert.ToInt32(this.TargetId.Value);
		auth.FunctionType = "Menu";
		auth.FunctionId = Convert.ToInt32(functionId);
		auth.Creator = this.CurrentUserName;
		auth.CreateDate = DateTime.Now;

		if (!ContainsAuth(auth)) {
			_currentAuthList.Add(auth);
			return true;
		}
		return false;
	}

	private bool ContainsAuth(SysAuthorization auth)
	{
		return (from a in _currentAuthList
				where a.TargetType == auth.TargetType && a.TargetId == auth.TargetId
					&& a.FunctionType == auth.FunctionType && a.FunctionId == auth.FunctionId
				select a).Any();
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		//主功能
		if (this.authMain.Items.Count > 0) {
			foreach (DataListItem mItem in this.authMain.Items) {
				//子功能
				var sub = mItem.FindControl("authSub") as DataList;
				if (sub.Items.Count > 0) {
					foreach (DataListItem sItem in sub.Items) {
						//功能项
						var authItems = sItem.FindControl("authItems") as CheckBoxList;
						foreach (ListItem item in authItems.Items) {
							if (item.Selected) {
								string[] values = item.Value.Split(',');
								string dataId = values[0];
								string path = values[1];

								if (AppendAuthItem(Convert.ToInt32(dataId))) {
									string[] paths = path.Trim('/').Split('/');
									for (int i = 0; i < paths.Length; i++) {
										AppendAuthItem(Convert.ToInt32(paths[i]));
									}
								}
							}
						}
					}
				}
			}
		}
		_bus.UpdateAuthList(_currentAuthList, this.TargetType.Value, this.TargetId.Value);
		SetAuthMode(false);
		BindAuthData();
	}

	protected void btnAuth_Click(object sender, EventArgs e)
	{
		SetAuthMode(true);
		BindFunData();
	}

}