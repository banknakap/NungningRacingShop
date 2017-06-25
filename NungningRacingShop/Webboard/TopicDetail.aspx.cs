using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Webboard
{
    public partial class TopicDetail : PageControl
    {
        public override bool requirelogin()
        {
            return false;
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
                    lblTitle.InnerText = current.title;
                    lblDes.InnerHtml = current.description;
                    lblCreateBy.InnerText = current.create_by;
                    lblTime.InnerText = current.create_date.ToString("dd MMM yyyy - HH:mm:ss");

                    navSup.InnerText = current.title;
                    navSup.HRef = HttpContext.Current.Request.Url.PathAndQuery;
                    
                }
            }
            
        }

        private void bindComments()
        {
            var result = WebboardController.getComment(null,topic_id);
            rptComments.DataSource = result.OrderBy(d => d.create_date);
            rptComments.DataBind();


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addComment();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }

        private void addComment()
        {
            CommentInfo info = new CommentInfo();
            info.topic_id = topic_id;
            info.description = txtDescription.Text;
            info.create_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;

            var result = WebboardController.addComment(info);
            if (result == null)
            {
                ShowMessage(Page, "เพิ่มไม่สำเร็จ");
            }
            else
            {
                ShowMessage(Page, "เพิ่มความเห็นสำเร็จ");
                bindComments();
            }

            
        }


        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtDescription.Text)) { errMsg = "กรุณาระบุ ความเห็น"; return errMsg; }
            return errMsg;
        }
    }
}