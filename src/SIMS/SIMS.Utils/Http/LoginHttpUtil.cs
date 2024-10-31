using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class LoginHttpUtil:HttpUtil
    {
        public static int Login(string username, string password) {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["username"] = username;
            data["password"] = password;
            var str = Get(UrlConfig.LOGIN_LOGIN, data);
            if (!string.IsNullOrEmpty(str)) { 
                return int.Parse(str);
            }
            return 0;
        }
    }
}
