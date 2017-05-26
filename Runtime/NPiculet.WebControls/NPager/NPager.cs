using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPiculet.Toolkit;

namespace NPiculet.WebControls
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:NPager runat=server></{0}:NPager>")]
	public class NPager : WebControl
	{
		/// <summary>
		/// 当前页码
		/// </summary>
		[Browsable(true)]
		[Category("Pagination"), DefaultValue(0), Description("模式")]
		public string Mode
		{
			get { return Convert.ToString(ViewState["__NPager__Mode"]); }
			set { ViewState["__NPager__Mode"] = value; }
		}

		/// <summary>
		/// 当前页码
		/// </summary>
		[Browsable(true)]
		[Category("Pagination"), DefaultValue(0), Description("当前页码")]
		public int CurrentPage
		{
			get
			{
				int pageCount = this.GetPageCount();
				int currentPage = Convert.ToInt32(ViewState["__NPager__CurrentPage"]);
				int result = currentPage > pageCount ? pageCount : currentPage;
				return result < 1 ? 1 : result;
			}
			set { ViewState["__NPager__CurrentPage"] = value; }
		}

		/// <summary>
		/// 分页大小
		/// </summary>
		[Browsable(true)]
		[Category("Pagination"), DefaultValue(0), Description("分页大小")]
		public int PageSize
		{
			get { return Convert.ToInt32(ViewState["__NPager__PageSize"]); }
			set { ViewState["__NPager__PageSize"] = value; }
		}

		/// <summary>
		/// 记录数
		/// </summary>
		[Browsable(true)]
		[Category("Pagination"), DefaultValue(0), Description("记录数")]
		public int RecordCount
		{
			get { return Convert.ToInt32(ViewState["__NPager__RecordCount"]); }
			set { ViewState["__NPager__RecordCount"] = value; }
		}

		/// <summary>
		/// 获取页码统计
		/// </summary>
		/// <returns></returns>
		public int GetPageCount()
		{
			if (this.PageSize <= 0) return 0;
			return RecordCount / PageSize + (RecordCount % PageSize == 0 ? 0 : 1);
		}

		/// <summary>
		/// 获取前一页码
		/// </summary>
		/// <returns></returns>
		public int GetPrevPage()
		{
			return this.CurrentPage - 1 < 1 ? 1 : this.CurrentPage - 1;
		}

		/// <summary>
		/// 获取后一页码
		/// </summary>
		/// <returns></returns>
		public int GetNextPage()
		{
			int pageCount = this.GetPageCount();
			return this.CurrentPage + 1 > pageCount ? pageCount : this.CurrentPage + 1;
		}

		/// <summary>
		/// 渲染内容
		/// </summary>
		/// <param name="output"></param>
		protected override void RenderContents(HtmlTextWriter output)
		{
			base.RenderContents(output);

			RenderPagination(output);
		}

		private PaginationManager _manager = null;

		public PaginationManager PaginationManager {
			get {
				if (_manager == null)
					_manager = new PaginationManager(PaginationManager.PaginationMode.Dynamic); 
				return _manager;
			}
			set { _manager = value; }
		}

		/// <summary>
		/// 渲染分页
		/// </summary>
		/// <param name="output"></param>
		private void RenderPagination(HtmlTextWriter output)
		{
			var mode = this.Mode == "Simple" ? PaginationManager.PaginationMode.Simple : PaginationManager.PaginationMode.Dynamic;
			if (_manager == null) _manager = new PaginationManager(mode);
			_manager.PageSize = this.PageSize;
			_manager.CurrentPage = this.CurrentPage;
			_manager.RecordCount = this.RecordCount;
			_manager.FixCss = "sui-pagination pagination-large";
			//manager.FirstString = "<i class=\"step backward icon\"></i>";
			//manager.PrevString = "<i class=\"caret left icon\"></i>";
			//manager.NextString = "<i class=\"caret right icon\"></i>";
			//manager.LastString = "<i class=\"step forward icon\"></i>";
			_manager.PrevStaticString = "";
			_manager.NextStaticString = "";
			//跳转页链接，参数：{0}页面地址、{1}当前页码、{2}链接文字
			//public string PageUrlString = "<a href=\"{0}?Page={1}\">{2}</a>";
			_manager.PageUrlString = "<li class=\"item{3}\"><a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, "{1}") + "\">{2}</a></li>";
			output.Write(_manager.Show());
		}

        public delegate void PageClickEventHandler(object sender, PageEventArgs e);
        public event PageClickEventHandler PageClick;

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			string target = WebParmKit.GetFormValue("__EVENTTARGET", "");
			if (target == this.UniqueID) {
				int argument = WebParmKit.GetFormValue("__EVENTARGUMENT", 1);
				ViewState["__NPager__CurrentPage"] = argument;
				var handler = PageClick;
				if (handler != null) PageClick(this, new PageEventArgs() { PageIndex = argument });
			}
		}
	}

	public class PageEventArgs : EventArgs
	{
		public int PageIndex { get; set; }
	}
}
