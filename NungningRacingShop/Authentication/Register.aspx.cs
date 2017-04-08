using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Authentication
{
    public partial class Register : MasterPageControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ff = UserController.GetUserByLogin("banknakap", "02123456");

            var fff = "";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
     
            }
        }
    }
}