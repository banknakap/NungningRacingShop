using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Webboard
{
    public partial class CommentEdit : PageControl
    {

        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return false;
        }

        private string comment_id
        {
            set
            {
                ViewState["comment_id"] = value;
            }
            get
            {
                return (string)ViewState["comment_id"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            comment_id = Request.QueryString["comment_id"];
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(comment_id))
                    return;
                bindComment();
            }

        }


        private void bindComment()
        {
            var result = WebboardController.getComment(comment_id,null);
            var current = result[0];
            if (current == null)
            {
                ShowMessage(Page, "ไม่พบความเห็นนี้");
                return;
            }
            txtDescription.Text = current.description;


        }

        protected void rptComments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string comment_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "EDIT":
                        RedirectTo("~/Backend/Webboard/CommentEdit.aspx" + "?comment_id=" + comment_id);
                        break;
                    case "DEL":
                        WebboardController.DelComment(comment_id, true);
                        break;
                    default:
                        break;
                }
                bindComment();
            }
            catch (Exception exc)
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
                    setComment();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }
        private void setComment()
        {
            var result = WebboardController.getComment(comment_id,null);
            var info = result[0];

            if (info == null)
            {
                ShowMessage(Page, "ไม่พบความเห็นนี้");
                return;
            }
            info.description = txtDescription.Text;
            info.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            info.lastupdate_date = DateTime.Now;

            var resulttopic = WebboardController.setComment(info);
            if (result != null)
            {
                bindComment();
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
            if (string.IsNullOrEmpty(txtDescription.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            return errMsg;
        }
    }
}