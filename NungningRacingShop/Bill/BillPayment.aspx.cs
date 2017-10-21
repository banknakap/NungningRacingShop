using Nungning.BLL.Controller;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Bill
{
    public partial class BillPayment : PageControl
    {
        public string bill_id
        {
            set
            {
                ViewState["bill_id"] = value;
            }
            get
            {
                return (string)ViewState["bill_id"];
            }
        }
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
            bill_id = Request.QueryString["bill_id"];
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
                    addBillPayment();
                }
                else
                    ShowMessage(Page, resultValidate);
            }
            catch (Exception ex)
            {

            }
        }
        private void addBillPayment()
        {
            string imageName = null;
            if (fileImage.HasFile)
            {
                string exttension = System.IO.Path.GetExtension(fileImage.FileName);
                string newNameImage = Guid.NewGuid().ToString();
                fileImage.SaveAs(System.IO.Path.Combine(Server.MapPath("~/PaymentImages/"), newNameImage + exttension));
                imageName = newNameImage + exttension;

            }

            var result = BillController.AddBillPayment(bill_id,txtDate.Text +" "+ txtTime.Text,float.Parse(txtPaymentPrice.Text), SessionApp.user_info.user_name,null,txtPaymentName.Text, imageName);
            if (result != null)
            {

                ShowMessage(Page, "ยืนยันการชำระเสร็จสิ้น");
            }
            else
            {
                ShowMessage(Page, "ผิดพลาด");
            }

        }

        private string Onvalidate()
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(txtDate.Text)) { errMsg = "กรุณาระบุ วัน"; return errMsg; }
            if (string.IsNullOrEmpty(txtTime.Text)) { errMsg = "กรุณาระบุ เวลา"; return errMsg; }
            if (string.IsNullOrEmpty(txtPaymentPrice.Text)) { errMsg = "กรุณาระบุ ยอดที่ชำระ"; return errMsg; }
            if (string.IsNullOrEmpty(txtPaymentName.Text)) { errMsg = "กรุณาระบุ ชื่อผู้ชำระเงิน"; return errMsg; }
            return errMsg;
        }
    }
}