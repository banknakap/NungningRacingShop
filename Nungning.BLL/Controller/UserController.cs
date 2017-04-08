﻿using Nungning.BLL.Info;
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
        

        public static List<UserInfo> GetUserByLogin(string user_name , string password)
        {
            //return DataProvider.Instance().GetUserByLogin(user_name, password);

            return CBO.FillCollection<UserInfo>(DataProvider.Instance().GetUserByLogin(user_name, password));
        }
    }
}
