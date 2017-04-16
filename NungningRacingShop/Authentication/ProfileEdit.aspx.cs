using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Authentication
{
    public partial class ProfileEdit : PageControl
    {

        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (user_info != null)
                {
                    bindProfile();
                }

            }
        }
        
        private void bindProfile()
        {
            txtFirstName.Text = user_info.first_name;
            txtLastName.Text = user_info.last_name;
            txtAddress.Text = user_info.address;
            rdoMale.Checked = (user_info.gender == 1) ? true : false;
            rdoFemale.Checked = (user_info.gender == 0) ? true : false;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    setProfile();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }
        private void setProfile()
        {
            user_info.first_name = txtFirstName.Text;
            user_info.last_name = txtLastName.Text;
            user_info.address = txtAddress.Text;
            user_info.gender = (rdoMale.Checked) ? 0 : 1;
            var result = UserController.SetUser(user_info);
            if (result!=null)
            {
                user_info = result;
                ShowMessage(Page, "แก้ไขสำเร็จ");
            }
            else
            {
                ShowMessage(Page, "แก้ไขผิดพลาด");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtFirstName.Text)) { errMsg = "กรุณาระบุ ชื่อ"; return errMsg; }
            if (string.IsNullOrEmpty(txtLastName.Text)) { errMsg = "กรุณาระบุ นามสกุล"; return errMsg; }
            if (string.IsNullOrEmpty(txtAddress.Text)) { errMsg = "กรุณาระบุ ที่อยู่"; return errMsg; }
            return errMsg;
        }
    }
}