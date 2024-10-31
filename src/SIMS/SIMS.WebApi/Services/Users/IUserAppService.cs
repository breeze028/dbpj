using SIMS.Entity;
using SIMS.Utils.Controls;

namespace SIMS.WebApi.Services.Users
{
    public interface IUserAppService
    {
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PagedRequest<UserEntity> GetUsers(string userName, int pageNum, int pageSize);

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public PagedRequest<UserRoleEntity> GetUserRoles(int? userId);

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public int SetUserRoles(int userId, string roleIds);

        /// <summary>
        /// 通过id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserEntity GetUser(int id);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(UserEntity user);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(UserEntity user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        public int DeleteUser(int id);
    }
}
