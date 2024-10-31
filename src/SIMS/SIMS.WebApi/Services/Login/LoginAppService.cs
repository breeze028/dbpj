using SIMS.WebApi.Data;

namespace SIMS.WebApi.Services.Login
{
    public class LoginAppService : ILoginAppService
    {
        private DataContext dataContext;

        public LoginAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int? Login(string username, string password)
        {
            var item = dataContext.Users.FirstOrDefault(i => i.UserName == username && i.Password == password);
            return item?.Id;
        }
    }
}
