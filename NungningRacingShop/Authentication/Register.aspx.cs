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


        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtUserName.Text)) { errMsg = "กรุณาระบุ User Name"; return errMsg; }
            if (string.IsNullOrEmpty(txtPassword.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            if (string.IsNullOrEmpty(txtRepassword.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            if (string.IsNullOrEmpty(txtFirstName.Text)) { errMsg = "กรุณาระบุ ชื่อ"; return errMsg; }
            if (string.IsNullOrEmpty(txtLastName.Text)) { errMsg = "กรุณาระบุ นามสกุล"; return errMsg; }
            if (string.IsNullOrEmpty(txtAddress.Text)) { errMsg = "กรุณาระบุ ที่อยู่"; return errMsg; }
            return errMsg;
        }
}