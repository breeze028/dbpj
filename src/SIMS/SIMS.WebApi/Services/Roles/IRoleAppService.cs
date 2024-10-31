using SIMS.Entity;
using SIMS.Utils.Controls;

namespace SIMS.WebApi.Services.Roles
{
    public interface IRoleAppService
    {
        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PagedRequest<RoleEntity> GetRoles(string roleName, int pageNum, int pageSize);


        /// <summary>
        /// 通过id查询角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleEntity GetRole(int id);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddRole(RoleEntity role);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int UpdateRole(RoleEntity role);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        public int DeleteRole(int id);

        public List<UserRight> GetUserRights(int? userId);

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public PagedRequest<RoleMenuEntity> GetRoleMenus(int? roleId);

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public int SetRoleMenus(int roleId, string menuIds);
    }
}
