using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;

namespace modules.info
{
	public partial class LinksList : AdminPage
	{
		readonly NPiculetEntities _db = new NPiculetEntities();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindData();
			}
		}

		private void BindData()
		{
			this.list.DataSource = _db.cms_friendlinks_info.ToList();
			this.list.DataBind();
		}

		protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (e.RowIndex <= -1) 
				return;
			if (this.list.DataKeys.Count > e.RowIndex)
			{
				var dataKey = this.list.DataKeys[e.RowIndex];
				if (dataKey != null)
				{
					string dataId = dataKey["Id"].ToString();

					var province = new cms_friendlinks_info { Id = int.Parse(dataId) };
					_db.Entry(province).State = System.Data.Entity.EntityState.Deleted;
				}
				_db.SaveChanges();
			}
			BindData();
		}
	}
}