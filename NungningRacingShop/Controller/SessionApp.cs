using Nungning.BLL.Info;
using NungningRacingShop.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NungningRacingShop.Controller
{
    public class SessionApp
    {
        public static UserInfo user_info
        {
            get
            {
                return (UserInfo)HttpContext.Current.Session["user_info"];
            }
            set
            {
                HttpContext.Current.Session["user_info"] = value;
            }
        }

        public static List<CartInfo> cart_session
        {
            set
            {
                HttpContext.Current.Session["cart_session"] = value;
            }
            get
            {
                return (List<CartInfo>)HttpContext.Current.Session["cart_session"];
            }
        }
    }
}