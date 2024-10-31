using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Data;

namespace SIMS.WebApi.Services.Menus
{
    public class MenuAppService : IMenuAppService
    {
        private DataContext dataContext;

        public MenuAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int AddMenu(MenuEntity menu)
        {
            var entry = dataContext.Menus.Add(menu);
            dataContext.SaveChanges();
            return 0;
        }

        public int DeleteMenu(int id)
        {
            var entity = dataContext.Menus.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Menus.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }

        public MenuEntity GetMenu(int id)
        {
            var entity = dataContext.Menus.FirstOrDefault(r => r.Id == id);
            return entity;
        }

        public PagedRequest<MenuEntity> GetMenus(string menuName, int pageNum, int pageSize)
        {
            IQueryable<MenuEntity> menus = null;
            if (!string.IsNullOrEmpty(menuName))
            {
                menus = dataContext.Menus.Where(r => r.Name.Contains(menuName)).OrderBy(r => r.Id);
            }
            else
            {
                menus = dataContext.Menus.Where(r => true).OrderBy(r => r.Id);
            }
            int count = menus.Count(); 
            List<MenuEntity> items;
            if (pageSize > 0)
            {
                items = menus.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = menus.ToList();
            }
            return new PagedRequest<MenuEntity>()
            {
                count = count,
                items = items
            };
        }

        public int UpdateMenu(MenuEntity menu)
        {
            dataContext.Menus.Update(menu);
            dataContext.SaveChanges();
            return 0;
        }
    }
}
