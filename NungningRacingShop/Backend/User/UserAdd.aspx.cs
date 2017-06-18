using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.User
{
    public partial class UserAdd : PageControl
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
                bindDdlUserType();
              
            }
        }

        private const string UnSelected = "------- กรุณาเลือก ---------";
        private void bindDdlUserType()
        {
            ddlUserType.DataBind();
            ddlUserType.Items.Insert(0, new ListItem(UnSelected, "General"));
            ddlUserType.Items.Insert(1, new ListItem("General", "General"));
            ddlUserType.Items.Insert(2, new ListItem("Admin", "Admin"));
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addProfile();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }
        private void addProfile()
        {
            var user_info = new UserInfo();
            user_info.user_name = txtUserName.Text;
            user_info.password = txtPassword.Text;
            user_info.first_name = txtFirstName.Text;
            user_info.last_name = txtLastName.Text;
            user_info.address = txtAddress.Text;
            user_info.gender = (rdoMale.Checked) ? 0 : 1;
            user_info.user_type = ddlUserType.SelectedValue;
            user_info.create_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            user_info.create_date = DateTime.Now;
            user_info.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            user_info.lastupdate_date = DateTime.Now;
            var result = UserController.AddUser(user_info);
            if (result != null)
            {
                ShowMessage(Page, "เพิ่มสำเร็จ");
            }
            else
            {
                ShowMessage(Page, "เพิ่มผิดพลาด");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtUserName.Text)) { errMsg = "กรุณาระบุ User Name"; return errMsg; }
            if (string.IsNullOrEmpty(txtPassword.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            if (string.IsNullOrEmpty(txtFirstName.Text)) { errMsg = "กรุณาระบุ ชื่อ"; return errMsg; }
            if (string.IsNullOrEmpty(txtLastName.Text)) { errMsg = "กรุณาระบุ นามสกุล"; return errMsg; }
            if (string.IsNullOrEmpty(txtAddress.Text)) { errMsg = "กรุณาระบุ ที่อยู่"; return errMsg; }
            return errMsg;
        }
    }
}