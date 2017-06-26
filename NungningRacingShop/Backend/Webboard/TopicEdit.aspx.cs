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
    public partial class TopicEdit : PageControl
    {

        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return false;
        }

        private string topic_id
        {
            set
            {
                ViewState["topic_id"] = value;
            }
            get
            {
                return (string)ViewState["topic_id"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            topic_id = Request.QueryString["topic_id"];
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(topic_id))
                    return;
                bindTopicDetail();
                bindComments();
            }

        }

        private void bindTopicDetail()
        {
            var result = WebboardController.getTopic(topic_id);

            if (result.Count > 0)
            {
                var current = result[0];
                if (current != null)
                {
                    txtTitle.Text = current.title;
                    txtDescription.Text = current.description;

                    rdoYes.Checked = current.is_top;

                }
            }

        }

        private void bindComments()
        {
            var result = WebboardController.getComment(null, topic_id);
            rptComments.DataSource = result.OrderBy(d => d.create_date);
            rptComments.DataBind();


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
                bindTopicDetail();
                bindComments();
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
                    setTopic();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }
        private void setTopic()
        {
            var result = WebboardController.getTopic(topic_id);
            var current = result[0];

            if (current == null)
            {
                ShowMessage(Page, "ไม่พบกระทู้นี้");
                return;
            }

            var info = new TopicInfo();
            info.topic_id = topic_id;
            info.title = txtTitle.Text;
            info.description = txtDescription.Text;
            info.read_count = current.read_count;
            info.is_top = rdoYes.Checked ? true : false;
            info.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            info.lastupdate_date = DateTime.Now;

            var resulttopic = WebboardController.setToppic(info);
            if (result != null)
            {
                bindTopicDetail();
                bindComments();
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
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ User Name"; return errMsg; }
            if (string.IsNullOrEmpty(txtDescription.Text)) { errMsg = "กรุณาระบุ Password"; return errMsg; }
            return errMsg;
        }
    }
}