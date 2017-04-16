using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Authentication
{
    public partial class Login : PageControl
    {
        public override bool requirelogin()
        {
            return false;
        }
        public override bool requireAdmin()
        {
            return false;
        }
        private string return_page
        {
            set
            {
                ViewState["return_page"] = value;
            }
            get
            {
                return (string)ViewState["return_page"];
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            return_page = Request.QueryString["return_page"];
            if (!Page.IsPostBack)
            {

            }
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

                if (!string.IsNullOrEmpty(return_page))
                {
                    RedirectTo("~"+return_page);
                }
                else
                {
                    RedirectTo("~/Default.aspx");
                }
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