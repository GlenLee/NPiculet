﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;

namespace NPiculet.Logic.Info
{
    public class NoticeManager : INoticeModule
    {
        #region INoticeModule 成员

        BasNoticeInfoBus _noticeBus = new BasNoticeInfoBus();
        BasNoticeRecordBus _recordBus = new BasNoticeRecordBus();

        /// <summary>
        /// 发送通知
        /// </summary>
        /// <param name="notice">通知内容</param>
        /// <param name="receiver">接收者ID集合</param>
        public void SendNotice(BasNoticeInfo notice, string[] receivers)
        {
            notice.Sn = Guid.NewGuid().ToString();
            _noticeBus.Insert(notice);

            foreach (var receiver in receivers) {
				BasNoticeRecord record = new BasNoticeRecord();
                record.NoticeSn = notice.Sn;
                record.UserId = int.Parse(receiver);
                _recordBus.Insert(record);
            }

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 结束通知
        /// </summary>
        /// <param name="noticeId"></param>
        /// <param name="userId"></param>
        public void FinishNotice(string noticeId, string userId)
        {
			//NoticePushRecord record = new NoticePushRecord();
			BasNoticeInfo notice = _noticeBus.QueryModel("\"Id\" ='" + noticeId + "'");
			BasNoticeRecord record = _recordBus.QueryModel("\"NoticeSn\"='" + notice.Sn + "' and \"UserId\" ='" + userId + "'");
            record.IsRead = 1;
            if (record != null) _recordBus.Update(record);
                //where record.NoticeSn == sn and record.UserId == userId; //接收通知的用户
                //uodate NoticePushRecord.IsRead = 1 中的数据
        }

        /// <summary>
        /// 删除通知
        /// </summary>
        /// <param name="noticeId"></param>
        /// <param name="userId"></param>
        public void DeleteNotice(string noticeId, string userId)
        {
            BasNoticeInfo notice= _noticeBus.QueryModel("\"Id\" ='"+noticeId+"'");
			BasNoticeRecord record = _recordBus.QueryModel("\"NoticeSn\"='" + notice.Sn + "' and \"UserId\" ='" + userId + "'");
            if (record!=null) _recordBus.Delete("\"Id\" = '" + record.Id + "'");
                //delete NoticePushRecord 中的数据
        }

        #endregion
    }
}