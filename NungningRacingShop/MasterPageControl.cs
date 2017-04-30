using Nungning.BLL.Info;
using NungningRacingShop.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace NungningRacingShop
{
    public abstract class MasterPageControl : MasterPage
    {
       
    

        public static void ShowMessage(Page page, string message, string redirectUrl = null)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(),"JSSCRIPT", string.Format("<script> alert('{0}');{1}", message.Replace("'", "\\'"), !string.IsNullOrEmpty(redirectUrl) ? "window.location = '" + redirectUrl + "';</script>" : "</script>"));
        }

        protected override void OnInit(EventArgs e)
        {
            

            base.OnInit(e);
        }
        public static string getUrl(string path)
        {
            string strUrl = HttpContext.Current.Request.Url.Host + VirtualPathUtility.ToAbsolute(path);
            return HttpUtility.UrlPathEncode(HttpContext.Current.Request.Url.Scheme + "://" + strUrl);
        }


        protected static void RedirectTo(string url)
        {
            HttpContext.Current.Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}