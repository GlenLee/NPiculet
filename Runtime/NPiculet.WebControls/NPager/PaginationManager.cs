/*
Name: PaginationFactory Class
Date: 2009-8-17
Author: iSLeeCN
Description: PaginationFactory Class.
*/
using System;

namespace NPiculet.WebControls
{
	/// <summary>
	/// 分页文字及分页链接管理器，用于组合页码链接 Html 字符串，这里可以组合复杂的链接，如果只需要简单的方法请使用 PageManager 类。
	/// </summary>
	public class PaginationManager
	{
		/// <summary>
		/// 统计字符串定位。
		/// </summary>
		public enum TotalStringPosition
		{
			/// <summary>
			/// 定位在页码前。
			/// </summary>
			Front,
			/// <summary>
			/// 定位在页码后。
			/// </summary>
			Back,
			/// <summary>
			/// 不产生统计字符串。
			/// </summary>
			None
		}

		/// <summary>
		/// 分页模式。
		/// </summary>
		public enum PaginationMode
		{
			/// <summary>
			/// 全部页码展示。
			/// </summary>
			All,
			/// <summary>
			/// 动态页码展示，当前页码是显示在中间，例如：当前是第5页，分隔为3页，那么就会显示2 3 4 5 6 7 8页。
			/// </summary>
			Dynamic,
			/// <summary>
			/// 静态页码展示，页码会固定显示一个区间，比如：1-10页，直到跳转到11页才会显示11-20页。
			/// </summary>
			Static,
			/// <summary>
			/// 简单页码展示，仅展示上一页和下一页。
			/// </summary>
			Simple,
		}

		/// <summary>
		/// 分页组合管理器。
		/// </summary>
		/// <param name="paginationMode"></param>
		public PaginationManager(PaginationMode paginationMode)
		{
			Mode = paginationMode;
		}

		/// <summary>
		/// 分页组合管理器。
		/// </summary>
		/// <param name="recordCount">总记录统计</param>
		public PaginationManager(int recordCount)
		{
			this.RecordCount = recordCount;
		}

		#region 主要参数

		/// <summary> 当前页码，必填 </summary>
		public int CurrentPage = 1;
		/// <summary> 统计记录数，必填 </summary>
		public int RecordCount = 0;
		/// <summary> 分页大小 </summary>
		public int PageSize = 10;
		/// <summary> 统计描述，文字中参数：{0}当前页、{1}总页数、{2}总记录数 </summary>
		public string TotalString = "<li><a>第{0}/{1}页 共{2}条记录</a><li>";
		/// <summary> 传值，格式：&valuename1=value1&valuename2=value2 </summary>
		public string RefererString = String.Empty;
		/// <summary> 统计描述的显示位置 </summary>
		public TotalStringPosition ShowTotalStringPosition = TotalStringPosition.Front;
		/// <summary> 页面地址 </summary>
		public string PageUrl = String.Empty;
		/// <summary> 跳转页链接，参数：{0}页面地址、{1}当前页码、{2}链接文字 </summary>
		public string PageUrlString = "<li{3}><a href=\"{0}?Page={1}\">{2}</a></li>";

		#endregion

		#region 可选参数

		/// <summary> 固定分隔页数 </summary>
		public int StaticNumber = 10;
		/// <summary> 动态分隔前页数 </summary>
		public int AutoPrevNumber = 4;
		/// <summary> 动态分隔后页数 </summary>
		public int AutoNextNumber = 4;
		/// <summary> 补充样式 </summary>
		public string FixCss = "";
		/// <summary> 当前页码颜色 </summary>
		public string CurrentPageCss = "active";
		/// <summary> 前一页描述 </summary>
		public string PrevString = "前一页";
		/// <summary> 后一页描述 </summary>
		public string NextString = "下一页";
		/// <summary> 第一页描述 </summary>
		public string FirstString = "第一页";
		/// <summary> 最后页描述 </summary>
		public string LastString = "最后页";
		/// <summary> 前一固定分隔描述 </summary>
		public string PrevStaticString = "前{0}页";
		/// <summary> 后一固定分隔描述 </summary>
		public string NextStaticString = "后{0}页";
		/// <summary> 超出分隔范围的页码用省略号 </summary>
		public bool ShowEllipsis = true;
		/// <summary> 动态分页时，显示页码数为 AutoPrevNumber + AutoNextNumber + 1 假设为 4 + 4 + 1，此项为 true 将增补显示页码到总和数 9，此项为 false 只会显示 AutoPrevNumber 或 AutoNextNumber 数 + 1 = 5 页 </summary>
		public bool FixedPages = true;
		/// <summary> 没有链接时是否显示跳转文字 </summary>
		public bool ShowNoLinkText = true;

		#endregion

		#region 初始化私有属性

		private string str = String.Empty;
		private string strfront = String.Empty;
		private string strback = String.Empty;

		private int _PageCount;
		private int _StartPage;//开始页
		private int _EndPage;//结束页

		/// <summary>
		/// 分页模式。
		/// </summary>
		public PaginationMode Mode = PaginationMode.Dynamic;

		#endregion

		/// <summary>
		/// 创建项
		/// </summary>
		/// <param name="text"></param>
		/// <param name="actived"></param>
		/// <returns></returns>
		private string CreatePageItem(string text, bool actived = false)
		{
			return "<li class=\"item" + (actived ? " " + CurrentPageCss : "") + "\"><a>" + text + "</a></li>";
		}

		/// <summary>
		/// 生成页码
		/// </summary>
		/// <returns></returns>
		private void CreatePages()
		{
			str = String.Empty;
			for (int i = _StartPage; i <= _EndPage; i++) {
				str += GetPageUrl(i, i.ToString(), (i == CurrentPage));
			}
		}

		/// <summary>
		/// 创建通用信息
		/// </summary>
		private void CreateCommonInfo()
		{
			switch (ShowTotalStringPosition) {
				case TotalStringPosition.Front:
					str = string.Format(TotalString, CurrentPage, _PageCount, RecordCount) + str;
					break;
				case TotalStringPosition.Back:
					str = str + string.Format(TotalString, CurrentPage, _PageCount, RecordCount);
					break;
				case TotalStringPosition.None:
					break;
			}
		}

		/// <summary>
		/// 生成全部页码
		/// </summary>
		private void CreateAllPages()
		{
			//生成页码
			_StartPage = 1;
			_EndPage = _PageCount;
		}

		/// <summary>
		/// 创建自动扩展的页码
		/// </summary>
		private void CreateAutoPages()
		{
			//计算开始页
			if (FixedPages && _PageCount < (CurrentPage + AutoNextNumber)) {
				_StartPage = _PageCount - AutoPrevNumber - AutoNextNumber;
			} else {
				_StartPage = CurrentPage - AutoPrevNumber;
			}
			if (_StartPage < 1) { _StartPage = 1; }
			//计算结束页
			if (FixedPages && CurrentPage <= AutoPrevNumber) {
				_EndPage = AutoNextNumber + AutoPrevNumber + 1;
			} else {
				_EndPage = CurrentPage + AutoNextNumber;
			}
			if (_EndPage > _PageCount) { _EndPage = _PageCount; }

			this.CreateInfos();
		}

		/// <summary>
		/// 创建自动扩展的页码信息。
		/// </summary>
		/// <returns></returns>
		public void CreateInfos()
		{
			//初始化
			strfront = String.Empty;
			strback = String.Empty;
			//向前跳转
			if (FirstString.Length > 0) { strfront += GetPageUrl(1, FirstString); }
			if (NextStaticString.Length > 0) { strfront += GetStaticPageUrl(PrevStaticString, true); }
			if (PrevString.Length > 0) { strfront += GetPageUrl(CurrentPage - 1, PrevString); }

			if (ShowEllipsis && CurrentPage > (AutoPrevNumber + 1)) { strfront += CreatePageItem("..."); }
			//向后跳转
			if (ShowEllipsis && CurrentPage < (_PageCount - AutoNextNumber)) { strback += CreatePageItem("..."); }

			if (NextString.Length > 0) { strback += GetPageUrl(CurrentPage + 1, NextString); }
			if (NextStaticString.Length > 0) { strback += GetStaticPageUrl(NextStaticString, false); }
			if (LastString.Length > 0) { strback += GetPageUrl(_PageCount, LastString); }
		}

		/// <summary>
		/// 创建分段显示的页码。
		/// </summary>
		/// <returns></returns>
		public void CreateStaticPages()
		{
			//计算开始页
			_StartPage = ((CurrentPage % StaticNumber) > 0) ? (int)(CurrentPage / StaticNumber) * StaticNumber + 1 : _StartPage = CurrentPage - StaticNumber + 1;
			if (_StartPage < 1) { _StartPage = 1; }
			//计算结束页
			_EndPage = _StartPage + StaticNumber - 1;
			if (_EndPage > _PageCount) { _EndPage = _PageCount; }

			this.CreateInfos();
		}

		/// <summary>
		/// 创建分段显示的页码。
		/// </summary>
		/// <returns></returns>
		public void CreateSimplePages()
		{
			this.CreateInfos();
		}

		/// <summary>
		/// 输出生成的页码。
		/// </summary>
		/// <returns></returns>
		public string Show()
		{
			//拦截非法页码
			if (CurrentPage < 1) { CurrentPage = 1; }
			int num = 0;
			if (PageSize > 0)
				num = ((RecordCount % PageSize) > 0) ? ((RecordCount / PageSize) + 1) : (RecordCount / PageSize);
			_PageCount = ((num < 1) ? 1 : num);
			//页码创建模式
			switch (Mode) {
				case PaginationMode.All:
					this.CreateAllPages();
					break;
				case PaginationMode.Dynamic:
					this.CreateAutoPages();
					break;
				case PaginationMode.Static:
					this.CreateStaticPages();
					break;
				case PaginationMode.Simple:
					this.CreateSimplePages();
					break;
			}
			//生成页码
			if (this.Mode != PaginationMode.Simple) {
				this.CreatePages();
			}
			//组合字符串
			str = strfront + str + strback;
			//显示通用信息
			this.CreateCommonInfo();
			//返回结果
			string html = "<nav class=\"npager\"><ul";
			if (!string.IsNullOrWhiteSpace(FixCss)) html += " class=\"" + FixCss + "\"";
			html += ">" + str + "</ul></nav>";
			return html;
		}

		#region 生成页码链接

		/// <summary>
		/// 获取首页链接字符串。
		/// </summary>
		/// <returns></returns>
		private string GetPageUrl(int page, string text, bool actived = false)
		{
			if (page >= 1 && page <= _PageCount) {
				return string.Format(PageUrlString
					, PageUrl
					, page.ToString() + RefererString
					, text
					, actived ? " class=\"active\"" : ""
				);
			} else {
				if (ShowNoLinkText) {
					if (text.Length > 0) {
						return "<li class=\"disabled\"><a>" + text + "</a></li>";
					}
				}
				return String.Empty;
			}
		}

		private string GetStaticPageUrl(string text, bool prev)
		{
			switch (Mode) {
				case PaginationMode.Dynamic:
					int staticNumeric = (AutoPrevNumber + AutoNextNumber + 1);
					if (prev) {
						return GetPageUrl(_StartPage - 1, string.Format(text, staticNumeric));
					} else {
						return GetPageUrl(_EndPage + 1, string.Format(text, staticNumeric));
					}

				case PaginationMode.Static:
					if (prev) {
						return GetPageUrl(_StartPage - 1, string.Format(text, StaticNumber));
					} else {
						return GetPageUrl(_EndPage + 1, string.Format(text, StaticNumber));
					}

				case PaginationMode.All:
					return String.Empty;

				default:
					return String.Empty;
			}
		}

		#endregion

	}

}
