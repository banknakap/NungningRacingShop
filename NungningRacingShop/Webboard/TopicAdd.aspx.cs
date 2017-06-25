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
    public partial class TopicAdd : PageControl
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
  

            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addTopic();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void addTopic()
        {
            TopicInfo top = new TopicInfo();
            top.title = txtTitle.Text;
            top.description = txtDescription.Text;
            top.create_by = (SessionApp.user_info == null) ? "ไม่เป็นสามาชิก" : SessionApp.user_info.user_name;

            var result = WebboardController.addTopic(top);


            if (result == null)
            {
                ShowMessage(Page, "เพิ่มผิดพลาด");
            }
            else
            {
                RedirectTo("~/Webboard/TopicDetail?topic_id="+result.topic_id);
            }

        }



        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ หัวเรื่อง"; return errMsg; }
            if (string.IsNullOrEmpty(txtDescription.Text)) { errMsg = "กรุณาระบุ คำอธิบาย"; return errMsg; }

            return errMsg;
        }
    }
}