using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.User
{
    public partial class UserList : PageControl
    {
        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindUserList();

            }
        }
        private const string UnSelected = "------- กรุณาเลือก ---------";

        private void bindUserList()
        {
            var result = UserController.SearchUser(null,null);
            rptUsers.DataSource = result;
            rptUsers.DataBind();
        }

        protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string user_infoid = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "USER_EDIT":
                        RedirectTo("~/Backend/User/UserEdit.aspx" + "?user_infoid=" + user_infoid);
                        break;
                    case "USER_DEL":
                        UserController.DelUser(user_infoid, true);
                        break;
                    default:
                        break;
                }
                bindUserList();
            }
            catch (Exception exc)
            {

            }
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                searchUser();


            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }
        private void searchUser()
        {
            var result = UserController.SearchUser(txtUserName.Text, txtFirstName.Text);
            rptUsers.DataSource = result;
            rptUsers.DataBind();
        }

    }
}