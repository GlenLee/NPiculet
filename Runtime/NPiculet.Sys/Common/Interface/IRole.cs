using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPiculet.Logic.Interface
{
	/// <summary>
	/// 角色接口
	/// </summary>
    public interface IRole
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="jsonRole">角色信息json</param>
        /// <returns></returns>
        int SaveRole(string jsonRole);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="jsonRole">角色信息json</param>
        /// <returns></returns>
        int UpdateRole(string jsonRole);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        int DelRole(string RoleID);

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        string GetRoleList(string condition);
    }
}
