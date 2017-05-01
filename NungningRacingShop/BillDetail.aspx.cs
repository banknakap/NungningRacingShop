using Nungning.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NungningRacingShop
{
    public partial class BillDetail : PageControl
    {
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
                bindBill();
            }
        }

        private void bindBill()
        {

            var billResult = BillController.GetBillDetail(null, bill_id);
            rptBillDetail.DataSource = billResult;
            rptBillDetail.DataBind();
        }


    }
}