using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Webboard
{
    public partial class TopicList : PageControl
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
                bindtopicList();

            }
        }
        private const string UnSelected = "------- กรุณาเลือก ---------";

        private void bindtopicList()
        {
            var result = WebboardController.getTopic(null);
            rptTopics.DataSource = result;
            rptTopics.DataBind();
        }

        protected void rptTopics_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string topic_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "EDIT":
                        RedirectTo("~/Backend/Webboard/TopicEdit.aspx" + "?topic_id=" + topic_id);
                        break;
                    case "DEL":
                        WebboardController.DelTopic(topic_id, true);
                        break;
                    default:
                        break;
                }
                bindtopicList();
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

                serchTopic();


            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }
        private void serchTopic()
        {
            var result = WebboardController.SearchTopic(txtTitle.Text);
            rptTopics.DataSource = result;
            rptTopics.DataBind();
        }

    }
}