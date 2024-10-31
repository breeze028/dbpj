using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class MenuHttpUtil:HttpUtil
    {
        /// <summary>
        /// 新增menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static bool AddMenu(MenuEntity menu)
        {
            var ret = Post<MenuEntity>(UrlConfig.MENU_ADDMENU, menu);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 删除Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteMenu(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.MENU_DELETEMENU, data);
            return int.Parse(ret) == 0;
        }

        /// <summary>
        /// 获取单个menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MenuEntity GetMenu(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.MENU_GETMENU, data);
            var menu = StrToObject<MenuEntity>(str);
            return menu;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedRequest<MenuEntity> GetMenus(string menuName, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["menuName"] = menuName;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.MENU_GETMENUS, data);
            var menus = StrToObject<PagedRequest<MenuEntity>>(str);
            return menus;
        }

        /// <summary>
        /// 修改Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static bool UpdateMenu(MenuEntity menu)
        {
            var ret = Put<MenuEntity>(UrlConfig.MENU_UPDATEMENU, menu);
            return int.Parse(ret) == 0;
        }
    }
}
