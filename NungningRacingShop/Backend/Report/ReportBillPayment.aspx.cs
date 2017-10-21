using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop.Backend.Report
{
    public partial class ReportBillPayment : PageControl
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
                bindReport();
            }
        }

        private void bindReport()
        {
                var result = BillController.GetBillPayment(null);

     
                if (result.Count == 0)
                {
                    ShowMessage(Page, "ไม่พบข้อมูลการซื้อสินค้า");
                    return;
                }

                rptReport.DataSource = result;
                rptReport.DataBind();
    
        }

        public string getImage(string image_name)
        {
            return NungningRacingShop.Utility.Utility.getPaymentImage(image_name);
        }
    }
}