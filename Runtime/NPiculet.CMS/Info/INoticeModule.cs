using NPiculet.Logic.Data;

namespace NPiculet.Logic.Info
{
	/// <summary>
	/// 通知处理模式
	/// </summary>
	public enum NoticeType
	{
		/// <summary>
		/// 查看后删除通知
		/// </summary>
		View,
		/// <summary>
		/// 处理后删除通知
		/// </summary>
		Process
	}

	/// <summary>
	/// 通知来源模块
	/// </summary>
	public enum NoticeSource
	{
		None //未指定来源
	}

	public interface INoticeModule
	{
		/// <summary>
		/// 发送通知
		/// </summary>
		/// <param name="notice">通知内容</param>
		/// <param name="receiver">接收者ID集合</param>
		void SendNotice(CmsNoticeInfo notice, string[] receiver);

		/// <summary>
		/// 结束通知
		/// </summary>
		/// <param name="noticeId"></param>
		/// <param name="userId"></param>
		void FinishNotice(string noticeId, string userId);

		/// <summary>
		/// 删除通知
		/// </summary>
		/// <param name="noticeId"></param>
		/// <param name="userId"></param>
		void DeleteNotice(string noticeId, string userId);
	}
}