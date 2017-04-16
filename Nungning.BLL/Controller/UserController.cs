using Nungning.BLL.Info;
using Nungning.BLL.Provider;
using NungningUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Controller
{
    public class UserController
    {
        public static UserInfo GetUserByLogin(string user_name , string password)
        {
            return CBO.FillObject<UserInfo>(DataProvider.Instance().GetUserByLogin(user_name, password));
        }
        public static List<UserInfo> AddUser(UserInfo user)
        {
            return CBO.FillCollection<UserInfo>(DataProvider.Instance().AddUser(user));
        }
        public static UserInfo SetUser(UserInfo user)
        {
            return CBO.FillObject<UserInfo>(DataProvider.Instance().SetUser(user));
        }
    }
}
