using Nungning.BLL.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace NungningRacingShop
{
    public abstract class MasterPageControl : Page
    {
        public abstract bool requirelogin();
        public abstract bool requireAdmin();
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


        public static void ShowMessage(Page page, string message, string redirectUrl = null)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(),"JSSCRIPT", string.Format("<script> alert('{0}');{1}", message.Replace("'", "\\'"), !string.IsNullOrEmpty(redirectUrl) ? "window.location = '" + redirectUrl + "';</script>" : "</script>"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (requirelogin())
            {
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                //RedirectTo("~/Default.aspx");
            }
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
        }

        protected static void RedirectTo(string url)
        {
            HttpContext.Current.Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}