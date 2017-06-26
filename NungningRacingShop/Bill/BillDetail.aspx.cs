﻿using Nungning.BLL.Controller;
using NungningRacingShop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop
{
    public partial class BillDetail : PageControl
    {

        public float total_price = 0;
        private string bill_id
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
                if (SessionApp.user_info == null || string.IsNullOrEmpty(bill_id))
                    return;
                bindBill();
                bindBillDetail();
            }
        }

        private void bindBill()
        {
            var result = BillController.GetBill(bill_id, SessionApp.user_info.user_infoid);
            var current = result[0];
            if (current == null)
                return;
            pAddress.InnerText = "ที่อยุ่ผู้รับ : " + current.address;
            pReceiptCode.InnerText = "หมายเลขใบเสร็จ : " + current.bill_code.ToString("000000#");
            pCreateDate.InnerText = "วันที่ซื้อ : " + current.create_date.ToString("dd MM yyyy HH:mm:ss");
            total_price = current.total_price;
        }

        private void bindBillDetail()
        {

            var billResult = BillController.GetBillDetail(null, bill_id);
            rptBillDetail.DataSource = billResult;
            rptBillDetail.DataBind();
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("NungNingRacingShop@gmail.com", "02123456");

            MailMessage mm = new MailMessage("NungNingRacingShop@gmail.com", "bangnaha@gmail.com");
            mm.BodyEncoding = UTF8Encoding.UTF8;

            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Subject = "this is a test email.";
            mm.Body = "this is my test email body";
            client.Send(mm);

        }




    }
}