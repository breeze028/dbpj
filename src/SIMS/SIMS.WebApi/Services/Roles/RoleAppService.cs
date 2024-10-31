using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Data;

namespace SIMS.WebApi.Services.Roles
{
    public class RoleAppService : IRoleAppService
    {
        private DataContext dataContext;

        public RoleAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int AddRole(RoleEntity role)
        {
            var entry = dataContext.Roles.Add(role);
            dataContext.SaveChanges();
            return 0;
        }

        public int DeleteRole(int id)
        {
            var entity = dataContext.Roles.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Roles.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }

        public RoleEntity GetRole(int id)
        {
            var entity = dataContext.Roles.FirstOrDefault(r => r.Id == id);
            return entity;
        }

        public PagedRequest<RoleEntity> GetRoles(string roleName, int pageNum, int pageSize)
        {
            IQueryable<RoleEntity> roles = null;
            if (!string.IsNullOrEmpty(roleName))
            {
                roles = dataContext.Roles.Where(r => r.Name.Contains(roleName)).OrderBy(r => r.Id);
            }
            else
            {
                roles = dataContext.Roles.Where(r => true).OrderBy(r => r.Id);
            }
            int count = roles.Count();
            List<RoleEntity> items;
            if (pageSize > 0)
            {
                items = roles.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = roles.ToList();
            }
            return new PagedRequest<RoleEntity>()
            {
                count = count,
                items = items
            };
        }

        public int UpdateRole(RoleEntity role)
        {
            dataContext.Roles.Update(role);
            dataContext.SaveChanges();
            return 0;
        }

        public List<UserRight> GetUserRights(int? userId)
        {
            if (userId != null)
            {
                var query = from u in dataContext.UserRoles
                            join r in dataContext.Roles on u.RoleId equals r.Id
                            join x in dataContext.RoleMenus on r.Id equals x.RoleId
                            join m in dataContext.Menus on x.MenuId equals m.Id
                            where u.UserId == userId
                            select new UserRight { Id = m.Id, RoleName = r.Name, MenuName = m.Name, Url = m.Url,Icon=m.Icon, ParentId = m.ParentId, SortId = m.SortId };

                return query.ToList();
            }
            return null;
        }

        public PagedRequest<RoleMenuEntity> GetRoleMenus(int? roleId)
        {
            if (roleId != null)
            {
                var roleMenus = this.dataContext.RoleMenus.Where(x => x.RoleId == roleId);
                return new PagedRequest<RoleMenuEntity>()
                {
                    count = roleMenus.Count(),
                    items = roleMenus.ToList()
                };
            }
            else
            {
                return null;
            }
        }

        public int SetRoleMenus(int roleId, string menuIds)
        {
            string[] menus = menuIds.Split(',');
            if (menus.Length == 0)
            {
                return -1;//权限为空
            }
            if (roleId < 1)
            {
                return -1;
            }
            var oldRoleMenus = dataContext.RoleMenus.Where(r => r.RoleId == roleId);
            if (oldRoleMenus.Count() > 0)
            {
                this.dataContext.RoleMenus.RemoveRange(oldRoleMenus);
            }
            var entities = menus.Select(r => new RoleMenuEntity()
            {
                RoleId = roleId,
                MenuId =int.Parse(r)
            });
            this.dataContext.RoleMenus.AddRange(entities);
            this.dataContext.SaveChanges();
            return 0;
        }
    }
}
