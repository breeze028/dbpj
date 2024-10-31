namespace SIMS.WebApi.Services.Login
{
    public interface ILoginAppService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int? Login(string username, string password);
    }
}
