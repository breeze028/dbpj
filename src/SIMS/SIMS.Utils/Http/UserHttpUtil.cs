using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class UserHttpUtil:HttpUtil
    {
        /// <summary>
        /// 新增user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(UserEntity user)
        {
            var ret = Post<UserEntity>(UrlConfig.USER_ADDUSER, user);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 删除User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUser(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.USER_DELETEUSER, data);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 获取单个user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserEntity GetUser(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.USER_GETUSER, data);
            var user = StrToObject<UserEntity>(str);
            return user;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedRequest<UserEntity> GetUsers(string userName, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["userName"] = userName;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.USER_GETUSERS, data);
            var users = StrToObject<PagedRequest<UserEntity>>(str);
            return users;
        }

        public static PagedRequest<UserRoleEntity> GetUserRoles(int? userId) {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["userId"] = userId;
            var str = Get(UrlConfig.USER_GETUSERROLES, data);
            var userRoles = StrToObject<PagedRequest<UserRoleEntity>>(str);
            return userRoles;
        }

        public static bool SetUserRoles(int? userId,string roleIds)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["userId"] = userId;
            data["roleIds"] = roleIds;
            var ret = Get(UrlConfig.USER_SETUSERROLES, data);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 修改User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UpdateUser(UserEntity user)
        {
            var ret = Put<UserEntity>(UrlConfig.USER_UPDATEUSER, user);
            return int.Parse(ret) == 0;
        }
    }
}
