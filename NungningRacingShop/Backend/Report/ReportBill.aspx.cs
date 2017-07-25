using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Report
{
    public partial class ReportBill : PageControl
    {

        public float total_price = 0;

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


            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                bindReport();
            }
            catch (Exception ex)
            {
                ShowMessage(Page, "เกิดข้อผิดพลาดในระบบ");
            }
        }


        private void bindReport()
        {

            try
            {
                DateTime start = DateTime.ParseExact(txtStart.Text, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime end = DateTime.ParseExact(txtEnd.Text, "dd/MM/yyyy", new CultureInfo("en-US"));

                var result = ReportController.GetReportHistory(start, end);

                if (result != null)
                {
                    total_price = result.Sum(d => d.total_price);
                }
                if (result.Count == 0)
                {
                    ShowMessage(Page, "ไม่พบข้อมูลการซื้อสินค้า");
                    return;
                }

                rptReport.DataSource = result;
                rptReport.DataBind();
            }
            catch
            {
                ShowMessage(Page, "กรุณาใส่วันที่ให้ถูกต้อง วัน/เดือน/ปี");
            }
        }

    }
}