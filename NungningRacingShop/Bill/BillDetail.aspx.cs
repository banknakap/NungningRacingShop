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
        public float net_price = 0;
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
        public string contentPayment = "";
        public static string bill_id_payment;

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
            payment.HRef = "~/Bill/BillPayment?bill_id=" + bill_id;
            if (!IsPostBack)
            {
                if (SessionApp.user_info == null || string.IsNullOrEmpty(bill_id))
                    return;
                bindBillPayment();
                bindBill();
                bindBillDetail();
                
            }
        }

        private void bindBillPayment()
        {
            var res = BillController.GetBillPayment(bill_id);
            if (res.Count > 0)
            {
                var c = res[0];
                if (c.payment_time != null)
                    paymentContent.InnerText = "ท่านได้มีการชำระมาแล้วเงินยอดที่ " + c.payment_price.ToString("#,###") + " เวลา " + c.payment_time;
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
            if (current.net_price >= 0)
                net_price = current.net_price;
            else
                net_price = current.total_price;
        }

        private void bindBillDetail()
        {

            var billResult = BillController.GetBillDetail(null, bill_id);
            rptBillDetail.DataSource = billResult;
            rptBillDetail.DataBind();
        }
    }
}