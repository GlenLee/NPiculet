using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NPiculet.Toolkit
{
	/// <summary>
	/// 绑定数据类，动态将数据绑定到各种控件的通用方法。
	/// </summary>
	public static class BindKit
	{
		#region 绑定数据到列表控件

		/// <summary>
		/// 从数据视图绑定数据到数据列表控件。
		/// </summary>
		/// <param name="obj">列表控件</param>
		/// <param name="dv">数据源</param>
		public static void BindToDataControl(object obj, DataView dv)
		{
			if (obj is BaseDataBoundControl) {
				BaseDataBoundControl control = (BaseDataBoundControl)obj;
				control.DataSource = dv;
				control.DataBind();
			} else if (obj is Repeater) {
				Repeater control = (Repeater)obj;
				control.DataSource = dv;
				control.DataBind();
			} else if (obj is BaseDataList) {
				BaseDataList control = (BaseDataList)obj;
				control.DataSource = dv;
				control.DataBind();
			}
		}

		/// <summary>
		/// 从数据表绑定数据到数据列表控件。
		/// </summary>
		/// <param name="obj">列表控件</param>
		/// <param name="dt">数据源</param>
		public static void BindToDataControl(object obj, DataTable dt)
		{
			BindToDataControl(obj, dt.DefaultView);
		}

		/// <summary>
		/// 从 IDataReader 绑定数据到数据列表控件。
		/// </summary>
		/// <param name="obj">列表控件</param>
		/// <param name="dr">数据源</param>
		public static void BindToDataControl(object obj, IDataReader dr)
		{
			if (obj is BaseDataBoundControl) {
				BaseDataBoundControl control = (BaseDataBoundControl)obj;
				control.DataSource = dr;
				control.DataBind();
			} else if (obj is Repeater) {
				Repeater control = (Repeater)obj;
				control.DataSource = dr;
				control.DataBind();
			} else if (obj is BaseDataList) {
				BaseDataList control = (BaseDataList)obj;
				control.DataSource = dr;
				control.DataBind();
			}
		}

		/// <summary>
		/// 从 IDataReader 绑定数据到数据列表控件。
		/// </summary>
		/// <param name="obj">列表控件</param>
		/// <param name="list">数据源</param>
		public static void BindToDataControl(object obj, IList list)
		{
			if (obj is BaseDataBoundControl) {
				BaseDataBoundControl control = (BaseDataBoundControl)obj;
				control.DataSource = list;
				control.DataBind();
			} else if (obj is Repeater) {
				Repeater control = (Repeater)obj;
				control.DataSource = list;
				control.DataBind();
			} else if (obj is BaseDataList) {
				BaseDataList control = (BaseDataList)obj;
				control.DataSource = list;
				control.DataBind();
			}
		}

		#endregion

		#region 绑定数据到清单控件

		/// <summary>
		/// 从数据视图绑定数据到清单控件。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="dv">数据源</param>
		/// <param name="textField">文本字段</param>
		/// <param name="valueField">值字段</param>
		/// <param name="createAllItem">创建一个“全部”选择项</param>
		public static void BindToListControl(ListControl lc, DataView dv, string textField, string valueField, bool createAllItem= false)
		{
			lc.DataSource = dv;
			lc.DataTextField = textField;
			lc.DataValueField = valueField;
			lc.DataBind();
			if (createAllItem)
				lc.Items.Insert(0, new ListItem("全部", ""));
		}

		/// <summary>
		/// 从数据表绑定数据到清单控件。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="dt">数据源</param>
		/// <param name="textField">文本字段</param>
		/// <param name="valueField">值字段</param>
		/// <param name="createAllItem">创建一个“全部”选择项</param>
		public static void BindToListControl(ListControl lc, DataTable dt, string textField, string valueField, bool createAllItem = false)
		{
			BindToListControl(lc, dt.DefaultView, textField, valueField, createAllItem);
		}

		/// <summary>
		/// 从 IDataReader 绑定数据到清单控件。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="dr">数据源</param>
		/// <param name="textField">文本字段</param>
		/// <param name="valueField">值字段</param>
		/// <param name="createAllItem">创建一个“全部”选择项</param>
		public static void BindToListControl(ListControl lc, IDataReader dr, string textField, string valueField, bool createAllItem = false)
		{
			if (createAllItem)
				lc.Items.Add(new ListItem("全部", ""));
			while (dr.Read()) {
				lc.Items.Add(new ListItem(dr[textField].ToString(), dr[valueField].ToString()));
			}
		}

		/// <summary>
		/// 从数据视图绑定数据到清单控件。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="list">数据源</param>
		/// <param name="textField">文本字段</param>
		/// <param name="valueField">值字段</param>
		/// <param name="createAllItem">创建一个“全部”选择项</param>
		public static void BindToListControl(ListControl lc, IList list, string textField, string valueField, bool createAllItem = false)
		{
			lc.DataSource = list;
			lc.DataTextField = textField;
			lc.DataValueField = valueField;
			lc.DataBind();
			if (createAllItem)
				lc.Items.Insert(0, new ListItem("全部", ""));
		}

		/// <summary>
		/// 从数据视图绑定数据到清单控件。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="query">数据源</param>
		/// <param name="textField">文本字段</param>
		/// <param name="valueField">值字段</param>
		/// <param name="createAllItem">创建一个“全部”选择项</param>
		public static void BindToListControl<T>(ListControl lc, IQueryable<T> query, string textField, string valueField, bool createAllItem = false)
		{
			lc.DataSource = query.ToList();
			lc.DataTextField = textField;
			lc.DataValueField = valueField;
			lc.DataBind();
			if (createAllItem)
				lc.Items.Insert(0, new ListItem("全部", ""));
		}

		#endregion

		#region 选中清单列表中的数据

		/// <summary>
		/// 根据值或文字，选中清单控件的单项。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="val">值</param>
		/// <param name="findByValue">是否根据值来搜索，true搜索值，false搜索文字</param>
		public static void SelectItemInSingleListControl(ListControl lc, string val, bool findByValue)
		{
			if (findByValue) {
				lc.SelectedIndex = lc.Items.IndexOf(lc.Items.FindByValue(val));
			} else {
				lc.SelectedIndex = lc.Items.IndexOf(lc.Items.FindByText(val));
			}
		}

		/// <summary>
		/// 根据值或文字，选中清单控件的多项。
		/// </summary>
		/// <param name="lc">清单控件</param>
		/// <param name="vals">值</param>
		/// <param name="findByValue">是否根据值来搜索，true搜索值，false搜索文字</param>
		public static void SelectItemInMultipleListControl(ListControl lc, string[] vals, bool findByValue)
		{
			foreach (ListItem item in lc.Items) {
				if (findByValue) {
					foreach (string val in vals) {
						if (item.Value == val)
							item.Selected = true;
					}
				} else {
					foreach (string val in vals) {
						if (item.Text == val)
							item.Selected = true;
					}
				}
			}
		}

		#endregion

		#region 控件通用操作类

		/// <summary>
		/// 绑定客户端单击事件到按钮或控件中包含的按钮。
		/// </summary>
		/// <param name="control">对象</param>
		/// <param name="commandName">按钮指令名称</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClick(Control control, string commandName, string javascript)
		{
			switch (control.GetType().ToString()) {
				// Table 处理
				case "System.Web.UI.WebControls.Table":
					foreach (TableRow row in ((Table)control).Rows) {
						BindOnClientClick(row, commandName, javascript);
					}
					break;
				case "System.Web.UI.WebControls.TableRow":
					foreach (TableCell cell in ((TableRow)control).Cells) {
						BindOnClientClick(cell, commandName, javascript);
					}
					break;
				case "System.Web.UI.WebControls.TableCell":
					foreach (Control con in control.Controls) {
						BindOnClientClick(con, commandName, javascript);
					}
					break;
				// GridView 处理
				case "System.Web.UI.WebControls.GridView":
					foreach (GridViewRow row in ((GridView)control).Rows) {
						BindOnClientClick(row, commandName, javascript);
					}
					break;
				case "System.Web.UI.WebControls.GridViewRow":
					foreach (TableCell cell in ((GridViewRow)control).Cells) {
						BindOnClientClick(cell, commandName, javascript);
					}
					break;
				case "System.Web.UI.WebControls.DataControlFieldCell":
					foreach (Control cell in control.Controls) {
						BindOnClientClick(cell, commandName, javascript);
					}
					break;
				// HyperLink 处理
				case "System.Web.UI.WebControls.HyperLink":
					BindOnClientClickToWebControl(control as WebControl, commandName, javascript);
					break;
				// HtmlForm 处理
				case "System.Web.UI.HtmlControls.HtmlForm":
					foreach (Control con in control.Controls) {
						BindOnClientClick(con, commandName, javascript);
					}
					break;
				// HtmlTable 处理
				case "System.Web.UI.HtmlControls.HtmlTable":
					foreach (HtmlTableRow row in ((HtmlTable)control).Rows) {
						BindOnClientClick(row, commandName, javascript);
					}
					break;
				case "System.Web.UI.HtmlControls.HtmlTableRow":
					foreach (TableCell cell in ((HtmlTableRow)control).Cells) {
						BindOnClientClick(cell, commandName, javascript);
					}
					break;
				case "System.Web.UI.HtmlControls.HtmlTableCell":
					foreach (Control con in ((TableCell)control).Controls) {
						BindOnClientClick(con, commandName, javascript);
					}
					break;
				// HtmlButton 处理
				case "System.Web.UI.HtmlControls.HtmlButton":
					BindOnClientClickToHtmlControl(control as HtmlControl, commandName, javascript);
					break;
				case "System.Web.UI.HtmlControls.HtmlInputButton":
					BindOnClientClickToHtmlControl(control as HtmlControl, commandName, javascript);
					break;
				case "System.Web.UI.HtmlControls.HtmlLink":
					BindOnClientClickToHtmlControl(control as HtmlControl, commandName, javascript);
					break;
				case "System.Web.UI.HtmlControls.HtmlInputSubmit":
					BindOnClientClickToHtmlControl(control as HtmlControl, commandName, javascript);
					break;
				case "System.Web.UI.HtmlControls.HtmlInputReset":
					BindOnClientClickToHtmlControl(control as HtmlControl, commandName, javascript);
					break;
				// IButtonControl 处理
				default:
					BindOnClientClickToButton(control as IButtonControl, commandName, javascript);
					break;
			}
		}

		/// <summary>
		/// 绑定客户端单击事件到按钮或控件中包含的按钮。
		/// </summary>
		/// <param name="control">对象</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClick(Control control, string javascript)
		{
			BindOnClientClick(control, null, javascript);
		}

		/// <summary>
		/// 绑定客户端单击事件到控件。
		/// </summary>
		/// <param name="btn">按钮控件</param>
		/// <param name="commandName">指令名称</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClickToButton(IButtonControl btn, string commandName, string javascript)
		{
			if (btn != null) {
				if (String.IsNullOrEmpty(commandName)) {
					BindOnClientClickToButton(btn, javascript);
				} else {
					if (btn.CommandName == commandName) {
						BindOnClientClickToButton(btn, javascript);
					}
				}
			}
		}

		/// <summary>
		/// 绑定客户端单击事件到控件。
		/// </summary>
		/// <param name="btn">按钮控件</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClickToButton(IButtonControl btn, string javascript)
		{
			switch (btn.GetType().ToString()) {
				case "System.Web.UI.WebControls.Button":
					((Button)btn).OnClientClick = javascript;
					break;
				case "System.Web.UI.WebControls.DataControlButton":
					((Button)btn).OnClientClick = javascript;
					break;
				case "System.Web.UI.WebControls.LinkButton":
					((LinkButton)btn).OnClientClick = javascript;
					break;
				case "System.Web.UI.WebControls.DataControlLinkButton":
					((LinkButton)btn).OnClientClick = javascript;
					break;
				case "System.Web.UI.WebControls.ImageButton":
					((ImageButton)btn).OnClientClick = javascript;
					break;
				case "System.Web.UI.WebControls.DataControlImageButton":
					((ImageButton)btn).OnClientClick = javascript;
					break;
			}
		}

		/// <summary>
		/// 绑定客户端单击事件到 Html 控件。
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="controlId">控件 ID</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClickToHtmlControl(HtmlControl control, string controlId, string javascript)
		{
			if (control != null) {
				if (String.IsNullOrEmpty(controlId)) {
					control.Attributes.Add("onclick", javascript);
				} else {
					if (control.ID == controlId) {
						control.Attributes.Add("onclick", javascript);
					}
				}
			}
		}

		/// <summary>
		/// 绑定客户端单击事件到 Web 控件。
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="controlId">控件 ID</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClickToWebControl(WebControl control, string controlId, string javascript)
		{
			if (control != null) {
				if (String.IsNullOrEmpty(controlId)) {
					control.Attributes.Add("onclick", javascript);
				} else {
					if (control.ID == controlId) {
						control.Attributes.Add("onclick", javascript);
					}
				}
			}
		}

		/// <summary>
		/// 绑定客户端单击事件到 Html 控件。
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="javascript">JavaScript 脚本</param>
		public static void BindOnClientClickToHtmlControl(HtmlControl control, string javascript)
		{
			BindOnClientClickToHtmlControl(control, null, javascript);
		}

		#endregion

		#region 页面绑定数据模型处理类

		/// <summary>
		/// 将数据模型绑定到容器中的控件。
		/// </summary>
		/// <param name="container">容器</param>
		/// <param name="model">数据模型</param>
		public static void BindModelToContainer(Control container, object model)
		{
			if (model != null) {
				Type type = model.GetType();
				PropertyInfo[] infos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
				PropertyInfo currentInfo = null;
				try {
					foreach (PropertyInfo info in infos) {
						currentInfo = info;
						BindPropertyToControl(container, model, info);
					}
				} catch (Exception ex) {
					if (currentInfo != null) {
						throw new Exception(string.Format("PropertyInfo: {0}\r\nValue: {1}\r\n", currentInfo.Name, currentInfo.GetValue(model, null)) + ex.Message, ex);
					} else {
						throw(ex);
					}
				}
			}
		}

		/// <summary>
		/// 将数据模型的指定属性中的值绑定到控件。
		/// </summary>
		/// <param name="container">容器</param>
		/// <param name="model">数据模型</param>
		/// <param name="info">属性</param>
		public static void BindPropertyToControl(Control container, object model, PropertyInfo info)
		{
			//属性可读
			if (info.CanRead) {
				Control control = container.FindControl(info.Name);
				object val = info.GetValue(model, null);
				if (control != null && val != null) {
					switch (control.GetType().ToString()) {
						case "System.Web.UI.WebControls.Label":
							((Label)control).Text = val.ToString();
							break;
						case "System.Web.UI.WebControls.Literal":
							((Literal)control).Text = val.ToString();
							break;
						case "System.Web.UI.WebControls.TextBox":
							((TextBox)control).Text = val.ToString();
							break;
						case "System.Web.UI.WebControls.HiddenField":
							((HiddenField)control).Value = val.ToString();
							break;
						case "System.Web.UI.WebControls.DropDownList":
							((DropDownList)control).SelectedIndex = ((DropDownList)control).Items.IndexOf(((DropDownList)control).Items.FindByValue(val.ToString()));
							break;
						case "System.Web.UI.WebControls.ListBox":
							((ListBox)control).SelectedIndex = ((ListBox)control).Items.IndexOf(((ListBox)control).Items.FindByValue(val.ToString()));
							break;
						case "System.Web.UI.WebControls.RadioButton":
							((RadioButton)control).Checked = Convert.ToBoolean(val);
							break;
						case "System.Web.UI.WebControls.RadioButtonList":
							((RadioButtonList)control).SelectedIndex = ((RadioButtonList)control).Items.IndexOf(((RadioButtonList)control).Items.FindByValue(val.ToString()));
							break;
						case "System.Web.UI.WebControls.CheckBox":
							((CheckBox)control).Checked = Convert.ToBoolean(val);
							break;
						case "System.Web.UI.WebControls.CheckBoxList":
							((CheckBoxList)control).SelectedIndex = ((CheckBoxList)control).Items.IndexOf(((CheckBoxList)control).Items.FindByValue(val.ToString()));
							break;
						case "System.Web.UI.WebControls.HyperLink":
							((HyperLink)control).NavigateUrl = val.ToString();
							break;
						case "System.Web.UI.WebControls.Image":
							((Image)control).ImageUrl = val.ToString();
							break;
						case "System.Web.UI.WebControls.Button":
							((Button)control).Text = val.ToString();
							break;
						case "System.Web.UI.WebControls.ImageButton":
							((ImageButton)control).ImageUrl = val.ToString();
							break;
						case "System.Web.UI.WebControls.LinkButton":
							((LinkButton)control).Text = val.ToString();
							break;
						case "System.Web.UI.WebControls.Calendar":
							((Calendar)control).SelectedDate = (DateTime)val;
							break;
						default:
							ListControl listControl = control as ListControl;
							if (listControl != null) {
								listControl.SelectedIndex = listControl.Items.IndexOf(listControl.Items.FindByValue(val.ToString()));
							} else {
								PropertyInfo p = control.GetType().GetProperty("Value", typeof(String));
								if (p != null) {
									p.SetValue(control, Convert.ToString(val), null);
								} else if ((p = control.GetType().GetProperty("Checked", typeof(Boolean))) != null) {
									p.SetValue(control, val, null);
								} else if ((p = control.GetType().GetProperty("Text", typeof(String))) != null) {
									p.SetValue(control, val, null);
								} else if ((p = control.GetType().GetProperty("SelectedDate", typeof(DateTime))) != null) {
									p.SetValue(control, val, null);
								} else if ((p = control.GetType().GetProperty("DataSource", typeof(Object))) != null) {
									p.SetValue(control, val, null);
								}
							}
							break;
					}
				}
			}
		}

		/// <summary>
		/// 将容器中的控件数据填充到数据模型。
		/// </summary>
		/// <param name="container">容器</param>
		/// <param name="model">数据模型</param>
		public static void FillModelFromContainer(Control container, object model)
		{
			if (model != null) {
				Type type = model.GetType();
				PropertyInfo[] infos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
				foreach (PropertyInfo info in infos) {
					//属性可写
					if (info.CanWrite) {
						Control control = container.FindControl(info.Name);
						object val = GetControlValue(control, info.PropertyType);
						if (val != null)
							info.SetValue(model, val, null);
					}
				}
			}
		}

		/// <summary>
		/// 转换当前模型中子项的值。
		/// </summary>
		/// <param name="val">需要转换类型的值</param>
		/// <param name="type">数据类型</param>
		public static object ConvertValue(object val, Type type)
		{
			if (val is bool && (type == typeof(int) || type == typeof(int?))) {
				return (bool)val ? 1 : 0;
			}
			return ConvertKit.ConvertValue(val, type);
		}

		/// <summary>
		/// 获取空间的值。
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="type">值类型</param>
		/// <returns></returns>
		public static object GetControlValue(Control control, Type type)
		{
			if (control != null) {
				switch (control.GetType().ToString()) {
					case "System.Web.UI.WebControls.Label":
						return ConvertValue(((Label)control).Text, type);
					case "System.Web.UI.WebControls.Literal":
						return ConvertValue(((Literal)control).Text, type);
					case "System.Web.UI.WebControls.TextBox":
						return ConvertValue(((TextBox)control).Text, type);
					case "System.Web.UI.WebControls.HiddenField":
						return ConvertValue(((HiddenField)control).Value, type);
					case "System.Web.UI.WebControls.DropDownList":
						return ConvertValue(((DropDownList)control).SelectedValue, type);
					case "System.Web.UI.WebControls.ListBox":
						return ConvertValue(((ListBox)control).SelectedValue, type);
					case "System.Web.UI.WebControls.RadioButton":
						return ConvertValue(((RadioButton)control).Checked, type);
					case "System.Web.UI.WebControls.RadioButtonList":
						return ConvertValue(((RadioButtonList)control).SelectedValue, type);
					case "System.Web.UI.WebControls.CheckBox":
						return ConvertValue(((CheckBox)control).Checked, type);
					case "System.Web.UI.WebControls.CheckBoxList":
						return ConvertValue(((CheckBoxList)control).SelectedValue, type);
					case "System.Web.UI.WebControls.HyperLink":
						return ConvertValue(((HyperLink)control).NavigateUrl, type);
					case "System.Web.UI.WebControls.Image":
						return ConvertValue(((Image)control).ImageUrl, type);
					case "System.Web.UI.WebControls.Button":
						return ConvertValue(((Button)control).Text, type);
					case "System.Web.UI.WebControls.ImageButton":
						return ConvertValue(((ImageButton)control).ImageUrl, type);
					case "System.Web.UI.WebControls.LinkButton":
						return ConvertValue(((LinkButton)control).Text, type);
					case "System.Web.UI.WebControls.Calendar":
						return ConvertValue(((Calendar)control).SelectedDate, type);
					default:
						PropertyInfo p = control.GetType().GetProperty("Value", typeof(String));
						if (p != null) {
							return ConvertValue(p.GetValue(control, null), type);
						} else if ((p = control.GetType().GetProperty("Checked", typeof(Boolean))) != null) {
							return ConvertValue(p.GetValue(control, null), type);
						} else if ((p = control.GetType().GetProperty("Text", typeof(String))) != null) {
							return ConvertValue(p.GetValue(control, null), type);
						} else if ((p = control.GetType().GetProperty("SelectedDate", typeof(DateTime))) != null) {
							return ConvertValue(p.GetValue(control, null), type);
						} else if ((p = control.GetType().GetProperty("DataSource", typeof(Object))) != null) {
							return ConvertValue(p.GetValue(control, null), type);
						}
						break;
				}
			}
			return null;
		}

		/// <summary>
		/// 将容器中的控件数据填充到数据模型。
		/// </summary>
		/// <param name="namingContainer">容器</param>
		public static TModel FillModelFromContainer<TModel>(Control namingContainer)
		{
			Type t = typeof(TModel);
			object m = Activator.CreateInstance(t);
			FillModelFromContainer(namingContainer, m);
			return (TModel)m;
		}

		/// <summary>
		/// 为对象指定的属性填充值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="name"></param>
		/// <param name="val"></param>
		public static void FillProperty<T>(T obj, string name, object val) {
			if (obj != null) {
				Type type = obj.GetType();
				PropertyInfo info = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
				//属性可写
				if (info != null && info.CanWrite) {
					info.SetValue(obj, val, null);
				}
			}
		}

		/// <summary>
		/// 将容器中的控件数据填充到数据模型。
		/// </summary>
		/// <param name="namingContainer">容器</param>
		public static object FillModelFromContainer(Control namingContainer, Type t)
		{
			object m = Activator.CreateInstance(t);
			FillModelFromContainer(namingContainer, m);
			return m;
		}

		/// <summary>
		/// 将数据模型绑定到容器中的控件。
		/// </summary>
		/// <param name="container">容器</param>
		/// <param name="dt">数据表</param>
		public static void BindDataToContainer(Control container, DataTable dt)
		{
			if (dt != null) {
				foreach (DataRow dr in dt.Rows) {
					foreach (DataColumn col in dt.Columns) {
						Control control = container.FindControl(col.ColumnName);
						object val = dr[col.ColumnName];
						if (control != null && val != null && val != DBNull.Value) {
							switch (control.GetType().ToString()) {
								case "System.Web.UI.WebControls.Label":
									((Label)control).Text = val.ToString();
									break;
								case "System.Web.UI.WebControls.Literal":
									((Literal)control).Text = val.ToString();
									break;
								case "System.Web.UI.WebControls.TextBox":
									((TextBox)control).Text = val.ToString();
									break;
								case "System.Web.UI.WebControls.HiddenField":
									((HiddenField)control).Value = val.ToString();
									break;
								case "System.Web.UI.WebControls.DropDownList":
									((DropDownList)control).SelectedIndex = ((DropDownList)control).Items.IndexOf(((DropDownList)control).Items.FindByValue(val.ToString()));
									break;
								case "System.Web.UI.WebControls.ListBox":
									((ListBox)control).SelectedIndex = ((ListBox)control).Items.IndexOf(((ListBox)control).Items.FindByValue(val.ToString()));
									break;
								case "System.Web.UI.WebControls.RadioButton":
									((RadioButton)control).Checked = Convert.ToBoolean(val);
									break;
								case "System.Web.UI.WebControls.RadioButtonList":
									((RadioButtonList)control).SelectedIndex = ((RadioButtonList)control).Items.IndexOf(((RadioButtonList)control).Items.FindByValue(val.ToString()));
									break;
								case "System.Web.UI.WebControls.CheckBox":
									((CheckBox)control).Checked = Convert.ToBoolean(val);
									break;
								case "System.Web.UI.WebControls.CheckBoxList":
									((CheckBoxList)control).SelectedIndex = ((CheckBoxList)control).Items.IndexOf(((CheckBoxList)control).Items.FindByValue(val.ToString()));
									break;
								case "System.Web.UI.WebControls.HyperLink":
									((HyperLink)control).NavigateUrl = val.ToString();
									break;
								case "System.Web.UI.WebControls.Image":
									((Image)control).ImageUrl = val.ToString();
									break;
								case "System.Web.UI.WebControls.Button":
									((Button)control).Text = val.ToString();
									break;
								case "System.Web.UI.WebControls.ImageButton":
									((ImageButton)control).ImageUrl = val.ToString();
									break;
								case "System.Web.UI.WebControls.LinkButton":
									((LinkButton)control).Text = val.ToString();
									break;
								case "System.Web.UI.WebControls.Calendar":
									((Calendar)control).SelectedDate = (DateTime)val;
									break;
								default:
									ListControl listControl = control as ListControl;
									if (listControl != null) {
										listControl.SelectedIndex = listControl.Items.IndexOf(listControl.Items.FindByValue(val.ToString()));
									} else {
										PropertyInfo conInfo = control.GetType().GetProperty("Value", typeof(String));
										if (conInfo != null) {
											conInfo.SetValue(control, val, null);
										} else if ((conInfo = control.GetType().GetProperty("Checked", typeof(Boolean))) != null) {
											conInfo.SetValue(control, val, null);
										} else if ((conInfo = control.GetType().GetProperty("Text", typeof(String))) != null) {
											conInfo.SetValue(control, val, null);
										} else if ((conInfo = control.GetType().GetProperty("SelectedDate", typeof(DateTime))) != null) {
											conInfo.SetValue(control, val, null);
										} else if ((conInfo = control.GetType().GetProperty("DataSource", typeof(Object))) != null) {
											conInfo.SetValue(control, val, null);
										}
									}
									break;
							}
						}
					}
				}
			}
		}

		#endregion

	}
}
