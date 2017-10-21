using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NungningRacingShop.Utility
{
    public class Utility
    {
        public static string getImage(string image_name)
        {
            string strUrl = HttpContext.Current.Request.Url.Host + VirtualPathUtility.ToAbsolute("~/Images/" + image_name);
            return HttpUtility.UrlPathEncode(HttpContext.Current.Request.Url.Scheme + "://" + strUrl);
        }
        public static string formatMoney(float x)
        {
            return string.Format("{0:#,##0.00}", x);
        }

        public static string getPaymentImage(string image_name)
        {
            string strUrl = HttpContext.Current.Request.Url.Host + VirtualPathUtility.ToAbsolute("~/PaymentImages/" + image_name);
            return HttpUtility.UrlPathEncode(HttpContext.Current.Request.Url.Scheme + "://" + strUrl);
        }


    }
}