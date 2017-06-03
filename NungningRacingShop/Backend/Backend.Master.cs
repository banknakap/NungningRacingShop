using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend
{
    public partial class Backend : MasterPageControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionApp.user_info != null)
            {
                string fullname = SessionApp.user_info.first_name + " " + SessionApp.user_info.last_name;
                lblFullName.Text = fullname;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionApp.user_info != null)
                {
                    SessionApp.user_info = null;

                    string path = Request.Url.PathAndQuery.ToString();
                    string return_path = path.Replace("~/", "");
                    RedirectTo("~" + return_path);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}