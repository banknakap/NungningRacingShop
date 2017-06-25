using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Webboard
{
    public partial class TopicList : PageControl
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
            if (!IsPostBack)
            {
                bindTopic();
                bindTopic2();

               
            }
        }

        private void bindTopic()
        {
            var result = WebboardController.getTopic(null);
            rptTopics.DataSource = result.Where(d => d.is_top).OrderByDescending(d => d.lastupdate_date);
            rptTopics.DataBind();
        }
        private void bindTopic2()
        {
            var result = WebboardController.getTopic(null);
            rptTopics2.DataSource = result.OrderByDescending(d => d.lastupdate_date);
            rptTopics2.DataBind();
        }

        protected void rptTopics_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string topic_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "TOPIC_DETAIL":
                        RedirectTo("~/Webboard/TopicDetail.aspx" + "?topic_id=" + topic_id);
                        break;
                    default:
                        break;
                }
                bindTopic();
            }
            catch (Exception exc)
            {

            }
        }

        protected void rptTopics2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string topic_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "TOPIC_DETAIL":
                        RedirectTo("~/Webboard/TopicDetail.aspx" + "?topic_id=" + topic_id);
                        break;
                    default:
                        break;
                }
                bindTopic();
            }
            catch (Exception exc)
            {

            }
        }

   
    }
}