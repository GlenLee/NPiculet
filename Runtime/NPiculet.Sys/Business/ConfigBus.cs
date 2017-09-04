using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using NPiculet.Base.EF;

namespace NPiculet.Logic.Business
{
	/// <summary>
	/// 自定义逻辑
	/// </summary>
	public partial class ConfigBus : IBusiness
	{
		/// <summary>
		/// 角色是否存在
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public List<sys_config> GetConfigList(Expression<Func<sys_config, bool>> predicate = null)
		{
			using (var db = new NPiculetEntities()) {
				if (predicate == null)
					return db.sys_config.ToList();
				else
					return db.sys_config.Where(predicate).ToList();
			}
		}

		/// <summary>
		/// 角色是否存在
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public sys_config GetConfig(Expression<Func<sys_config, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				return db.sys_config.FirstOrDefault(predicate);
			}
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="config"></param>
		/// <param name="predicate"></param>
		public void Save(sys_config config, Expression<Func<sys_config, bool>> predicate)
		{
			using (var db = new NPiculetEntities()) {
				var c = db.sys_config.FirstOrDefault(predicate);
				if (c != null) {
					config.Id = c.Id;
				}
				db.sys_config.AddOrUpdate(config);
				db.SaveChanges();
			}
		}
	}
}
