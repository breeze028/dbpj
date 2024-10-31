using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class RoleHttpUtil:HttpUtil
    {
        /// <summary>
        /// 新增role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool AddRole(RoleEntity role)
        {
            var ret = Post<RoleEntity>(UrlConfig.ROLE_ADDROLE, role);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 删除Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteRole(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.ROLE_DELETEROLE, data);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 获取单个role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RoleEntity GetRole(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.ROLE_GETROLE, data);
            var role = StrToObject<RoleEntity>(str);
            return role;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedRequest<RoleEntity> GetRoles(string roleName, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["roleName"] = roleName;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.ROLE_GETROLES, data);
            var roles = StrToObject<PagedRequest<RoleEntity>>(str);
            return roles;
        }

        /// <summary>
        /// 修改Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool UpdateRole(RoleEntity role)
        {
            var ret = Put<RoleEntity>(UrlConfig.ROLE_UPDATEROLE, role);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static PagedRequest<RoleMenuEntity> GetRoleMenus(int? roleId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["roleId"] = roleId;
            var str = Get(UrlConfig.ROLE_GETROLEMENUS, data);
            var roleMenus = StrToObject<PagedRequest<RoleMenuEntity>>(str);
            return roleMenus;
        }

        public static bool SetRoleMenus(int? roleId, string menuIds)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["roleId"] = roleId;
            data["menuIds"] = menuIds;
            var ret = Get(UrlConfig.ROLE_SETROLEMENUS, data);
            return int.Parse(ret) == 0;
        }

        public static List<UserRight> GetUserRights(int userId) {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["userId"] = userId;
            var str = Get(UrlConfig.ROLE_GETUSERRIGHTS, data);
            var userRights = StrToObject<List<UserRight>>(str);
            return userRights;
        }
    }
}
