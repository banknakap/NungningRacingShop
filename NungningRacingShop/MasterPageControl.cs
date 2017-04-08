using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace NungningRacingShop
{
    public class MasterPageControl : Page
    {
        public static string user_info
        {
            get
            {
                object value = HttpContext.Current.Session["user_info"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["user_info"] = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}