using Nungning.BLL.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace NungningRacingShop
{
    public abstract class PageControl : Page
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

        protected override void OnInit(EventArgs e)
        {
            

            base.OnInit(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (requirelogin())
            {
                if (user_info == null)
                {
                    string path = Request.Url.PathAndQuery.ToString();
                    string return_path = path.Replace("/NungningRacingShop", "");
                    RedirectTo("~/Authentication/Login.aspx?return_page="+ return_path);
                    return;
                }
                if (requireAdmin())
                {
                    if (!user_info.user_type.Equals(UserType.Admin.ToString()))
                    {
                        ShowMessage(Page, "คุณไม่มีสิทธิ์เข้าใช้งานหน้านี้", getUrl("~/Default.aspx"));
                        return;
                    }
                }

            }
            base.OnPreInit(e);
           
        }
        protected override void OnLoad(EventArgs e)
        {
          

            base.OnLoad(e);

         
        }

        public static string getUrl(string path)
        {
            string strUrl = HttpContext.Current.Request.Url.Host + VirtualPathUtility.ToAbsolute(path);
            return HttpUtility.UrlPathEncode(HttpContext.Current.Request.Url.Scheme + "://" + strUrl);
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