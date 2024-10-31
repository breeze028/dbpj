using Microsoft.AspNetCore.Mvc;
using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Services.Users;

namespace SIMS.WebApi.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> logger;

        private readonly IUserAppService userAppService;

        public UserController(ILogger<UserController> logger, IUserAppService userAppService)
        {
            this.logger = logger;
            this.userAppService = userAppService;
        }

        /// <summary>
        /// 新增user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddUser(UserEntity user)
        {
            return userAppService.AddUser(user);
        }

        /// <summary>
        /// 删除User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteUser(int id)
        {
            return userAppService.DeleteUser(id); ;
        }

        /// <summary>
        /// 获取单个user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public UserEntity GetUser(int id)
        {
            return userAppService.GetUser(id);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<UserEntity> GetUsers(int pageNum, int pageSize,string? userName)
        {
            return userAppService.GetUsers(userName, pageNum, pageSize);
        }

        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<UserRoleEntity> GetUserRoles(int? userId) { 
            return userAppService.GetUserRoles(userId);
        }

        /// <summary>
        /// 设置角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        [HttpGet]
        public int SetUserRoles(int userId, string roleIds) { 
            return userAppService.SetUserRoles(userId, roleIds);
        }

        /// <summary>
        /// 修改User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateUser(UserEntity user)
        {
            return userAppService.UpdateUser(user);
        }
    }
}
