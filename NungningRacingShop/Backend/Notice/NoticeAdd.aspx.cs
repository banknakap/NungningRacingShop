using Nungning.BLL.Controller;
using Nungning.BLL.Info;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Notice
{
    public partial class NoticeAdd : PageControl
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
                bindDllLinkPage();
            }

        }
        private const string UnSelected = "------- กรุณาเลือก ---------";
        private void bindDllLinkPage()
        {
            var result = LinkPageController.GetLinkPage(null);
            ddlLinkPage.DataSource = result;
            ddlLinkPage.DataValueField = "link_page";
            ddlLinkPage.DataTextField = "description";
            ddlLinkPage.DataBind();
            ddlLinkPage.Items.Insert(0, new ListItem(UnSelected, "0"));


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    addNotice();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void addNotice()
        {
            NoticeInfo notice = new NoticeInfo();
            notice.title = txtTitle.Text;
            notice.description = txtDesciption.Text;

            if (fileImage.HasFile)
            {
                var current = fileImage.PostedFile;
                string exttension = System.IO.Path.GetExtension(current.FileName);
                string newNameImage = Guid.NewGuid().ToString();
                current.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), newNameImage + exttension));
                listofuploadedfiles.Text += String.Format("{0}<br />", newNameImage + exttension);

                notice.image = newNameImage + exttension;

            }

            notice.url = txtUrl.Text;
            int display;
            int.TryParse(txtDisplaySort.Text,out display);
            notice.display_sort = display;
            notice.create_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            notice.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            notice.link_page = int.Parse(ddlLinkPage.SelectedValue);
            notice.link_param = txtLinkParam.Text;

            var result = NoticeController.AddNotice(notice);

            if (result == null)
            {
                ShowMessage(Page, "ชื่อประกาศนี้มีอยู่ในระบบแล้ว");
            }
            else
            {
                ShowMessage(Page, "เพิ่มสำเร็จ");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtTitle.Text)) { errMsg = "กรุณาระบุ ชื่อหมวดหมู่"; return errMsg; }
            if (string.IsNullOrEmpty(txtDesciption.Text)) { errMsg = "กรุณาระบุ คำอธิบาย"; return errMsg; }

            return errMsg;
        }

    }
}