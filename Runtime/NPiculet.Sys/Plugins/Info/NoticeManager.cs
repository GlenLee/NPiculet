using System;
using NPiculet.Base.EF;

namespace NPiculet.Logic.Plugin
{
	public class NoticeManager : INoticeModule
	{
		#region INoticeModule 成员

		/// <summary>
		/// 发送通知
		/// </summary>
		/// <param name="notice">通知内容</param>
		/// <param name="receiver">接收者ID集合</param>
		public void SendNotice(bas_notice_info notice, string[] receivers)
		{
			//notice.Sn = Guid.NewGuid().ToString();
			//_noticeBus.Insert(notice);

			//foreach (var receiver in receivers) {
			//	BasNoticeRecord record = new BasNoticeRecord();
			//	record.NoticeSn = notice.Sn;
			//	record.UserId = int.Parse(receiver);
			//	_recordBus.Insert(record);
			//}
		}

		/// <summary>
		/// 结束通知
		/// </summary>
		/// <param name="noticeId"></param>
		/// <param name="userId"></param>
		public void FinishNotice(string noticeId, string userId)
		{
			//bas_notice_info notice = _noticeBus.QueryModel("\"Id\" ='" + noticeId + "'");
			//bas_notice_record record = _recordBus.QueryModel("\"NoticeSn\"='" + notice.Sn + "' and \"UserId\" ='" + userId + "'");
			//record.IsRead = 1;
			//if (record != null) _recordBus.Update(record);
		}

		/// <summary>
		/// 删除通知
		/// </summary>
		/// <param name="noticeId"></param>
		/// <param name="userId"></param>
		public void DeleteNotice(string noticeId, string userId)
		{
			//bas_notice_info notice = _noticeBus.QueryModel("\"Id\" ='" + noticeId + "'");
			//bas_notice_record record = _recordBus.QueryModel("\"NoticeSn\"='" + notice.Sn + "' and \"UserId\" ='" + userId + "'");
			//if (record != null) _recordBus.Delete("\"Id\" = '" + record.Id + "'");
		}

		#endregion
	}
}
