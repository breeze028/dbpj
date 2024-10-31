using Microsoft.AspNetCore.Mvc;
using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Services.Roles;

namespace SIMS.WebApi.Controllers
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController  : ControllerBase
    {
        private readonly ILogger<RoleController> logger;

        private readonly IRoleAppService roleAppService;

        public RoleController(ILogger<RoleController> logger, IRoleAppService roleAppService)
        {
            this.logger = logger;
            this.roleAppService = roleAppService;
        }

        /// <summary>
        /// 新增role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddRole(RoleEntity role)
        {
            return roleAppService.AddRole(role);
        }

        /// <summary>
        /// 删除Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteRole(int id)
        {
            return roleAppService.DeleteRole(id); ;
        }

        /// <summary>
        /// 获取单个role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public RoleEntity GetRole(int id)
        {
            return roleAppService.GetRole(id);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<RoleEntity> GetRoles(string? roleName, int pageNum, int pageSize)
        {
            return roleAppService.GetRoles(roleName, pageNum, pageSize);
        }

        /// <summary>
        /// 修改Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateRole(RoleEntity role)
        {
            return roleAppService.UpdateRole(role);
        }

        [HttpGet]
        public List<UserRight> GetUserRights(int? userId) { 
            return roleAppService.GetUserRights(userId);
        }

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<RoleMenuEntity> GetRoleMenus(int? roleId)
        {
            return roleAppService.GetRoleMenus(roleId);
        }

        /// <summary>
        /// 设置角色菜单列表
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        [HttpGet]
        public int SetRoleMenus(int roleId, string menuIds)
        {
            return roleAppService.SetRoleMenus(roleId, menuIds);
        }
    }
}
