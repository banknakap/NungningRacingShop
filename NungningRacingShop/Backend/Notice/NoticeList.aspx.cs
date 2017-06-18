using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Notice
{
    public partial class NoticeList : PageControl
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
                bindNoticeList();

            }
        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
    
        private void bindNoticeList()
        {
            var result = NoticeController.SearchNotice(null, null);
            rptNotices.DataSource = result;
            rptNotices.DataBind();
        }

        protected void rptNotices_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string notice_id = (string)e.CommandArgument;
                switch (e.CommandName)
                {
                    case "NOTICE_EDIT":
                        RedirectTo("~/Backend/Notice/NoticeEdit.aspx" + "?notice_id=" + notice_id);
                        break;
                    case "NOTICE_DEL":
                        NoticeController.DelNotice(notice_id, true);
                        break;
                    default:
                        break;
                }
                bindNoticeList();
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

                searchNotice();


            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }
        private void searchNotice()
        {
            var result = NoticeController.SearchNotice(null,txtTitle.Text);
            rptNotices.DataSource = result;
            rptNotices.DataBind();
        }



    }
}