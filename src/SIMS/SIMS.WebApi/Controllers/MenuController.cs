using Microsoft.AspNetCore.Mvc;
using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Services.Menus;

namespace SIMS.WebApi.Controllers
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController :   ControllerBase
    {
        private readonly ILogger<MenuController> logger;

        private readonly IMenuAppService menuAppService;

        public MenuController(ILogger<MenuController> logger, IMenuAppService menuAppService)
        {
            this.logger = logger;
            this.menuAppService = menuAppService;
        }

        /// <summary>
        /// 新增Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMenu(MenuEntity menu)
        {
            return menuAppService.AddMenu(menu);
        }

        /// <summary>
        /// 删除Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteMenu(int id)
        {
            return menuAppService.DeleteMenu(id); ;
        }

        /// <summary>
        /// 获取单个menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public MenuEntity GetMenu(int id)
        {
            return menuAppService.GetMenu(id);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<MenuEntity> GetMenus(string? menuName, int pageNum, int pageSize)
        {
            return menuAppService.GetMenus(menuName, pageNum, pageSize);
        }

        /// <summary>
        /// 修改Menu
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateMenu(MenuEntity menu)
        {
            return menuAppService.UpdateMenu(menu);
        }
    }
}
