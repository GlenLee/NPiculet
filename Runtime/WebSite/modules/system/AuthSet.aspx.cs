using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Business;
using NPiculet.Toolkit;

public partial class modules_system_AuthSet : AdminPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) {
			SetAuthMode(false);

			BindTargetData();
			BindAuthFunData();
		}
	}

	private readonly AuthorizationBus _bus = new AuthorizationBus();

	/// <summary>
	/// 绑定待授权目标数据
	/// </summary>
	private void BindTargetData()
	{
		string moduleName = WebParmKit.GetQuery("m", "");
		int dataId = WebParmKit.GetQuery("key", 0);
		string pageUrl = WebParmKit.GetQuery("p", "");

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
		RoleBus bus = new RoleBus();
		var model = bus.GetRoleInfo(ConvertKit.ConvertValue(this.TargetId.Value, 0));
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
		UserBus bus = new UserBus();
		var model = bus.GetUserInfo(ConvertKit.ConvertValue(this.TargetId.Value, 0));
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
		OrgBus bus = new OrgBus();
		var model = bus.GetOrgInfo(ConvertKit.ConvertValue(this.TargetId.Value, 0));
		if (model != null) {
			this.TargetName.Text = model.OrgName;
			this.TargetMemo.Text = model.Memo;
		}
	}

	private DataView _dv = null;

	/// <summary>
	/// 显示已授权数据
	/// </summary>
	private void BindAuthFunData()
	{
		_dv = _bus.GetAuthList(this.TargetType.Value, this.TargetId.Value).DefaultView;
		_dv.RowFilter = "ParentId=0";
		this.authFunList.DataSource = _dv;
		this.authFunList.DataBind();
	}

	/// <summary>
	/// 显示所有功能
	/// </summary>
	private void BindAllFunData()
	{
		_dv = _bus.GetFullAuthList(this.TargetType.Value, this.TargetId.Value).DefaultView;
		_dv.RowFilter = "ParentId=0";
		this.authAllList.DataSource = _dv;
		this.authAllList.DataBind();
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
		this.authFunList.Visible = !visible;
		this.authAllList.Visible = visible;
	}

	private List<sys_authorization> _currentAuthList = new List<sys_authorization>();

	private bool AppendAuthItem(int functionId)
	{
		var auth = new sys_authorization();
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

	private bool ContainsAuth(sys_authorization auth)
	{
		return (from a in _currentAuthList
			where a.TargetType == auth.TargetType && a.TargetId == auth.TargetId
			      && a.FunctionType == auth.FunctionType && a.FunctionId == auth.FunctionId
			select a).Any();
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		//主功能
		if (this.authAllList.Items.Count > 0) {
			foreach (DataListItem mItem in this.authAllList.Items) {
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
		_bus.UpdateAuthList(_currentAuthList, this.TargetType.Value, ConvertKit.ConvertValue(this.TargetId.Value, 0));
		SetAuthMode(false);
		BindAuthFunData();
	}

	protected void btnAuth_Click(object sender, EventArgs e)
	{
		SetAuthMode(true);
		BindAllFunData();
	}

}