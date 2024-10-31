using SIMS.Entity;
using SIMS.Utils.Controls;

namespace SIMS.WebApi.Services.Menus
{
    public interface IMenuAppService
    {
        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PagedRequest<MenuEntity> GetMenus(string menuName, int pageNum, int pageSize);


        /// <summary>
        /// 通过id查询菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuEntity GetMenu(int id);

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int AddMenu(MenuEntity menu);

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int UpdateMenu(MenuEntity menu);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        public int DeleteMenu(int id);
    }
}
