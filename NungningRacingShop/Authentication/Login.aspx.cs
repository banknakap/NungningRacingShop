using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Authentication
{
    public partial class Login : MasterPageControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    login();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }
        private void login()
        {
            var user = UserController.GetUserByLogin(txtUserName.Text, txtPassword.Text);
            if (user != null)
            {
                user_info = user;
                RedirectTo("~/Default.aspx");
            }
            else
            {
                ShowMessage(Page, "username & password ผิด");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtUserName.Text)) { errMsg = "กรุณาระบุ User Name"; return errMsg; }
            if (string.IsNullOrEmpty(txtPassword.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            return errMsg;
        }


    }

   
}