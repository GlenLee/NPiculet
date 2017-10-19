using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPiculet.Authorization;
using NPiculet.Base.EF;
using NPiculet.Logic.Business;

namespace NPiculet.Cms.Business
{
	public class CmsPointBus : IBusiness
	{
		/// <summary>
		/// 保存日志
		/// </summary>
		/// <param name="admin"></param>
		/// <param name="businessCode"></param>
		/// <param name="businessId"></param>
		/// <param name="point"></param>
		/// <param name="tag"></param>
		/// <param name="comment"></param>
		public void SavePointLog(Administrator<int> admin, string businessCode, string businessId, int point, string tag, string comment) {
			using (var db = new NPiculetEntities()) {

				int userId = admin.Id;
				int orgId = admin.Organization != null ? admin.Organization.Id : 0;

				//增加积分
				var org = db.sys_org_info.FirstOrDefault(o => o.Id == orgId);
				if (org != null) {
					org.Point = (org.Point ?? 0) + point;
				}

				//记录日志
				var p = new cms_points_log();
				p.ActionType = "Point";
				p.ActionUserId = userId;
				p.ActionOrgId = orgId;
				p.TargetCode = businessCode;
				p.TargetId = businessId;
				p.Point = point;
				p.Tag = tag;
				p.Comment = comment;
				p.Creator = admin.Name;
				p.CreateDate = DateTime.Now;

				db.cms_points_log.Add(p);

				db.SaveChanges();
			}
		}

		/// <summary>
		/// 保存日志
		/// </summary>
		/// <param name="admin"></param>
		/// <param name="orgId"></param>
		/// <param name="businessCode"></param>
		/// <param name="businessId"></param>
		/// <param name="point"></param>
		/// <param name="tag"></param>
		/// <param name="comment"></param>
		public void SavePointLog(Administrator<int> admin, int orgId, string businessCode, string businessId, decimal point, string tag, string comment)
		{
			if (orgId == 0) return;

			using (var db = new NPiculetEntities()) {

				var p = new cms_points_log();

				//增加积分
				var org = db.sys_org_info.FirstOrDefault(o => o.Id == orgId);
				if (org != null) {
					//p.OldPoint = org.Point;
					//org.NewsCount = (org.NewsCount ?? 0) + 1;
					org.Point = (org.Point ?? 0) + point;
					//p.NewPoint = org.Point;
				}

				//记录日志
				p.ActionType = "Point";
				p.ActionUserId = admin.Id;
				p.ActionOrgId = orgId;
				p.TargetCode = businessCode;
				p.TargetId = businessId;
				p.Point = point;
				p.Tag = tag;
				p.Comment = comment;
				p.Creator = admin.Name;
				p.CreateDate = DateTime.Now;

				db.cms_points_log.Add(p);

				db.SaveChanges();
			}
		}
	}
}