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
    public partial class NoticeEdit : PageControl
    {
        public override bool requirelogin()
        {
            return true;
        }
        public override bool requireAdmin()
        {
            return true;
        }

        private string notice_id
        {
            set
            {
                ViewState["notice_id"] = value;
            }
            get
            {
                return (string)ViewState["notice_id"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            notice_id = Request.QueryString["notice_id"];
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(notice_id))
                    return;
                //bindDllLinkPage();
                bindNotice();
            }

        }
        //private const string UnSelected = "------- กรุณาเลือก ---------";
        //private void bindDllLinkPage()
        //{
        //    var result = LinkPageController.GetLinkPage(null);
        //    ddlLinkPage.DataSource = result;
        //    ddlLinkPage.DataValueField = "link_page";
        //    ddlLinkPage.DataTextField = "description";
        //    ddlLinkPage.DataBind();
        //    ddlLinkPage.Items.Insert(0, new ListItem(UnSelected, "0"));


        //}

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string resultValidate = Onvalidate();
                if (string.IsNullOrEmpty(resultValidate))
                {
                    setNotice();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }

        private void setNotice()
        {
            NoticeInfo notice = new NoticeInfo();
            notice.notice_id = notice_id;
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
            else
            {
                notice.image = imgName.Value;
            }

            //notice.url = txtUrl.Text;
            int display;
            int.TryParse(txtDisplaySort.Text, out display);
            notice.display_sort = display;
            notice.create_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            notice.lastupdate_by = (SessionApp.user_info == null) ? "No Login" : SessionApp.user_info.user_name;
            //notice.link_page = int.Parse(ddlLinkPage.SelectedValue);
            //notice.link_param = txtLinkParam.Text;

            var result = NoticeController.SetNotice(notice);


            if (result == null)
            {
                ShowMessage(Page, "ชื่อประกาศนี้มีอยู่ในระบบแล้ว");
            }
            else
            {
                bindNotice();
                ShowMessage(Page, "แก้สำเร็จ");
            }

        }


        private void bindNotice()
        {
            var current = NoticeController.GetNotice(notice_id);
            if (current.Count > 0)
            {
                txtTitle.Text = current[0].title;
                txtDesciption.Text = current[0].description;
                imgNotice.ImageUrl = getImage(current[0].image);
                txtDisplaySort.Text = current[0].display_sort.ToString();
                //ddlLinkPage.SelectedValue = current[0].link_page.ToString();
                //txtLinkParam.Text = current[0].link_param;

                imgName.Value = current[0].image;
            }
            
        }
        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getImage(image_name);
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