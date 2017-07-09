using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Authentication
{
    public partial class Register : PageControl
    {
        public override bool requirelogin()
        {
            return false;
        }
        public override bool requireAdmin()
        {
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionApp.user_info != null)
            {
                RedirectTo("~/Default.aspx");
            }
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    register();
                }
                else
                    ShowMessage(Page,resultValidate);
            }
            catch (Exception ex)
            {

            }
        }

        private void register()
        {
            UserInfo user_info = new UserInfo();
            user_info.user_type = "General";
            user_info.user_name = txtUserName.Text;
            user_info.password = txtPassword.Text;
            user_info.first_name = txtFirstName.Text;
            user_info.last_name = txtLastName.Text;
            user_info.email = txtEmail.Text;
            user_info.gender = (rdoMale.Checked) ? 0 : 1;
            user_info.address = txtAddress.Text;
            user_info.create_by = txtUserName.Text;
            user_info.create_date = DateTime.Now;
            user_info.lastupdate_by = txtUserName.Text;
            user_info.lastupdate_date = DateTime.Now;
            var result = UserController.AddUser(user_info);
            if (result.Count==0)
            {
                ShowMessage(Page,"UserName มีอยู่ในระบบแล้ว");
            }
            else
            {
                ShowMessage(Page, "สมัครสมาชิกสำเร็จ");
            }
        }


        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtUserName.Text)) { errMsg = "กรุณาระบุ User Name"; return errMsg; }
            if (string.IsNullOrEmpty(txtPassword.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            if (string.IsNullOrEmpty(txtRepassword.Text)) { errMsg = "กรุณาระบุ Re-Password"; return errMsg; }
            if (string.IsNullOrEmpty(txtFirstName.Text)) { errMsg = "กรุณาระบุ ชื่อ"; return errMsg; }
            if (string.IsNullOrEmpty(txtLastName.Text)) { errMsg = "กรุณาระบุ นามสกุล"; return errMsg; }
            if (string.IsNullOrEmpty(txtEmail.Text)) { errMsg = "กรุณาระบุ อีเมล์"; return errMsg; }
            if (string.IsNullOrEmpty(txtAddress.Text)) { errMsg = "กรุณาระบุ ที่อยู่"; return errMsg; }
            return errMsg;
        }
    }
}