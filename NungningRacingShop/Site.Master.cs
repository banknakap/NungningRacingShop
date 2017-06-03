using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop
{
    public partial class SiteMaster : MasterPageControl
    {
      


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionApp.user_info !=null)
                {
                    string fullname = SessionApp.user_info.first_name + " " + SessionApp.user_info.last_name;
                    lblFullName.Text = fullname;

                    div_nologin.Visible = false;

                    badge_cart.InnerText = SessionApp.cart_session.Count.ToString();

                    
                }
                else
                {
                    string path = Request.Url.PathAndQuery.ToString();
                    string return_path = path.Replace("~/", "");
                    btn_login.HRef = "~/Authentication/Login.aspx?return_page=" + return_path;

                    div_login.Visible = false;


                    if (SessionApp.cart_session != null)
                        badge_cart2.InnerText = SessionApp.cart_session.Count.ToString();

                }

         

           
  
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionApp.user_info !=null)
                {
                    SessionApp.user_info = null;

                    string path = Request.Url.PathAndQuery.ToString();
                    string return_path = path.Replace("~/", "");
                    //RedirectTo("~"+ return_path);
                    RedirectTo("~~/.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }

 
    }
}