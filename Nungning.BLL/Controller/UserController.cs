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
        public static List<UserInfo> GetUser(string user_infoid)
        {
            return CBO.FillCollection<UserInfo>(DataProvider.Instance().GetUser(user_infoid));
        }
        public static List<UserInfo> AddUser(UserInfo user)
        {
            return CBO.FillCollection<UserInfo>(DataProvider.Instance().AddUser(user));
        }
        public static UserInfo SetUser(UserInfo user)
        {
            return CBO.FillObject<UserInfo>(DataProvider.Instance().SetUser(user));
        }

        public static List<UserInfo> SearchUser(string user_name,string first_name)
        {
            return CBO.FillCollection<UserInfo>(DataProvider.Instance().SearchUser(user_name, first_name));
        }

        public static UserInfo DelUser(string user_infoid, bool is_del)
        {
            var result = GetUser(user_infoid);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<UserInfo>(DataProvider.Instance().SetUser(result[0]));
            }
            else
                return null;
        }
    }
}
