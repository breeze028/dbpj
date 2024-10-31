using Microsoft.AspNetCore.Mvc;
using SIMS.WebApi.Services.Login;

namespace SIMS.WebApi.Controllers
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;

        private readonly ILoginAppService loginAppService;

        public LoginController(ILogger<LoginController> logger, ILoginAppService loginAppService)
        {
            this.logger = logger;
            this.loginAppService = loginAppService;
        }


        [HttpGet]
        public int? Login(string username, string password)
        {
            return loginAppService.Login(username, password);
        }
    }
}
